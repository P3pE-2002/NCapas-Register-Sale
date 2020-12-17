using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Importar la libreria para SQLSERVER
using System.Data.SqlClient;

namespace CapaDatos
{
    public class ConexionCD
    {
        public static SqlConnection conectarBD()
        {
            //Generar la cadena de Conexion
            //Instanciar la clase ConnectionStringBuilder
            SqlConnectionStringBuilder generadorCadena = new SqlConnectionStringBuilder();
            //Asignar los valores de la cadena
            //generadorCadena.DataSource = "127.0.0.1"; //servidor
            generadorCadena.DataSource = @"DESKTOP-BKHUJQ5\SQLEXPRESS";
            generadorCadena.InitialCatalog = "BDMARKET"; //base de datos
            generadorCadena.IntegratedSecurity = true; //Activar autenticación Windows
            //generadorCadena.UserID = "sa"; //usuario
            //generadorCadena.Password = "123456"; //contraseña

            //Recoger la cadena de conexion
            string cadenaConexion = generadorCadena.ConnectionString;

            //Instanciar una conexion con la cadena generada
            SqlConnection sqlConnection = new SqlConnection(cadenaConexion);

            //Retornar el objeto de conexion
            return sqlConnection;

        }
    }
}
