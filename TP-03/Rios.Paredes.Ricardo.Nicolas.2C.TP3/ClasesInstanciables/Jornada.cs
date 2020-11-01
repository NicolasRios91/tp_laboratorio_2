using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        private Jornada()
        {
            if(this.alumnos == null)
            {
                this.alumnos = new List<Alumno>();
            }
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
            :this()
        {
            Clase = clase;
            Instructor = instructor;
        }

        //PROPIEDADES
        public List<Alumno> Alumnos
        {
            get
            {
                return this.Alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

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

        public static Jornada operator +(Jornada j,Alumno a)
        {
            if (j == a)
            {
                foreach (Alumno aux in j.Alumnos)
                {
                    if (aux == a)
                    {
                        return j;
                    }    
                }
                j.Alumnos.Add(a);
            }
            return j;
        }

        public static bool operator ==(Jornada j,Alumno a)
        {
            foreach(Alumno aux in j.Alumnos)
            {
                if (a == j.Clase)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(Jornada j,Alumno a)
        {
            return !(j == a);
        }

        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine("Jornada:");
            cadena.AppendLine($"Clase de: {Clase}");
            return cadena.ToString();
        }

    }
}
