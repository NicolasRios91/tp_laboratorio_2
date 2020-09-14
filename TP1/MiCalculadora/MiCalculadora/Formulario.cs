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

        private static double Operar(string valor1, string valor2,string operador)
        {
            Numero numero1 = new Numero(valor1);
            Numero numero2 = new Numero(valor2);
            return Calculadora.Operar(numero1,numero2,operador);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;
            resultado = Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text);
            this.lblResultado.Text = resultado.ToString();
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtNumero1.Text = string.Empty;
            this.txtNumero2.Text = string.Empty;
            this.lblResultado.Text = string.Empty;
            this.cmbOperador.Text = string.Empty;
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero objeto = new Numero();
            string binario = objeto.DecimalBinario(this.lblResultado.Text);
            this.lblResultado.Text = binario;
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero objeto = new Numero();
            string valorDecimal = objeto.BinarioDecimal(this.lblResultado.Text);
            this.lblResultado.Text = valorDecimal;
        }
    }
}
