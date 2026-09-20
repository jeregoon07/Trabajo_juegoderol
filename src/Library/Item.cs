namespace Ucu.Poo.RolePlayGame
{
    //super clase
    public class Item
    {
        public string Nombre { get; set; }
        public int Ataque { get; set; }
        public int Defensa { get; set; }
        public int Durabilidad { get; set; }

        public Item(string nombre, int ataque, int defensa, int durabilidad)
        {
            this.Nombre = nombre;
            this.Ataque = ataque;
            this.Defensa = defensa;
            this.Durabilidad = durabilidad;
        }
    }
}