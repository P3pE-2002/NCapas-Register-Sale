using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Importar la CapaEntidad
using CapaEntidad;

//Importar la libreria para DATOS en C#
using System.Data;

//Importar la libreria para SQLSERVER
using System.Data.SqlClient;

namespace CapaDatos   
{
    public class ProductoCD
    {
        //Propiedades --> NO
        //Metodos: CRUD
        public ProductoCE buscarId(int idBuscado)
        {
            //Crear la conexion
            SqlConnection cnx = ConexionCD.conectarBD();
            //Abrir la conexion
            cnx.Open();
            //Crear el comando
            SqlCommand cmd = cnx.CreateCommand();
            //Tipo de comando
            cmd.CommandType = CommandType.Text;
            //Asignar la instruccion SQL
            cmd.CommandText = "select * from producto " +
                "where id=@id";
            //Asignar valor al parametro
            cmd.Parameters.AddWithValue("@id", idBuscado);
            //Ejecutar el comando
            SqlDataReader drProducto = cmd.ExecuteReader();

            //Declarar variables para los datos
            int id;
            string descripcion;
            string categoria;
            double precio;

            //Ejecutar un Read()
            if (drProducto.Read())
            {
                //Si existe fila
                id = Convert.ToInt32( drProducto["id"]);
                descripcion =Convert.ToString( drProducto["descripcion"]);
                categoria = Convert.ToString(drProducto["categoria"]);
                precio = Convert.ToDouble(drProducto["precio"]);
            }
            else
            {
                //Si no existe fila
                id = 0;
                descripcion = "";
                categoria = "";
                precio = 0;
            }

            //Cerrar la conexion
            cnx.Close();

            //Asignar los valores a las propiedades de ProductoCE
            ProductoCE productoCE = new ProductoCE(id, descripcion, categoria, precio);

            //Retornar el producto
            return productoCE;
        }
        public List<ProductoCE> buscarDescripcion(string desBuscado)
        {
            //Crear la conexion
            SqlConnection cnx = ConexionCD.conectarBD();
            //Abrir la conexion
            cnx.Open();
            //Crear el comando
            SqlCommand cmd = cnx.CreateCommand();
            //Tipo de comando
            cmd.CommandType = CommandType.Text;
            //Asignar la instruccion SQL
            cmd.CommandText = "select * from producto " +
                "where descripcion like '%' + @descripcion + '%'";
            //Asignar valor al parametro
            cmd.Parameters.AddWithValue("@descripcion", desBuscado);
            //Ejecutar el comando
            SqlDataReader drProducto = cmd.ExecuteReader();

            //Declarar lista
            List<ProductoCE> productosCE = new List<ProductoCE>();

            //Ejecutar un Read()
            while (drProducto.Read())
            {
                //Si existe fila leer los datos
                int id = Convert.ToInt32(drProducto["id"]);
                string descripcion = Convert.ToString(drProducto["descripcion"]);
                string categoria = Convert.ToString(drProducto["categoria"]);
                double precio = Convert.ToDouble(drProducto["precio"]);

                //Instanciar y asignar los valores a las propiedades de ProductoCE
                ProductoCE productoCE = new ProductoCE(id, descripcion, categoria, precio);

                //Agregar a lista
                productosCE.Add(productoCE);

            }


            //Cerrar la conexion
            cnx.Close();


            //Retornar la lista de productos
            return productosCE;
        }
        public int insertar(ProductoCE productoCE)
        {
            SqlConnection cnx = ConexionCD.conectarBD();

            cnx.Open();

            SqlCommand cmd = cnx.CreateCommand();

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "insert into producto (descripcion, categoria, precio) " +
                "values (@descripcion, @categoria, @precio)";

            cmd.Parameters.AddWithValue("@descripcion",productoCE.Descripcion);
            cmd.Parameters.AddWithValue("@categoria",productoCE.Categoria);
            cmd.Parameters.AddWithValue("@precio",productoCE.Precio);

            // value == 0 ninguna fila afectada
            // value != 0 filas afectadas
            
            int numFilas = cmd.ExecuteNonQuery();  // insert delete update

            // Declarar variable nuevoID
            int nuevoId;

            if (numFilas > 0)
            {
                // Asignar nuevo SQL
                cmd.CommandText = "select max(id) as nuevoId from producto " +
                    "where descripcion = @descripcion";
                // Actualizar el parametro
                cmd.Parameters["@descripcion"].Value = productoCE.Descripcion;

                // Ejecutar el comando 
                SqlDataReader drProducto = cmd.ExecuteReader();

                

                if (drProducto.Read())
                {
                    // recuperar el nuevo id
                    nuevoId = Convert.ToInt32(drProducto["nuevoId"]);
                }
                else
                {
                    nuevoId = 0;
                }

            }
            else
            {
                nuevoId = 0;
            }
            // cerrar conexion
            cnx.Close();

            // Retornar nuevo id
            return nuevoId;


            
        }
        public int actualizar(ProductoCE productoCE)
        {
            SqlConnection cnx = ConexionCD.conectarBD();

            cnx.Open();

            SqlCommand cmd = cnx.CreateCommand();

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "update producto set "+
                "descripcion=@descripcion, precio=@precio, categoria=@categoria "+
                "where id = @id";

            cmd.Parameters.AddWithValue("@descripcion", productoCE.Descripcion);
            cmd.Parameters.AddWithValue("@categoria", productoCE.Categoria);
            cmd.Parameters.AddWithValue("@precio", productoCE.Precio);
            cmd.Parameters.AddWithValue("@id", productoCE.Id);
            // value == 0 ninguna fila afectada
            // value != 0 filas afectadas

            int numFilas = cmd.ExecuteNonQuery();  // insert delete update

            // Cerrar conexion
            cnx.Close();

            // Retornar cantidad de filas afectadas
            return numFilas;
        }
        public int eliminar(ProductoCE productoCE)
        {
            SqlConnection cnx = ConexionCD.conectarBD();

            cnx.Open();
             
            SqlCommand cmd = cnx.CreateCommand();

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "delete from producto where id = @id";

            cmd.Parameters.AddWithValue("@id", productoCE.Id);
            // value == 0 ninguna fila afectada
            // value != 0 filas afectadas

            int numFilas = cmd.ExecuteNonQuery();  // insert delete update

            // Cerrar conexion
            cnx.Close();

            // Retornar cantidad de filas afectadas
            return numFilas;
        }
    }
}
