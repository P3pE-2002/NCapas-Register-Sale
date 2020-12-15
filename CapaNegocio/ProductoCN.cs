using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;
namespace CapaNegocio
{
    class ProductoCN
    {
        // Metodos equivalentes a la capa DATOS

        public ProductoCE buscarId(int idBuscado)
        {

            // Instanciar la capa datos
            ProductoCD productoCD = new ProductoCD();
            
            // Ejecutar el metodo buscarid de la capa de datos
            ProductoCE producto = productoCD.buscarId(idBuscado);

            // retornar el resultado
            return producto;
        }
        public List<ProductoCE> buscarDescripcion(string descripcion)
        {
            // Instanciar la capa datos
            ProductoCD productoCD = new ProductoCD();

            // Ejecutar el metodo buscarDescripcion de la capa datos
            List<ProductoCE> productos = productoCD.buscarDescripcion(descripcion);

            // retornar el resultado
            return productos;
        }

        public int insertar(ProductoCE productoCE)
        {
            // Instanciar capa datos
            ProductoCD productoCD = new ProductoCD();
            // Ejecutar metodo insertar
            int numFila = productoCD.insertar(productoCE);
            // Retornar numero de filas afectadas
            return numFila;
        }
        public int actualizar(ProductoCE productoCE)
        {
            // Instanciar capa datos
            ProductoCD productoCD = new ProductoCD();
            // Ejecutar metodo actualizar
            int numFila = productoCD.actualizar(productoCE);
            // Retornar numero de filas afectadas
            return numFila;
        }
        public int eliminar(ProductoCE productoCE)
        {
            // Instanciar capa datos
            ProductoCD productoCD = new ProductoCD();
            // Ejecutar metodo eliminar
            int numFila = productoCD.eliminar(productoCE);
            // Retornar numero de filas afectadas
            return numFila;
        }
    }
}
