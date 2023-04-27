using System;

namespace Binary_Search_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            var root = new BinarySearchTree();
            root.GrowRandomTree(10, 1, 10);
            root.BalanceTree();
            root.PrintTree();

            Console.WriteLine("\nDFS:"); // DFS deep-first search
            Console.WriteLine(string.Join(" --> ", root.GetDfsWay()) + "\n");
            Console.WriteLine("BFS:"); // BFS breadth-first search
            Console.WriteLine(string.Join(" --> ", root.GetBfsWay()));
        }
    }
}
