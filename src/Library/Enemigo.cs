namespace Ucu.Poo.RolePlayGame
{
    public class Enemigo : PersonajeBase
    {
        public override int PuntosVictoria { get;  set; }
        public Enemigo(string nombre, int defensa, int vidaMaxima, int valorPuntosVictoria) 
            : base(nombre, defensa, vidaMaxima, valorPuntosVictoria)
        {
            this.PuntosVictoria = valorPuntosVictoria;
        }
    }
}