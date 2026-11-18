using System;
using System.Collections.Generic;

namespace Ucu.Poo.RolePlayGame
{
    public abstract class PersonajeBase : IPersonaje
    {
        // La lista es privada: desde afuera solo se puede mirar, no modificar (encapsulación).
        private List<Item> items;

        public string Nombre { get; private set; }
        public int VidaActual { get; protected set; }
        public int VidaMaxima { get; protected set; }
        public int Defensa { get; private set; }
        public IReadOnlyCollection<Item> Items { get { return this.items.AsReadOnly(); } }
        public int BonusAtaque { get; private set; }
        public int PuntosVictoria { get; private set; }
        public bool EstaVivo { get { return this.VidaActual > 0; } }

        // Expert (GRASP): el personaje conoce sus items, por eso él calcula el total.
        public int ValorAtaqueTotal
        {
            get
            {
                int total = this.BonusAtaque;
                foreach (Item item in this.items) { total += item.Ataque; }
                return total;
            }
        }

        public int ValorDefensaTotal
        {
            get
            {
                int total = this.Defensa;
                foreach (Item item in this.items) { total += item.Defensa; }
                return total;
            }
        }

        protected PersonajeBase(string nombre, int defensa, int vidaMaxima, int puntosVictoria)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre no puede estar vacío.", nameof(nombre));
            }
            if (vidaMaxima <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(vidaMaxima));
            }
            this.Nombre = nombre;
            this.VidaActual = vidaMaxima;
            this.VidaMaxima = vidaMaxima;
            this.Defensa = defensa;
            this.items = new List<Item>();
            this.PuntosVictoria = puntosVictoria;
        }

        public void GanarPuntos(int cantidad) { this.PuntosVictoria += cantidad; }

        public virtual void Curarse()
        {
            if (!this.EstaVivo)
            {
                throw new InvalidOperationException("Un personaje muerto no puede curarse.");
            }
            this.VidaActual = this.VidaMaxima;
        }

        public virtual void RecibirDaño(int daño)
        {
            if (daño < 0) { throw new ArgumentOutOfRangeException(nameof(daño)); }
            this.VidaActual -= daño;
            if (this.VidaActual < 0) { this.VidaActual = 0; }
        }

        public virtual void AgregarItems(Item item)
        {
            if (item == null) { throw new ArgumentNullException(nameof(item)); }
            this.items.Add(item);
        }

        public virtual void SacarItems(Item item) { this.items.Remove(item); }
        public virtual void AumentarBonusAtaque(int cantidad) { this.BonusAtaque += cantidad; }

        public virtual void Atacar(IPersonaje objetivo, int dañoBase)
        {
            if (objetivo == null) { throw new ArgumentNullException(nameof(objetivo)); }
            int dañoTotal = dañoBase + this.BonusAtaque;
            objetivo.RecibirDaño(dañoTotal);
        }
    }
}