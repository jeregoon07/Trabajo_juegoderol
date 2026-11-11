using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Ucu.Poo.RolePlayGame
{
<<<<<<< HEAD
    public class Elfo:Heroe
=======
    //esta clase hereda de personaje. clase hija
    public class Elfo:Personaje
>>>>>>> refs/remotes/origin/main
    {
        public Elfo(string nombre, int defensa, int VidaMaxima): base(nombre, defensa, VidaMaxima)
        {}
            public void Ayudar(Personaje objetivo)
        {
            objetivo.Curarse();
        }
        public void UsarMagia(Personaje objetivo, int cantidad)
        {
            objetivo.AumentarBonusAtaque(cantidad);
        }
    }
}