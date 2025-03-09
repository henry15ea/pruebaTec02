using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.People.Core.Abstractions;
using Module.People.Core.DTO.MoneyTransfer;
using Module.People.Core.Entities;
using Module.People.Core.Utils;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Module.People.Core.Commands
{
    public class ProcessTransferToClientCommand : IRequest<ProcccessTransferStatusDTO>
    {
        public string CodigoCuentaOrigen { get; set; }
        public string CodigoCuentaDestino { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }

        //end user functions or definitions
    }
    internal class UserTransferCommandHandler : IRequestHandler<ProcessTransferToClientCommand, ProcccessTransferStatusDTO>
    {
        private readonly IUserAccountDbContext _context;
        public UserTransferCommandHandler(IUserAccountDbContext context)
        {
            _context = context;
        }

        public async Task<ProcccessTransferStatusDTO> Handle(ProcessTransferToClientCommand request, CancellationToken cancellationToken)
        {
            ProcccessTransferStatusDTO procccessTransferStatusDTO = new ProcccessTransferStatusDTO();
            string TransactionId = TransactionGeneratorCode.GetCodeTransaction().Trim();

            //var userAccountDetails = await _context.Transacciones.Include(c => c.cuentaorigen).Include(c => c.cuentadestino)
            //        .FirstOrDefaultAsync(c => c.transaccionid == 1, cancellationToken);
            decimal TransferenciaAmmount = request.Monto;

            #region ObtenerInformacion de ambas cuentas
            string CodigoCuentaOrigen = request.CodigoCuentaOrigen.Trim();
            string CodigoCuentaDestino = request.CodigoCuentaDestino.Trim();

            var cuentaOrigen = await _context.UserAccount.Include(c => c.Cliente)
                    .FirstOrDefaultAsync(c => c.codigocuenta == CodigoCuentaOrigen.Trim(), cancellationToken);

            var cuentaDestino = await _context.UserAccount.Include(c => c.Cliente)
                    .FirstOrDefaultAsync(c => c.codigocuenta == CodigoCuentaDestino.Trim(), cancellationToken);

            #endregion



            if (cuentaOrigen == null || cuentaDestino == null)
            {
                throw new Exception("Una o ambas cuentas no existen.");
            }

            // Verificar si hay suficiente saldo en la cuenta de origen
            if (cuentaOrigen.saldo < TransferenciaAmmount)
            {
                throw new InvalidOperationException("Saldo insuficiente en la cuenta de origen.");
            }

            // Actualizar saldo de la cuenta de origen
            cuentaOrigen.saldo -= TransferenciaAmmount;

            // Actualizar saldo de la cuenta de destino
            cuentaDestino.saldo += TransferenciaAmmount;



            // Crear registro de la transacción
            ETransacciones transaccion = new ETransacciones
            {
                cuentaorigenid = cuentaOrigen.cuentaid,
                cuentadestinoid = cuentaDestino.cuentaid,
                monto = TransferenciaAmmount,
                TipoTransatipotransaccionccion = "TRANSFER365",
                descripcion = request.Descripcion.Trim(),
                codigotransaccion = TransactionId
            };

            // Agregar la transacción al contexto
            _context.Transacciones.Add(transaccion);

            // Guardar los cambios en la base de datos
            int cambiosGuardados =  await _context.SaveChangesAsync(cancellationToken);

            var userTransactionDetails = await _context.Transacciones.Include(c => c.cuentaorigen).Include(c => c.cuentadestino)
                    .FirstOrDefaultAsync(c => c.codigotransaccion == TransactionId, cancellationToken);

            if (userTransactionDetails != null && cambiosGuardados >0) 
            {
                procccessTransferStatusDTO.TipoTransaccion = transaccion.TipoTransatipotransaccionccion;
                procccessTransferStatusDTO.fechaTransaccion = userTransactionDetails.fechatransaccion;
                procccessTransferStatusDTO.Descripccion = request.Descripcion.Trim();
                procccessTransferStatusDTO.CuentaOrigen = request.CodigoCuentaOrigen;
                procccessTransferStatusDTO.CuentaDestino = request.CodigoCuentaDestino;
                procccessTransferStatusDTO.Monto = TransferenciaAmmount;
                procccessTransferStatusDTO.TransactionId = TransactionId;

            }

            return procccessTransferStatusDTO;
        }
    }


    //end class
}
//end namespaces
