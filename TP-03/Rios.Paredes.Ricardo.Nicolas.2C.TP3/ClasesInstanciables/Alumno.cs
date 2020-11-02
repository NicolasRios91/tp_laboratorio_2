using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta { AlDia,Deudor,Becado};

        private Universidad.EClases claseQueToma; 
        private EEstadoCuenta estadoCuenta;

        //CONSTRUCTORES
        public Alumno()
        {
        }
        public Alumno(int id,string nombre,string apellido,string dni,ENacionalidad nacionalidad,Universidad.EClases claseQueToma)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma,EEstadoCuenta estadoCuenta)
            :this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        protected override string MostrarDatos()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine(base.MostrarDatos());
            cadena.Append("Estado de cuenta: ");
            if (this.estadoCuenta == EEstadoCuenta.AlDia)
            {
                cadena.AppendLine("Cuota al dia");
            }
            else
            {
                cadena.AppendLine($"{this.estadoCuenta}");
            }
            
            cadena.AppendLine(this.ParticiparEnClase());
            return cadena.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public static bool operator ==(Alumno a,Universidad.EClases clase)
        {
            if (a.estadoCuenta != EEstadoCuenta.Deudor && a.claseQueToma == clase)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a == clase);
        }

        protected override string ParticiparEnClase()
        {
            return $"Toma clase de: {this.claseQueToma}";
        }

    }
}
