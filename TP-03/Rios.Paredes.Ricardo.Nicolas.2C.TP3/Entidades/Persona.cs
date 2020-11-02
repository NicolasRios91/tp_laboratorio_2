using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Atributos y Enumerados
        /// <summary>
        /// Tipos de nacionalidades de la persona
        /// </summary>
        public enum ENacionalidad { Argentino,Extranjero }

        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion

        #region Propiedades

        /// <summary>
        /// Retorna o inicializa el valor del apellido
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Retorno o inicializa el valor del dni
        /// </summary>
        public int Dni
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(Nacionalidad, value.ToString());
            }
        }
        /// <summary>
        /// Retorno o inicializa el valor de la nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// Retorna o inicializa el valor del nombre
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = this.ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Iniciliza el valor del dni a partir de una cadena de caracteres
        /// </summary>
        public string StringToDni
        {
            set
            {
                this.dni = ValidarDni(Nacionalidad, value);
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public Persona()
        {
        }
        
        /// <summary>
        /// Instancia una Persona
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido,ENacionalidad nacionalidad)
        {
            Nombre = nombre;
            Apellido = apellido;
            Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Instancia una Persona
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="dni">Dni de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, int dni,ENacionalidad nacionalidad)
            :this(nombre,apellido,nacionalidad)
        {
            Dni = dni;
        }

        /// <summary>
        /// Instancia una Persona
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="dni">Dni de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :this(nombre,apellido,nacionalidad)
        {
            StringToDni = dni;
        }
        #endregion

        #region Metodos y Sobrecargas
        /// <summary>
        /// Muestra los datos de la Persona
        /// </summary>
        /// <returns>Una cadena de caracteres con los datos de la persona</returns>
        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine($"Nombre Completo: {Apellido}, {Nombre}");
            cadena.AppendLine($"Nacionalidad: {Nacionalidad}");
            return cadena.ToString();
        }

        /// <summary>
        /// Evalua si el dni y la nacionalidad son correctos
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad a comparar</param>
        /// <param name="dato">dni a comparar</param>
        /// <returns>El dni si este es valido, de lo contrario una Excepcion del tipo NacionalidadInvalidaException</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (nacionalidad == ENacionalidad.Argentino && dato >0 && dato <90000000)
            {
                return dato;
            }
            else if(nacionalidad == ENacionalidad.Extranjero && dato >89999999 && dato <=99999999)
            {
                return dato;
            }    
            else
            {
                    throw new NacionalidadInvalidaException();

            }
        }
        

        /// <summary>
        /// Evalua si el dni cumple con la cantidad y tipo de caracteres correctos, y con la nacionalidad
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad a comparar</param>
        /// <param name="dato">Dni a comparar</param>
        /// <returns>El dni si cumple con todas las validaciones, de lo contrario una Excepcion del tipo DniInvalidoException</returns>
        private int ValidarDni(ENacionalidad nacionalidad,string dato)
        {
            int aux;
            if (dato.Length < 9 && int.TryParse(dato,out aux))
            {
                return ValidarDni(nacionalidad, aux);
            }
            else
            {
                throw new DniInvalidoException("Dni Invalido");
            }
        }

        /// <summary>
        /// Evalua que el nombre o apellido tenga caracteres validos
        /// </summary>
        /// <param name="dato">Palabra a evaluar</param>
        /// <returns>El nombre o palabra si es valido, de lo contrario un valor vacio</returns>
        private string ValidarNombreApellido(string dato)
        {
            foreach(char c in dato)
            {
                if(char.IsLetter(c) || char.IsWhiteSpace(c))
                {
                    continue;
                }
                else
                {
                    return String.Empty;
                }
            }
            return dato;
        }
        #endregion
    }
}
