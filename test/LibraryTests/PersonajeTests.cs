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
        //test de cuando se cura el personaje por completo
        public void CurarseAlMaximo()
        {
            PersonajePrueba personaje= new PersonajePrueba("Aragorn", 10, 100);
            personaje.RecibirDaño(30);
            personaje.Curarse();
            Assert.That(personaje.VidaActual, Is.EqualTo(personaje.VidaMaxima));
        }
        [Test]
        //test de cuando recibe daño critico el personaje
        public void Recibirdaño()
        {
            PersonajePrueba personaje= new PersonajePrueba("Aragorn", 10, 100);
            personaje.Curarse();
            personaje.RecibirDaño(150);
            Assert.That(personaje.VidaActual, Is.EqualTo(0));
        }
        [Test]
        public void AgregarItem()
        {
            PersonajePrueba personaje= new PersonajePrueba("Aragorn", 10, 100);
            Item pechera= new Item("pechera", 0, 15, 100);
            personaje.AgregarItems(pechera);
            Assert.That(personaje.Items.Count, Is.EqualTo(1));
        }
        [Test]
        public void SacarItem()
        {
            PersonajePrueba personaje= new PersonajePrueba("Aragorn", 10, 100);
            Item espada= new Item("espada",50, 0, 30 );
            personaje.SacarItems(espada);
            Assert.That(personaje.Items.Count, Is.EqualTo(0));

        }
    }
}