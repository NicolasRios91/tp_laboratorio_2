using Archivos;
using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClasesInstanciables
{
    public class Universidad
    {
        public enum EClases { Programacion, Laboratorio, Legislacion, SPD };

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        public Universidad()
        {
            Alumnos = new List<Alumno>();
            Jornada = new List<Jornada>();
            Instructores = new List<Profesor>();
        }
        public Jornada this[int index]
        {
            get
            {
                return this.jornada[index];
            }
        }
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

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor aux in g.Instructores)
            {
                if (i == aux)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

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

        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u!=a)
            {
                u.Alumnos.Add(a);
            }
            return u;
        }

        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u!=i)
            {
                u.Instructores.Add(i);
            }
            return u;
        }

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

        public override string ToString()
        {
            return MostrarDatos(this);
        }

        public static bool Guardar (Universidad uni)
        {
            try
            {
                Xml<Universidad>xml = new Xml<Universidad>();
                xml.Guardar("Universidad", uni);
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        public Universidad Leer ()
        {
            try
            {
                Universidad uni = null;
                Xml<Universidad> xml = new Xml<Universidad>();
                xml.Leer("Universidad",out uni);
                return uni;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
            
            


    }
}
