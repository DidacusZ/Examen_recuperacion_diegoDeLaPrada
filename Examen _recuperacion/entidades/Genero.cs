using System;
/*
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
*/

namespace Examen__recuperacion.entidades
{
    internal class Genero
    {
        //atributos
        string nombre;
        int cantidad;
        string unidad;

        /*
        public Genero(string nombre, int cantidad, string unidad)
        {
            this.nombre = nombre;
            this.cantidad = cantidad;
            this.unidad = unidad;
        }
        */

        //consstructor vacio
        public Genero()
        {
        }

        //getters y setters
        public string Nombre { get => nombre; set => nombre = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public string Unidad { get => unidad; set => unidad = value; }

        override
        public string ToString()
        {
            return String.Format("{0};{1};{2}",nombre,cantidad,unidad);
        }
    }
}
