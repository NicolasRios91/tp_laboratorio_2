using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;
using ClasesInstanciables;
using Excepciones;
using Archivos;

namespace MainConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            UtnStore u = new UtnStore();
            
            
            Juego j1 = new Juego("God of War", 400, Producto.EPlataforma.Ps4, Juego.EFormato.Digital);
            Juego j2 = new Juego("God of War", 400, Producto.EPlataforma.Ps4, Juego.EFormato.Digital);
            Juego j3 = new Juego("Fifa 1990", 100,  Producto.EPlataforma.Xbox, Juego.EFormato.Fisico);
            Juego j4 = new Juego("Pokemon Azul", 100, Producto.EPlataforma.NintendoSwitch, Juego.EFormato.Fisico);

            Consola c1 = new Consola("Play station 4 500gb", 10000, Producto.EPlataforma.Ps4, ConsoleColor.White);
            Consola c2 = new Consola("Nintendo Switch", 12000, Producto.EPlataforma.NintendoSwitch, ConsoleColor.Black);
            
            //AGREGO PRODUCTOS
            try
            {
                u += j1;
            }
            catch (ProductoRepetidoException e)
            {

                Console.WriteLine(e.Message);
            }
            try
            {
                //se espera Excepcion
                u += j2;
            }
            catch (ProductoRepetidoException e)
            {

                Console.WriteLine(e.Message);
            }

            try
            {
                u += j3;
            }
            catch (ProductoRepetidoException e)
            {

                Console.WriteLine(e.Message);
            }
            try
            {
                u += c1;
            }
            catch (ProductoRepetidoException e)
            {

                Console.WriteLine(e.Message);
            }
            try
            {
                u += c2;
            }
            catch (ProductoRepetidoException e)
            {

                Console.WriteLine(e.Message);
            }

            Venta<Producto> v1 = new Venta<Producto>(j1, 2);
            Venta<Producto> v2 = new Venta<Producto>(j3, 2);
            Venta<Producto> v3 = new Venta<Producto>(j4, 5);
            Venta<Producto> v4 = new Venta<Producto>(c2, 2);
            Venta<Producto> v5 = new Venta<Producto>(c2, 11);

            //AGREGO VENTAS
            try
            {
                u += v1;
            }
            catch (CantidadLimiteException e)
            {

                Console.WriteLine(e.Message);
            }
            try
            {
                u += v2;
            }
            catch (CantidadLimiteException e)
            {

                Console.WriteLine(e.Message);
            }
            try
            {
                //Se espera excpcion, el producto nunca se agrego a la lista
                u += v3;
            }
            catch (CantidadLimiteException e)
            {

                Console.WriteLine(e.Message);
            }
            try
            {
                u += v4;
            }
            catch (CantidadLimiteException e)
            {

                Console.WriteLine(e.Message);
            }

            try
            {
                //Se espera excepcion por exceso de cantidad
                u += v5;
            }
            catch (CantidadLimiteException e)
            {

                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Precione una tecla para seguir");
            Console.ReadKey();
            Console.Clear();

            //u = UtnStore.Leer();

            //Instancio una VentasDao para guardar archivos en la base de datos
            VentasDAO sql = new VentasDAO();
            
            foreach(Venta<Producto> p in u.Ventas)
            {
                try
                {
                    sql.InsertarVenta(p);
                }
                catch(ArchivosException e)
                {

                    Console.WriteLine(e.Message);
                }
                
            }
            
            //intento obtener los datos de una venta por id
            try
            {
                string cadena = sql.ObtenerVentaPorId(23);
            }
            catch (ArchivosException e)
            {

                Console.WriteLine(e.Message);
            }
            
            
            Console.WriteLine(u.MostrarProductos());
            Console.WriteLine("Precione una tecla para seguir");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine(u.MostrarVentas());
            Console.WriteLine("Precione una tecla para seguir");
            Console.ReadKey();
            Console.Clear();

            UtnStore.GuardarXml(u);
            Console.WriteLine("Se guardo el archivo xml");
            UtnStore.GuardarTxt(u);
            Console.WriteLine("Se guardo el archivo de texto");
            Console.ReadKey();
        }
    }
}
