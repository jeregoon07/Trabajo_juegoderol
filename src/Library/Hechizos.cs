namespace Ucu.Poo.RolePlayGame
{
    //clase unica entre sus pares
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