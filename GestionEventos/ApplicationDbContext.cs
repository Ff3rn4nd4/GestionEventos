using GestionEventos.Configuraciones;
using GestionEventos.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GestionEventos
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options) 
        {

        }

        //bases de datos
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<RegistroAsistencia> registroAsistencias { get; set; }
        //public DbSet<UsuarioEventoFavorito> UsuarioEventoFavoritos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConfigRegistroAsistencia());

            modelBuilder.Entity<UsuarioHistorialAsistencia>()
               .HasKey(x => new { x.HistorialAsistenciaId, x.UsuarioId });
        }

    }
}