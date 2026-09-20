using NUnit.Framework;

namespace Ucu.Poo.RolePlayGame.Tests
{
    [TestFixture]
    public class MagoTests
    {
        [Test]
        public void AprenderHechizoConLibro()
        {
            Mago mago = new Mago("Gandalf");
            LibroDeHechizos libro = new LibroDeHechizos("Grimorio Ancient", 100);
            mago.Items.Add(libro);

            Hechizo bolaDeFuego = new Hechizo("Bola de Fuego", 40);
            mago.AprenderHechizo(bolaDeFuego);

            Assert.That(libro.Hechizos.Contains(bolaDeFuego), Is.True);
            Assert.That(libro.Ataque, Is.EqualTo(40));
        }

        [Test]
        public void AprenderHechizoSinLibroNoFalla()
        {
            Mago mago = new Mago("Gandalf");
            Hechizo bolaDeFuego = new Hechizo("Bola de Fuego", 40);

            Assert.DoesNotThrow(() => mago.AprenderHechizo(bolaDeFuego));
        }

        [Test]
        public void AtacarConMagiaSinBaston()
        {
            Mago mago = new Mago("Gandalf");
            PersonajePrueba objetivo = new PersonajePrueba("Orco", 10, 100);
            Hechizo bolaDeFuego = new Hechizo("Bola de Fuego", 40);

            mago.AtacarConMagia(objetivo, bolaDeFuego);

            Assert.That(objetivo.VidaActual, Is.EqualTo(60));
        }

        [Test]
        public void AtacarConMagiaConBaston()
        {
            Mago mago = new Mago("Gandalf");
            BastonMagico baston = new BastonMagico("Bastón Ancestral", 100, 20m, 10m);
            mago.Items.Add(baston);

            PersonajePrueba objetivo = new PersonajePrueba("Orco", 10, 100);
            Hechizo bolaDeFuego = new Hechizo("Bola de Fuego", 40);

            mago.AtacarConMagia(objetivo, bolaDeFuego);

            Assert.That(objetivo.VidaActual, Is.EqualTo(40));
        }
    }
}