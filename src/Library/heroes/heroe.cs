namespace Ucu.Poo.RolePlayGame
{
    //Decisión de diseño: los héroes son aliados y no se atacan entre sí
    public abstract class Heroe : PersonajeBase
    {
        protected Heroe(
            string nombre,
            int defensa,
            int vidaMaxima,
            int puntosVictoria
        ) : base(nombre, defensa, vidaMaxima,puntosVictoria)
        {
        }

        public override void Atacar(
            IPersonaje objetivo,
            int dañoBase
        )
        {
            if (objetivo is Heroe)
            {
                return;
            }

            base.Atacar(objetivo, dañoBase);
        }
    }
}