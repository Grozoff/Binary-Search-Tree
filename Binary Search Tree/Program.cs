using System;
using System.Linq;

namespace Binary_Search_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = new BinarySearchTree();

            var numbersArray = new int[] { 90, 110, 80, 70, 115, 25, 87, 119, 59, 6 };

            foreach (var number in numbersArray)
            {
                root.AddItem(number);
            }

            var value = root.GetNodeByValue(70);

            root.RemoveItem(115);

            var array = root.GetTreeInLine();

            root.PrintTree();

            // Проход по дереву с выводом каждого шага
            Console.WriteLine("\nDFS:"); // DFS deep-first search
            Console.WriteLine(string.Join(" --> ", root.Dfs())+ "\n"); 
            Console.WriteLine("BFS:"); // BFS breadth-first search
            Console.WriteLine(string.Join(" --> ", root.Bfs()));
        }
    }
}
