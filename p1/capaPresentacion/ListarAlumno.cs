using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using capaNegocio;

namespace capaPresentacion
{
    public partial class ListarAlumno : Form
    {
        N_Alumno NA1 = new N_Alumno();
        public ListarAlumno()
        {
            InitializeComponent();
        }
        public void listarAlumnos()
        {
            DataTable dt = NA1.N_Listar();
            dataGridView1.DataSource = dt;
        }
        private void P_Alumno_Load(object sender, EventArgs e)
        {
            listarAlumnos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            listarAlumnos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarAlumno buscar = new BuscarAlumno();
            buscar.Show();
            Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
