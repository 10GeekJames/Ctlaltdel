For the next step, "Player Movement," you'll be adding functionality to allow a player character to move through the world you've created, respecting the walls and pathways. This involves handling user input for movement commands and updating the player's position in the game world.

### Expanding the Project

#### Step 1: Define the Player

First, you'll need a `Player` class to represent the player character in the game.

#### Player.cs

```csharp
namespace DragonsQuest
{
    public class Player
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Player(int initialX, int initialY)
        {
            X = initialX;
            Y = initialY;
        }

        public void Move(int deltaX, int deltaY)
        {
            X += deltaX;
            Y += deltaY;
        }
    }
}
```

In this class, `X` and `Y` represent the player's position in the world. The `Move` method changes the player's position based on the input.

#### Step 2: Update the World Class

Modify the `World` class to include a `Player` object and handle movement.

#### World.cs (Updated Sections)

Add a player field:

```csharp
private Player player;
```

In the `Initialize` method, instantiate the player:

```csharp
public void Initialize()
{
    // ... existing initialization code ...

    // Place the player in the starting position, e.g., (1, 1)
    player = new Player(1, 1);
}
```

Update the `DisplayWorld` method to show the player's position:

```csharp
public void DisplayWorld()
{
    for (int y = 0; y < Height; y++)
    {
        for (int x = 0; x < Width; x++)
        {
            if (player.X == x && player.Y == y)
            {
                Console.Write("P"); // Representing the Player
            }
            else
            {
                Console.Write(grid[x, y].IsPassable ? " " : "#");
            }
        }
        Console.WriteLine();
    }
}
```

#### Step 3: Handling Movement

In the `Program.cs`, you'll need to add a loop to handle user input and move the player.

#### Program.cs (Updated)

```csharp
static void Main(string[] args)
{
    World world = new World();
    world.Initialize();

    while (true)
    {
        Console.Clear();
        world.DisplayWorld();

        Console.WriteLine("Use WASD to move. Press 'Q' to quit.");
        char input = Console.ReadKey(true).KeyChar;

        switch (input)
        {
            case 'w':
                world.TryMovePlayer(0, -1);
                break;
            case 'a':
                world.TryMovePlayer(-1, 0);
                break;
            case 's':
                world.TryMovePlayer(0, 1);
                break;
            case 'd':
                world.TryMovePlayer(1, 0);
                break;
            case 'q':
                return;
        }
    }
}
```

#### Step 4: Implementing Movement Logic

Add a method in `World.cs` to handle player movement, ensuring they can't walk through walls.

#### World.cs (Additional Method)

```csharp
public void TryMovePlayer(int deltaX, int deltaY)
{
    int newX = player.X + deltaX;
    int newY = player.Y + deltaY;

    if (newX >= 0 && newX < Width && newY >= 0 && newY < Height && grid[newX, newY].IsPassable)
    {
        player.Move(deltaX, deltaY);
    }
}
```

### Conclusion

With these updates, your game now has a player character that can move around the world. The player's movement is constrained by the walls, and their position is updated in response to user input. This lays the foundation for more complex interactions and gameplay mechanics in future mini-adventures.