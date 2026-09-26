using System.Collections.Generic;
using Ucu.Poo.RolePlayGame;

namespace Ucu.Poo.RolePlayGame
{
    public interface IHechizos
{
    
    string Nombre { get; }
    int CostoMana { get; }
    int ValorAtaque { get; }
    int ValorCuracion { get; }
}
    public interface ICurable
    {
        int VidaActual { get; }
        void RecibirCuracion(int cantidadCuracion);
    }
    public interface IAtacable
    {
        int VidaActual { get; }
        void RecibirAtaque(int cantidadDano);
    }
    public interface ICuracion
    {
        int ValorCuracion { get; }
        void Curar(ICurable objetivo);
    }
    public interface IAtaque
    {
        int ValorAtaque { get; }
        void Atacar(IAtacable objetivo);
    }
    public interface IDefensa
    {
        int ValorDefensa { get; }
        int Defender(int danoRecibido);
    }
    public interface IMagico
    {
        int ValorMagico { get; }
    }
}

public interface IDurable
{
    int Durabilidad{get;}
    void Desgastar(int cantidad);
}

public interface ILibroDeHechizos
{
    IReadOnlyCollection<IHechizos> Hechizos { get; }

    void AgregarHechizo(IHechizos hechizo);

    IHechizos ConsultarHechizo(string nombreHechizo);
}

public interface IHabilidad
{
    string Nombre {get;}
    int CostoEnergia{get;}
    bool EsPasiva {get;}
    void Ejecutar(Personaje usuario, Personaje objetivo);
    public interface IConsumible
    {
        bool FueConsumido { get; }
        void Consumir(ICurable objetivo);
    }

    public interface IHechizo : IMagico
    {
    
    }

public interface IInventario
{
    IReadOnlyCollection<Item> Items { get; }
    void AgregarItem(Item item);
    void RemoverItem(Item item);
}
}

