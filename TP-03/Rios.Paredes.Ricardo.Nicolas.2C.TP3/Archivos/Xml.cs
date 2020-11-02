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
    public class Xml<T> : IArchivo<T>
        where T : new()
    {
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

        public bool Leer(string archivo, out T datos)
        {
            try
            {
                archivo += ".xml";
                XmlTextReader reader = new XmlTextReader(archivo);
                XmlSerializer seralizer = new XmlSerializer(typeof(T));
                datos = (T)seralizer.Deserialize(reader);   
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return true;
        }
    }
}
