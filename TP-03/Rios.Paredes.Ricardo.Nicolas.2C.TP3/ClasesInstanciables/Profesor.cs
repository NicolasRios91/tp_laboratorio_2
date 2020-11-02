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

        #region Atributos

        private Queue<Universidad.EClases> claseDeldia;
        private static Random random;
        #endregion


        #region Constructores
        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public Profesor()
        {
        }

        /// <summary>
        /// Constructor de clase que inicializa el atributo random
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Instancia un profesor
        /// </summary>
        /// <param name="id">Legajo del profesor</param>
        /// <param name="nombre">Nombre del profesor</param>
        /// <param name="apellido">Apellido del profesor</param>
        /// <param name="dni">Dni del profesor</param>
        /// <param name="nacionalidad">Nacionalidad del profesor</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseDeldia = new Queue<Universidad.EClases>();
            this._randomClases();

        }
        #endregion

        #region Metodos Y Sobrecargas

        /// <summary>
        /// Genera una clase aleatoria a partir del atributo random
        /// </summary>
        private void _randomClases()
        {
            for(int i =0; i<2;i++)
            {
                this.claseDeldia.Enqueue((Universidad.EClases)random.Next(0, 4));
                Thread.Sleep(250);
            }

        }
        
        /// <summary>
        /// Evalua si un profesor da una clase
        /// </summary>
        /// <param name="i">Profesor a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>true si la esta dando, caso contrario false</returns>
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

        /// <summary>
        /// Evalua si un profesor no da una clase
        /// </summary>
        /// <param name="i">Profesor a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>True si no da la clase, false si la esta dando</returns>
        public static bool operator !=(Profesor i,Universidad.EClases clase)
        {
            return !(i == clase);
        }

        /// <summary>
        /// Genera un StringBuilder con lo datos del profesor
        /// </summary>
        /// <returns>Cadena de caracteres con los datos del profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine(base.MostrarDatos());
            cadena.AppendLine(this.ParticiparEnClase());
            return cadena.ToString();
        }

        /// <summary>
        /// Genera un StringBuilder con las clases que da el profesor
        /// </summary>
        /// <returns>Cadena de caracteres con las clases que da el profesor</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine("Clases del dia: ");
            foreach (Universidad.EClases aux in this.claseDeldia)
            {
                cadena.AppendLine($"{aux}");
            }
            return cadena.ToString();
        }

        /// <summary>
        /// Muestra los datos del profesor
        /// </summary>
        /// <returns>Cadena de caracteres con todos sus datos</returns>
        public override string ToString()
        {
            return MostrarDatos();
        }

        #endregion
    }
}
