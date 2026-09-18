using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;

namespace Ucu.Poo.RolePlayGame
{
    public abstract class Personaje
    {
        public string Nombre {get; private set;}
        public int VidaActual{get; private set;}
        public int VidaMaxima{get; private set;}
        public int Defensa{get; private set;}
        public List<Item> Items {get; private set;}
        public int BonusAtaque{get; private set;}
        public Personaje(string nombre, int defensa, int vidaMaxima)
        {
            this.Nombre= nombre;
            this.VidaActual=vidaMaxima;
            this.VidaMaxima=vidaMaxima;
            this.Defensa=defensa;
            this.Items= new List<Item>();
        }
        public void Curarse()
        {
            this.VidaActual=this.VidaMaxima;
        }
        public void RecibirDaño(int daño)
        {
            this.VidaActual-=daño;
            if (this.VidaActual<0)
            {
                this.VidaActual=0;
            }
        }
        public void AgregarItems(Item item)
        {
            this.Items.Add(item);
        }
        public void SacarItems(Item item)
        {
            this.Items.Remove(item);
        }
        public void AumentarBonusAtaque(int cantidad)
        {
            this.BonusAtaque+=cantidad;
        }
        public void Atacar(Personaje objetivo, int dañoBase)
        {
            int dañoTotal = dañoBase + this.BonusAtaque;
            objetivo.RecibirDaño(dañoTotal);
        }


    }
}