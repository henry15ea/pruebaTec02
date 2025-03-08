using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.Auth.Core.Abstractions;
using Module.Auth.Core.DTO;
using Module.Auth.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Module.Auth.Core.Queries.GetSession
{
    public class GetSessionQuery : IRequest<AccountDetails>
    {
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
    }

    internal class GetSessionHandler : IRequestHandler<GetSessionQuery, AccountDetails>
    {
        private readonly ISessionDBContext _context;
        public GetSessionHandler(ISessionDBContext context)
        {
            _context = context;
        }
        async Task<AccountDetails> IRequestHandler<GetSessionQuery, AccountDetails>.Handle(GetSessionQuery command, CancellationToken cancellationToken)
        {
            AccountDetails accountDetails = new AccountDetails();
            string PasswordHash = Text2Sha256Tool.Fn_ComputeSha256Hash(command.Contrasena.Trim());
            var user = await _context.Users
                    .FirstOrDefaultAsync(c => c.NombreUsuario == command.NombreUsuario.Trim() && c.Contrasena == PasswordHash.Trim(), cancellationToken);

            if (user != null)
            {
                accountDetails.Correo = user.Correo.Trim();
                accountDetails.FechaRegistro = user.FechaRegistro;
                accountDetails.NombreCompleto = user.NombreCompleto.Trim();
                accountDetails.Estado = user.Estado;
                accountDetails.UsuarioId = user.UsuarioId;
            }

            return accountDetails;
        }
    }

    //end class
}
//end namespaces
