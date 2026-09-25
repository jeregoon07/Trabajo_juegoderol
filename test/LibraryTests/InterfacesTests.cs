using NUnit.Framework;
using System.Collections.Generic;

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

        [Test]
        public void TestConsumibleCambiaEstadoAlUsarse()
        {
            IConsumible panLembas = new ConsumibleTestnabo(10);
            Assert.That(panLembas.FueConsumido, Is.False);
            
            panLembas.Consumir(this.personaje);
            
            Assert.That(panLembas.FueConsumido, Is.True);
            Assert.That(this.personaje.VidaActual, Is.EqualTo(110));
        }

        [Test]
        public void TestHechizoTieneValorMagico()
        {
            IHechizo bolaDeFuego = new HechizoTestnabo(50);
            Assert.That(bolaDeFuego.ValorMagico, Is.EqualTo(50));
        }

        [Test]
        public void TestInventarioAgregaYRemueveItems()
        {
            IInventario miInventario = new InventarioTestnabo();
            Item itemFalso = null; 
            
            miInventario.AgregarItem(itemFalso);
            Assert.That(miInventario.Items.Count, Is.EqualTo(1));

            miInventario.RemoverItem(itemFalso);
            Assert.That(miInventario.Items.Count, Is.EqualTo(0));
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

    public class ConsumibleTestnabo : IConsumible
    {
        public bool FueConsumido { get; private set; }
        private int valorRestauracion;

        public ConsumibleTestnabo(int valorRestauracion)
        {
            this.valorRestauracion = valorRestauracion;
            this.FueConsumido = false;
        }

        public void Consumir(ICurable objetivo)
        {
            if (!this.FueConsumido)
            {
                objetivo?.RecibirCuracion(this.valorRestauracion);
                this.FueConsumido = true;
            }
        }
    }

    public class HechizoTestnabo : IHechizo
    {
        public int ValorMagico { get; }

        public HechizoTestnabo(int poderMagico)
        {
            this.ValorMagico = poderMagico;
        }
    }

    public class InventarioTestnabo : IInventario
    {
        private List<Item> listaInterna = new List<Item>();
        
        public IReadOnlyCollection<Item> Items => this.listaInterna.AsReadOnly();

        public void AgregarItem(Item item)
        {
            this.listaInterna.Add(item);
        }

        public void RemoverItem(Item item)
        {
            this.listaInterna.Remove(item);
        }
    }
}