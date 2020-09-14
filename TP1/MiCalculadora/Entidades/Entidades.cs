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
    public static class Calculadora
    {
        private static string ValidarOperador(char operador)
        {
            if (operador != '+' && operador != '-' && operador != '/' && operador != '*')
            {
                return char.ToString('+');
            }
            return char.ToString(operador);
        }
        

        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;//sino le asigno valor me tira error en el ultimo return;
            char.TryParse(operador, out char a);
            string b = ValidarOperador(a);
            switch (b)
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
            }
            return resultado;
        }
    }

    public class Numero
    {
        private double numero;

        private double ValidarNumero(string strNumero)
        {
            if (double.TryParse(strNumero, out double valor))
            {
                return valor;
            }
            return 0;
        }

        //CONSTRUCTORES
        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            double.TryParse(strNumero,out this.numero);
        }

        //SOBRECARGAS
        /// <summary>
        /// 
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static double operator +(Numero num1, Numero num2)
        {
            return num1.numero + num2.numero;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static double operator -(Numero num1, Numero num2)
        {
            return num1.numero - num2.numero;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static double operator *(Numero num1, Numero num2)
        {
            return num1.numero * num2.numero;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static double operator /(Numero num1, Numero num2)
        {
            if (num1.numero == 0)
            {
                return double.MinValue;
            }
            return num1.numero / num2.numero;
        }

        //PROPIEDAD
        /// <summary>
        /// 
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);//
            }
        }

        //METODOS

        /// <summary>
        /// 
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        private bool EsBinario(string binario)
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
        /// 
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        public string BinarioDecimal(string binario)
        {
            if (EsBinario(binario) && binario != "")
            {
                int resultado=0;//si no asigno el return resultado me da error
                for (int i=0;i <binario.Length;i++)
                {
                    if (binario[i] == '1')
                    {
                    resultado += (int)Math.Pow(2, binario.Length-1-i);//casteo porque math.pow devuelve double
                    }
                }
                return resultado.ToString();
            }
            return "Valor Invalido";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public string DecimalBinario(double numero)
        {
            string valorBinario ="";
            int numeroSinDecimales = (int)numero;
            do
            {
                int resto = numeroSinDecimales % 2;//resto de la division
                valorBinario = resto.ToString() + valorBinario;//primero el ultimo resto,sino queda al reves
                numeroSinDecimales = numeroSinDecimales / 2;//nuevo valor a dividir
            } while (numeroSinDecimales > 0);

            return valorBinario;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public string DecimalBinario(string numero)
        {
            if(int.TryParse(numero, out int valor))
            {
                return (DecimalBinario(valor));
            }
            return "Valor Invalido";
        }












    }
}
