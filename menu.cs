using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Acceso_a_datos
{
    public partial class menu : Form
    {
        private const string connectionString = "Data Source=LAPTOP-CA86S4UF\\SQLEXPRESS01;Initial Catalog=Northwind;Integrated Security=True;";
        public menu()
        {
            InitializeComponent();
        }

        private void Consultas_Click(object sender, EventArgs e)
        {
            Form1 formPrincipal = new Form1();

            formPrincipal.Show();

            this.Hide();
        }

        //Boton para hacer un respaldo
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear un nuevo cuadro de diálogo para guardar archivo
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                // Configurar las opciones del cuadro de diálogo
                saveFileDialog1.Filter = "Archivos de respaldo (*.bak)|*.bak|Todos los archivos (*.*)|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog1.FileName;

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Comando para realizar el respaldo de la base de datos Northwind
                        string backupQuery = $"BACKUP DATABASE [Northwind] TO DISK = '{filePath}' WITH INIT, FORMAT, SKIP, NOREWIND, NOUNLOAD";

                        using (SqlCommand command = new SqlCommand(backupQuery, connection))
                        {
                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Respaldo de la base de datos Northwind creado correctamente.", "Respaldo Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al realizar el respaldo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=LAPTOP-CA86S4UF\\SQLEXPRESS01;Initial Catalog=Northwind;Integrated Security=True;";
            BTCProductoForm btcProductoForm = new BTCProductoForm(connectionString);
            btcProductoForm.Show();
            this.Hide();
        }

        private void menu_Load(object sender, EventArgs e)
        {

        }
    }
}
