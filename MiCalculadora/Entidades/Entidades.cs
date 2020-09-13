using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    static class Calculadora
    {
        private static string ValidarOperador(char operador)
        {
            if (operador != '+' && operador != '-' && operador != '/' && operador != '*')
            {
                return char.ToString('+');
            }
            return char.ToString(operador);
        }

        public static double Operar(double num1, double num2, string operador)
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
                    if (num2 ==0)
                    {
                        resultado = double.MinValue;
                    }
                    else
                    {
                    resultado = num1 / num2;
                    }
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
            this.numero = float.Parse(strNumero);
        }

        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);//
            }
        }

        private bool EsBinario(string binario)
        {
            if(object.Equals(binario, "0") || object.Equals(binario,"1"))
            {
                return true;
            }
            return false;
        }

        public string BinarioDecimal(string binario)
        {
            int resultado = 0;//si no asigno el return resultado me da error
            if (EsBinario(binario))
            {
                for (int i=0;i <binario.Length;i++)
                {
                    if (binario[i] == '1')
                    {
                    resultado += (int)Math.Pow(2, binario.Length - i);//casteo porque math.pow devuelve double
                    }
                }
                return resultado.ToString();
            }
            return "Valor Invalido";
        }

        public string DecimalBinario(double numero)
        {
            string valorBinario="";
            
            while (numero /2 > 0)
            {
                int resto = (int)numero % 2;
                valorBinario = resto.ToString() + valorBinario;
            }
            return valorBinario;

        }

        public string DecimalBinario(string numero)
        {
            int valor;
            if(int.TryParse(numero, out valor))
            {
                return (DecimalBinario(valor));
            }
            return "Valor invalido";
        }












    }
}
