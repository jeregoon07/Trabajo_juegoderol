namespace Ucu.Poo.RolePlayGame
{
    // Lo mismo que con arma, muestra que ropa hereda de item
    public class Ropa : Item
    {
        // Aca es la logica inversa, la ropa te da mas defensa pero no te suma ataque
        public Ropa(string nombre, int defensa, int durabilidad) 
            : base(nombre, 0, defensa, durabilidad)
        {
        }
        // Aca seria como la proteccion iv de minecraft, que absorve el daño 
        public int AbsorberDaño(int dañoRecibido)
        {
            // Aca es para cuando la ropa ya no tenga durabilidad (osea que este rota) pierda esa propiedad de absorcion
            if (this.Durabilidad <= 0)
            {
                return dañoRecibido;
            }
            // Aca ya entra en que tan buena sea la ropa o armadura, osea mientras mejor, mas daño absorve 
            int dañoAbsorbido = Math.Min(dañoRecibido, this.Defensa);
            int dañoRestante = dañoRecibido - dañoAbsorbido;
            // Aca normal, cuando recibe impactos, se reduce durabilidad
            this.Durabilidad -= 1;
            if (this.Durabilidad < 0)
            {
                this.Durabilidad = 0;
            }
            return dañoRestante;
            // que conste que cuando digo que "absorve" seria como que si se saca 10 de daño, la armadura toma un porcentaje de el mismo cosa que no vaya para el personaje
        }
    }
}