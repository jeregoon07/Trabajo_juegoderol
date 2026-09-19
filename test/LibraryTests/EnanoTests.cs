using NUnit.Framework;

namespace Ucu.Poo.RolePlayGame.Tests
{
    [TestFixture]
    public class EnanoTests
    {
        [Test]
        public void Atacar()
        {
            Enano enanoAtacante= new Enano("Peter Dinklage", 100, 300, 400);
            PersonajePrueba objetivo= new PersonajePrueba("Orco", 10, 100);
            enanoAtacante.Atacar(objetivo, 30);
            Assert.That(objetivo.VidaActual, Is.EqualTo(70));
        }
        public void EnanoConFuria()
        {
            Enano enanoAtacante= new Enano("Peter Dinklage", 100, 300, 400);
            PersonajePrueba objetivo= new PersonajePrueba("Orco", 0, 100);
            enanoAtacante.ActivarFuria(objetivo);
            Assert.That(objetivo.VidaActual, Is.EqualTo(30));
        }
        public void RecibirDaño()
        {
            Enano enano= new Enano("glimi", 10, 5, 100);
            enano.RecibirDanioConResistencia(40);
            Assert.That(enano.VidaActual, Is.EqualTo(75));
        }
        public void DañoInsignificante()
        {
            Enano enano= new Enano("glimi", 10, 10, 100);
            enano.RecibirDanioConResistencia(10);
            Assert.That(enano.VidaActual, Is.EqualTo(100));
        }
        
    }
}