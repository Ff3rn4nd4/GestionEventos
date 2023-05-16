namespace GestionEventos.Entidades
{
    //Clase Padre
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contrasenia { get; set; }

        //Relacion uno a muchos
        public List <Comentario> comentarios { get; set; }

    }
}
