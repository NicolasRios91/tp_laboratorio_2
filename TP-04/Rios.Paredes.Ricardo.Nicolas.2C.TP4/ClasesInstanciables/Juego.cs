using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;
using Interfaz;
using MetodoExtension;
using System.Xml;
using System.Xml.Serialization;


namespace ClasesInstanciables
{
    /// <summary>
    /// Clase Juegos
    /// </summary>
    public class Juego : Producto
    {
        //Atributos
        public enum EFormato { Fisico,Digital};
        private EFormato formato;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Juego()
        {
        }

        /// <summary>
        /// Constructor Parametrizado del juego
        /// </summary>
        /// <param name="descripcion">Descripcion del juego</param>
        /// <param name="precio">precio sin iva del juego</param>
        /// <param name="plataformaJuego">plataforma del juego</param>
        /// <param name="formato">Formato del juego</param>
        public Juego(string descripcion, float precio,EPlataforma plataformaJuego,EFormato formato)
            :base(descripcion,precio, plataformaJuego)
        {
            Plataforma = plataformaJuego;
            Formato = formato;
            PrecioConIva = Precio;
        }

        /// <summary>
        /// Getter y setter del formato de la consola
        /// </summary>
        public EFormato Formato
        {
            get
            {
                return this.formato;
            }
            set
            {
                this.formato = value;
            }
        }

        /// <summary>
        /// Getter del precio con iva, aplica iva si el juego esta en formato Digital
        /// </summary>
        public override float PrecioConIva
        {
            get
            {
                return this.precioConIva;
            }
            set

            {
                if(Formato == EFormato.Digital)
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
        /// Devuelve los datos del juego
        /// </summary>
        /// <returns>Datos del juego</returns>
        public override string ToString()
        {
            return this.MostrarDatos() + $"Formato: {Formato}\n";
        }

    }
}
