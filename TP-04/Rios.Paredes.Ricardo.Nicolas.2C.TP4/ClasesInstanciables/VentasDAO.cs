using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ClasesAbstractas;
using Excepciones;

namespace ClasesInstanciables
{
    public class VentasDAO
    {
        /// <summary>
        /// Atributos
        /// </summary>
        private SqlConnection sqlConnection;
        private string connectionString;

        /// <summary>
        /// Constructor por defecto, inicializa la ruta de conexion
        /// </summary>
        public VentasDAO()
        {
            this.connectionString = "Server=.;Database=TP4;Trusted_Connection=True;";
            this.sqlConnection = new SqlConnection(connectionString);
        }

        /// <summary>
        /// Ingresa los datos de una venta en la tabla Venta de la base de datos
        /// </summary>
        /// <param name="venta">Venta a agregar</param>
        public void InsertarVenta(Venta<Producto> venta)
        {
            try
            {
                string command = "INSERT INTO Ventas(fecha,descripcion, cantidad, total) " +
                   "VALUES(@fecha, @descripcion, @cantidad,@total)";

                SqlCommand sqlCommand = new SqlCommand(command, this.sqlConnection);
                sqlCommand.Parameters.AddWithValue("fecha", venta.Fecha);
                sqlCommand.Parameters.AddWithValue("descripcion", venta.Producto.Descripcion);
                sqlCommand.Parameters.AddWithValue("cantidad", venta.Cantidad);
                sqlCommand.Parameters.AddWithValue("total", venta.PrecioFinal);
                this.sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new ArchivosException("Error de archivo",e);
            }
            finally
            {
                if (sqlConnection != null &&
                    sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    this.sqlConnection.Close();
                }
            }
        }

        /// <summary>
        /// Muestra los datos de una venta de la tabla en particular
        /// </summary>
        /// <param name="id">id de la venta a buscar</param>
        /// <returns>Datos de la venta, caso contrario lanza una excepcion</returns>
        public string ObtenerVentaPorId(int id)
        {
            try
            {
                string command = "SELECT * FROM Ventas WHERE id=@id";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                reader.Read();
                DateTime fecha = (DateTime)reader["fecha"];
                string descripcion = (string)reader["descripcion"];
                int cantidad = (int)reader["cantidad"];
                float precioFinal = (float)Convert.ToDouble(reader["total"]);
                return $"Fecha: {fecha}\nDescripcion {descripcion}\nCantidad: {cantidad}\nPrecio Final: {precioFinal}\n";
            }
            catch (Exception e)
            {
                throw new ArchivosException("Error de archivo", e);
            }
            finally
            {
                if (sqlConnection != null &&
                    sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    this.sqlConnection.Close();
                }
            }
        }
    }               
}
