
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
        public DbSet<Comentario> Comentarios { get; set; }
        //public DbSet<RegistroAsistencia> RegistroAsistencias { get; set; }
        //public DbSet<UsuarioEventoFavorito> UsuarioEventoFavoritos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comentario>().Ignore(c => c.Evento);
        }


    }
}