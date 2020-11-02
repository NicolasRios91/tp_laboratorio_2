using Archivos;
using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClasesInstanciables
{
    /// <summary>
    /// Clase para declarar las jornadas, con su respectiva clase, profesor, y lista de alumnos
    /// </summary>
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region PROPIEDADES

        /// <summary>
        /// Retorna o inicializa la lista de alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// Retorna o inicializa la clase que se dictara en la jornada
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;

            }
            set
            {
                this.clase = value;
            }
        }

        /// <summary>
        /// Retorno a inicializa el profesor
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;

            }
        }
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor privado que inicializa la lista de alumnos
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Instancia la jornada
        /// </summary>
        /// <param name="clase">Clase que se va a dar</param>
        /// <param name="instructor">Profesor de la jornada</param>
        public Jornada(Universidad.EClases clase, Profesor instructor)
            :this()
        {
            Clase = clase;
            Instructor = instructor;
        }
        #endregion




        #region Metodos y Sobrecargas



        /// <summary>
        /// Agrega un alumno a la jornada si no esta en la lista
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j,Alumno a)
        {
            if (j!=a)
            {
                j.Alumnos.Add(a);
            }
            return j;
        }

        /// <summary>
        /// Evalua si una jornada es igual a un alumno
        /// </summary>
        /// <param name="j">Jornada a evaluar</param>
        /// <param name="a">Alumno a evaluar</param>
        /// <returns>True si coinciden las clases, de lo contrario false</returns>
        public static bool operator ==(Jornada j,Alumno a)
        {
            foreach(Alumno aux in j.Alumnos)
            {
                if (a == aux)
                {
                    return true;
                    //throw new AlumnoRepetidoException();
                }
            }
            return false;
        }

        /// <summary>
        /// Evalua si una jornada es distinta a un alumno
        /// </summary>
        /// <param name="j">Jornada a evaluar</param>
        /// <param name="a">Alumno a evaluar</param>
        /// <returns>True si las clases no coinciden, de lo contrario false</returns>
        public static bool operator !=(Jornada j,Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Muestra los datos de la jornada
        /// </summary>
        /// <returns>Cadena de caracteres con todos los datos de la jornada</returns>
        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.Append($"CLASE DE: {this.Clase}  ");
            cadena.Append($"POR: {this.Instructor}");
            cadena.AppendLine("ALUMNOS");
            foreach(Alumno a in this.Alumnos)
            {
                cadena.Append(a.ToString());
            }
            return cadena.ToString();
        }

        /// <summary>
        /// Lee el archivo de la jornada guardada
        /// </summary>
        /// <returns>Retorna el archivo en una cadena de caracteres</returns>
        public static string Leer()
        {
            try
            {
                string textoJornada;
                Texto texto = new Texto();
                texto.Leer("Jornada", out textoJornada);
                return textoJornada;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// Guarda los datos de la jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>True si pudo guardar, Excepcion del tipo ArchivosException si no pudo</returns>
        public static bool Guardar(Jornada jornada)
        {
            try
            {
                Texto texto = new Texto();
                texto.Guardar("Jornada", jornada.ToString());
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return true;
        }


        #endregion
    }
}
