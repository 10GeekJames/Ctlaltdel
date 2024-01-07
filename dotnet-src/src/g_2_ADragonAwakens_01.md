Let's continue with "Mini-Adventure 2: The Dragon Awakens." In this phase, you'll set up the initial game environment, introduce the player character as a dragon, and implement basic concepts like energy and movement.

### Step 1: Define the Dragon Player

First, you'll need to modify the `Player` class to represent a dragon and include an energy attribute.

#### Dragon.cs

```csharp
namespace DragonsQuest
{
    public class Dragon
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Energy { get; private set; }

        public Dragon(int initialX, int initialY, int initialEnergy)
        {
            X = initialX;
            Y = initialY;
            Energy = initialEnergy;
        }

        public void Move(int deltaX, int deltaY)
        {
            X += deltaX;
            Y += deltaY;
            Energy--; // Moving costs energy
        }

        // Additional methods related to energy can be added here
    }
}
```

In this class, `Energy` represents the dragon's current energy level. Moving the dragon decreases its energy.

### Step 2: Update the World Class

Modify the `World` class to include a `Dragon` object instead of a `Player` and handle the dragon's energy.

#### World.cs (Updated Sections)

Replace the `Player` object with a `Dragon`:

```csharp
private Dragon dragon;
```

In the `Initialize` method, instantiate the dragon:

```csharp
public void Initialize()
{
    // ... existing initialization code ...

    // Place the dragon in the starting position, e.g., (1, 1), with initial energy
    dragon = new Dragon(1, 1, 100); // Starting with 100 energy
}
```

Update the `DisplayWorld` method to show the dragon's position:

```csharp
public void DisplayWorld()
{
    for (int y = 0; y < Height; y++)
    {
        for (int x = 0; x < Width; x++)
        {
            if (dragon.X == x && dragon.Y == y)
            {
                Console.Write("D"); // Representing the Dragon
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

### Step 3: Handling Movement and Energy

Update the `Program.cs` to handle the dragon's movement and display energy levels.

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
        Console.WriteLine($"Energy: {world.Dragon.Energy}");

        if (world.Dragon.Energy <= 0)
        {
            Console.WriteLine("You have run out of energy. Game over.");
            break;
        }

        Console.WriteLine("Use WASD to move. Press 'Q' to quit.");
        char input = Console.ReadKey(true).KeyChar;

        switch (input)
        {
            case 'w':
                world.TryMoveDragon(0, -1);
                break;
            case 'a':
                world.TryMoveDragon(-1, 0);
                break;
            case 's':
                world.TryMoveDragon(0, 1);
                break;
            case 'd':
                world.TryMoveDragon(1, 0);
                break;
            case 'q':
                return;
        }
    }
}
```

### Step 4: Implementing Movement Logic with Energy

Modify the `TryMoveDragon` method in `World.cs` to ensure the dragon's energy is considered during movement.

#### World.cs (Additional Method)

```csharp
public void TryMoveDragon(int deltaX, int deltaY)
{
    int newX = dragon.X + deltaX;
    int newY = dragon.Y + deltaY;

    if (newX >= 0 && newX < Width && newY >= 0 && newY < Height && grid[newX, newY].IsPassable)
    {
        dragon.Move(deltaX, deltaY);
    }
}
```

### Conclusion

With these updates, your game now features a dragon character with energy mechanics. The dragon can move around the world, and each movement costs energy. This lays the groundwork for further gameplay elements like searching for food to replenish energy, encountering challenges, and exploring the world. As you progress through the mini-adventures, you can continue to build upon this foundation, adding complexity and depth to your game.









Let's expand "Mini-Adventure 2: The Dragon Awakens" to include more detailed mechanics like energy costs based on inventory weight, as well as the foundations for eating, healing, and dealing with injuries. We'll build upon the existing classes and introduce new concepts and functionalities.

### Step 1: Enhance the Dragon Class

First, we'll modify the `Dragon` class to include inventory weight and methods for eating and healing.

#### Dragon.cs

```csharp
using System.Collections.Generic;

namespace DragonsQuest
{
    public class Dragon
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Energy { get; private set; }
        public int Health { get; private set; }
        private List<Item> inventory;

        public Dragon(int initialX, int initialY)
        {
            X = initialX;
            Y = initialY;
            Energy = 100; // Starting energy
            Health = 100; // Starting health
            inventory = new List<Item>();
        }

        public void Move(int deltaX, int deltaY)
        {
            int weight = CalculateInventoryWeight();
            int energyCost = 1 + weight / 10; // Example: energy cost increases with weight

            if (Energy >= energyCost)
            {
                X += deltaX;
                Y += deltaY;
                Energy -= energyCost;
            }
        }

        public void Eat(Item food)
        {
            if (food.Type == ItemType.Food)
            {
                Energy += food.Value; // Restore energy based on food value
                if (Energy > 100) Energy = 100; // Cap energy at 100
            }
        }

        public void Heal(int amount)
        {
            Health += amount;
            if (Health > 100) Health = 100; // Cap health at 100
        }

        public void AddToInventory(Item item)
        {
            inventory.Add(item);
        }

        private int CalculateInventoryWeight()
        {
            int totalWeight = 0;
            foreach (var item in inventory)
            {
                totalWeight += item.Weight;
            }
            return totalWeight;
        }
    }
}
```

#### Item.cs

```csharp
namespace DragonsQuest
{
    public enum ItemType
    {
        Food,
        Treasure,
        Equipment
    }

    public class Item
    {
        public ItemType Type { get; private set; }
        public int Weight { get; private set; }
        public int Value { get; private set; }

        public Item(ItemType type, int weight, int value)
        {
            Type = type;
            Weight = weight;
            Value = value;
        }
    }
}
```

### Step 2: Update the World Class

Modify the `World` class to handle new dragon actions like eating and healing.

#### World.cs (Updated Sections)

Add methods for dragon actions:

```csharp
public void DragonEat(Item food)
{
    dragon.Eat(food);
}

public void DragonHeal(int amount)
{
    dragon.Heal(amount);
}
```

### Step 3: Handling Movement and Actions in Program.cs

Update `Program.cs` to include new actions and display health and energy.

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
        Console.WriteLine($"Energy: {world.Dragon.Energy}, Health: {world.Dragon.Health}");

        if (world.Dragon.Energy <= 0)
        {
            Console.WriteLine("You have run out of energy. Game over.");
            break;
        }

        Console.WriteLine("Use WASD to move, 'E' to eat, 'H' to heal, 'Q' to quit.");
        char input = Console.ReadKey(true).KeyChar;

        switch (input)
        {
            case 'w': world.TryMoveDragon(0, -1); break;
            case 'a': world.TryMoveDragon(-1, 0); break;
            case 's': world.TryMoveDragon(0, 1); break;
            case 'd': world.TryMoveDragon(1, 0); break;
            case 'e': 
                // Example: Eat an item (you'll need to define how the dragon gets food)
                world.DragonEat(new Item(ItemType.Food, 1, 20)); 
                break;
            case 'h': 
                // Example: Heal (you'll need to define how the dragon gets healing items)
                world.DragonHeal(10); 
                break;
            case 'q': return;
        }
    }
}
```

### Conclusion

With these updates, your game now features a dragon character with energy and health mechanics, affected by inventory weight and actions like eating and healing. This lays the groundwork for more complex gameplay elements such as managing resources, exploring for food and healing items, and dealing with the consequences of carrying too much weight.

As you continue developing the game, you can add more features like different types of food and healing items, injuries from battles, and more sophisticated inventory management. This approach provides a solid foundation for building a rich and engaging game world.