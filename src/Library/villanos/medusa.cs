
namespace Ucu.Poo.RolePlayGame
{
    // Medusa es una villana que hereda de Villano.
    public class Medusa : Villano
    {
        // Hechizo especial de Medusa.
        public Hechizo MiradaPetrificante { get; private set; }

        // Constructor de Medusa.
        public Medusa(string nombre)
            : base(nombre, 15, 120)
        {
            this.MiradaPetrificante =
                new Hechizo("Mirada petrificante", 30);
        }

        // Medusa utiliza su mirada para atacar.
        public void UsarMiradaPetrificante(Personaje objetivo)
        {
            this.Atacar(objetivo, this.MiradaPetrificante.Poder);
        }

        // Medusa ataca utilizando sus serpientes.
        public void AtacarConSerpientes(Personaje objetivo)
        {
            int dañoSerpientes = 15;

            this.Atacar(objetivo, dañoSerpientes);
        }
    }
}
