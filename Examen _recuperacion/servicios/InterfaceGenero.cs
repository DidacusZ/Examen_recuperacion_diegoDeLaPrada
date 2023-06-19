using Examen__recuperacion.entidades;
using System.Collections.Generic;
/*
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
*/

namespace Examen__recuperacion.servicios
{
    internal interface InterfaceGenero
    {
        //listar todos los productos
        //con cabecera 1º linea
        void ListarProductos(List<Genero> list);

        //añade un producto
        //si ya existe suma cantidad a este
        void NuevoProducto(List<Genero> list);

        //pide el nombre del producto y cantidad de salida
        //lo resta a stock
        void SalidaProducto(List<Genero> list);


        //el fichero se mantiene actualizado en todo momento
        //ruta fichero: Examen _recuperacion\bin\Debug

        //añade toda la informacion de la lista al fichero
        //lo hace borrando el fichero actual si es que existe y voviendo a escribir
        //esto lo hace por si la lista se actualiza
        void FicheroInsert(List<Genero> list);

        //carga la informacion del fichero en la lista
        void FicheroCargar(List<Genero> list);
    }
}
