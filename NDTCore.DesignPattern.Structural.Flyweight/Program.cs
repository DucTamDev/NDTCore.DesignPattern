namespace NDTCore.DesignPattern.Structural.Flyweight
{
    using System;
    using System.Collections.Generic;

    // Flyweight class (TreeType)
    public class TreeType
    {
        public string Name { get; }
        public string Color { get; }
        public string Texture { get; }

        public TreeType(string name, string color, string texture)
        {
            Name = name;
            Color = color;
            Texture = texture;
        }

        public void Draw(int x, int y)
        {
            Console.WriteLine($"Drawing tree [{Name}, {Color}, {Texture}] at ({x}, {y})");
        }
    }

    // Flyweight Factory (TreeFactory)
    public class TreeFactory
    {
        private static readonly Dictionary<string, TreeType> _treeTypes = new();

        public static TreeType GetTreeType(string name, string color, string texture)
        {
            string key = $"{name}_{color}_{texture}";

            if (!_treeTypes.ContainsKey(key))
            {
                _treeTypes[key] = new TreeType(name, color, texture);
                Console.WriteLine($"Created new TreeType: {name} - {color} - {texture}");
            }

            return _treeTypes[key];
        }
    }

    // Context class (Tree)
    public class Tree
    {
        public int X { get; }
        public int Y { get; }
        public TreeType Type { get; }

        public Tree(int x, int y, TreeType type)
        {
            X = x;
            Y = y;
            Type = type;
        }

        public void Draw()
        {
            Type.Draw(X, Y);
        }
    }

    // Client class (Forest)
    public class Forest
    {
        private readonly List<Tree> _trees = new();

        public void PlantTree(int x, int y, string name, string color, string texture)
        {
            TreeType type = TreeFactory.GetTreeType(name, color, texture);
            Tree tree = new Tree(x, y, type);
            _trees.Add(tree);
        }

        public void Draw()
        {
            foreach (var tree in _trees)
            {
                tree.Draw();
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Forest forest = new();

            forest.PlantTree(10, 20, "Oak", "Green", "Rough");
            forest.PlantTree(15, 30, "Oak", "Green", "Rough");
            forest.PlantTree(40, 50, "Pine", "Dark Green", "Smooth");

            forest.Draw();
        }
    }
}