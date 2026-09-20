using System.Collections.Generic;

namespace Ucu.Poo.RolePlayGame
{
    //clase hija de personaje
    public class Mago : Personaje
    {
        public Mago(string nombre) : base(nombre, 10, 100)
        {
        }
        public void AprenderHechizo(Hechizo hechizo)
        {
            foreach (Item item in this.Items)
            {
                LibroDeHechizos libro = item as LibroDeHechizos;
                
                if (libro != null)
                {
                    libro.AgregarHechizo(hechizo);
                    return; 
                }
            }
        }
        public void AtacarConMagia(Personaje objetivo, Hechizo hechizo)
        {
            int dañoTotal = hechizo.Poder;
            
            foreach (Item item in this.Items)
            {
                BastonMagico baston = item as BastonMagico;
                
                if (baston != null)
                {
                    dañoTotal += (int)baston.BuffeoDaño;
                }
            }
            
            this.Atacar(objetivo, dañoTotal);
        }
    }
}