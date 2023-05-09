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
    }
}
