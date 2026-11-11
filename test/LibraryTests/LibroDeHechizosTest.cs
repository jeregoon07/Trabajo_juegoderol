using NUnit.Framework;
using Ucu.Poo.RolePlayGame;

namespace Ucu.Poo.RolePlayGame.Tests
{
    [TestFixture]
    public class LibroDeHechizosTests
    {
        [Test]
        public void Constructor_InicializaValoresCorrectamente()
        {
            LibroDeHechizos libro = new LibroDeHechizos("Grimorio Antiguo", 100);

            Assert.That(libro.Nombre, Is.EqualTo("Grimorio Antiguo"));
            Assert.That(libro.Durabilidad, Is.EqualTo(100));
            Assert.That(libro.Hechizos, Is.Not.Null);
            Assert.That(libro.Hechizos.Count, Is.EqualTo(0));
            Assert.That(libro.Ataque, Is.EqualTo(0));
            Assert.That(libro.Defensa, Is.EqualTo(0));
        }

        [Test]
        public void AgregarHechizo_AñadeElHechizoALaLista()
        {
            LibroDeHechizos libro = new LibroDeHechizos("Grimorio", 50);
            Hechizo fuego = new Hechizo("Bola de Fuego", 40);

            libro.AgregarHechizo(fuego);

            Assert.That(libro.Hechizos.Count, Is.EqualTo(1));
            Assert.That(libro.Hechizos, Does.Contain(fuego));
        }

        [Test]
        public void AgregarHechizo_ActualizaElPoderDeAtaqueDelLibro()
        {
            LibroDeHechizos libro = new LibroDeHechizos("Grimorio", 50);
            Hechizo fuego = new Hechizo("Bola de Fuego", 40);
            Hechizo rayo = new Hechizo("Rayo", 35);

            libro.AgregarHechizo(fuego);
            libro.AgregarHechizo(rayo);

            Assert.That(libro.Ataque, Is.EqualTo(75));
        }

        [Test]
        public void AgregarHechizo_SiEsNull_NoHaceNada()
        {
            LibroDeHechizos libro = new LibroDeHechizos("Grimorio", 50);

            libro.AgregarHechizo(null);

            Assert.That(libro.Hechizos.Count, Is.EqualTo(0));
            Assert.That(libro.Ataque, Is.EqualTo(0));
        }
    }
}