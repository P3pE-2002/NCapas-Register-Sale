using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ProductoCE
    {
        //Propiedades
        private int id;
        private string descripcion;
        private string categoria;
        private double precio;
        //Encapsulados
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }
        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        //Construtores
        public ProductoCE() { }
        public ProductoCE(int id, string descripcion, string categoria, double precio)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.categoria = categoria;
            this.precio = precio;
        }
    }
}
