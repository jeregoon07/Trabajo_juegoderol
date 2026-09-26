using Microsoft.Testing.Platform.Extensions.CommandLine;
using NUnit.Framework;

namespace Ucu.Poo.RolePlayGame.Tests
{
    [TestFixture]
    public class InterfacesTests
    {
        private PersonajeTestnabo personaje;
        private PocionTestnabo pocion;

        [SetUp]
        public void Setup()
        {
            this.personaje = new PersonajeTestnabo(100);
            this.pocion = new PocionTestnabo(30);
        }

        [Test]
        public void TestRecibirAtaqueReduceVida()
        {
            IAtacable objetivoAtacable = this.personaje;
            objetivoAtacable.RecibirAtaque(40);
            Assert.That(this.personaje.VidaActual, Is.EqualTo(60));
        }

        [Test]
        public void TestRecibirCuracionAumentaVida()
        {
            ICurable objetivoCurable = this.personaje;
            objetivoCurable.RecibirCuracion(20);
            Assert.That(this.personaje.VidaActual, Is.EqualTo(120));
        }

        [Test]
        public void TestPocionCuraAObjetivoCurable()
        {
            this.pocion.Curar(this.personaje);
            Assert.That(this.personaje.VidaActual, Is.EqualTo(130));
        }

        [Test]
        public void TestPocionConObjetivoNullNoLanzaExcepcion()
        {
            Assert.DoesNotThrow(() => this.pocion.Curar(null));
        }
    }
    public class PersonajeTestnabo : ICurable, IAtacable
    {
        public int VidaActual { get; private set; }
        public PersonajeTestnabo(int vidaInicial)
        {
            this.VidaActual = vidaInicial;
        }
        public void RecibirCuracion(int cantidadCuracion)
        {
            this.VidaActual += cantidadCuracion;
        }
        public void RecibirAtaque(int cantidadDano)
        {
            this.VidaActual -= cantidadDano;
            if (this.VidaActual < 0)
            {
                this.VidaActual = 0;
            }
        }
    }
    public class PocionTestnabo : ICuracion
    {
        public int ValorCuracion { get; }
        public PocionTestnabo(int valorCuracion)
        {
            this.ValorCuracion = valorCuracion;
        }
        public void Curar(ICurable objetivo)
        {
            objetivo?.RecibirCuracion(this.ValorCuracion);
        }
    }
    public class DurableTest
    {
        [Test]
        public void ReducirDurabilidad()
        {
            Arma espada = new Arma("Espada", 50, durabilidad: 100);
            int durabilidadInicial = espada.Durabilidad;
            espada.Desgastar();
            Assert.That(espada.Durabilidad, Is.LessThan(durabilidadInicial));
        }
    
    [Test]
    public void Desgastar_NoPermiteDurabilidadNegativa()
    {
        
        Arma espada = new Arma("Espada Oxidada", 50, durabilidad: 5);

        
        espada.Desgastar();

        
        Assert.That(espada.Durabilidad, Is.EqualTo(0));
    }
    }
    public class DefensaTests
{
    [Test]
    public void DefenderReduceElDanio()
    {
        
        IDefensa miArmaescudo = new Arma("Escudo de roble", 0, 100);
        int danoEntrante = 40;

        
        int cantidadDano = miArmaescudo.Defender(danoEntrante);

        
        Assert.That(cantidadDano, Is.EqualTo(40));
    }
}
    public class HabilidadTests
    {
        [Test]
        public void EjecutarAplicaEfecoEnElObjetivo()
        {
            Personaje usuario= new Enano("Glimli", 100, 0, 100);
            Personaje objetivo= new Enano("Orco", 100, 0, 100);
            IHabilidad habilidad= (IHabilidad)usuario;
            int vidaInicial= objetivo.VidaActual;
            habilidad.Ejecutar(usuario, objetivo);
            Assert.That(objetivo.VidaActual, Is.LessThan(vidaInicial));
        }
    }
}

