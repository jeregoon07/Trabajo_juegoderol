# EJERCICIO 07: TARJETAS CRC Y DIAGRAMA UML

**Analista en Informática — Programación II**

### Integrantes

* Jeremías González¹
* Tamara Flores²
* Luis Orlando Cartagena³
* Lautaro Pereira Das Neves⁴

---

# Clases Padre

## Clase: `Personaje`

| Responsabilidades                                                                 | Colaboradores |
| --------------------------------------------------------------------------------- | ------------- |
| Gestionar el estado y la salud del personaje (nombre, vida actual y vida máxima). | `Item`        |
| Tener, quitar y cambiar elementos (`items`).                                      | `Personaje`   |
| Atacar.                                                                           |               |
| Curarse.                                                                          |               |
| Defenderse.                                                                       |               |

---

## Clase: `Item`

| Responsabilidades                                                          | Colaboradores |
| -------------------------------------------------------------------------- | ------------- |
| Proveer bonificaciones de ataque y defensa.                                | `Personaje`   |
| Administrar las propiedades e integridad del objeto (durabilidad, nombre). |               |

---

# Clases Hijas

## Clase: `Mago`

**Subclase de:** `Personaje`

| Responsabilidades                     | Colaboradores |
| ------------------------------------- | ------------- |
| Utilizar magia.                       | `Personaje`   |
| Interactuar con un libro de hechizos. | `Item`        |
| Aprender hechizos.                    |               |

---

## Clase: `Elfo`

**Subclase de:** `Personaje`

| Responsabilidades                 | Colaboradores |
| --------------------------------- | ------------- |
| Utilizar magia.                   | `Personaje`   |
| Ayudar a otros personajes.        | `Item`        |
| Equipar items.                    |               |
| Calcular el valor de los ataques. |               |

---

## Clase: `Enano`

**Subclase de:** `Personaje`

| Responsabilidades                               | Colaboradores |
| ----------------------------------------------- | ------------- |
| Utilizar armas y otros elementos.               | `Personaje`   |
| Activar habilidades de combate temperamentales. | `Item`        |
| Poseer alta resistencia corporal.               |               |

---

# Clases Hijas de `Item`

## Clase: `LibroDeHechizos`

**Subclase de:** `Item`

| Responsabilidades                  | Colaboradores        |
| ---------------------------------- | -------------------- |
| Contener hechizos.                 | `Hechizo`            |
| Agregar hechizos.                  | `Personaje` (`Mago`) |
| Proporcionar poder.                | `Hechizo`            |
| Proporcionar conocimiento al mago. |                      |

---

## Clase: `BastonMagico`

**Subclase de:** `Item`

| Responsabilidades                   | Colaboradores        |
| ----------------------------------- | -------------------- |
| Proveer un bono de potencia mágica. | `Personaje` (`Mago`) |
| Potenciar los hechizos y ataques.   |                      |
| Administrar sus propiedades únicas. |                      |

---

## Clase: `Ropa`

**Subclase de:** `Item`

| Responsabilidades                                   | Colaboradores |
| --------------------------------------------------- | ------------- |
| Incrementar la defensa y resistencia ante impactos. | `Personaje`   |
| Absorber parte del daño dirigido al personaje.      |               |

---

## Clase: `Arma`

**Subclase de:** `Item`

| Responsabilidades                        | Colaboradores |
| ---------------------------------------- | ------------- |
| Incrementar los puntos de ataque físico. | `Personaje`   |
| Gestionar el desgaste tras cada ataque.  |               |

---

# Clase Independiente

## Clase: `Hechizo`

| Responsabilidades                             | Colaboradores     |
| --------------------------------------------- | ----------------- |
| Contener el nombre del hechizo.               | `LibroDeHechizos` |
| Representar un hechizo individual del libro.  |                   |
| Contener el valor del hechizo (daño o poder). |                   |
| Gestionar el poder del hechizo.               |                   |
