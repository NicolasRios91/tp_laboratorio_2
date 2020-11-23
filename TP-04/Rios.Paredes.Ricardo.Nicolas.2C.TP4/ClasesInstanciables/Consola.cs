using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;
using Interfaz;
using MetodoExtension;
namespace ClasesInstanciables
{
    /// <summary>
    /// Consolas de video juegos
    /// </summary>
    public class Consola : Producto
    {
        //Atributos
        private ConsoleColor color;
       
        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public Consola()
        {
        }

        /// <summary>
        /// Constructor de Consola Parametrizado
        /// </summary>
        /// <param name="descripcion">Descripcion de la Consola</param>
        /// <param name="precio">Precio de la Consola</param>
        /// <param name="plataforma">Plataforma de la Consola</param>
        /// <param name="color">Color de la Consola</param>
        public Consola(string descripcion, float precio,EPlataforma plataforma, ConsoleColor color)
            :base(descripcion, precio, plataforma)
        {
            Color = color;
            PrecioConIva = Precio;
        }

        /// <summary>
        /// Getter y setter del Color de la consola
        /// </summary>
        public ConsoleColor Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
            }
        }

        /// <summary>
        /// Getter del precio con iva, aplica iva salvo si el color de la consola es Blanco
        /// </summary>
        public override float PrecioConIva
        {
            get
            {
                return this.precioConIva;
            }
            set

            {
                if (Color != ConsoleColor.White)
                {

                    this.precioConIva = CalcularPrecioFinal(value);
                }
                else

                {
                    this.precioConIva = value;
                }
            }
        }
        
        /// <summary>
        /// Muestra los datos de la consola
        /// </summary>
        /// <returns>Datos de la consola</returns>
        public override string ToString()
        {
            return  this.MostrarDatos() + $"Color {Color}\n";
        }

    }
}
