using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClasesAbstractas;
using Excepciones;
using ClasesInstanciables;
using System.Threading;

namespace FormUtnStore
{
    public partial class Formulario : Form
    {
        private UtnStore u;
        private Thread hilo;

        /// <summary>
        /// Constructor por defecto, se suscribe el metodo correspondiente al evento
        /// </summary>
        public Formulario()
        {
            this.u = UtnStore.Leer();
            u.seVendio += ManejadorEvento;
            InitializeComponent();
            this.cmbPlataforma.DataSource = Enum.GetValues(typeof(Producto.EPlataforma));
            this.cmbFormato.DataSource = Enum.GetValues(typeof(Juego.EFormato));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Maneja el evento para que se pueda modificar un atributo del form desde otro hilo
        /// </summary>
        /// <param name="datos">Datos a agregar al campo del form richTextBox</param>
        private void ManejadorEvento(string datos)
        {

            if(rchTextBox.InvokeRequired)
            {
                VentaRandom callback = new VentaRandom(ManejadorEvento);
                object[] objs = new object[] { datos };
                this.Invoke(callback, objs);
            
            }
            else
            {
                this.rchTextBox.AppendText(datos);
            }    
        }

        /// <summary>
        /// Inicia un thread con metodo que invoca el evento y se inicia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.btnVender.Text = "Limpiar y volver a vender";
            this.rchTextBox.Clear();
            hilo = new Thread(u.Vender);
            hilo.Start();
        }


        /// <summary>
        /// Agrega un juego a la lista de productos, si no puedo lanza una excepcion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Juego.EPlataforma plataforma = (Juego.EPlataforma)this.cmbPlataforma.SelectedValue;
                Juego.EFormato formato = (Juego.EFormato)this.cmbFormato.SelectedValue;
                float precio = float.Parse(txtPrecio.Text);
                Juego j = new Juego(txtDescripcion.Text, precio, plataforma, formato);
                u += j;
                MessageBox.Show("El producto se agrego!");
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error");
            }

        }

        /// <summary>
        /// Cierra el hilo si esta activo y guarda los datos de la Tienda, de no poder hacerlo lanza una excepcion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Formulario_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.hilo !=null && this.hilo.IsAlive)
            {
                hilo.Abort();
            }
            try
            {
                UtnStore.GuardarXml(u);
                UtnStore.GuardarTxt(u);
                MessageBox.Show("Se guardaron los archivos txt y xml");
            }
            catch (ArchivosException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
