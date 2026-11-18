using System.Collections.Generic;
using System;
namespace Ucu.Poo.RolePlayGame
{
public class Mago : Heroe
    {
        public Mago(string nombre, int defensa, int vidaMaxima,int valorPuntosVictoria)
        : base(nombre, defensa, vidaMaxima, valorPuntosVictoria)
        {
        }
        public void AprenderHechizo(Hechizo hechizo)
        
{
    if (hechizo == null) { throw new ArgumentNullException(nameof(hechizo)); }
    foreach (Item item in this.Items)
{
    LibroDeHechizos libro = item as LibroDeHechizos;
    if (libro != null)
    {
        libro.AgregarHechizo(hechizo);
        return;
    }
}

    // Si llegó hasta acá, el mago no tenía ningún libro.
    throw new InvalidOperationException("El mago no tiene un libro de hechizos.");
}
        public void AtacarConMagia(IPersonaje objetivo, Hechizo hechizo)
        {
            
            if(hechizo==null)
            {
                throw new ArgumentNullException(nameof(hechizo));
            }
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