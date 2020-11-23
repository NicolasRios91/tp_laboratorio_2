using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaz;
using MetodoExtension;
namespace ClasesAbstractas
{
    
    public abstract class Producto : IMiInterfaz
    {
        /// <summary>
        /// Enumerado de Plataformas posibles
        /// </summary>
        public enum EPlataforma { Ps4, Xbox,NintendoSwitch,Otros };

        //ATRIBUTOS
        private EPlataforma plataforma;
        private string descripcion;
        private float precio;
        protected float precioConIva;
        protected const int iva = 20;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Producto()
        { 
        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="descripcion">Descripcion del producto</param>
        /// <param name="precio">Precio sin iva del producto</param>
        /// <param name="plataforma">Plataforma del producto</param>
        public Producto(string descripcion,float precio,EPlataforma plataforma)
        {
            Descripcion = descripcion;
            Precio = precio;
            Plataforma = plataforma;
        }

        //PROPIEDADES
        public abstract float PrecioConIva { get; set; }

        /// <summary>
        /// Getter y setter del atributo precio
        /// </summary>
        public float Precio
        {
            get
            {
                return this.precio;
            }
            set
            {
                this.precio = value;
            }
        }

        /// <summary>
        /// Getter y setter del atributo plataforma
        /// </summary>
        public EPlataforma Plataforma
        {
            get
            {
                return this.plataforma;
            }
            set
            {
                this.plataforma = value;
            }
        }

        /// <summary>
        /// Getter y setter del atributo descripcion
        /// </summary>
        public string Descripcion
        {
            get
            {
                return this.descripcion;
            }
            set
            {
                this.descripcion = value;
            }
        }

        /// <summary>
        /// 2 productos si la plataforma es distinta a otros y coinciden, y si su descripcion es la misma
        /// </summary>
        /// <param name="p1">Primer objeto a comparar</param>
        /// <param name="p2">Segundo objeto a comparar</param>
        /// <returns></returns>
        public static bool operator == (Producto p1, Producto p2)
        {
            bool retorno = false;

            if (p1.Plataforma == EPlataforma.Otros || p2.Plataforma == EPlataforma.Otros)
            {
                retorno = false;
            }

            else
            {
                if (p1.Descripcion == p2.Descripcion && p1.Plataforma == p2.Plataforma)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        /// <summary>
        /// 2 Productos son distintos si tienen distinto nombre, y su plataforma es otros, o no coinciden
        /// </summary>
        /// <param name="p1">Primer objeto a comparar</param>
        /// <param name="p2">Segundo objeto a comparar</param>
        /// <returns></returns>
        public static bool operator !=(Producto p1, Producto p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Devuelve el precio de un producto con su iva incluido
        /// </summary>
        /// <param name="precio">Precio donde adicionar el iva</param>
        /// <returns></returns>
        public float CalcularPrecioFinal(float precio)
        {
            return precio.AgregarIva(iva);
        }

        /// <summary>
        /// Muestra los datos del producto
        /// </summary>
        /// <returns>Datos del producto</returns>
        public string MostrarDatos()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine($"Descripcion: {Descripcion}");
            cadena.AppendLine($"Precio por unidad: {Precio}");
            cadena.AppendLine($"Precio con IVA: {precioConIva}");
            return cadena.ToString();
        }

        /// <summary>
        /// Devuelve los datos del producto
        /// </summary>
        /// <returns>Datos del producto</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
