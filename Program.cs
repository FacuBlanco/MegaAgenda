using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Domain;

namespace MegaAgenda
{
    class Program
    {
        static void Main(string[] args)
        {
            AgendaController agendaController = new AgendaController();
            ContactoController contactoController = new ContactoController();
            bool fin = false;
            do
            {
                Menu();
                switch (IngresarNumero(3))
                {
                    case 1:
                        AgregarAgenda();
                        break;
                    case 2:
                        MostrarAgendas();
                        break;
                    case 3:
                        Console.WriteLine("Hasta la próxima");
                        Console.ReadKey();
                        fin = true;
                        break;
                }
                Console.Clear();
            } while (!fin);
        }
        public static void Menu()
        {
            Console.WriteLine("Bienvenido al sistema MEGAAGENDASUPERPODEROSAULTRAREQUETEINMEJORABLEOMNIPOTENTE\n1- Registrar nueva agenda\n2- Ver agendas\n3- Salir");
        }

        private static int IngresarNumero(int maximo)
        {
            int numero;
            string dato = Console.ReadLine();
            bool correcto = int.TryParse(dato, out numero);
            if (maximo == -1)
            {
                while (!correcto)
                {
                    Console.WriteLine("Error, ingrese de nuevo");
                    dato = Console.ReadLine();
                    correcto = int.TryParse(dato, out numero);
                }
            }
            else
            {
                while (!correcto || numero < 1 || numero > maximo)
                {
                    Console.WriteLine("Error, ingrese de nuevo");
                    dato = Console.ReadLine();
                    correcto = int.TryParse(dato, out numero);
                }
            }
            Console.Clear();
            return numero;
        }
        private static void MostrarAgendas()
        {
            Console.WriteLine("Agendas registradas");
            AgendaController agendaController = new AgendaController();
            foreach (Agenda agenda in agendaController.MostrarAgenda())
            {
                Console.WriteLine(agenda);
            }
            Console.WriteLine("Presione una tecla para volver al menu");
            Console.ReadKey();
            Menu();
        }
        private static void AgregarAgenda()
        {
            AgendaController agendaController = new AgendaController();
            Console.WriteLine("Nueva agenda\nIngrese el nombre de la agenda");
            string nombreAgenda = Console.ReadLine();
            string fechaCreacion = DateTime.Now.ToString();
            agendaController.Crear(nombreAgenda, fechaCreacion);
        }
    }
}
