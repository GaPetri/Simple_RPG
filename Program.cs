using System;
using System.Threading;

// Abstrakte Klasse Character definiert die Eigenschaften und Methoden aller Charaktere im Spiel
public abstract class Character
{// Eigenschaften des Charakters
    public string Name { get; set; }
    public int Health { get; set; }
    public int Strength { get; set; }
    public int Magic { get; set; }
    public int Agility { get; set; }
    public int Experience { get; set; }
    public int Level { get; set; }
    // Abstrakte Methoden, die von den Unterklassen implementiert werden müssen
    public abstract void Attack();
    public abstract void SpecialAbility();
    public abstract void Defend();
    public abstract void Heal();
    // Methode zum Hinzufügen von Erfahrungspunkten und Levelaufstieg
    public void GainExperience(int experience)
    {
        Experience += experience;
        if (Experience >= Level * 100)
        {
            LevelUp();
        }
    }
    // Methode zum Levelaufstieg
    public void LevelUp()
    {
        // Nach den ersten drei Gegnern, Charakter auf Level 4 bringen
        if (Level == 3)
        {
            Level = 4;
            Experience = 0; // Erfahrungspunkte für den nächsten Level zurücksetzen
        }
        // Nach dem ersten Boss, Charakter auf Level 5 bringen
        else if (Level == 4)
        {
            Level = 5;
            Experience = 0; // Erfahrungspunkte für den nächsten Level zurücksetzen
        }
        // Nach dem zweiten Boss, Charakter auf Level 10 bringen
        else if (Level == 9)
        {
            Level = 10;
            Experience = 0; // Erfahrungspunkte für den nächsten Level zurücksetzen
        }
        // Nach dem dritten Boss, Charakter auf Level 15 bringen
        else if (Level == 14)
        {
            Level = 15;
            Experience = 0; // Erfahrungspunkte für den nächsten Level zurücksetzen
        }
        else
        {
            Level++; // Standard-Levelaufstieg
        }

        // Attribute entsprechend erhöhen
        Health += 10;
        Strength += 2;
        Magic += 2;
        Agility += 2;

        PrintWithDelay($"Level up! You are now level {Level}.", 50);
    }
    // Hilfsmethode zum Ausgeben von Text mit Verzögerung
    public static void PrintWithDelay(string text, int delay)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(delay);
        }
        Console.WriteLine();
    }
}
// Unterklassen, die spezifische Charaktertypen repräsentieren (Krieger, Magier, Bogenschütze)
public class Warrior : Character
{// Konstruktor initialisiert Attribute für Krieger
    // Überschreiben von abstrakten Methoden mit spezifischen Aktionen für den Krieger
    public Warrior(string name)
    {
        Name = name;
        Health = 100;
        Strength = 18;
        Magic = 10;
        Agility = 12;
        Experience = 0;
        Level = 1;
    }

    public override void Attack() => PrintWithDelay("You attack with your sword!", 50);
    public override void SpecialAbility() => PrintWithDelay("You perform a mighty strike!", 50);
    public override void Defend() => PrintWithDelay("You raise your shield to defend yourself!", 50);
    public override void Heal() => PrintWithDelay("You use a potion to heal yourself!", 50);
}

public class Mage : Character
{ // Konstruktor initialisiert Attribute für Magier
    // Überschreiben von abstrakten Methoden mit spezifischen Aktionen für den Magier

public Mage(string name)
    {
        Name = name;
        Health = 80;
        Strength = 12;
        Magic = 18;
        Agility = 10;
        Experience = 0;
        Level = 1;
    }

    public override void Attack() => PrintWithDelay("You cast a fireball!", 50);
    public override void SpecialAbility() => PrintWithDelay("You unleash a powerful spell!", 50);
    public override void Defend() => PrintWithDelay("You cast a protective barrier!", 50);
    public override void Heal() => PrintWithDelay("You cast a healing spell on yourself!", 50);
}

public class Archer : Character
{    // Konstruktor initialisiert Attribute für Bogenschützen
    // Überschreiben von abstrakten Methoden mit spezifischen Aktionen für den Bogenschützen

    public Archer(string name)
    {
        Name = name;
        Health = 90;
        Strength = 15;
        Magic = 12;
        Agility = 15;
        Experience = 0;
        Level = 1;
    }

