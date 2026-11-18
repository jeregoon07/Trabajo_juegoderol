using System;
using System.Collections.Generic;
using NUnit.Framework;
using Ucu.Poo.RolePlayGame;

namespace Ucu.Poo.RolePlayGame.Tests
{
    [TestFixture]
    public class EncuentroDeCombateTests
    {
        [Test]
        public void Constructor_SinHeroesOEnemigos_LanzaExcepcion()
        {
            var heroe = new Mago("Gandalf",30,20,40);
            var enemigo = new Enemigo("Azog", 10, 50, 2);

            Assert.Throws<ArgumentException>(delegate
            {
                new EncuentroDeCombate(new List<Heroe>(), new List<Enemigo> { enemigo });
            });

            Assert.Throws<ArgumentException>(delegate
            {
                new EncuentroDeCombate(new List<Heroe> { heroe }, new List<Enemigo>());
            });
        }

        [Test]
        public void DoEncounter_EnemigosAtacanPrimero_SiMatanAlHeroeNoContraataca()
        {
            var heroe = new Mago("Gandalf Debil",30,20,40);
            var enemigo = new Enemigo("Balrog", 100, 200, 5);
            int vidaInicialEnemigo = enemigo.VidaActual;

            var encuentro = new EncuentroDeCombate(new List<Heroe> { heroe }, new List<Enemigo> { enemigo });

            encuentro.DoEncounter();

            Assert.That(heroe.VidaActual, Is.EqualTo(0));
            Assert.That(enemigo.VidaActual, Is.EqualTo(vidaInicialEnemigo));
        }

        [Test]
        public void DoEncounter_MasEnemigosQueHeroes_ReparteAtaquesConModulo()
        {
            var h1 = new Mago("H1",30,20,40);
            var h2 = new Elfo("H2", 10, 100,30);
            var e1 = new Enemigo("E1", 20, 500, 1);
            var e2 = new Enemigo("E2", 20, 500, 1);
            var e3 = new Enemigo("E3", 20, 500, 1);

            var encuentro = new EncuentroDeCombate(
                new List<Heroe> { h1, h2 },
                new List<Enemigo> { e1, e2, e3 }
            );

            encuentro.DoEncounter();

            Assert.That(h1.VidaMaxima, Is.EqualTo(20));
            Assert.That(e1.VidaActual, Is.LessThan(500));
        }

        [Test]
        public void DoEncounter_HeroeGana5OMasVP_SeCuraAlFinalizar()
        {
            var heroe = new Mago("Gandalf", 30, 100, 0);
            var e1 = new Enemigo("Orco 1", 15, 30, 3);
            var e2 = new Enemigo("Orco 2", 15, 30, 2);
            var encuentro = new EncuentroDeCombate(new List<Heroe> { heroe }, new List<Enemigo> { e1, e2 });
            encuentro.DoEncounter();
            Assert.That(heroe.PuntosVictoria, Is.EqualTo(5));
            Assert.That(heroe.VidaActual, Is.EqualTo(heroe.VidaMaxima));
        }
    }
}