using NUnit.Framework;

namespace Ucu.Poo.RolePlayGame.Tests
{
    [TestFixture]
    public class ArmaTests
    {
        [Test]
        // Prueba: Al desgastar una vez, debe restar exactamente el 'DesgastePorAtaque'
        public void DesgasteDurabilidad()
        {
            // 1. ARRANGE: Espada con 10 de durabilidad y desgaste de 2 por uso
            Arma espada = new Arma("Espada de Hierro", ataque: 15, durabilidad: 10, desgastePorAtaque: 2);
            // 2. ACT: Usamos la espada una vez
            espada.Desgastar();
            // 3. ASSERT: 10 - 2 = 8. Verificamos que quede en 8
            Assert.That(espada.Durabilidad, Is.EqualTo(8));
        }
        [Test]
        // Prueba: Si el desgaste es mayor a la durabilidad actual, NO debe quedar en negativo
        public void DurabilidadQuedaEnCero()
        {
            // 1. ARRANGE: Espada casi rota (2 de durabilidad) con desgaste alto (10)
            Arma espadaFragil = new Arma("Espada de Cristal", ataque: 20, durabilidad: 2, desgastePorAtaque: 10);
            // 2. ACT: La usamos
            espadaFragil.Desgastar();
            // 3. ASSERT: En lugar de dar -8, tu código fuerza que sea 0
            Assert.That(espadaFragil.Durabilidad, Is.EqualTo(0));
        }
        [Test]
        // Prueba: Si no pasamos el parámetro 'desgastePorAtaque', debe valer 1 por defecto
        public void DesgastePorDefault()
        {
            // 1. ARRANGE: No le pasamos el último número (usa el default = 1)
            Arma hacha = new Arma("Hacha de Madera", ataque: 8, durabilidad: 5);
            // 2. ACT: Desgastamos
            hacha.Desgastar();
            // 3. ASSERT: Como por defecto el desgaste es 1, 5 - 1 = 4
            Assert.That(hacha.Durabilidad, Is.EqualTo(4));
            Assert.That(hacha.DesgastePorAtaque, Is.EqualTo(1));
        }
    }
}