using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    /// <summary>
    /// Clase con funciones de lectura y guardado de archivos xml
    /// </summary>
    /// <typeparam name="T">Tipo de objeto a leer o guardar</typeparam>
    public class Xml<T> : IArchivo<T>
        where T : new()
    {
        /// <summary>
        /// Guarda el objeto en la archivo indicado
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <param name="datos">Objeto a guardar en el archivo</param>
        /// <returns>True si pudo guardarlo, de lo contrario una Excepcion del tipo ArchivosException</returns>
        public bool Guardar(string archivo, T datos)
        {
            XmlTextWriter writer = null;
            XmlSerializer serializer = null;
            try
            {
                archivo += ".xml";
                writer = new XmlTextWriter(archivo, Encoding.UTF8);
                serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer,datos);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                if(writer!=null)
                {
                    writer.Close();
                }
            }
            return true;
        }

        /// <summary>
        /// Lee el contenido de un archivo xml y lo guarda en un objeto
        /// </summary>
        /// <param name="archivo">Ruta del archivo a leer</param>
        /// <param name="datos">Objeto donde se guardaran los datos del archivo</param>
        /// <returns>True si pudo leer, de lo contrario una Excepcion del tipo ArchivosException</returns>
        public bool Leer(string archivo, out T datos)
        {
            XmlTextReader reader = null;
            XmlSerializer serializer = null;
            try
            {
                archivo += ".xml";
                reader = new XmlTextReader(archivo);
                serializer = new XmlSerializer(typeof(T));
                datos = (T)serializer.Deserialize(reader);   
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                if (reader!=null)
                {
                    reader.Close();
                }    
            }
            return true;
        }
    }
}
