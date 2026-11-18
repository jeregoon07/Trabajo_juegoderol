using NUnit.Framework;

namespace Ucu.Poo.RolePlayGame.Tests
{
    [TestFixture]
    public class EnanoTests
    {
        [Test]
        public void Atacar()
        {
            Enano enanoAtacante= new Enano("Peter Dinklage", 100, 300, 400,30);
            PersonajePrueba objetivo= new PersonajePrueba("Orco", 10, 100,30);
            enanoAtacante.Atacar(objetivo, 30);
            Assert.That(objetivo.VidaActual, Is.EqualTo(70));
        }
        [Test]
        public void EnanoConFuria()
        {
            Enano enanoAtacante= new Enano("Peter Dinklage", 100, 300, 400,30);
            PersonajePrueba objetivo= new PersonajePrueba("Orco", 0, 100,30);
            enanoAtacante.ActivarFuria(objetivo);
            Assert.That(objetivo.VidaActual, Is.EqualTo(70));
        }
        [Test]
        public void RecibirDaño()
        {
            Enano enano= new Enano("glimi", 10, 100, 20,30);
            enano.RecibirDaño(40);
            Assert.That(enano.VidaActual, Is.EqualTo(90));
        }
        [Test]
        public void DañoInsignificante()
        {
            Enano enano= new Enano("glimi", 10, 100, 100,30);
            enano.RecibirDaño(10);
            Assert.That(enano.VidaActual, Is.EqualTo(100));
        }
        
    }
}