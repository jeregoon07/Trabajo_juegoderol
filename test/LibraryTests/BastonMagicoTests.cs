using NUnit.Framework;

namespace Ucu.Poo.RolePlayGame.Tests
{
    [TestFixture]
    public class BastonMagicoTests
    {
        [Test]
        // Prueba que el constructor asigne correctamente las propiedades propias y heredadas de Item
        public void PropiedadesOK()
        {
            // 1. ARRANGE
            string nombreEsperado = "Báculo Ancestral";
            int durabilidadEsperada = 15;
            decimal buffDañoEsperado = 0.20m; // 20%
            decimal buffVidaEsperado = 0.10m; // 10%
            // 2. ACT 
            BastonMagico baston = new BastonMagico(nombreEsperado, durabilidadEsperada, buffDañoEsperado, buffVidaEsperado);
            // 3. ASSERT (Comprobamos las propiedades específicas del bastón)
            Assert.That(baston.Nombre, Is.EqualTo(nombreEsperado));
            Assert.That(baston.Durabilidad, Is.EqualTo(durabilidadEsperada));
            Assert.That(baston.BuffeoDaño, Is.EqualTo(buffDañoEsperado));
            Assert.That(baston.BuffeoVida, Is.EqualTo(buffVidaEsperado));
            // Comprobamos que base(nombre, 0, 0, durabilidad) haya fijado ataque y defensa en 0
            Assert.That(baston.Ataque, Is.EqualTo(0));
            Assert.That(baston.Defensa, Is.EqualTo(0));
        }
        [Test]
        // Prueba que acepte valores en 0 sin errores
        public void BuffeoEnCero()
        {
            // 1. ARRANGE y 2. ACT
            BastonMagico bastonSinMagia = new BastonMagico("Bastón de Madera", 10, 0m, 0m);
            // 3. ASSERT
            Assert.That(bastonSinMagia.BuffeoDaño, Is.EqualTo(0m));
            Assert.That(bastonSinMagia.BuffeoVida, Is.EqualTo(0m));
        }
    }
}