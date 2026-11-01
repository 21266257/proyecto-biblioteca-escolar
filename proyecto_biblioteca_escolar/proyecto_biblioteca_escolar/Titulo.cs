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


        //Dia 3
        public int EjemplaresDisponibles()
        {
            int disponibles = 0;
            foreach (int ejemplar in Ejemplares)
            {
                if (ejemplar == 1)
                {
                    disponibles++;
                }
            }
            return disponibles;
        }

        public bool PrestamosEjemplares()
        {
            for (int i = 0; i < Ejemplares.Length; i++)
            {
                if (Ejemplares[i] == 1)
                {
                    Ejemplares[i] = 0;
                    Prestamos++;
                    return true;
                }
            }
            return false;
        }
    }
}
