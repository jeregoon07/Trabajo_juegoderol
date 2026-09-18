namespace Ucu.Poo.RolePlayGame
{
    public class BastonMagico : Item
    {
        public decimal BuffeoDaño {get; private set;}
        public decimal BuffeoVida {get; private set;}
        public BastonMagico (decimal buffeoDaño, decimal buffeoVida)
        {
            this.BuffeoDaño = buffeoDaño;
            this.BuffeoVida = buffeoVida;
        }
    }
}