    public override void Attack() => PrintWithDelay("You shoot an arrow!", 50);
    public override void SpecialAbility() => PrintWithDelay("You perform a rapid shot!", 50);
    public override void Defend() => PrintWithDelay("You dodge swiftly!", 50);
    public override void Heal() => PrintWithDelay("You use a healing herb!", 50);
}
// Feindklasse, die Gegner im Spiel repräsentiert
public class Enemy
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Strength { get; set; }

    public Enemy(string name, int health, int strength)
    {
        Name = name;
        Health = health;
        Strength = strength;
    }

    public virtual void Attack(Character character)
    {
        int damage = Strength;
        character.Health -= damage;
        Character.PrintWithDelay($"{Name} attacks and deals {damage} damage!", 50);
    }

    public virtual void SpecialAbility(Character character)
    {
        int damage = Strength * 2;
        character.Health -= damage;
        Character.PrintWithDelay($"{Name} uses a special ability and deals {damage} damage!", 50);
    }

    public virtual void Defend()
    {
        Character.PrintWithDelay($"{Name} defends!", 50);
    }

    public virtual void Heal()
    {
        Health += 20;
        Character.PrintWithDelay($"{Name} heals for 20 health!", 50);
    }
}
// Klasse für spezielle Gegner (Dämon), die zusätzliche Aktionen ausführen können
public class Demon : Enemy
{
    public Demon(string name, int health, int strength) : base(name, health, strength)
    {
    }

    public void Act(Character character)
    {
        Random random = new Random();
        int action = random.Next(100);

        if (action < 50 && Health < Health / 2)
        {
            Heal();
        }
        else if (action < 80)
        {
            Attack(character);
        }
        else
        {
            Defend();
        }
    }
}

public class Game
{
    public Character Character { get; set; }
    public Enemy CurrentEnemy { get; set; }
    public int CurrentLocation { get; set; }

    public Game(Character character)
    {
        Character = character;
        CurrentEnemy = new Enemy("", 0, 0);
        CurrentLocation = 1;
    }
    // Spielklasse, die den Spielablauf steuert
    public void StartGame()
    {
        Character.PrintWithDelay("Welcome to SimpleRPG!", 50);
        Character.PrintWithDelay($"You are {Character.Name} and have the following attributes:", 50);
        Character.PrintWithDelay($"Health: {Character.Health}", 50);
        Character.PrintWithDelay($"Strength: {Character.Strength}", 50);
        Character.PrintWithDelay($"Magic: {Character.Magic}", 50);
        Character.PrintWithDelay($"Agility: {Character.Agility}", 50);

        ShowLocationDescription();

        while (true)
        {
            Character.PrintWithDelay("What would you like to do?", 50);
            Character.PrintWithDelay("1. Explore", 50);
            Character.PrintWithDelay("2. Look for a fight", 50);
            Character.PrintWithDelay("3. Save game", 50);
            Character.PrintWithDelay("4. Exit", 50);

            string input = Console.ReadLine().ToLower();

            switch (input)
            {
                case "1":
                case "explore":
                    Explore();
                    break;
                case "2":
                case "fight":
                    Fight();
                    break;
                case "3":
                case "save":
                    SaveGame();
                    break;
                case "4":
                case "exit":
                    Environment.Exit(0);
                    break;
                default:
                    Character.PrintWithDelay("Invalid input!", 50);
                    break;
            }
        }
    }

    public void Explore()
    {
        ShowLocationDescription();

        if (CurrentLocation == 1)
        {
            Character.PrintWithDelay("You explore the surroundings...", 50);
            Character.PrintWithDelay("You see some slimes, wolves, and bees.", 50);
            Character.PrintWithDelay("You decide to fight the Kobold.", 50);
            CurrentEnemy = new Enemy("Kobold", 20, 5);
            Fight();
            if (CurrentEnemy.Health <= 0)
            {
                CurrentLocation = 2;
                Character.GainExperience(400);
            }
        }
        else if (CurrentLocation == 2)
        {
            Character.PrintWithDelay("You explore the surroundings...", 50);
            Character.PrintWithDelay("You see some snakes, scorpions, and vultures.", 50);
            Character.PrintWithDelay("You decide to fight the Sandworm.", 50);
            CurrentEnemy = new Enemy("Sandworm", 30, 10);
            Fight();
            if (CurrentEnemy.Health <= 0)
            {
                CurrentLocation = 3;
                Character.GainExperience(500);
            }
        }
        else if (CurrentLocation == 3)
        {
            Character.PrintWithDelay("You explore the surroundings...", 50);
            Character.PrintWithDelay("You see some goblins, spiders, and bats.", 50);
            Character.PrintWithDelay("You decide to fight the Skeleton Warrior.", 50);
            CurrentEnemy = new Enemy("Skeleton Warrior", 40, 15);
            Fight();
            if (CurrentEnemy.Health <= 0)
            {
                CurrentLocation = 4;
                Character.GainExperience(500);
            }
        }
        else if (CurrentLocation == 4)
        {
            Character.PrintWithDelay("You explore the surroundings...", 50);
            Character.PrintWithDelay("You see an abandoned castle.", 50);
            string input = "";
            do
            {
                Character.PrintWithDelay("Do you want to search for the Demon? (yes/no)", 50);
                input = Console.ReadLine().ToLower();
            } while (input != "yes" && input != "no");

            if (input == "yes")
            {
                CurrentEnemy = new Demon("Demon", Character.Health + 2, Character.Strength + 2);
                Fight();
                if (CurrentEnemy.Health <= 0)
                {
                    Character.PrintWithDelay("Congratulations, you have won the game!", 50);
                    Environment.Exit(0);
                }
            }
            else
            {
                Character.PrintWithDelay("You decide to leave the castle.", 50);
            }
        }
    }

