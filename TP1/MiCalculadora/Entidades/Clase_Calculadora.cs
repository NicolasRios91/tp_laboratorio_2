using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
        public static class Calculadora
        {
            /// <summary>
            /// Valida si el parametro es un operador
            /// </summary>
            /// <param name="operador">El operador usado en la calculadora</param>
            /// <returns>El valor del operador, o '+' en caso de ser uno invalido</returns>
            private static string ValidarOperador(char operador)
            {
                if (operador != '+' && operador != '-' && operador != '/' && operador != '*')
                {
                    return char.ToString('+');
                }
                return char.ToString(operador);
            }

        /// <summary>
        /// Realiza la operacion de la calculadora
        /// </summary>
        /// <param name="num1">Primer operando</param>
        /// <param name="num2">Segundo operando</param>
        /// <param name="operador">Operador para la ecuacion</param>
        /// <returns>El resultado de la operacion</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;//si no le asigno valor me tira error en el ultimo return;
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
}

