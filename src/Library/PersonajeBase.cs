using System.Collections.Generic;

namespace Ucu.Poo.RolePlayGame
{
    public abstract class PersonajeBase : IPersonaje
    {
        public string Nombre { get; private set; }
        public int VidaActual { get; protected set; }
        public int VidaMaxima { get; protected set; }
        public int Defensa { get; private set; }
        public List<Item> Items { get; private set; }
        public int BonusAtaque { get; private set; }
        public virtual int PuntosVictoria { get;  set; }
        protected PersonajeBase(string nombre, int defensa, int vidaMaxima,int puntosVictoria)
        {
            this.Nombre = nombre;
            this.VidaActual = vidaMaxima;
            this.VidaMaxima = vidaMaxima;
            this.Defensa = defensa;
            this.Items = new List<Item>();
            this.PuntosVictoria=puntosVictoria;
        }
        public virtual void Curarse() => this.VidaActual = this.VidaMaxima;
        public virtual void RecibirDaño(int daño)
        {
            this.VidaActual -= daño;
            if (this.VidaActual < 0) this.VidaActual = 0;
        }
        public virtual void AgregarItems(Item item) => this.Items.Add(item);
        public virtual void SacarItems(Item item) => this.Items.Remove(item);
        public virtual void AumentarBonusAtaque(int cantidad) => this.BonusAtaque += cantidad;
        public virtual void Atacar(IPersonaje objetivo, int dañoBase)
        {
            int dañoTotal = dañoBase + this.BonusAtaque;
            objetivo.RecibirDaño(dañoTotal);
        }
    }
}