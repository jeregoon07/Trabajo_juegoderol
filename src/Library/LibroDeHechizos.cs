using System.Collections.Generic;

namespace Ucu.Poo.RolePlayGame
{
    // Subclase de Item
    public class LibroDeHechizos : Item
    {
        // Contenedor de hechizos
        public List<Hechizo> Hechizos { get; private set; }

        public LibroDeHechizos(string nombre, int durabilidad) 
            : base(nombre, 0, 0, durabilidad)
        {
            this.Hechizos = new List<Hechizo>();
        }

        // Agregar hechizos
        public void AgregarHechizo(Hechizo hechizo)
        {
            if (hechizo != null)
            {
                this.Hechizos.Add(hechizo);
                ActualizarPoder();
            }
        }

        // Proporcionar poder según los hechizos agregados
        private void ActualizarPoder()
        {
            int totalAtaque = 0;
            int totalDefensa = 0;

            foreach (Hechizo h in this.Hechizos)
            {
                totalAtaque += h.ValorAtaque;
                totalDefensa += h.ValorDefensa;
            }

            this.Ataque = totalAtaque;
            this.Defensa = totalDefensa;
        }
    }
}