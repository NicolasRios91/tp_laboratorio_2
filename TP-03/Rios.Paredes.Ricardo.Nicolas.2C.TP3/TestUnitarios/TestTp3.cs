using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;
using Excepciones;

namespace TestUnitarios
{
    [TestClass]
    public class TestTp3
    {
        /// <summary>
        /// Metodo que testea que al cargar un dni con caracteres invalidos lance la excepcion correcta
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void ValidarDni()
        {
            Alumno a1 = new Alumno(12, "Dante", "Alvarez", "95awd156", EntidadesAbstractas.Persona.ENacionalidad.Argentino,Universidad.EClases.Laboratorio);
           
        }

        /// <summary>
        /// Metodo que testea que al cargar un dni no compatible con la nacionalidad lance la excepcion correcta
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void ValidarNacionalidad()
        {
            Alumno a1 = new Alumno(12, "Dante", "Alvarez", "95687840", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
        }

        /// <summary>
        /// Metodo que testea que al cargar un alumno repetido se lance la excepcion correcta
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void AlumnoRepetido()
        {
            Universidad universidad = new Universidad();
            Alumno a1 = new Alumno(12, "Dante", "Alvarez", "44455568",
                EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Becado);
            Alumno a2 = new Alumno(12, "Dante", "Alvarez", "44455568",
                EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Becado);
            universidad += a1;
            universidad += a2;

        }

        /// <summary>
        /// Metodo que testea que al inicializar una Jornada, su lista de Alumnos no sea null
        /// </summary>
        [TestMethod]
        public void ValidarListaAlumnosEnJornada()
        {
            Profesor p = new Profesor();
            Jornada j = new Jornada(Universidad.EClases.Laboratorio, p);
            Assert.IsNotNull(j.Alumnos);
        }

    }
}
