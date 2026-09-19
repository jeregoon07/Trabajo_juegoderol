using NUnit.Framework;
using Ucu.Poo.RolePlayGame;
namespace Ucu.Poo.RolePlayGame.Tests
{
    public class PersonajePrueba: Personaje
    {
        public PersonajePrueba(string nombre, int defensa, int vidaMaxima) 
        : base(nombre, defensa, vidaMaxima){}
    }
    [TestFixture]
    public class PersonajeTest
    {
        [Test]
        public void CurarseAlMaximo()
        {
            PersonajePrueba personaje= new PersonajePrueba("Aragorn", 10, 100);
            personaje.RecibirDaño(30);
            personaje.Curarse();
            Assert.That(personaje.VidaActual, Is.EqualTo(personaje.VidaMaxima));
        }
        [Test]
        public void Recibir_daño()
        {
            PersonajePrueba personaje= new PersonajePrueba("Aragorn", 10, 100);
            personaje.Curarse();
            personaje.RecibirDaño(150);
            Assert.That(personaje.VidaActual, Is.EqualTo(0));
        }
    }
}