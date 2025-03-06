# LinCityCS

LinCityCS is a C# port of the original LinCity-NG city simulation game. This project aims to replicate the core functionality of the original C++ implementation while leveraging C#-friendly technologies like MonoGame for rendering.

## Project Structure

The solution is organized into the following projects:

- **LinCityCS.SimulationCore**: Contains the core simulation components such as the city/map, tiles, buildings, simulation engine, event management, and resource management.
- **LinCityCS.RenderingUI**: Handles rendering, input processing, and UI components using MonoGame.
- **LinCityCS.Utilities**: Provides supporting functionality like configuration, asset loading, and logging.
- **LinCityCS.Game**: The main entry point for the game, integrating the simulation and rendering components.
- **LinCityCS.Tests**: Contains unit tests for verifying the behavior of the simulation components.

## Core Components

### Simulation Core

- **World**: Manages the layout of the city, including a grid of tiles.
- **MapTile**: Represents individual units or cells in the city grid, which can host terrain, buildings, or other features.
- **Construction**: Base class for all constructions (buildings, roads, etc.) that can be placed in the city.
- **ConstructionGroup**: Defines the properties and behaviors of a type of construction.
- **SimulationEngine**: Drives the simulation updates (ticks), coordinating changes across the city, tiles, and buildings.
- **CommodityManager**: Manages the flow of resources like food, labor, goods, etc. between constructions.
- **Economy**: Handles the financial aspects of the simulation, including taxes, expenses, and income.

### Building Types

The game includes various types of buildings, each with specific behaviors:

- **Residences**: Housing for the city's population, consuming resources and producing labor.
- **Power Plants**: Generate electricity for the city (coal, solar, wind).
- **Industry**: Produces goods and materials (light and heavy industry).
- **Markets**: Distribute resources to nearby residences and businesses.
- **Transport**: Infrastructure for moving people and goods (roads, rails).

### Rendering and UI

- **GameRenderer**: Renders the visual representation of the city using MonoGame.
- **Camera**: Manages the view of the city, including panning and zooming.
- **InputManager**: Captures and processes user inputs (keyboard, mouse).
- **UIManager**: Coordinates the display and interaction with UI elements.
- **UI Components**: Various UI elements like panels, buttons, labels, etc.

## Building and Running

### Prerequisites

- .NET 6.0 SDK or later
- MonoGame 3.8 or later

### Building the Project

```bash
dotnet build
```

### Running the Game

```bash
dotnet run --project LinCityCS.Game
```

### Running the Tests

```bash
dotnet test
```

## Architecture

The project follows a modular architecture with clear separation of concerns:

1. **Simulation Layer**: Handles the game logic, state management, and simulation updates.
2. **Rendering Layer**: Responsible for displaying the game state to the user.
3. **Input Layer**: Processes user inputs and translates them into game actions.
4. **UI Layer**: Manages the user interface elements and interactions.

This separation allows for easier maintenance, testing, and extension of the codebase.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the same license as the original LinCity-NG project.

## Acknowledgments

- The original LinCity-NG developers for creating the game.
- The MonoGame community for providing a great framework for game development in C#.
