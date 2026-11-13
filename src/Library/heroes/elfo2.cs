namespace Ucu.Poo.RolePlayGame
{
    public class Elfo : Heroe
    {
        public Elfo(string nombre, int defensa, int VidaMaxima,int valorPuntosVictoria) : base(nombre, defensa, VidaMaxima,valorPuntosVictoria)
        {
        }

        public void Ayudar(IPersonaje objetivo)
        {
            objetivo.Curarse();
        }

        public void UsarMagia(IPersonaje objetivo, int cantidad)
        {
            objetivo.AumentarBonusAtaque(cantidad);
        }
    }
}