
using Acceso_a_datos.DataAcces;
using System;
using System.Windows.Forms;

namespace Acceso_a_datos
{
    public partial class Form1 : Form
    {
        ConexionDA conexion = new ConexionDA("misael", "1234");

        public Form1()
        {
            InitializeComponent();
            conexion.Test_Conectar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (conexion.Test_Query(tbx_Query.Text))
            {
                dataGridView1.DataSource = conexion.Fill_dvg(tbx_Query.Text).Tables[0];
            }
            else
            {
                MessageBox.Show("Error al ejecutar la consulta.");
            }
        }
    }
}


/*using Acceso_a_datos.DataAcces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Acceso_a_datos
{
    public partial class Form1 : Form
    {
        ConexionDA conexion = new ConexionDA("misael", "1234");
        public Form1()
        {
            InitializeComponent();
            conexion.Test_Conectar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (conexion.Test_Query(tbx_Query.Text))
            {
                dataGridView1.DataSource = conexion.Fill_dvg(tbx_Query.Text).Tables[0];
            }
            else{
                MessageBox.Show("Ejecucion no realizada");
                Application.Restart();
            }
        }
    }
}
*/