    public void ShowLocationDescription()
    {
        if (CurrentLocation == 1)
        {
            Character.PrintWithDelay("Welcome to Firstia.", 50);
            Character.PrintWithDelay("Firstia is a medieval-themed town with wooden cottages built by early settlers. Surrounded by nature, it exudes a peaceful and rustic charm.", 50);
        }
        else if (CurrentLocation == 2)
        {
            Character.PrintWithDelay("Welcome to Secondil.", 50);
            Character.PrintWithDelay("Secondil is a more structured city with wooden and brick constructions. Street lamps light up the streets, and outdoor stalls sell various goods. The city has inns, bars, florists, and an armor shop. A castle stands on a hill in the center.", 50);
        }
        else if (CurrentLocation == 3)
        {
            Character.PrintWithDelay("Welcome to Thirdrema.", 50);
            Character.PrintWithDelay("Thirdrema is a well-developed stone city located between mountain cliffs and forest trees. The houses have white walls with red, orange, or blue rooftops. Some houses are built on flat ground, while others are built on hills. A large castle structure stands at the back, surrounded by nobility.", 50);
        }
        else if (CurrentLocation == 4)
        {
            Character.PrintWithDelay("Welcome to the Prismatic Forest Grotto.", 50);
            Character.PrintWithDelay("The Prismatic Forest Grotto is a vast forest covered by countless blooming flowers. It has a labyrinthine cave with a flower-carpeted ground, full of colorful plants and trees, giving it an ancient forest appearance. A secret spot called the Hidden Tunnel can be found inside.", 50);
        }
    }

    public void Fight()
    {
        if (CurrentEnemy == null || CurrentEnemy.Health <= 0)
        {
            Character.PrintWithDelay("There's no enemy to fight!", 50);
            return;
        }

        while (CurrentEnemy.Health > 0 && Character.Health > 0)
        {
            Character.PrintWithDelay($"You are fighting {CurrentEnemy.Name}!", 50);
            Character.PrintWithDelay("What would you like to do?", 50);
            Character.PrintWithDelay("1. Attack", 50);
            Character.PrintWithDelay("2. Special Ability", 50);
            Character.PrintWithDelay("3. Defend", 50);
            Character.PrintWithDelay("4. Heal", 50);

            string input = Console.ReadLine().ToLower();

            switch (input)
            {
                case "1":
                case "attack":
                    Character.Attack();
                    CurrentEnemy.Health -= Character.Strength;
                    break;
                case "2":
                case "special":
                    Character.SpecialAbility();
                    CurrentEnemy.Health -= Character.Strength * 2;
                    break;
                case "3":
                case "defend":
                    Character.Defend();
                    break;
                case "4":
                case "heal":
                    Character.Heal();
                    Character.Health += 20;
                    break;
                default:
                    Character.PrintWithDelay("Invalid input!", 50);
                    break;
            }

            if (CurrentEnemy.Health > 0)
            {
                if (CurrentEnemy is Demon demon)
                {
                    demon.Act(Character);
                }
                else
                {
                    CurrentEnemy.Attack(Character);
                }
            }

            if (Character.Health <= 0)
            {
                Character.PrintWithDelay("You have been defeated!", 50);
                Environment.Exit(0);
            }
        }

        if (CurrentEnemy.Health <= 0)
        {
            Character.PrintWithDelay($"You have defeated {CurrentEnemy.Name}!", 50);
            Character.GainExperience(CurrentEnemy.Health * 10);
            CurrentEnemy = null;
        }
    }

