using System.Collections.Generic;

namespace Ucu.Poo.RolePlayGame
{
    public class Mago : Personaje
    {
        public List<Hechizo> LibroHechizos { get; private set; }
        public Mago(string nombre) : base(nombre, 10, 100)
        {
            this.LibroHechizos = new List<Hechizo>();
        }
        public void AprenderHechizo(Hechizo hechizo)
        {
            this.LibroHechizos.Add(hechizo);
        }
    }
}