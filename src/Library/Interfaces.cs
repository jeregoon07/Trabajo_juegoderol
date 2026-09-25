using System.Collections.Generic;
namespace Ucu.Poo.RolePlayGame
{
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

