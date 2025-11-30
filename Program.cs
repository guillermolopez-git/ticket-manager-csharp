using System;

namespace archivos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("--- SISTEMA DE GESTIÓN DE TICKETS ---");

            // Inicializar el gestor de tickets (asegúrate GestorTickets está en namespace 'archivos')
            GestorTickets gestor = new GestorTickets("tickets_datos.txt");

            int opcion = -1;

            while (opcion != 0)
            {
                Console.Clear();
                Console.WriteLine("=======================================");
                Console.WriteLine("     SISTEMA DE GESTIÓN DE TICKETS");
                Console.WriteLine("=======================================");
                Console.WriteLine("1. Crear ticket");
                Console.WriteLine("2. Mostrar estado actual");
                Console.WriteLine("3. Completar un ticket");
                Console.WriteLine("4. Deshacer última acción");
                Console.WriteLine("0. Salir");
                Console.WriteLine("=======================================");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("❌ Opción no válida. Presione una tecla...");
                    Console.ReadKey();
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        Console.Write("\nIngrese el nombre del cliente: ");
                        string cliente = Console.ReadLine()?.Trim();

                        Console.Write("Ingrese la descripción del problema: ");
                        string descripcion = Console.ReadLine()?.Trim();

                        if (string.IsNullOrWhiteSpace(cliente) || string.IsNullOrWhiteSpace(descripcion))
                        {
                            Console.WriteLine("\n❌ Cliente o descripción vacíos. Ticket no creado.");
                        }
                        else
                        {
                            // AgregarTicket devuelve void en tu Gestor actual, por eso no asignamos a una variable
                            gestor.AgregarTicket(cliente, descripcion);
                            Console.WriteLine("\n✔ Ticket agregado correctamente.");
                        }

                        Console.WriteLine("\nPresione una tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.WriteLine("\n--- ESTADO ACTUAL DEL SISTEMA ---");
                        gestor.MostrarEstado();
                        Console.WriteLine("\nPresione una tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.Write("\nIngrese el ID del ticket a completar: ");
                        if (int.TryParse(Console.ReadLine(), out int idCompletar))
                        {
                            gestor.CompletarTicket(idCompletar);
                        }
                        else
                        {
                            Console.WriteLine("❌ ID inválido.");
                        }
                        Console.WriteLine("\nPresione una tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.WriteLine("\n--- DESHACER ACCIÓN ---");
                        gestor.DeshacerAccion();
                        Console.WriteLine("\nPresione una tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case 0:
                        Console.WriteLine("\nSaliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("\n❌ Opción no válida.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
