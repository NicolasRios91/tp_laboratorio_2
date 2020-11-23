using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;


namespace Archivos
{
    public class Texto : IArchivos<string>
    {

        public bool Guardar(string archivo, string datos)
        {
            StreamWriter streamWriter = null;
            try
            {
                streamWriter = new StreamWriter(archivo);
                streamWriter.WriteLine(datos);
            }
            catch (Exception e)
            {
                throw new ArchivosException("Error al guardar",e);
            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                }
            }
            return true;

        }
        public bool Leer(string archivo, out string datos)
        {
            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(archivo);
                string texto = string.Empty;
                string nuevaLinea = streamReader.ReadLine();
                while (nuevaLinea != null)
                {
                    texto += nuevaLinea;
                    nuevaLinea = streamReader.ReadLine();
                }
                datos = texto;
            }
            catch (Exception e)
            {
                throw new ArchivosException("Error al cargar el archivo",e);
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                }
            }
            return true;
        }


    }
}
