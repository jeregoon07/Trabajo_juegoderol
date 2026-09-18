using System;
using Ucu.Poo.RolePlayGame;

namespace Ucu.Poo.RolePlayGame
{
    // Acá se define la subclase 'Enano' que hereda con : los atributos y metodos de la clase personaje
    public class Enano : Personaje
    {
        // Atributo propio del Enano que representa alta resistencia física
        public int ResistenciaCorporal { get; private set; }
        
        // Este es el constructor, recibe todos los datos necesarios para poder instanciar al Enano.
        public Enano(string nombre, int defensa, int vidaMaxima, int resistenciaCorporal)
        : base(nombre, defensa, vidaMaxima)
        
    {
        // se le asigna el valor de la resistencia corporal a la propiedad de esa instancia.
        this.ResistenciaCorporal = resistenciaCorporal;
    }

    // Utiliza armas u otros elementos: colabora con Item y Prsonaje
    public void UsarItem(Item item, Personaje objetivo)
        {
            //Se aplica el ataque al personaje objetivo segun el daño o ataque que posee tal item usado
            Atacar(objetivo, item.Ataque);
        }

    // Activa habilidades de combate según su temperamento
    public void ActivarFuria(Personaje objetivo)
        {
            int dañoModificado = 20 + 10;
            Atacar(objetivo, dañoModificado);
        }

    // Posee alta resistencia corporal
    public void RecibirDanioConResistencia(int daño)
        {
            // Resta al daño recibido tanto la defensa base del personaje como la resistencia corporal
            int dañoReal = daño - (this.Defensa + this.ResistenciaCorporal);
            
            // Solo descuenta vida si el daño supera la protección combinada
            if (dañoReal > 0)
            {
                //llama al metodo heredado RecibirDaño para descontar la vida actual
                RecibirDaño(dañoReal);
                        }
        }
}
}