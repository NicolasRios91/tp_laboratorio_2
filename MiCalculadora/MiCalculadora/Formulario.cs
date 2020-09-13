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
            resultado = Operar(this.txtNumero1.ToString(), this.txtNumero2.ToString(), this.cmbOperador.ToString());
            this.lblResultado.Text = resultado.ToString();
            
        }
    }
}
