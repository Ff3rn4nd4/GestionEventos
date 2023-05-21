using GestionEventos.DTOs;
using GestionEventos.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GestionEventos
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options) 
        {

        }

        //bases de datos
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Favorito> Favoritos { get; set; }
        public DbSet<Promocion> Promociones { get; set; }
        public DbSet<Asistencia> Asistencias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comentario>().Ignore(c => c.Evento);

        }
    }
}