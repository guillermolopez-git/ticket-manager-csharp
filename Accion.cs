using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace archivos
{

    public class Accion
    {
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; } // Opcional
        public int? IdTicket { get; set; }

        public Accion(string descripcion, string tipo = null, int? idTicket = null)
        {
            Descripcion = descripcion;
            Tipo = tipo;
            Fecha = DateTime.Now;
            IdTicket = idTicket;
        }

        // Sobrescribe ToString para facilitar la visualización o el guardado
        public override string ToString() =>
            $"[{Fecha:yyyy-MM-dd HH:mm}] ({Tipo ?? "General"}) - {Descripcion}";




    }
}
