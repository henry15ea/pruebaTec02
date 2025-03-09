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
        protected override string Schema => "Cuentas";
        //end user functions or definitions
        public DbSet<EClientes> Clientes { get; set; }
        public DbSet<EUsuarios> Usuarios { get; set; }
        public DbSet<EUserAccount> UserAccount { get; set; }

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
                entity.ToTable("Clientes", "public");

                // Configuración de la relación uno a muchos entre EClientes y EUsuarios
                entity.HasOne(c => c.Usuario)  // Un cliente tiene un solo usuario
                    .WithMany()  // Un usuario puede tener varios clientes
                    .HasForeignKey(c => c.usuarioid)  // La clave foránea es 'usuarioid' en 'EClientes'
                    .OnDelete(DeleteBehavior.Restrict);  // Evitar eliminación en cascada, puedes modificarlo según lo necesites
            });

            // Configuración de la relación entre EUserAccount y EClientes
            modelBuilder.Entity<EUserAccount>(entity =>
            {
                // Mapea la entidad EUserAccount a la tabla "usuarios" en el esquema "public"
                entity.ToTable("Cuentas", "public");

                // Configuración de la relación uno a muchos entre EUserAccount y EClientes
                entity.HasOne(ua => ua.Cliente)  // Una cuenta tiene un solo cliente
                    .WithMany()  // Un cliente puede tener muchas cuentas
                    .HasForeignKey(ua => ua.clienteid)  // La clave foránea es 'clienteid' en 'EUserAccount'
                    .OnDelete(DeleteBehavior.SetNull);  // Si se elimina un cliente, las cuentas asociadas tendrán un 'clienteid' NULL

                // Configuración de índice único en 'codigocuenta' de EUserAccount
                entity.HasIndex(ua => ua.codigocuenta)
                    .IsUnique();  // Esto asegura que 'codigocuenta' sea único en la tabla
            });

            // Configuración de la relación entre EUsuarios y EClientes
            modelBuilder.Entity<EUsuarios>(entity =>
            {
                // Mapea la entidad EUsuarios a la tabla "usuarios" en el esquema "public"
                entity.ToTable("Usuarios", "public");

                // Otras configuraciones de la entidad EUsuarios (por ejemplo, sus propiedades, si es necesario)
                entity.Property(u => u.nombreusuario).HasMaxLength(100).IsRequired();
                entity.Property(u => u.contrasena).HasMaxLength(255).IsRequired();
                entity.Property(u => u.nombrecompleto).HasMaxLength(100);
                entity.Property(u => u.correo).HasMaxLength(100);
                entity.Property(u => u.fecharegistro).IsRequired();
                entity.Property(u => u.estado).IsRequired();
            });

            // Otras configuraciones adicionales si es necesario, como restricciones de longitud o validaciones

        }
    }

    //end class
}
//end namespaces
