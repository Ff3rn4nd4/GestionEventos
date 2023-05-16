namespace GestionEventos.Entidades
{
    //Clase Padre
    public class HistorialAsistencia
    {
        public int Id { get; set; }
        public string Fecha { get; set; }

        //Relacion muchos a muchos 
        public List<UsuarioHistorialAsistencia> Usuario { get; set; }
    }
}
