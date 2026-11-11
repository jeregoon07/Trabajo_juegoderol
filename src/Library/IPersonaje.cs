using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
namespace Ucu.Poo.RolePlayGame
{
    public interface IPersonaje
    {
        string Nombre { get; }
        int VidaActual { get; }
        int VidaMaxima { get; }
        int Defensa { get; }
        List<Item> Items { get; }
        int BonusAtaque { get; }
        int PuntosVictoria { get; } // Nuevo para juntar VP
        void Curarse();
        void RecibirDaño(int daño);
        void AgregarItems(Item item);
        void SacarItems(Item item);
        void AumentarBonusAtaque(int cantidad);
        void Atacar(IPersonaje objetivo, int dañoBase);
    }
}