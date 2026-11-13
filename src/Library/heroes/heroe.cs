namespace Ucu.Poo.RolePlayGame
{
    public abstract class Heroe : PersonajeBase
    {
        protected Heroe(
            string nombre,
            int defensa,
            int vidaMaxima
        ) : base(nombre, defensa, vidaMaxima)
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