using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public class Numero
    {
        //ATRIBUTOS
        private double numero;


        //PROPIEDAD
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        /// <summary>
        /// Valida que una cadena de caracteres sea un valor numerico
        /// </summary>
        /// <param name="strNumero">Cadena a evaluar</param>
        /// <returns>Un double con el valor interpretado de la cadena, caso contrario 0</returns>
        private double ValidarNumero(string strNumero)
        {
            if (double.TryParse(strNumero, out double valor))
            {
                return valor;
            }
            return 0;
        }

        //CONSTRUCTORES
        /// <summary>
        /// Asigna el valor 0 por default al atributo numero
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }
        /// <summary>
        /// Asigna un valor por parametro al atributo numero
        /// </summary>
        /// <param name="numero">Valor a asignar</param>
        public Numero(double numero)
        {

            this.numero = numero;
        }

        /// <summary>
        /// Convierte una cadena de caracteres a un valor numerico y la asigna al atributo numero
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero)
        {
            if (double.TryParse(strNumero,out double valor))
            {
                this.numero = valor;
            }
        }

        //SOBRECARGAS

        /// <summary>
        /// Sobrecarga del operador +
        /// </summary>
        /// <param name="num1">Primer objeto operando</param>
        /// <param name="num2">Segundo objeto operando</param>
        /// <returns>La suma entre los atributos numero de ambos objetos</returns>
        public static double operator +(Numero num1, Numero num2)
        {
            return num1.numero + num2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador -
        /// </summary>
        /// <param name="num1">Primer objeto operando</param>
        /// <param name="num2">Segungo objeto operando</param>
        /// <returns>La resta entre los atributos numero de ambos objetos</returns>
        public static double operator -(Numero num1, Numero num2)
        {
            return num1.numero - num2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador *
        /// </summary>
        /// <param name="num1">Primer objeto operando</param>
        /// <param name="num2">Segundo objeto operando</param>
        /// <returns>La multiplicacion entre los atributos numero de ambos objetos</returns>
        public static double operator *(Numero num1, Numero num2)
        {
            return num1.numero * num2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador /
        /// </summary>
        /// <param name="num1">Primer objeto operando</param>
        /// <param name="num2">Segundo objeto operando</param>
        /// <returns>La division entre los atributos numero de ambos objetos, o el valor minimo si el segundo
        /// es igual a 0</returns>
        public static double operator /(Numero num1, Numero num2)
        {
            if (num2.numero == 0)
            {
                return double.MinValue;
            }
            return num1.numero / num2.numero;
        }


        //METODOS

        /// <summary>
        /// Verifica que una cadena este compuesto por 0 o 1 (binaria)
        /// </summary>
        /// <param name="binario">Cadena a validar</param>
        /// <returns>true si la cadena es binaria, caso contrario false</returns>
        private static bool EsBinario(string binario)
        {
            foreach (char p in binario)
            {
                if (p != '0' && p != '1')
                {
                    return false;

                }
            }
            return true;
        }

        /// <summary>
        /// Convierte una cadena a decimal en formato string
        /// </summary>
        /// <param name="binario">Cadena a convertir</param>
        /// <returns>El numero decimal convertido o un mensaje de error</returns>
        public static string BinarioDecimal(string binario)
        {
            if (EsBinario(binario) && binario != "")
            {
                int resultado = 0;//si no asigno el return resultado me da error
                for (int i = 0; i < binario.Length; i++)
                {
                    if (binario[i] == '1')
                    {
                        resultado += (int)Math.Pow(2, binario.Length - 1 - i);//casteo porque math.pow devuelve double
                    }
                }
                return resultado.ToString();
            }
            return "Valor Invalido";
        }

        /// <summary>
        /// Convierte un double a binario
        /// </summary>
        /// <param name="numero">Valor a convertir</param>
        /// <returns>El binario si es que se pudo convertir, 0 si el valor por parametro es 0,
        /// o un mensaje de error</returns>
        public static string DecimalBinario(double numero)
        {
            string valorBinario = "";
            int numeroSinDecimales = (int)numero;
            if (numeroSinDecimales == 0)
            {
                valorBinario = "0";
                return valorBinario ;
            }
            else
            {
                if (numero < 0)
                {
                    return "Valor Invalido";
                }
                else
                {
                    do
                    {
                        int resto = numeroSinDecimales % 2;//resto de la division
                        valorBinario = resto.ToString() + valorBinario;//primero el ultimo resto,sino queda al reves
                        numeroSinDecimales = numeroSinDecimales / 2;//nuevo valor a dividir
                    } while (numeroSinDecimales > 0);
                }

                return valorBinario;
            }
        }
        /// <summary>
        /// Convierte una cadena a binario
        /// </summary>
        /// <param name="numero">Cadena a convertir</param>
        /// <returns>El binario si es que se pudo convertir, 0 si el valor por parametro es 0,
        /// o un mensaje de error</returns>
        public static string DecimalBinario(string numero)
            {
                if (double.TryParse(numero, out double valor))
                {
                    return (DecimalBinario(valor));
                }
                return "Valor Invalido";
            }
        }
    }

