using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
        
    {
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
