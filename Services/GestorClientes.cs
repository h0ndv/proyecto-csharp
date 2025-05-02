using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyectocsharp.Models;
using System.Data.SqlClient;

namespace proyectocsharp
{
    internal class GestorClientes
    {
        // Lista de clientes
        public List<Clientes> clientes = new List<Clientes>();

        // Instanciar clase conexion
        Conexion conexion = new Conexion();

        // Guardar cliente
        public void GuardarCliente(Clientes cliente)
        {
            clientes.Add(cliente);
        }

        // Obtener La lista clientes
        public List<Clientes> MostrarClientes()
        {
            return clientes;
        }

        // Validar cliente en la base de datos
        public string ValidarCliente(Clientes clientes)
        {
            try
            {
                string consulta = "SELECT * FROM Clientes WHERE Nombre = @nombre AND Rut = @rut";

                // Abrir la conexion
                SqlCommand sqlCommand = new SqlCommand(consulta, conexion.AbrirConexion());

                // Parametros de la consulta
                sqlCommand.Parameters.AddWithValue("@nombre", clientes.GetNombre());
                sqlCommand.Parameters.AddWithValue("@rut", clientes.GetRut());

                // Ejecutar la consulta
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                // Verificar si el cliente existe
                return sqlDataReader.HasRows ? null : "Cliente no existe";
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error: " + ex.Message);
                return $"Error al validar el cliente: {ex.Message}";
            }
            finally
            {
                // Cerrar la conexion
                conexion.CerrarConexion();

            }
        }

        // Agregar cliente a la base de datos
        public void AgregarCliente(Clientes clientes)
        {
            try
            {
                // Consulta sql
                string consulta = "INSERT INTO Clientes (Nombre, Rut) VALUES (@nombre, @rut)";
                // Abrir la conexion
                SqlCommand sqlCommand = new SqlCommand(consulta, conexion.AbrirConexion());
                // Parametros de la consulta
                sqlCommand.Parameters.AddWithValue("@nombre", clientes.GetNombre());
                sqlCommand.Parameters.AddWithValue("@rut", clientes.GetRut());
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

        // Eliminar cliente de la base de datos
        public void EliminarCliente(Clientes clientes)
        {
            try
            {
                // Consulta sql
                string consulta = "DELETE FROM Clientes WHERE Nombre = @nombre AND Rut = @rut";

                // Abrir la conexion
                SqlCommand sqlCommand = new SqlCommand(consulta, conexion.AbrirConexion());

                // Parametros de la consulta
                sqlCommand.Parameters.AddWithValue("@nombre", clientes.GetNombre());
                sqlCommand.Parameters.AddWithValue("@rut", clientes.GetRut());

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

        // Actualizar cliente en la base de datos
        public void ActualizarCliente(Clientes clientes)
        {
            try
            {
                // Consulta sql
                string consulta = "UPDATE Clientes SET Nombre = @nombre, Rut = @rut, Celular = @celular, Correo = @correo, Compras = @compras, Preferencias = @preferencias WHERE Rut = @rut";

                // Abrir la conexion
                SqlCommand sqlCommand = new SqlCommand(consulta, conexion.AbrirConexion());

                // Parametros de la consulta
                sqlCommand.Parameters.AddWithValue("@nombre", clientes.GetNombre());
                sqlCommand.Parameters.AddWithValue("@rut", clientes.GetRut());
                sqlCommand.Parameters.AddWithValue("@celular", clientes.GetCelular());
                sqlCommand.Parameters.AddWithValue("@correo", clientes.GetCorreo());
                sqlCommand.Parameters.AddWithValue("@compras", clientes.GetCompras());
                sqlCommand.Parameters.AddWithValue("@preferencias", clientes.GetPreferencias());

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

        // Obtener clientes de la base de datos
        public List<Clientes> ObtenerClientes()
        {
            List<Clientes> listaClientes = new List<Clientes>();
            try
            {
                // Consulta sql
                string consulta = "SELECT * FROM Clientes";

                // Abrir la conexion
                SqlCommand sqlCommand = new SqlCommand(consulta, conexion.AbrirConexion());

                // Ejecutar la consulta
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                
                // Leer los datos del cliente
                while (sqlDataReader.Read())
                {
                    Clientes cliente = new Clientes();
                    cliente.SetNombre(sqlDataReader["Nombre"].ToString());
                    cliente.SetRut(Convert.ToInt32(sqlDataReader["Rut"]));
                    cliente.SetCelular(Convert.ToInt32(sqlDataReader["Celular"]));
                    cliente.SetCorreo(sqlDataReader["Correo"].ToString());
                    cliente.SetCompras(sqlDataReader["Compras"].ToString());
                    cliente.SetPreferencias(sqlDataReader["Preferencias"].ToString());

                    // Agregar el cliente a la lista
                    listaClientes.Add(cliente);
                }
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
            return listaClientes;
        }
    }
}
