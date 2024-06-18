using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using capaDatos;
using capaEntidad;
using System.Data;

namespace capaNegocio
{
    public class N_Alumno
    {
        D_Alumno DA1 = new D_Alumno();

        public DataTable N_Listar()
        {
            return DA1.D_Listar();
        }

        public E_Alumno N_Datos(int ci)
        {
            return DA1.D_Datos(ci);
        }
    }
}
