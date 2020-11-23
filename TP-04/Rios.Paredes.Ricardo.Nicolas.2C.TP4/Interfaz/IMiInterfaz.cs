using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz
{
    public interface IMiInterfaz
    {
        /// <summary>
        /// Calculara el precio Final de acuerdo a la clase que la implemente
        /// </summary>
        /// <param name="precio">Precio a evaluar</param>
        /// <returns>Preco con las modificaciones pertinentes</returns>
        float CalcularPrecioFinal(float precio);
        
        /// <summary>
        /// Mostrara los datos de la clase que lo implemente
        /// </summary>
        /// <returns>Cadena de caracteres con los datos</returns>
        string MostrarDatos();
    }
}
