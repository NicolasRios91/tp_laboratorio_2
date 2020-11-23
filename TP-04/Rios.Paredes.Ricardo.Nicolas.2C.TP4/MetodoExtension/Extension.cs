using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodoExtension
{
    public static class Extension
    {
        /// <summary>
        /// Agrega el iva al valor que invoca el metodo
        /// </summary>
        /// <param name="valor">valor a modificar</param>
        /// <param name="iva">iva a agregar</param>
        /// <returns>valor con el iva icluido</returns>
        public static float AgregarIva(this float valor ,int iva)
        {
            return valor += iva * valor / 100;
        }

        /// <summary>
        /// Aplica un descuento al valor que invoca el metodo
        /// </summary>
        /// <param name="valor">Valor a modificar</param>
        /// <param name="descuento">Valor a descontar</param>
        /// <returns>valor con el decuento aplicado</returns>
        public static float AplicarDescuento(this float valor,int descuento)
        {
            return valor -= descuento *valor / 100; 
        }
    }
}
