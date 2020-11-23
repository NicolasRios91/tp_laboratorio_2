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
    /// Clase Venta de productos
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Venta<T> : IMiInterfaz
        where T : Producto
    {
        /// <summary>
        /// Atributos
        /// </summary>
        private DateTime fecha;
        private T producto;
        private float precioTotalConIva;
        private float precioFinal;
        private int cantidad;
        private const int descuento = 10;
        private const float rangoDescuento = 1200;
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Venta()
        {
        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="producto">Producto a vender</param>
        /// <param name="cantidad">Cantidad a vender</param>
        public Venta(T producto, int cantidad)
           :this(producto,cantidad,DateTime.Now)
        {
        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="producto">Producto a vender</param>
        /// <param name="cantidad">Cantidad a vender</param>
        /// <param name="fecha">Fecha de la venta</param>
        public Venta(T producto,int cantidad, DateTime fecha)
        {
            this.producto = producto;
            Cantidad = cantidad;
            PrecioTotalConIva = producto.PrecioConIva;
            PrecioFinal = PrecioTotalConIva;
            Fecha = fecha;
        }
           
        /// <summary>
        /// Getter y setter del atributo fecha
        /// </summary>
        public DateTime Fecha
        {
            get
            {
                return this.fecha;
            }
            set
            {
                this.fecha = value;
            }
        }

        /// <summary>
        /// Getter y setter del precio bruto de la venta
        /// </summary>
        public float PrecioTotalConIva
        {
            get
            {
                return this.precioTotalConIva;
            }
            set
            {
                this.precioTotalConIva = Cantidad * value;
            }
        }

        /// <summary>
        /// Getter y setter del producto
        /// </summary>
        public T Producto
        {
            get
            {
                return this.producto;
            }

            set
            {
                this.producto = value;
            }
        }

        /// <summary>
        /// Getter y setter de la cantidad
        /// </summary>
        public int Cantidad
        {
            get
            {
                return this.cantidad;
            }
            set

            {
                this.cantidad = value;
            }
        }

        /// <summary>
        /// Getter y setter del precio final
        /// </summary>
        public float PrecioFinal
        {
            get
            {
                return this.precioFinal;
            }
            set
            {
                this.precioFinal = CalcularPrecioFinal(value);
            }
        }

        /// <summary>
        /// Aplica un descuento al precio bruto de la venta si cumple con la condicion
        /// </summary>
        /// <param name="precioTotal">Precio a evaluar </param>
        /// <returns>Precio final con el descuento aplicado de corresponder</returns>
        public float CalcularPrecioFinal(float precioTotal)
        {
            if (precioTotal > rangoDescuento)
            {
                return precioTotal.AplicarDescuento(descuento);
            }
            else
            {
                return precioTotal;
            }    
        }

        /// <summary>
        /// Muestra los datos de la venta
        /// </summary>
        /// <returns>Datos de la venta</returns>
        public string MostrarDatos()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine($"Fecha: {this.fecha}");
            cadena.AppendLine($"Descripcion: {this.producto.Descripcion}");
            cadena.AppendLine($"Cantidad: {this.cantidad}");
            cadena.AppendLine($"Precio Venta: {this.PrecioFinal}");
            return cadena.ToString();
        }

        /// <summary>
        /// Devuelve los datos de la venta
        /// </summary>
        /// <returns>Datos de la venta</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
