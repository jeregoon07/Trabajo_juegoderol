namespace Ucu.Poo.RolePlayGame
{
    public class Hechizo
    {
        public string Nombre { get; private set; }
        public int Poder { get; private set; } 
        public Hechizo(string nombre, int poder)
        {
            this.Nombre = nombre;
            this.Poder = poder;
        }
    }
}