using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesInstanciables
{
    public class Universidad
    {
        public enum EClases {Programacion,Laboratorio,Legislacion,SPD};

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
            foreach(Alumno aux in g.Alumnos)
            {
                if (aux == a)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static bool operator == (Universidad g,Profesor i)
        {
            foreach(Jornada aux in g.jornada)
            {
                if (i == aux.Clase)
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
            foreach(Profesor p in u.Instructores)
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
            foreach(Profesor p in u.Instructores)
            {
                if(p!=clase)
                {
                    return p;
                }
            }
            throw new SinProfesorException("Todos los profesores dan esa clase");
        }

        public static Universidad operator +(Universidad u,Alumno a)
        {
            foreach(Alumno aux in u.Alumnos)
            {
                if (aux == a)
                {
                    throw new AlumnoRepetidoException();
                }
            }
            u.Alumnos.Add(a);
            return u;
        }
        public static Universidad operator +(Universidad u,Profesor i)
        {
            foreach (Profesor aux in u.Instructores)
            {
                if (aux == i)
                {
                    return u;
                }
            }
            u.Instructores.Add(i);
            return u;
        }

        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor p = (g == clase);
            Jornada nuevaJornada = new Jornada(clase,p);
            foreach(Alumno aux in g.Alumnos)
            {
                nuevaJornada += aux;
            }
            g.Jornada.Add(nuevaJornada);
            return g;
        }
    }
}
