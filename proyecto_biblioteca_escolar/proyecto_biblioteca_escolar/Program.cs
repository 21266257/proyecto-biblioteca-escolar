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
            //Cargamos los datos
            List<Titulo> catalogo = CargarDatos();

            //Inicia catalogo
            Console.WriteLine("Estado incial del catalogo");
            MostrarCatalogo(catalogo);


            //Los ordena por insercion 
            OrdenarInsercion(catalogo);


            //Prestamos 
            RealizarPrestamo(catalogo[0], "Prestamo #1");
            RealizarPrestamo(catalogo[3], "Prestamo #2");
            RealizarPrestamo(catalogo[3], "Prestamo #3");
            //Muestra el catalogo despues de los prestamos
            Console.WriteLine("Estado del catalogo despues de los prestamos simulados");
            MostrarCatalogo(catalogo);

            //Integracion y prueba
            catalogo.Sort((x, y) => x.ISBN.CompareTo(y.ISBN));
            //Arreglo para verificacion con Array.BinarySearch
            string[] arregloISBN = catalogo.ConvertAll(x => x.ISBN).ToArray();

            Console.WriteLine("Busqueda binaria por ISBN.");

            // Búsqueda por ISBN "existente"
            string isbnExistente = "978-0131103627";
            Console.WriteLine($"\nBuscando ISBN: '{isbnExistente}'.");
            BuscarPorISBNBi(catalogo, isbnExistente);
            Console.WriteLine($"Verificacion de Array.BinarySearch: {Array.BinarySearch(arregloISBN, isbnExistente)}");

            // Búsqueda por ISBN "inexistente"
            string isbnInexistente = "978-0000000000";
            Console.WriteLine($"\nBuscando ISBN: '{isbnInexistente}'.");
            BuscarPorISBNBi(catalogo, isbnInexistente);
            Console.WriteLine($"Verificacion de Array.BinarySearch: {Array.BinarySearch(arregloISBN, isbnInexistente)}");

            Console.WriteLine("Busqueda secuencial por titulo.");

            //Busqueda por titulo existente
            string tituloExistente = "El lenguaje de programacion C";
            Console.WriteLine($"\nBuscando Titulo: '{tituloExistente}'.");
            BuscarPorTitulo(catalogo, tituloExistente);

            //Busqueda por titulo inexistente
            string tituloInexistente = "Aprende con python";
            Console.WriteLine($"\nBuscando Titulo: '{tituloInexistente}'.");
            BuscarPorTitulo(catalogo, tituloInexistente);

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
            Console.WriteLine($"{"ISBN",-18} | {"Titulo",-34} | {"Prestamos",-10} | {"Ejemplares",-10}");
            Console.WriteLine(new string('-', 80));

            foreach (var libro in lista)
            {
                Console.WriteLine($"{libro.ISBN,-18} | {libro.Nombre,-34} | {libro.Prestamos,-10} | {libro.EjemplaresDisponibles(),-10}");
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

        static void BuscarPorISBNBi(List<Titulo> lista, string isbnBuscado)
        {
            int inicio = 0;
            int fin = lista.Count - 1;
            bool encontrado = false;
            int comparaciones = 0;

            while (inicio <= fin)
            {
                comparaciones++;
                int medio = inicio + (fin - inicio) / 2;
                int comparacion = string.CompareOrdinal(lista[medio].ISBN, isbnBuscado);

                if (comparacion == 0)
                {
                    Console.WriteLine($"Libro encontrado: '{lista[medio].Nombre}' (ISBN: {lista[medio].ISBN} - Comparaciones: {comparaciones})");
                    encontrado = true;
                    break;
                }

                if (comparacion < 0)
                {
                    inicio = medio + 1;
                }
                else
                {
                    fin = medio - 1;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine($"El libro con ISBN '{isbnBuscado}' no fue encontrado en el catalogo. - Comparaciones: {comparaciones}");
            }
        }

        static void BuscarPorTitulo(List<Titulo> lista, string tituloBuscado)
        {
            bool encontrado = false;

            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].Nombre.Equals(tituloBuscado, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Libro encontrado: '{lista[i].Nombre}' (ISBN: {lista[i].ISBN})");
                    encontrado = true;
                    break; 
                }
            }

            if (!encontrado)
            {
                Console.WriteLine($"El libro con titulo '{tituloBuscado}' no fue encontrado en el catalogo.");
            }
        }
    }
}