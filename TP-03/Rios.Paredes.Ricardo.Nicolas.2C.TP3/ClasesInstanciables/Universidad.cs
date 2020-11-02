using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace ClasesInstanciables
{

    public class Universidad
    {

        public enum EClases { Programacion, Laboratorio, Legislacion, SPD };

        #region Atributos
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region Constructores

        /// <summary>
        /// instancia la universidad con valores por defecto
        /// </summary>
        public Universidad()
        {
            Alumnos = new List<Alumno>();
            Jornada = new List<Jornada>();
            Instructores = new List<Profesor>();
        }
        #endregion

        #region Propiedades

        /// <summary>
        /// Retorna una jornada especifica de la lista
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Jornada this[int index]
        {
            get
            {
                return this.jornada[index];
            }
        }

        /// <summary>
        /// Retorna o inicializa el valor de la lista de jornadas
        /// </summary>
        public List<Jornada> Jornada
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        /// <summary>
        /// Retorna o inicializa el valor de la lista de alumnos
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
        /// Retorna o inicializa el valor de la lista de profesores
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }
        #endregion

        #region Metodos y Sobrecargas

        /// <summary>
        /// Evalua si un alumno esta en la universidad
        /// </summary>
        /// <param name="g">Universidad donde se busca al alumno</param>
        /// <param name="a">Alumno a buscar</param>
        /// <returns>Lanza una excepcion del tipo AlumnoRepetidoException si esta en la universidad,false si no se encuentra</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno aux in g.Alumnos)
            {
                if (aux == a)
                {
                    throw new AlumnoRepetidoException();
                }
            }
            return false;
        }

        /// <summary>
        /// Evalua si un alumno no se encuentra en la universidad
        /// </summary>
        /// <param name="g">Universidad donde se busca al alumno</param>
        /// <param name="a">Alumno a buscar</param>
        /// <returns>True si no se encuentra, AlumnoRepetidoException en caso de encontrarlo</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Evalua si un profesor da clases en la universidad
        /// </summary>
        /// <param name="g">Universidad donde se busca al profesor</param>
        /// <param name="i">Profesor a buscar</param>
        /// <returns>true si da clases, false si no da clases</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor aux in g.Instructores)
            {
                if (i == aux)
                {
                    return true;
                }
            }
            return false;//podria ir throw SinProfesorException("no da clases");
        }

        /// <summary>
        /// Evalua si un profesor no da clases en la universidad
        /// </summary>
        /// <param name="g">Universidad donde se busca al profesor</param>
        /// <param name="i">Profesor a buscar</param>
        /// <returns>True si no da clases, false si da clases</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Compara la universidad con una clase y devuelve el primer profesor que encuentra y pueda dar la clase
        /// </summary>
        /// <param name="u">Universidad donde se busca al profesor</param>
        /// <param name="clase">Clase que debe dar el profesor</param>
        /// <returns>El primer profesor encontrado que pueda dar la clase, Excepcion del tipo SinProfesorException en caso de no encontrar uno </returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor p in u.Instructores)
            {
                if (p == clase)
                {
                    return p;
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Compara la universidad con una clase y devuelve el primer profesor que encuentra y no de dicha clase
        /// </summary>
        /// <param name="u">Universidad donde se busca al profesor</param>
        /// <param name="clase">Clase que no debe dar el profedor</param>
        /// <returns>El primer profesor que no de la clase, Exception del tipo SinProfesorException si lo encuentra</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor p in u.Instructores)
            {
                if (p != clase)
                {
                    return p;
                }
            }
            throw new SinProfesorException("Todos los profesores dan esa clase");
        }

        /// <summary>
        /// Agrega un alumno a la universidad, si este no concurre a la misma
        /// </summary>
        /// <param name="u">Universidad donde se agregara al alumno</param>
        /// <param name="a">Alumno a agregar</param>
        /// <returns>La universidad con el nuevo alumno, la universidad sin cambios si es que el alumno ya estaba</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
            }
            return u;
        }

        /// <summary>
        /// Agrega un profesor a la universidad, si este no esta en la misma
        /// </summary>
        /// <param name="u">Universidad donde se agregara al profesor</param>
        /// <param name="i">Profesor a agregar</param>
        /// <returns>La universidad con el nuevo profesor, la universidad sin cambios si es que el profesor ya estaba</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.Instructores.Add(i);
            }
            return u;
        }

        /// <summary>
        /// Agrega una clase a la universidad, generando una nueva jornada con sus alumnos y profesor
        /// </summary>
        /// <param name="g">Universidad donde se agregara la jornada</param>
        /// <param name="clase">Clase que se dara en la jornada</param>
        /// <returns>La universidad con su nueva jornada</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            //Profesor p = (g == clase);
            Jornada nuevaJornada = new Jornada(clase, g == clase);
            foreach (Alumno aux in g.Alumnos)
            {
                if (aux == clase)
                {
                    nuevaJornada += aux;
                }

            }
            g.Jornada.Add(nuevaJornada);
            return g;
        }

        /// <summary>
        /// Genera un StringBuilder con los datos de la universidad recibida
        /// </summary>
        /// <param name="uni">Universidad a mostrar</param>
        /// <returns>Cadena de caracteres con los datos del StringBuilder</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine("Jornada");
            foreach (Jornada j in uni.Jornada)
            {
                cadena.Append(j.ToString());
                cadena.AppendLine("<---------------------------------------->");
                //cadena.AppendLine("");
            }
            return cadena.ToString();
        }

        /// <summary>
        /// Muestra los datos de las jornadas
        /// </summary>
        /// <returns>Cadena de caracteres con los datos de cada jornada</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Genera un archivo xml con los datos de la universidad
        /// </summary>
        /// <param name="uni">Universidad a guardar en el archivo xml</param>
        /// <returns>True si pudo guardar el archivo, Excepcion del tipo ArchivosException si no pudo</returns>
        public static bool Guardar(Universidad uni)
        {
            try
            {
                Xml<Universidad> xml = new Xml<Universidad>();
                xml.Guardar("Universidad", uni);
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
        /// <summary>
        /// Lee un archivo en xml y lo devuelve en una instancia de Universidad
        /// </summary>
        /// <returns>La universidad con los datos deserializados, Excepcion del tipo ArchivosException si no pudo</returns>
        public static Universidad Leer()
        {
            try
            {
                Universidad uni = new Universidad();
                Xml<Universidad> xml = new Xml<Universidad>();
                xml.Leer("Universidad",out uni);
                return uni;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
        #endregion
    }
}
