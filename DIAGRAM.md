# Diagrama de clases

Completa a continuación tu diagrama de clases usando
[Mermaid](https://mermaid.live/edit). Debes completar el diagrama agregando las
clases y sus atributos, operaciones y relaciones faltantes. La ventaja de usar
**Mermaid** es que el diagrama es simplemente texto en un archivo
[Markdown](https://www.markdownguide.org) como este, y no gráficos ni imágenes.

```mermaid
classDiagram
    Item <|-- Arma
    Item <|-- Ropa
    Item <|-- BastonMagico
    Item <|-- LibroDeHechizos
    PersonajeBase <|-- Heroe
    PersonajeBase <|-- Enemigo
    Heroe <|-- Mago
    Heroe <|-- Elfo
    Heroe <|-- Enano
    Enemigo <|-- EsqueletoUnicornio
    Enemigo <|-- ZombieMini
    Enemigo <|-- Medusa
    PersonajeBase "1" --> "*" Item : tiene
    LibroDeHechizos "1" --> "*" Hechizo : contiene
    Medusa "1" --> "1" Hechizo : MiradaPetrificante
    EncuentroDeCombate ..|> IEncuentro
    EncuentroDeCombate --> Heroe
    EncuentroDeCombate --> Enemigo

    class Item {
        +string Nombre
        +int Ataque
        +int Defensa
        +int Durabilidad
    }
    class Arma { +int DesgastePorAtaque
        +Desgastar() }
    class Ropa { +AbsorberDaño(int) int }
    class BastonMagico { +decimal BuffeoDaño
        +decimal BuffeoVida }
    class LibroDeHechizos { +AgregarHechizo(Hechizo) }
    class Hechizo { +string Nombre
        +int Poder }
    class PersonajeBase {
        <<abstract>>
        +string Nombre
        +int VidaActual
        +int VidaMaxima
        +int Defensa
        +int BonusAtaque
        +int PuntosVictoria
        +bool EstaVivo
        +int ValorAtaqueTotal
        +int ValorDefensaTotal
        +Atacar(IPersonaje, int)
        +RecibirDaño(int)
        +Curarse()
        +AgregarItems(Item)
        +SacarItems(Item)
        +AumentarBonusAtaque(int)
        +GanarPuntos(int)
    }
    class Heroe { <<abstract>> }
    class Mago { +AprenderHechizo(Hechizo)
        +AtacarConMagia(IPersonaje, Hechizo) }
    class Elfo { +Ayudar(IPersonaje)
        +UsarMagia(IPersonaje, int) }
    class Enano { +int ResistenciaCorporal
        +UsarItem(Item, IPersonaje)
        +ActivarFuria(IPersonaje) }
    class EncuentroDeCombate { +DoEncounter() }
```