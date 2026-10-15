# Sistema de personajes de videojuego

## Descripción

Este proyecto consiste en el desarrollo de una aplicación de consola en C# que representa diferentes tipos de personajes de videojuegos mediante los conceptos fundamentales de la Programación Orientada a Objetos (POO).

El sistema permite crear guerreros, magos y arqueros, cada uno con características y comportamientos específicos. También incorpora habilidades especiales, control de vida, recepción de daño y administración de flechas.

## Objetivo

Aplicar los conceptos de Programación Orientada a Objetos mediante la construcción de un sistema que permita representar personajes de videojuegos, reutilizar código y demostrar diferentes comportamientos a través de la herencia y el polimorfismo.

## Tecnologías utilizadas

- **Lenguaje:** C#
- **Plataforma:** .NET
- **Tipo de aplicación:** Consola
- **Paradigma:** Programación Orientada a Objetos

## Características principales

- Creación de personajes de tipo Guerrero, Mago y Arquero.
- Visualización del nombre, la vida y el nivel de cada personaje.
- Ataques específicos según el tipo de personaje.
- Sistema de recepción de daño y control de vida.
- Habilidad de curación para el mago.
- Habilidad de defensa para el guerrero.
- Control de flechas disponibles para el arquero.
- Validación de los valores iniciales y de las acciones de los personajes.
- Recorrido de personajes mediante una colección de tipo `Personaje[]`.

## Conceptos de Programación Orientada a Objetos

El proyecto implementa los siguientes conceptos:

| Concepto | Descripción |
|---|---|
| Clases y objetos | Permiten representar y crear personajes del videojuego. |
| Encapsulamiento | Protege los atributos internos de cada personaje. |
| Propiedades | Controlan el acceso a los datos de los objetos. |
| Constructores | Inicializan las características de cada personaje. |
| Herencia | Guerrero, Mago y Arquero heredan de la clase Personaje. |
| Clase abstracta | Personaje define la estructura común de los personajes. |
| Método abstracto | Atacar() obliga a las clases derivadas a implementar su propio ataque. |
| Sobrescritura | `override` permite definir comportamientos específicos. |
| Interfaces | ICurable e IDefendible representan habilidades particulares. |
| Polimorfismo | Permite ejecutar diferentes ataques mediante una referencia común de tipo Personaje. |

## Estructura del sistema

### Clase abstracta Personaje

Contiene las propiedades comunes:

- Nombre
- Vida
- Nivel

También implementa los métodos `MostrarEstado()`, `Atacar()` como método abstracto y `RecibirDanio(int cantidad)`.

### Clase Guerrero

Hereda de `Personaje` e incorpora la propiedad `Fuerza`. Implementa el ataque con espada y la interfaz `IDefendible`, que proporciona el método `Defender()`.

### Clase Mago

Hereda de `Personaje` e incorpora la propiedad `Mana`. Implementa el ataque mediante hechizos y la interfaz `ICurable`, que proporciona el método `Curar()`.

### Clase Arquero

Hereda de `Personaje` e incorpora la propiedad `Flechas`. Su ataque consume una flecha por cada disparo y evita atacar cuando no quedan flechas disponibles.

### Interfaces

- `ICurable`: define la capacidad de recuperar vida.
- `IDefendible`: define la capacidad de defenderse.

## Requisitos

Para ejecutar el proyecto se necesita:

- Tener instalado el SDK de .NET.
- Disponer de un editor compatible con C#, como Visual Studio o Visual Studio Code.
- Contar con el código fuente del proyecto.

## Instalación y ejecución

1. Clonar el repositorio:

   ```bash
   git clone https://github.com/stevenagamez/Sistema-de-personajes-de-videojuego.git
   ```

2. Ingresar a la carpeta del proyecto:

   ```bash
   cd Sistema-de-personajes-de-videojuego
   ```

3. Si el proyecto contiene un archivo `.csproj`, ejecutar:

   ```bash
   dotnet run
   ```

   Si únicamente se dispone del archivo `Program.cs`, primero se debe crear un proyecto de consola:

   ```bash
   dotnet new console
   ```

   Después, reemplazar el contenido de `Program.cs` por el código del sistema y ejecutar:

   ```bash
   dotnet run
   ```

## Funcionamiento

Al ejecutar el programa, se crean tres personajes:

- **Kratos:** guerrero con fuerza y habilidad de defensa.
- **Merlín:** mago con maná y capacidad de curación.
- **Legolas:** arquero que utiliza flechas para atacar.

El programa muestra el estado inicial de cada personaje, ejecuta sus ataques y prueba las habilidades especiales. También comprueba la disminución de flechas, la recuperación de vida y la recepción de daño.

## Polimorfismo

El polimorfismo se demuestra mediante una colección de tipo `Personaje[]` que contiene objetos de las tres clases derivadas.

```csharp
foreach (Personaje personaje in personajes)
{
    personaje.MostrarEstado();
    personaje.Atacar();
}
```

Aunque todos los elementos se manejan mediante el tipo `Personaje`, cada objeto ejecuta su propia implementación del método `Atacar()`.

## Autor

**Steven Andrés Agámez Orozco**

Proyecto académico desarrollado para aplicar los fundamentos de la Programación Orientada a Objetos en C#.

## Estado del proyecto

Proyecto académico funcional que demuestra la implementación de clases, herencia, encapsulamiento, abstracción, interfaces y polimorfismo.
