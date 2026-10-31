using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace proyecto_biblioteca_escolar
{
    internal class program
    {
        static void Main(string[] args)
        {
            Console.Title = "Biblioteca escolar";

            List<Titulo> catalogo = CargarDatos();
            MostrarCatalogo(catalogo);

            Console.WriteLine("\n" + new string('=', 80));
            Console.WriteLine("Carga finalizada correctamente. No hay celdas nulas");
            Console.WriteLine(new string('=', 80));
            Console.WriteLine("\nPreciosa cualquier tecla para poder salir");
            Console.ReadKey();
        }

        static List<Titulo> CargarDatos()
        {
            return new List<Titulo>
            {
                new Titulo ("978-0131103627", "El lenguaje de programacion C", 15, new int[] {1, 1, 1, 1, 1 }),
                new Titulo ("978-0201633610", "Patrones de diseño", 22, new int[] {1, 1, 1 }),
                new Titulo ("978-0132350884", "Codigo limpio", 30, new int[] {1, 1, 1, 1 }),
                new Titulo ("978-0262033848", "Introduccion a los algoritmos", 8, new int[] {1 }),
                new Titulo ("978-0321356680", "Java efectivo", 12, new int[] {1, 1 }),
                new Titulo ("978-0596007126", "Head First Design Patterns", 22, new int[] {1, 1, 1 }),
                new Titulo ("978-1449331818", "Aprende C# en 21 dias", 5, new int[] {1, 1 }),
                new Titulo ("978-0134494166", "Estructuras de datos en C#", 18, new int[] {1, 1, 1, 1 })
            };
        }

        static void MostrarCatalogo(List<Titulo> lista)
        {
            Console.WriteLine($"{"ISBN", -18} | {"Titulo", -34} | {"Prestamos", -10} | {"Ejemplares", -10}");
            Console.WriteLine(new string('-', 80));

            foreach (var libro in lista)
            {
                Console.WriteLine($"{libro.ISBN, -18} | {libro.Nombre, -34} | {libro.Prestamos, -10} | {libro.TotalEjemplares, -10}");
            }
        }
    }
}