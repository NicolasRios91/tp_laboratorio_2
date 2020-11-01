using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        public Universitario()
        {
        }
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        protected virtual string MostrarDatos()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine($"Legajo: {this.legajo}");
            cadena.AppendLine(base.ToString());
            return cadena.ToString();
        }

        protected abstract string ParticiparEnClase();

        public override bool Equals(object obj)
        {
            if (obj is Universitario)
            {
                return true;
            }
            return false;
        }

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if (pg1.Equals(pg2) && pg1.Dni == pg2.Dni || pg1.legajo == pg2.legajo)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Universitario u1, Universitario u2)
        {
            return !(u1 == u2);
        }
    }
}
