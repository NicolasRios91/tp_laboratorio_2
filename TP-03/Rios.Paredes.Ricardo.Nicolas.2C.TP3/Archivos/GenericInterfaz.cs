using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    /// <summary>
    /// Interfaz para la lectura y guardado de archivos
    /// </summary>
    /// <typeparam name="T">Tipo de objeto a leer o guardar</typeparam>
    interface IArchivo<T>
    {
        bool Leer(string archivo, out T datos);
        bool Guardar(string archivo, T datos);
    }
}
