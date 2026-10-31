using System;
using System.Collections.Generic;
using System.Text;

namespace proyecto_biblioteca_escolar
{
    public class Titulo
    {
        public string ISBN {  get; set; }
        public string Nombre { get; set; }
        public int Prestamos { get; set; }
        public int[] Ejemplares { get; set; }


        public Titulo(string isbn, string nombre, int prestamos, int[] ejemplares)
        {
            ISBN = isbn;
            Nombre = nombre;
            Prestamos = prestamos;
            Ejemplares = ejemplares;
        }

        public int TotalEjemplares => Ejemplares.Length;
    }
}
