using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad { Argentino,Extranjero }

        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;


        //PROPIEDADES

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = value;//validar
            }
        }

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

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;//validar
            }
        }

        public string StringToDni
        {
            set
            {
                this.dni = ValidarDni(Nacionalidad, value);
            }
        }

        public Persona()
        {
        }
        
        public Persona(string nombre, string apellido,ENacionalidad nacionalidad)
        {
            Nombre = nombre;
            Apellido = apellido;
            this.nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni,ENacionalidad nacionalidad)
            :this(nombre,apellido,nacionalidad)
        {
            Dni = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :this(nombre,apellido,nacionalidad)
        {
            StringToDni = dni;
        }

        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine($"Nombre: {Nombre}");
            cadena.AppendLine($"Apellido: {Apellido}");
            cadena.AppendLine($"Dni: {Dni}");
            cadena.AppendLine($"Nacionalidad: {Nacionalidad}");
            return cadena.ToString();
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (dato < 99999999 && dato >899999999 && nacionalidad == ENacionalidad.Extranjero)
            {
                return dato;
            }
            else if (dato >0 && dato < 900000000 && nacionalidad == ENacionalidad.Argentino)
            {
                return dato;
            }
            else
            {
                throw new Exception("Nacionalidad Invalida");
            }            
        }
        private int ValidarDni(ENacionalidad nacionalidad,string dato)
        {
            int aux;
            if (dato.Length < 10 && int.TryParse(dato,out aux))
            {
                return ValidarDni(nacionalidad, aux);
            }
            else
            {
                throw new Exception("Dni Invalido");
            }
        }
        private string ValidarNombreApellido(string dato)
        {
            return dato;
        }
    }
}
