namespace Ucu.Poo.RolePlayGame
{
    public class BastonMagico : Item
    {
        public decimal BuffeoDaño {get; private set;}
        public decimal BuffeoVida {get; private set;}
        public BastonMagico (string nombre, int durabilidad, decimal buffeoDaño, decimal buffeoVida)
            : base(nombre, 0, 0, durabilidad)
        {
            this.BuffeoDaño = buffeoDaño;
            this.BuffeoVida = buffeoVida;
        }
    }
}