using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace proyecto_biblioteca_escolar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Biblioteca escolar";

            List<Titulo> catalogo = CargarDatos();
            Console.WriteLine("Estado incial del catalogo");
            MostrarCatalogo(catalogo);

            OrdenarInsercion(catalogo);

            RealizarPrestamo(catalogo[0], "Prestamo #1");
            RealizarPrestamo(catalogo[3], "Prestamo #2");
            RealizarPrestamo(catalogo[3], "Prestamo #3");
            Console.WriteLine("Estado del catalogo despues de los prestamos simulados");
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
                Console.WriteLine($"{libro.ISBN, -18} | {libro.Nombre, -34} | {libro.Prestamos, -10} | {libro.EjemplaresDisponibles(), -10}");
            }
        }

        static void RealizarPrestamo(Titulo libro, string numPrestamo)
        {
            Console.WriteLine($"\n[{numPrestamo}] Libro prestado: '{libro.Nombre}' (ISBN: {libro.ISBN})");
            Console.WriteLine($" Disponibles antes del prestamo: {libro.EjemplaresDisponibles()}");

            if (libro.PrestamosEjemplares())
            {
                Console.WriteLine($"Se presto un ejemplar. Disponibles: {libro.EjemplaresDisponibles()}");
            }
            else
            {
                Console.WriteLine($"No hay ejemplares de este libro.");
            }
        }

        static void OrdenarInsercion(List<Titulo> lista)
        {
            for (int i = 1; i < lista.Count; i++)
            {
                Titulo clave = lista[i];
                int j = i - 1;

                while (j >= 0 && lista[j].Prestamos < clave.Prestamos)
                {
                    lista[j + 1] = lista[j];
                    j--;
                }
                lista[j + 1] = clave;
            }
        }
    }
}