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
        [Test]
        public void CambiarUpgradearPropiedades()
        {
            // 1. ARRANGE: Se crea un objeto base
            Item item = new Item("Anillo Básico", 0, 0, 10);
            // 2. ACT: Modificamos sus propiedades a través de los { get; set; }
            item.Nombre = "Anillo Mejorado";
            item.Ataque = 3;
            item.Defensa = 3;
            item.Durabilidad = 15;
            // 3. ASSERT: Verificamos que los cambios hayan quedado guardados
            Assert.That(item.Nombre, Is.EqualTo("Anillo Mejorado"));
            Assert.That(item.Ataque, Is.EqualTo(3));
            Assert.That(item.Defensa, Is.EqualTo(3));
            Assert.That(item.Durabilidad, Is.EqualTo(15));
        }
    }
}