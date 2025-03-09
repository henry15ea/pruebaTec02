using Microsoft.EntityFrameworkCore;
using Module.People.Core.Abstractions;
using Module.People.Core.DTO.AccountDetails;
using Module.People.Core.Entities;
using Shared.Infrastructure.Persistence;
using System.Threading;
using System.Threading.Tasks;
using Shared.Infrastructure.Persistence;

namespace Module.People.Infrastructure.Persistence
{
    public class PeopleDbContext : ModuleDbContext, IUserAccountDbContext
    {
        protected override string Schema => "cuentas";
        //end user functions or definitions
        public DbSet<EClientes> Clientes { get; set; }
        public DbSet<EUsuarios> Usuarios { get; set; }
        public DbSet<EUserAccount> UserAccount { get; set; }
        public DbSet<ETransacciones> Transacciones { get; set; }

        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
        {
        }
        public Task<AccountBalance> GetDetailsAccount(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        // Configuramos la entidad 'Usuario' en OnModelCreating si es necesario
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);


            // Configuración de la relación entre EClientes y EUsuarios
            modelBuilder.Entity<EClientes>(entity =>
            {
                // Mapea la entidad EClientes a la tabla "usuarios" en el esquema "public"
                entity.ToTable("clientes", "public");
            });

            // Configuración de la relación entre EUserAccount y EClientes
            modelBuilder.Entity<EUserAccount>(entity =>
            {
                // Mapea la entidad EUserAccount a la tabla "usuarios" en el esquema "public"
                entity.ToTable("cuentas", "public");
            });

            // Configuración de la relación entre EUsuarios y EClientes
            modelBuilder.Entity<EUsuarios>(entity =>
            {
                // Mapea la entidad EUsuarios a la tabla "usuarios" en el esquema "public"
                entity.ToTable("usuarios", "public");

                // Otras configuraciones de la entidad EUsuarios (por ejemplo, sus propiedades, si es necesario)
                entity.Property(u => u.nombreusuario).HasMaxLength(100).IsRequired();
                entity.Property(u => u.contrasena).HasMaxLength(255).IsRequired();
                entity.Property(u => u.nombrecompleto).HasMaxLength(100);
                entity.Property(u => u.correo).HasMaxLength(100);
                entity.Property(u => u.fecharegistro).IsRequired();
                entity.Property(u => u.estado).IsRequired();
            });

            modelBuilder.Entity<ETransacciones>(entity =>
            {
                // Mapea la entidad EUserAccount a la tabla "usuarios" en el esquema "public"
                entity.ToTable("transacciones", "public");
            });

            // Otras configuraciones adicionales si es necesario, como restricciones de longitud o validaciones

        }
    }

    //end class
}
//end namespaces
