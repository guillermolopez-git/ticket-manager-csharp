using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace archivos
{
    public class GestorTickets
    {

        private int ultimoId = 1000;



        private Queue<Ticket> pendientes = new Queue<Ticket>();
        private List<Ticket> completados = new List<Ticket>();
        private Stack<Accion> accionesRecientes = new Stack<Accion>();

        private string rutaArchivo;

        public GestorTickets(string archivo)
        {
            this.rutaArchivo = archivo;

        }

        private int GenerarId()
        {
            return ++ultimoId;
        }


        // --- MÉTODOS DE GESTIÓN ---
        public void AgregarTicket(string cliente, string descripcion)
        {
            int nuevoId = GenerarId();
            Ticket nuevo = new Ticket(nuevoId, cliente, descripcion, DateTime.Now, EstadoTicket.Pendiente);

            pendientes.Enqueue(nuevo);
            accionesRecientes.Push(new Accion($"Ticket #{nuevo.Id} creado y encolado."));
        }

        public void CompletarTicket(int idTicket)
        {
            Queue<Ticket> aux = new Queue<Ticket>();
            Ticket encontrado = null;

            while (pendientes.Count > 0)
            {
                Ticket t = pendientes.Dequeue();
                if (t.Id == idTicket)
                {
                    encontrado = t;
                    break;
                }
                aux.Enqueue(t);
            }

            // Restaurar los que pasaron a la auxiliar
            while (aux.Count > 0)
                pendientes.Enqueue(aux.Dequeue());

            if (encontrado != null)
            {
                encontrado.Estado = EstadoTicket.Completado;
                encontrado.AgregarAccion(new Accion("Ticket completado."));
                completados.Add(encontrado);

                accionesRecientes.Push(new Accion($"Ticket #{idTicket} completado.", "COMPLETADO"));
                Console.WriteLine($"Ticket #{idTicket} completado correctamente.");
            }
            else
            {
                Console.WriteLine($"⚠️ Ticket #{idTicket} no encontrado en la cola.");
            }
        }


        // Método clave para la PILA
        public void DeshacerAccion()
        {
            if (accionesRecientes.Count == 0)
            {
                Console.WriteLine("No hay acciones para deshacer.");
                return;
            }

            Accion ultima = accionesRecientes.Pop();
            Console.WriteLine($"↩️ Revirtiendo: {ultima.Descripcion}");

            if (ultima.Tipo == "COMPLETADO")
            {
                // Buscar en completados
                Ticket t = completados.FirstOrDefault(x => x.Id == ultima.IdTicket);
                if (t != null)
                {
                    completados.Remove(t);
                    t.Estado = EstadoTicket.Pendiente;
                    pendientes.Enqueue(t);
                    Console.WriteLine($"Ticket #{t.Id} volvió a estado pendiente.");
                }
            }
        }


        public void MostrarEstado()
        {
            Console.WriteLine("\n--- ESTADO DEL GESTOR ---");
            Console.WriteLine($"Tickets Pendientes (Queue): {pendientes.Count} items.");
            foreach (var t in pendientes)
            {
                Console.WriteLine($"  - [Pendiente] ID: {t.Id}, Cliente: {t.Cliente}");
            }

            Console.WriteLine($"\nTickets Completados (List): {completados.Count} items.");
            // Mostrar Completados...

            Console.WriteLine($"\nAcciones Recientes (Stack): {accionesRecientes.Count} items (para Deshacer).");
        }
    }
}