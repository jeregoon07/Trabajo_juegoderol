using NUnit.Framework;

namespace Ucu.Poo.RolePlayGame.Tests
{
    public class RopaTests
    {
        private Ropa pechera;
        [SetUp]
        public void Setup()
        {
            // Para "llamar" a los objetos
            pechera = new Ropa("Pechera de cuero", defensa: 5, durabilidad: 10);
        }
        [Test]
        public void VerificarDefensaYDurabilidad()
        {
            // Act (Usamos la 'pechera' que ya creó el Setup)
            int dañoRestante = pechera.AbsorberDaño(12);
            // Assert
            Assert.That(dañoRestante, Is.EqualTo(7));
            Assert.That(pechera.Durabilidad, Is.EqualTo(9));
        }
        [Test]
        public void VerificarConPecheraRota()
        {
            // Arrange local (Sobrescribimos o creamos una ropa rota para esta prueba)
            Ropa pecheraRota = new Ropa("Pechera Rota", defensa: 5, durabilidad: 0);
            // Act
            int dañoRestante = pecheraRota.AbsorberDaño(12);
            // Assert
            Assert.That(dañoRestante, Is.EqualTo(12));
            Assert.That(pecheraRota.Durabilidad, Is.EqualTo(0));
        }
    }
}