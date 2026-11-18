namespace Ucu.Poo.RolePlayGame
{
    public class ZombieMini : Enemigo
    {
        public ZombieMini(): base("Pequeño Timy", defensa:10, vidaMaxima:50, valorPuntosVictoria:30)
        {}
        public void GolpeConVeneno(IPersonaje objetivo, int dañoBase)
        {
            int dañototal= dañoBase + this.BonusAtaque + 30;
            objetivo.RecibirDaño(dañototal);
        }
    }
}
