using NUnit.Framework;

namespace Ucu.Poo.RolePlayGame.Tests
{
    [TestFixture]
    public class ItemTests
    {
        [Test]
        public void ValoresYPropiedadesCorrectas()
        {
            // 1. ARRANGE
            string nombreEsperado = "Amuleto de Fuerza";
            int ataqueEsperado = 10;
            int defensaEsperada = 5;
            int durabilidadEsperada = 20;
            // 2. ACT
            Item item = new Item(nombreEsperado, ataqueEsperado, defensaEsperada, durabilidadEsperada);
            // 3. ASSERT
            Assert.That(item.Nombre, Is.EqualTo(nombreEsperado));
            Assert.That(item.Ataque, Is.EqualTo(ataqueEsperado));
            Assert.That(item.Defensa, Is.EqualTo(defensaEsperada));
            Assert.That(item.Durabilidad, Is.EqualTo(durabilidadEsperada));
        }
    }
}