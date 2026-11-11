namespace Ucu.Poo.RolePlayGame
{
    /// <summary>
    /// Representa al enemigo Esqueleto montando un Unicornio oscuro.
    /// </summary>
    public class EsqueletoUnicornio : Enemigo
    {
        /// <summary>
        /// Instancia una nueva instancia de la clase <see cref="EsqueletoUnicornio"/>
        /// con sus estadísticas y nombre 
        /// </summary>
        public EsqueletoUnicornio() 
            : base("Esqueleto Caballero en Unicornio", defensa: 15, vidaMaxima: 150, valorPuntosVictoria: 50)
        {
            //Aca puede ir si queremos ponerle armas o asi
        }
        /// <summary>
        /// Ataque especial en el que el unicornio embiste al objetivo sumando daño extra
        /// </summary>
        /// <param name="objetivo">El personaje que recibe el ataque.</param>
        /// <param name="dañoBase">El daño base del ataque.</param>
        public void EmbestidaCorrupta(IPersonaje objetivo, int dañoBase)
        {
            int dañoTotal = dañoBase + this.BonusAtaque + 15;
            objetivo.RecibirDaño(dañoTotal);
        }
    }
}