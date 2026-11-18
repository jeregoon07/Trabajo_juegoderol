using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace Ucu.Poo.RolePlayGame
{
    //clase unica entre sus pares
    public class LibroDeHechizos : Item
    {
        private List<Hechizo> hechizos;
public ReadOnlyCollection<Hechizo> Hechizos { get { return this.hechizos.AsReadOnly(); } }

        public LibroDeHechizos(string nombre, int durabilidad) 
            : base(nombre, 0, 0, durabilidad)
        {
            this.hechizos = new List<Hechizo>();
        }
        public void AgregarHechizo(Hechizo hechizo)
        {
            if (hechizo != null)
            {
                this.hechizos.Add(hechizo);
                ActualizarPoder();
            }
        }
private void ActualizarPoder()
        {
            int totalAtaque = 0;
            
            foreach (Hechizo h in this.hechizos)
            {
                totalAtaque += h.Poder; 
            }
            this.Ataque = totalAtaque;
            this.Defensa = 0; 
        }
    }
}