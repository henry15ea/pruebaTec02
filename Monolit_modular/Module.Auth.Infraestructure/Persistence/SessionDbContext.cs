using Microsoft.EntityFrameworkCore;
using Module.Auth.Core.Abstractions;
using Module.Auth.Core.Entities;
using Shared.Infrastructure.Persistence;

namespace Module.Auth.Infraestructure.Persistence
{
    public class SessionDbContext : ModuleDbContext, ISessionDBContext
    {
        protected override string Schema => "Usuarios";

        public DbSet<EUserLogin> Users { get; set; }

        public SessionDbContext(DbContextOptions<SessionDbContext> options) : base(options)
        {
        }

        // Configuramos la entidad 'Usuario' en OnModelCreating si es necesario
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración personalizada de la tabla 'Usuarios'
            modelBuilder.Entity<EUserLogin>(entity =>
            {
                entity.ToTable("Usuarios"); // Asegúrate de que la tabla se llame 'Usuarios'

                // Configura el nombre de la columna 'UsuarioID' como la clave primaria
                entity.HasKey(u => u.UsuarioId);

                // Define que la columna 'UsuarioID' es de tipo autoincremental
                entity.Property(u => u.UsuarioId)
                      .ValueGeneratedOnAdd()
                      .HasColumnName("UsuarioID");

                // Configura la longitud y unicidad de 'NombreUsuario'
                entity.Property(u => u.NombreUsuario)
                      .IsRequired()  // Requiere un valor no nulo
                      .HasMaxLength(100);  // Longitud máxima de 100 caracteres
                      //.IsUnique();  // Asegura que el nombre de usuario sea único

                // Configura la longitud de la contraseña
                entity.Property(u => u.Contrasena)
                      .IsRequired()
                      .HasMaxLength(255);

                // Configura la longitud de 'NombreCompleto' y 'Correo'
                entity.Property(u => u.NombreCompleto)
                      .HasMaxLength(100);

                entity.Property(u => u.Correo)
                      .HasMaxLength(100);

                // Configura la columna 'FechaRegistro' con valor por defecto
                entity.Property(u => u.FechaRegistro)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                // Configura la columna 'Estado' como tipo BIT (booleano)
                entity.Property(u => u.Estado)
                      .HasDefaultValue(false);
            });
        }

        public Task<bool> GetSessionValidate(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    //end class
}
//end namespaces
