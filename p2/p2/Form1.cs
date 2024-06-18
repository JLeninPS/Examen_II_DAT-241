using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace p2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAbrir1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "archivos (*.png)|*.PNG|archivos (*.jpg)|*.JPG|Todos los archivos (*.*)|*.*";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();

            Bitmap bmp = new Bitmap(openFileDialog1.FileName);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = bmp;

            
            int[, ] mSparse = funciones.matrizSparse(bmp);
            int l = mSparse.GetLength(1); //Numero de columnas de mSparse.
            lblRes1.Text = "X    Y    VAL\n";
            for (int i = 0; i < l/20; i++)
            {
                lblRes1.Text += mSparse[0, i].ToString() + "   " + mSparse[1, i].ToString() + "   " + mSparse[2, i].ToString() + "\n";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "archivos (*.png)|*.PNG|archivos (*.jpg)|*.JPG|Todos los archivos (*.*)|*.*";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();

            Bitmap bmp = new Bitmap(openFileDialog1.FileName);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = bmp;

            int[,] mSparse = funciones.matrizSparse(bmp);
            int l = mSparse.GetLength(1); //Numero de columnas de mSparse.
            lblRes2.Text = "X    Y    VAL\n";
            for (int i = 0; i < l / 20; i++)
            {
                lblRes2.Text += mSparse[0, i].ToString() + "   " + mSparse[1, i].ToString() + "   " + mSparse[2, i].ToString() + "\n";
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            Bitmap bmp1 = (Bitmap)pictureBox1.Image;
            Bitmap bmp2 = (Bitmap)pictureBox2.Image;
            Bitmap bmp3 = (Bitmap)pictureBox1.Image;

            int[,] mSparse = funciones.sumarMatricesSparse(bmp1, bmp2);
            int l = mSparse.GetLength(1); //Numero de columnas de mSparse.

            Bitmap sparse = new Bitmap(bmp3.Width, bmp3.Height);
            for (int i = 0; i < l; i++)
            {
                sparse.SetPixel(mSparse[0, i], mSparse[1, i], Color.Black);
            }

            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.Image = sparse;

            lblRes3.Text = "X    Y    VAL\n";
            for (int i = 0; i < l / 20; i++)
            {
                lblRes3.Text += mSparse[0, i].ToString() + "   " + mSparse[1, i].ToString() + "   " + mSparse[2, i].ToString() + "\n";
            }
        }
    }
}
