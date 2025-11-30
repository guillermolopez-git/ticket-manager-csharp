using System;
using System.Collections.Generic;


namespace archivos
{

    public class Ticket
    {

        public int Id { get; set; }
        public string Cliente { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public EstadoTicket Estado { get; set; }

        public List<Accion> Historial { get; set; } = new List<Accion>(); // Renombrado a Historial (o Acciones)

        // Constructor
        public Ticket(int id, string cliente, string descripcion, DateTime fecha, EstadoTicket estado)
        {
            this.Id = id;
            this.Cliente = cliente;
            this.Descripcion = descripcion;
            this.Fecha = fecha;
            this.Estado = estado;
        }
        public void AgregarAccion(Accion nuevaAccion)
        {
            this.Historial.Add(nuevaAccion);
        }
    }
}