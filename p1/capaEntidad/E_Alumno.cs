using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidad
{
    public class E_Alumno
    {
        private int ci;
        private string nombre;
        private string paterno;
        private string materno;
        private int edad;

        //Constructores
        public E_Alumno()
        {
            this.ci = 0;
            this.nombre = "";
            this.paterno = "";
            this.materno = "materno";
            this.edad = 0;
        }
        public E_Alumno(int ci, string nombre, string paterno, string materno, int edad)
        {
            this.ci = ci;
            this.nombre = nombre;
            this.paterno = paterno;
            this.materno = materno;
            this.edad = edad;
        }

        //Getters Y Setters

        public int Ci { get => ci; set => ci = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Paterno { get => paterno; set => paterno = value; }
        public string Materno { get => materno; set => materno = value; }
        public int Edad { get => edad; set => edad = value; }



        //public int ci {  get; set; }
        //public string nombre {  get; set; }
        //public string paterno {  get; set; }
        //public string materno {  get; set; }
        //public int edad {  get; set; }
    }
}
