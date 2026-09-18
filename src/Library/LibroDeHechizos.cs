using System.Collections.Generic;

namespace Ucu.Poo.RolePlayGame
{
    public class LibroDeHechizos : Item
    {
        public List<Hechizo> Hechizos { get; private set; }

        public LibroDeHechizos(string nombre, int durabilidad) 
            : base(nombre, 0, 0, durabilidad)
        {
            this.Hechizos = new List<Hechizo>();
        }
        public void AgregarHechizo(Hechizo hechizo)
        {
            if (hechizo != null)
            {
                this.Hechizos.Add(hechizo);
                ActualizarPoder();
            }
        }
private void ActualizarPoder()
        {
            int totalAtaque = 0;
            
            foreach (Hechizo h in this.Hechizos)
            {
                totalAtaque += h.Poder; 
            }
            this.Ataque = totalAtaque;
            this.Defensa = 0; 
        }
    }
}