using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.Auth.Core.Abstractions;
using Module.Auth.Core.DTO;
using Module.Auth.Core.Utilities;

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
                    .FirstOrDefaultAsync(c => c.nombreusuario == command.NombreUsuario.Trim() && c.contrasena == PasswordHash.Trim(), cancellationToken);

            if (user != null)
            {
                accountDetails.Correo = user.correo.Trim();
                accountDetails.FechaRegistro = user.fecharegistro;
                accountDetails.NombreCompleto = user.nombrecompleto.Trim();
                accountDetails.Estado = user.estado;
                accountDetails.UsuarioId = user.usuarioid;
            }

            return accountDetails;
        }
    }

    //end class
}
//end namespaces
