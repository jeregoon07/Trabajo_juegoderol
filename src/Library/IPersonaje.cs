using System.Collections.Generic;
namespace Ucu.Poo.RolePlayGame
{
    public interface IPersonaje
    {
        string Nombre { get; }
        int VidaActual { get; }
        int VidaMaxima { get; }
        int Defensa { get; }
        IReadOnlyCollection<Item> Items{get;}
        int BonusAtaque { get; }
        int PuntosVictoria { get; } 
        int ValorAtaqueTotal{get;}

        int ValorDefensaTotal{get;}
        void Curarse();
        void RecibirDaño(int daño);
        void AgregarItems(Item item);
        void SacarItems(Item item);
        void AumentarBonusAtaque(int cantidad);
        void Atacar(IPersonaje objetivo, int dañoBase);
    }
}