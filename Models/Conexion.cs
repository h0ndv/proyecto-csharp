using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectocsharp.Models
{
    public class Conexion
    {
        private SqlConnection conexion;

        public Conexion()
        {
            string cadena = ConfigurationManager.ConnectionStrings["STOMAS_NET"].ConnectionString;
            conexion = new SqlConnection(cadena);
        }

        public SqlConnection AbrirConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
            }
            return conexion;
        }

        public void CerrarConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
        }

        public SqlCommand CrearComando(string consulta)
        {
            return new SqlCommand(consulta, conexion);
        }

        public SqlDataReader EjecutarConsulta(string consulta)
        {
            SqlCommand comando = new SqlCommand(consulta, AbrirConexion());
            return comando.ExecuteReader();
        }

        public int EjecutarNoQuery(string consulta)
        {
            SqlCommand comando = new SqlCommand(consulta, AbrirConexion());
            int resultado = comando.ExecuteNonQuery();
            CerrarConexion();
            return resultado;
        }
    }
}

