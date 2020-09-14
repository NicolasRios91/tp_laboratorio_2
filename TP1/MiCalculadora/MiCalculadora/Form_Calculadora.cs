using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Realizala operacion correspondiente entre 2 objetos
        /// </summary>
        /// <param name="numero1">Valor del primer operando</param>
        /// <param name="numero2">Valor del segundo oprando</param>
        /// <param name="operador">Operacion a realizar</param>
        /// <returns>El resultado de la operacion</returns>
        private static double Operar(string numero1, string numero2,string operador)
        {
            Numero valor1 = new Numero(numero1);
            Numero valor2 = new Numero(numero2);
            return Calculadora.Operar(valor1,valor2,operador);
        }

        /// <summary>
        /// Limpia todos los valores de la calculadora
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.lblResultado.Text = "";
            this.cmbOperador.Text = "";
            btnConvertirABinario.Enabled = true;
            btnConvertirADecimal.Enabled = true;
        }

        /// <summary>
        /// Cierra la aplicacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Realiza la operacion y muestra el resultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;
            resultado = Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text);
            this.lblResultado.Text = resultado.ToString();
            btnConvertirADecimal.Enabled = false;//deshabilito para pasar a decimal, no tiene sentido que este activo
            btnConvertirABinario.Enabled = true;
            
        }

        /// <summary>
        /// Llama a la funcion Limpiar de la calculadora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Convierte el resultado a binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        { 
            string binario = Numero.DecimalBinario(this.lblResultado.Text);
            this.lblResultado.Text = binario;
            btnConvertirADecimal.Enabled = true;
            btnConvertirABinario.Enabled = false; //deshabilito porque sino me toma al resultado
                                                  //binario como decimal, y lo vuelve a pasar a binario
                                                  
        }

        /// <summary>
        /// Convierte el resultado binario a decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            
            string valorDecimal = Numero.BinarioDecimal(this.lblResultado.Text);
            this.lblResultado.Text = valorDecimal;
            btnConvertirADecimal.Enabled = false;
            btnConvertirABinario.Enabled = true;
        }
    }
}
