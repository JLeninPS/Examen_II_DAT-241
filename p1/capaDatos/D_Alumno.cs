using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using capaEntidad;
using System.Configuration;

using System.Data.SqlClient;
using System.Data;

namespace capaDatos
{
    public class D_Alumno
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon1"].ConnectionString);

        public DataTable D_Listar()
        {
            SqlCommand cmd = new SqlCommand("select * from alumno", con);
            cmd.CommandType = CommandType.Text;
            //cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
          
            return dt;
        }

        public E_Alumno D_Datos(int ci)
        {
            E_Alumno EA = new E_Alumno();

            con.Open();
            SqlCommand cmd = new SqlCommand("select nombre, paterno, materno, edad from alumno where ci = " + ci + "", con);
            cmd.CommandType = CommandType.Text;
            //cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                EA.Nombre = dr["nombre"].ToString();
                EA.Paterno = dr["paterno"].ToString();
                EA.Materno = dr["materno"].ToString();
                EA.Edad = Int32.Parse(dr["edad"].ToString());
            }
            else
            {
                EA = null;
            }
            dr.Close();
            con.Close();
            return EA;
        }
    }
}
