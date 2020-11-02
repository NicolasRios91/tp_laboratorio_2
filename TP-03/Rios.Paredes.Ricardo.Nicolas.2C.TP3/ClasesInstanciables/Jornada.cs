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
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        private Jornada()
        {

            this.alumnos = new List<Alumno>();
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
                return this.alumnos;
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
            if (j!=a)
            {
                j.Alumnos.Add(a);
            }
            return j;
        }

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
        public static bool operator !=(Jornada j,Alumno a)
        {
            return !(j == a);
        }

        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine($"Clase de: {this.Clase}");
            cadena.Append($"Por {this.Instructor}");
            cadena.AppendLine("Alumnos");
            foreach(Alumno a in this.Alumnos)
            {
                cadena.AppendLine(a.ToString());
            }
            return cadena.ToString();
        }

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

    }
}