    public void SaveGame()
    {
        Character.PrintWithDelay("Saving game...", 50);
        string filePath = "savegame.txt";
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine(Character.Name);
            writer.WriteLine(Character.Health);
            writer.WriteLine(Character.Strength);
            writer.WriteLine(Character.Magic);
            writer.WriteLine(Character.Agility);
            writer.WriteLine(Character.Experience);
            writer.WriteLine(Character.Level);
            writer.WriteLine(CurrentLocation);
            writer.WriteLine(CurrentEnemy?.Name);
            writer.WriteLine(CurrentEnemy?.Health);
            writer.WriteLine(CurrentEnemy?.Strength);
        }
        Character.PrintWithDelay("Game saved!", 50);
    }

    public void LoadGame()
    {
        Character.PrintWithDelay("Loading game...", 50);
        string filePath = "savegame.txt";
        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                Character.Name = reader.ReadLine();
                Character.Health = int.Parse(reader.ReadLine());
                Character.Strength = int.Parse(reader.ReadLine());
                Character.Magic = int.Parse(reader.ReadLine());
                Character.Agility = int.Parse(reader.ReadLine());
                Character.Experience = int.Parse(reader.ReadLine());
                Character.Level = int.Parse(reader.ReadLine());
                CurrentLocation = int.Parse(reader.ReadLine());
                CurrentEnemy = new Enemy(reader.ReadLine(), int.Parse(reader.ReadLine()), int.Parse(reader.ReadLine()));
            }
            Character.PrintWithDelay("Game loaded!", 50);
        }
        else
        {
            Character.PrintWithDelay("No saved game found!", 50);
        }
    }
}

class Program
{
    static void PrintWithDelay(string text, int delay)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(delay);
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        PrintWithDelay(" ##########################################################################", 2);
        PrintWithDelay(" #                                                                        #", 2);
        PrintWithDelay(" #    ____    _                       _          ____    ____     ____    #", 2);
        PrintWithDelay(" #   / ___|  (_)  _ __ ___    _ __   | |   ___  |  _ \\  |  _ \\   / ___|   #", 2);
        PrintWithDelay(" #   \\___ \\  | | | '_ ` _ \\  | '_ \\  | |  / _ \\ | |_) | | |_) | | |  _    #", 2);
        PrintWithDelay(" #    ___) | | | | | | | | | | |_) | | | |  __/ |  _ <  |  __/  | |_| |   #", 2);
        PrintWithDelay(" #   |____/  |_| |_| |_| |_| | .__/  |_|  \\___| |_| \\_\\ |_|      \\____|   #", 2);
        PrintWithDelay(" #                           |_|                                          #", 2);
        PrintWithDelay(" #                                                                        #", 2);
        PrintWithDelay(" #                                                                        #", 2);
        PrintWithDelay(" #                                                                        #", 2);
        PrintWithDelay(" ##########################################################################", 2);

        Console.SetCursorPosition(0, Console.CursorTop - 3);
        while (!Console.KeyAvailable)
        {
            Thread.Sleep(500);
            Console.WriteLine(" #                                                                        #");
            Thread.Sleep(500);
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.WriteLine(" #                       Press any key to continue...                     #");
            Thread.Sleep(500);
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }
        Console.ReadKey();

        // Clear the console
        Console.Clear();

        PrintWithDelay("Welcome To The World of Yggdrasil", 50);
        Thread.Sleep(2500);
        Console.WriteLine(" ");
        PrintWithDelay("I'll introduce myself!", 50);
        Thread.Sleep(2000);
        PrintWithDelay("My name is Pixel!!!!!", 50);
        Thread.Sleep(3000);
        PrintWithDelay("I am your Helper and Navigator Fairy!", 50);
        Thread.Sleep(2400);
        PrintWithDelay("From now on I will accompany you on your Journey!!!", 50);
        Thread.Sleep(2800);
        Console.WriteLine(" ");

        PrintWithDelay("Now please tell me your Name, Traveler...", 50);

        string name;
        do
        {

            name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name cannot be empty. Please enter a valid name.");
            }
            else if (!name.All(char.IsLetter))
            {
                Console.WriteLine("Name must contain only letters. Please enter a valid name.");
            }
        } while (string.IsNullOrWhiteSpace(name) || !name.All(char.IsLetter));

        PrintWithDelay("One more question, Dear Traveler. If your friends were in danger...", 50);
        Thread.Sleep(1000);
        PrintWithDelay("Would you choose a sword to fight the enemy, a bow to fight from afar, or a staff to harness powerful magic?", 50);
        Thread.Sleep(1000);

        string input = Console.ReadLine().ToLower();

        Character character;

        switch (input)
        {
            case "sword":
                character = new Warrior(name);
                break;
            case "bow":
                character = new Archer(name);
                break;
            case "staff":
                character = new Mage(name);
                break;
            default:
                PrintWithDelay("Invalid input!", 50);
                return;
        }

        Game game = new Game(character);

        Character.PrintWithDelay("Do you want to load a saved game? (yes/no)", 50);
        string loadInput = Console.ReadLine().ToLower();
        if (loadInput == "yes")
        {
            game.LoadGame();
        }
        game.StartGame();
    }
}