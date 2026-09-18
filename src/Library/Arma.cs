namespace Ucu.Poo.RolePlayGame
{
    // Esto muestra que el arma hereda las propiedades del item
    public class Arma : Item
    {
        // Como el maicra, cada que se usa que pierda durabilidad
        public int DesgastePorAtaque { get; set; }
        // Aca puse 0 pq por lo general las armas no tienen defensa (un escudo no cuenta = literalmente es escudo y no arma)
        public Arma(string nombre, int ataque, int durabilidad, int desgastePorAtaque = 1) 
            : base(nombre, ataque, 0, durabilidad)
        {
            this.DesgastePorAtaque = desgastePorAtaque;
        }
        // Lo que hace para que cuando se use el arma se desgaste
        public void Desgastar()
        {
            if (this.Durabilidad > 0)
            {
                this.Durabilidad -= this.DesgastePorAtaque;
                // aca para que la durabilidad no llegue a ser negativa pues sino no tendria sentido
                if (this.Durabilidad < 0)
                {
                    this.Durabilidad = 0;
                }
            }
        }
    }
}