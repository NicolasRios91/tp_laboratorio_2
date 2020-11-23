using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;
using Excepciones;
using Archivos;
using System.Xml;
using System.Xml.Serialization;
using System.Threading;
namespace ClasesInstanciables
{

    public delegate void VentaRandom(string datos);
    [XmlInclude(typeof(Consola))]
    [XmlInclude(typeof(Juego))]

    public class UtnStore
    {
        /// <summary>
        /// Atributos
        /// </summary>
        private List<Producto> productos;
        private List<Venta<Producto>> ventas;
        private const int maxProductoPorVenta = 10;

        public event VentaRandom seVendio;

        /// <summary>
        /// Constructor por defecto, instancia las listas
        /// </summary>
        public UtnStore()
        {
            Productos = new List<Producto>();
            Ventas = new List<Venta<Producto>>();
        }

        /// <summary>
        /// Devuelve un producto en el indice indicado
        /// </summary>
        /// <param name="index">Indice a buscar</param>
        /// <returns>Producto</returns>
        public Producto this[int index]
        {
            get
            {
                return Productos.ElementAt(index);
            }
        }

        /// <summary>
        /// Getter y setter de la lista de la tienda
        /// </summary>
        public List<Producto> Productos
        {
            get

            {
                return this.productos;
            }
            
            set
            {
                this.productos = value;
            }
            
        }

        /// <summary>
        /// getter y setter de las ventasd de la tienda
        /// </summary>
        public List<Venta<Producto>> Ventas
        {
            get

            {
                return this.ventas;
            }
            set
            {
                this.ventas = value;
            }
        }

        /// <summary>
        /// La tienda es igual a un producto si hay un producto igual en la lista de la tienda
        /// </summary>
        /// <param name="u">Tienda donde buscar el producto</param>
        /// <param name="j">Juego a comparar</param>
        /// <returns>True si lo contiene, de lo contrario false</returns>
        public static bool operator == (UtnStore u, Producto j)
        {
            foreach (Producto aux in u.Productos)
            {
                if (aux == j)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// La tienda es distinta a un producto si no hay un producto igual en la lista de la tienda
        /// </summary>
        /// <param name="u">Tienda donde buscar el producto</param>
        /// <param name="j">Producto a comparar</param>
        /// <returns>True si no existe, false si el producto existe</returns>
        public static bool operator !=(UtnStore u, Producto j)
        {
            return !(u == j);
        }
        
        /// <summary>
        /// Agrega un producto a la lista de productos si este no esta en la lista, caso contrario lanza una excepcion
        /// </summary>
        /// <param name="u">Tienda donde se agregara el producto</param>
        /// <param name="j">Producto a agregar</param>
        /// <returns>Tienda con el producto agregado, caso contrario se lanza una excepcion</returns>
        public static UtnStore operator +(UtnStore u, Producto j)
        {
            foreach (Producto aux in u.Productos)
            {
                if (aux == j)
                {
                    throw new ProductoRepetidoException("El producto ya esta en la tienda");
                }
            }
            u.productos.Add(j);
            
            return u;
        }

        /// <summary>
        /// Agrega una venta a la lista de la tienda, si esta cumple con las cantidades y si ademas el producto existe en la tienda
        /// caso contrario lanza una exepcion
        /// </summary>
        /// <param name="u">Tienda donde agregar la venta</param>
        /// <param name="v">Venta a agregar</param>
        /// <returns>Tienda con la venta agregada, caso contrario lanza una excepcion</returns>
        public static UtnStore operator +(UtnStore u,Venta<Producto> v)
        {
            if (v.Cantidad > maxProductoPorVenta || u!=v.Producto) 
            {
                throw new CantidadLimiteException("No se pudo realizar la venta");
            }
            u.Ventas.Add(v);
            return u;
        }


        /// <summary>
        /// Muestra la lista con todos los productos de la tienda
        /// </summary>
        /// <returns>Lista de productos en formato string</returns>
        public string MostrarProductos()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine("Lista de Productos\n");
            foreach (Producto p in this.Productos)
            {
                cadena.AppendLine(p.ToString());
                cadena.AppendLine("");
            }
            return cadena.ToString();
        }

        /// <summary>
        /// Muestra la lista con todas las venta de la tienda
        /// </summary>
        /// <returns>Lista de ventas en formato string</returns>
        public string MostrarVentas()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine("Lista de Ventas\n");
            foreach(Venta<Producto> v in this.Ventas)
            {
                cadena.AppendLine(v.ToString());
            }
            return cadena.ToString();
        }


        /// <summary>
        /// Muestra las 2 listas de la tienda
        /// </summary>
        /// <returns>Datos de la tienda</returns>
        public override string ToString()
        {
            return MostrarVentas() + MostrarProductos();
        }

        /// <summary>
        /// Guarda los datos de la tienda en un archivo xml
        /// </summary>
        /// <param name="u">Tienda a guardar</param>
        /// <returns>True si la pudo guardar, caso contrario lanza una excepcion</returns>
        public static bool GuardarXml(UtnStore u)
        {
            {
                try
                {
                    Xml<UtnStore> xml = new Xml<UtnStore>();
                    xml.Guardar("UtnStore.xml", u);
                    return true;
                }
                catch (Exception e)
                {
                    throw new ArchivosException(e);
                }
            }
        }

        /// <summary>
        /// Guarda los datos de la tienda en un archivo de texto
        /// </summary>
        /// <param name="u">Tienda a guardar</param>
        /// <returns>True si la pudo guardar</returns>
        public static bool GuardarTxt(UtnStore u)
        {
            Texto texto = new Texto();
            texto.Guardar("UtnStore.txt", u.ToString());
            return true;
        }
        

        /// <summary>
        /// Devulve una instancia de UtnStore con los datos cargados de un archivo xml
        /// </summary>
        /// <returns>True si pudo cargar, caso contrario lanza una excepcion</returns>
        public static UtnStore Leer()
        {
            try
            {
                UtnStore u;
                Xml<UtnStore> xml = new Xml<UtnStore>();
                xml.Leer("UtnStore.xml", out u);
            return u;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
        
        /// <summary>
        /// Simula ventas para cargarlas en un campo en la clase Form
        /// </summary>
        public void Vender()
        {
            if (!(object.ReferenceEquals(this.seVendio, null)))
            {
                int i = 0;
                while (i<10)
                {
                Thread.Sleep(2000);
                Random r1 = new Random();
                Random r2 = new Random();
                int index = r1.Next(0, this.Productos.Count);
                int cantidad = r2.Next(1, 10);
                Venta<Producto> venta = new Venta<Producto>(this.Productos.ElementAt(index), cantidad);
                if(!(object.ReferenceEquals(this.seVendio,null)))
                {
                    this.seVendio.Invoke(venta.ToString()+"\n");

                }
                i++;
                }
            }
        }
    }
}
