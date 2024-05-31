using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Acceso_a_datos.DataAcces
{

    internal class ConexionDA
    {
        private string connectionString;

        public ConexionDA(string usuario, string password)
        {
            connectionString = $"Data Source=LAPTOP-CA86S4UF\\SQLEXPRESS01;Initial Catalog=Northwind;User ID={usuario};Password={password};TrustServerCertificate=True";
        }

        public bool Test_Conectar()
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    // La conexión se abre correctamente
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error de conexión con la base de datos: {ex.Message}");
                    return false;
                }
            }
        }

        public bool Test_Query(string str_Query)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand comando = new SqlCommand(str_Query, conexion))
                    {
                        conexion.Open();
                        comando.ExecuteNonQuery();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al ejecutar la consulta: {ex.Message}");
                    return false;
                }
            }
        }

        public DataSet Fill_dvg(string str_Query)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlDataAdapter adaptador = new SqlDataAdapter(str_Query, conexion))
                    {
                        adaptador.Fill(ds);
                    }
                    return ds;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al llenar el DataSet: {ex.Message}");
                    return ds;
                }
            }
        }
    }
}






