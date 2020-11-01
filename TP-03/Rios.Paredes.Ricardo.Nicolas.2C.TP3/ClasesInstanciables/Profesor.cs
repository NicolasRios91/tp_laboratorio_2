using EntidadesAbstractas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> claseDeldia;
        private static Random random;

        public Profesor()
        {
        }
        static Profesor()
        {
            random = new Random();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseDeldia = new Queue<Universidad.EClases>();
            _randomClases();
            Thread.Sleep(200);
            _randomClases();

        }

        private void _randomClases()
        {
            
            //creo un array con todos los valores de EClases
            Array valores = Enum.GetValues(typeof(Universidad.EClases));

            int numero = random.Next(0, valores.Length) - 1;
            //variable auxiliar para asignar el valor de la posicion random
            Universidad.EClases aux = (Universidad.EClases)valores.GetValue(numero);
            this.claseDeldia.Enqueue(aux);
        }
        
        public static bool operator ==(Profesor i,Universidad.EClases clase)
        {
            foreach(Universidad.EClases aux in i.claseDeldia)
            {
                if (aux == clase)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(Profesor i,Universidad.EClases clase)
        {
            return !(i == clase);
        }

        protected override string MostrarDatos()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine(base.MostrarDatos());
            cadena.AppendLine(ParticiparEnClase());
            return cadena.ToString();
        }
        protected override string ParticiparEnClase()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine("Clases del dia: ");
            foreach (Universidad.EClases aux in this.claseDeldia)
            {
                cadena.Append($"{aux} ||");
            }
            return cadena.ToString();
        }

        public override string ToString()
        {
            return MostrarDatos();
        }


    }
}
