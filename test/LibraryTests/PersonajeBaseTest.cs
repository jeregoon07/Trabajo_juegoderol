using System;
using NUnit.Framework;

namespace Ucu.Poo.RolePlayGame.Tests
{
    [TestFixture]
    public class PersonajeBaseTests
    {
        [Test]
        public void ValorAtaqueTotal_ConArmaYBonus_SumaTodo()
        {
            Mago mago = new Mago("Merlin", 5, 50, 0);
            mago.AgregarItems(new Arma("Espada", 15, 10));
            mago.AumentarBonusAtaque(3);

            Assert.That(mago.ValorAtaqueTotal, Is.EqualTo(18));
        }

        [Test]
        public void ValorDefensaTotal_ConRopa_SumaDefensaPropiaMasItems()
        {
            Mago mago = new Mago("Merlin", 5, 50, 0);
            mago.AgregarItems(new Ropa("Pechera", 7, 10));

            Assert.That(mago.ValorDefensaTotal, Is.EqualTo(12));
        }

        [Test]
        public void Curarse_PersonajeMuerto_LanzaExcepcion()
        {
            Enemigo enemigo = new Enemigo("Orco", 0, 10, 0);
            enemigo.RecibirDaño(99);

            Assert.Throws<InvalidOperationException>(() => enemigo.Curarse());
        }

        [Test]
        public void RecibirDaño_ConValorNegativo_LanzaExcepcion()
        {
            Enemigo enemigo = new Enemigo("Orco", 0, 10, 0);

            Assert.Throws<ArgumentOutOfRangeException>(() => enemigo.RecibirDaño(-5));
        }

        [Test]
        public void Constructor_ConVidaCero_LanzaExcepcion()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Enemigo("Orco", 0, 0, 0));
        }

        [Test]
        public void Constructor_ConNombreVacio_LanzaExcepcion()
        {
            Assert.Throws<ArgumentException>(() => new Enemigo("", 0, 10, 0));
        }

        [Test]
        public void AgregarItems_ConNull_LanzaExcepcion()
        {
            Enemigo enemigo = new Enemigo("Orco", 0, 10, 0);

            Assert.Throws<ArgumentNullException>(() => enemigo.AgregarItems(null));
        }

        [Test]
        public void Atacar_HeroeAOtroHeroe_NoHaceDaño()
        {
            Mago atacante = new Mago("A", 1, 100, 0);
            Mago otro = new Mago("B", 1, 100, 0);

            atacante.Atacar(otro, 50);

            Assert.That(otro.VidaActual, Is.EqualTo(100));
        }

        [Test]
        public void AtacarConMagia_ConHechizoNull_LanzaArgumentNullException()
        {
            Mago mago = new Mago("Merlin", 1, 50, 0);
            Enemigo enemigo = new Enemigo("Orco", 0, 50, 0);

            Assert.Throws<ArgumentNullException>(() => mago.AtacarConMagia(enemigo, null));
        }
    }
}