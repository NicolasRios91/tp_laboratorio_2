using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesAbstractas;
using ClasesInstanciables;
using Excepciones;
using Interfaz;
using MetodoExtension;

namespace TestUnitarios
{
    [TestClass]
    public class Tests
    {
        /// <summary>
        /// Evalua que una venta aplique el descuento correspondiente, asi como verificar si se aplica el iva a la consola
        /// acorde a su color
        /// </summary>
        [TestMethod]
        public void VerificaSiAplicaDescentoAVentaMayorA1200()
        {
            //Se espera descuento del 10% en la venta
            //Se espera que se aplique el iva al precio de la consola, por ser de color rojo

            UtnStore u = new UtnStore();
            Consola c = new Consola("Nintendo switch", 10000, Producto.EPlataforma.NintendoSwitch, ConsoleColor.Red);
            Venta<Producto> v = new Venta<Producto>(c, 1);

            //igualo el auxiliar al precio sin iva de la consola, y luego le aplico el iva con el metodo de extension, porque
            float aplicaIva = c.Precio;
            aplicaIva = aplicaIva.AgregarIva(20);

            //igualo al precio de venta con iva PERO SIN DESCUENTOS, luego aplico el descuento del 10% porque supera el rango
            float precioVenta = v.PrecioTotalConIva;
            precioVenta = precioVenta.AplicarDescuento(10);

            
            Assert.IsTrue(v.PrecioFinal == precioVenta);
            Assert.IsTrue(c.PrecioConIva == aplicaIva);

        }

        /// <summary>
        /// Se verifica que al agregar un producto igual a la lista lance una excepcion
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ProductoRepetidoException))]
        public void VerificaSiHayUnProductoIgual()
        {
            UtnStore u = new UtnStore();
            Juego j1 = new Juego("fifa 2020", 500, Producto.EPlataforma.Ps4, Juego.EFormato.Fisico);
            Juego j2 = new Juego("fifa 2020", 500, Producto.EPlataforma.Ps4, Juego.EFormato.Fisico);

            u += j1;
            u += j2;
        }
    }
    

}
