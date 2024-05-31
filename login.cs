using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Acceso_a_datos
{
    public partial class login : Form
    {
        private Font placeholderFont;
        private Font regularFont;

        public login()
        {
            InitializeComponent();
            placeholderFont = new Font("Microsoft Sans Serif", 11, FontStyle.Regular); // Define el tamaño y estilo de la fuente para el placeholder
            regularFont = new Font("Microsoft Sans Serif", 11, FontStyle.Regular); // Define el tamaño y estilo de la fuente para el texto normal
            SetPlaceholder(textBox1, "Usuario");
            SetPlaceholder(textBox2, "Contraseña", isPassword: true);
        }

        private void SetPlaceholder(TextBox textBox, string placeholderText, bool isPassword = false)
        {
            textBox.Text = placeholderText;
            textBox.ForeColor = Color.Gray;
            textBox.Font = placeholderFont;

            textBox.GotFocus += (sender, e) =>
            {
                if (textBox.ForeColor == Color.Gray)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                    textBox.Font = regularFont;
                    if (isPassword)
                    {
                        textBox.PasswordChar = '*';
                    }
                }
            };

            textBox.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholderText;
                    textBox.ForeColor = Color.Gray;
                    textBox.Font = placeholderFont;
                    if (isPassword)
                    {
                        textBox.PasswordChar = '\0';
                    }
                }
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = textBox1.Text;
            string password = textBox2.Text;

            string connectionString = $"Data Source=LAPTOP-CA86S4UF\\SQLEXPRESS01;Initial Catalog=Northwind;User ID={usuario};Password={password};TrustServerCertificate=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Muestra un cuadro de mensaje bonito cuando el inicio de sesión es exitoso
                    MessageBox.Show("Inicio de sesión exitoso", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    menu formPrincipal = new menu();
                    formPrincipal.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar a la base de datos: " + ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
     
    }
}

