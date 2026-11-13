using System;
using Ucu.Poo.RolePlayGame;
using NUnit.Framework;

namespace Ucu.Poo.RolePlayGame.Tests
{
    [TestFixture]
    public class ElfoTests
    {
        [Test]
        public void ElfoCuradorDeAliados()
        {
            Elfo elfo = new Elfo("hobbit", 10, 100,30);
            PersonajePrueba aliado= new PersonajePrueba("leñador", 10, 100,50);
            aliado.RecibirDaño(30);
            elfo.Ayudar(aliado);
            Assert.That(aliado.VidaActual, Is.EqualTo(100));
        }
        public void AumentarDañoAliado()
        {
            Elfo elfo = new Elfo("hobbit", 10, 100,30);
            PersonajePrueba aliado = new PersonajePrueba("leñador", 10, 100,40);
            int bonusInical= aliado.BonusAtaque;
            elfo.UsarMagia(aliado,20);
            Assert.That(aliado.BonusAtaque, Is.GreaterThan(bonusInical));
        }
        public void AtacarAotros()
        {
            Elfo elfo = new Elfo("hobbit", 10,100,30);
            PersonajePrueba enemigo= new PersonajePrueba("duende", 10, 115,30);
            elfo.Atacar(enemigo,30);
            Assert.That(enemigo.VidaActual, Is.EqualTo(85));

        }
    }
}