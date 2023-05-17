namespace GestionEventos.Entidades
{
    //Clase Padre
    public class Evento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public  string Ubicacion { get; set; }
        public int Capacidad { get; set; }

        //Relacion directa/tabla intermedia implicita para tipo Muchos a Muchos
        public class Favorito
        {
            public int Id { get; set; }
            public int EventoId { get; set; }
            public Evento Evento { get; set; }
        }

        //Relaciones Uno a Muchos
        public List<Comentario> Comentarios { get; set; }
        //public List<Promocion> Promociones { get; set; }
        //public List<RegistroAsistencia> RegistroAsistencias { get; set; }


    }
}
