using capaEntidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using capaEntidad;
using capaNegocio;

namespace capaPresentacion
{
    public partial class BuscarAlumno : Form
    {
        N_Alumno NA1 = new N_Alumno();
        E_Alumno EA1 = new E_Alumno();
        public BuscarAlumno()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int ci, edad;
            string nombre, paterno, materno;
            
            if(txtCi.Text != "")
                ci = Int32.Parse(txtCi.Text);
            else
                ci = 0;

            EA1 = NA1.N_Datos(ci);

            if (EA1 != null)
            {
                nombre = EA1.Nombre;
                paterno = EA1.Paterno;
                materno = EA1.Materno;
                edad = EA1.Edad;

                txtNombre.Text = nombre.ToUpper();
                txtPaterno.Text = paterno.ToUpper();
                txtMaterno.Text = materno.ToUpper();
                txtEdad.Text = edad.ToString();
            }
            else
                MessageBox.Show("CI desconocido...", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnTabla_Click(object sender, EventArgs e)
        {
            ListarAlumno tabla = new ListarAlumno();
            tabla.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
