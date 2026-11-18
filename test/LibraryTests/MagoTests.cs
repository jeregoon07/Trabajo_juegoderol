using System;
using NUnit.Framework;

namespace Ucu.Poo.RolePlayGame.Tests
{
    [TestFixture]
    public class MagoTests
    {
        [Test]
        public void AprenderHechizoConLibro()
        {
            Mago mago = new Mago("Gandalf",30,20,40);
            LibroDeHechizos libro = new LibroDeHechizos("Grimorio Ancient", 100);
            mago.AgregarItems(libro);

            Hechizo bolaDeFuego = new Hechizo("Bola de Fuego", 40);
            mago.AprenderHechizo(bolaDeFuego);

            Assert.That(libro.Hechizos.Contains(bolaDeFuego), Is.True);
            Assert.That(libro.Ataque, Is.EqualTo(40));
        }

        [Test]
        public void AprenderHechizoSinLibroLanzaExcepcion()
        {
            Mago mago = new Mago("Gandalf",30,20,40);
            Hechizo bolaDeFuego = new Hechizo("Bola de Fuego", 40);

            Assert.Throws<InvalidOperationException>(() => mago.AprenderHechizo(bolaDeFuego));
        }

        [Test]
        public void AtacarConMagiaSinBaston()
        {
            Mago mago = new Mago("Gandalf",30,20,40);
            PersonajePrueba objetivo = new PersonajePrueba("Orco", 10, 100,0);
            Hechizo bolaDeFuego = new Hechizo("Bola de Fuego", 40);

            mago.AtacarConMagia(objetivo, bolaDeFuego);

            Assert.That(objetivo.VidaActual, Is.EqualTo(60));
        }

        [Test]
        public void AtacarConMagiaConBaston()
        {
            Mago mago = new Mago("Gandalf",30,20,40);
            BastonMagico baston = new BastonMagico("Bastón Ancestral", 100, 20m, 10m);
            mago.AgregarItems(baston);

            PersonajePrueba objetivo = new PersonajePrueba("Orco", 10, 100,0);
            Hechizo bolaDeFuego = new Hechizo("Bola de Fuego", 40);

            mago.AtacarConMagia(objetivo, bolaDeFuego);

            Assert.That(objetivo.VidaActual, Is.EqualTo(40));
        }
    }
}