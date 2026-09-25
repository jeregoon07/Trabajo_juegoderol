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
}