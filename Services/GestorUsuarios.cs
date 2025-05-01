using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyectocsharp.Models;

namespace proyectocsharp
{
    internal class GestorUsuarios
    {
        // Instanciar la clase Conexion
        Conexion conexion = new Conexion();

        public string validarUsuario(Usuarios usuarios)
        {
            try
            {
                // Consulta sql
                string consulta = "SELECT * FROM Usuarios WHERE Usuario = @usuario AND Password = @contraseña";

                // Abrir la conexion
                SqlCommand sqlCommand = new SqlCommand(consulta, conexion.AbrirConexion());

                // Parametros de la consulta
                sqlCommand.Parameters.AddWithValue("@usuario", usuarios.GetUsuario());
                sqlCommand.Parameters.AddWithValue("@contraseña", usuarios.GetContraseña());

                // Ejecutar la consulta
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                // Verificar si el usuario existe
                return sqlDataReader.HasRows ? null : "Usuario o contraseña incorrectos";
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error: " + ex.Message);
                return $"Error al validar el usuario: {ex.Message}";
            }
            finally
            {
                // Cerrar la conexion
                conexion.CerrarConexion();
            }
        }

        public void AgregarUsuario(Usuarios usuarios)
        {
            try
            {
                // Consulta sql
                string consulta = "INSERT INTO Usuarios (Usuario, Password) VALUES (@usuario, @contraseña)";

                // Abrir la conexion
                SqlCommand sqlCommand = new SqlCommand(consulta, conexion.AbrirConexion());

                // Parametros de la consulta
                sqlCommand.Parameters.AddWithValue("@usuario", usuarios.GetUsuario());
                sqlCommand.Parameters.AddWithValue("@contraseña", usuarios.GetContraseña());

                // Ejecutar la consulta
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexion
                conexion.CerrarConexion();
            }
        }

        public void EliminarUsuario(Usuarios usuarios)
        {
            try
            {
                // Consulta sql
                string consulta = "DELETE FROM Usuarios WHERE Usuario = @usuario";

                // Abrir la conexion
                SqlCommand sqlCommand = new SqlCommand(consulta, conexion.AbrirConexion());

                // Parametros de la consulta
                sqlCommand.Parameters.AddWithValue("@usuario", usuarios.GetUsuario());

                // Ejecutar la consulta
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexion
                conexion.CerrarConexion();
            }
        }

        public void ModificarUsuario(Usuarios usuarios)
        {
            try
            {
                // Consulta sql
                string consulta = "UPDATE Usuarios SET Password = @contraseña WHERE Usuario = @usuario";

                // Abrir la conexion
                SqlCommand sqlCommand = new SqlCommand(consulta, conexion.AbrirConexion());

                // Parametros de la consulta
                sqlCommand.Parameters.AddWithValue("@usuario", usuarios.GetUsuario());
                sqlCommand.Parameters.AddWithValue("@contraseña", usuarios.GetContraseña());
                
                // Ejecutar la consulta
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexion
                conexion.CerrarConexion();
            }
        }
    }
}
