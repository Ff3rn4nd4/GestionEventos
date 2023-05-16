using GestionEventos.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionEventos.Configuraciones
{
    public class ConfigRegistroAsistencia: IEntityTypeConfiguration<RegistroAsistencia>
    {
        public void Configure(EntityTypeBuilder<RegistroAsistencia> builder)
        {
            builder.HasKey(a => new { a.EventoId, a.UsuarioId, a.Fecha });
        }
    }
}
