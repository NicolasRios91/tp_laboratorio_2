using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    /// <summary>
    /// Clase con funciones de lectura y guardado de archivos de texto
    /// </summary>
    public class Texto : IArchivo<string>
        
    {
        /// <summary>
        /// Lee el contenido del archivo indicado y lo guarda en la variable datos
        /// </summary>
        /// <param name="archivo">ruta del archivo a leer</param>
        /// <param name="datos">variable donde se guardaran los datos</param>
        /// <returns>true si pudo leer y cargar los datos, de lo contrario una Excepcion del tipo ArchivosException</returns>
        public bool Leer(string archivo, out string datos)
        {
            StreamReader streamReader = null;
            try
            {
                archivo += ".txt";
                streamReader = new StreamReader(archivo);
                string texto = string.Empty;
                string nuevaLinea = streamReader.ReadLine();
                while(nuevaLinea!=null)
                {
                    texto += nuevaLinea;
                    nuevaLinea = streamReader.ReadLine();
                }
                datos = texto;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                if (streamReader!=null)
                {
                    streamReader.Close();
                }
            }
            return true;
        }

        /// <summary>
        /// Guarda una cadena de caracteres en un archivo de texto
        /// </summary>
        /// <param name="archivo">Ruta donde se guardara el archivo</param>
        /// <param name="datos">Texto a guardar</param>
        /// <returns>True si pudo guardar, de lo contrario una Excepcion del tipo ArchivosException</returns>
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter streamWriter = null;
            try
            {
                archivo += ".txt";
                streamWriter = new StreamWriter(archivo);
                streamWriter.WriteLine(datos);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                if (streamWriter!=null)
                {
                    streamWriter.Close();
                }
            }
            return true;

        }

    }
}
