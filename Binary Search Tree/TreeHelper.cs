using System.Collections.Generic;

namespace Binary_Search_Tree
{
    public static class TreeHelper
    {
        public static (int depth, int nodeValue)[] GetTreeInLine(this ITree tree)
        {
            var buffer = new Queue<NodeInfo>();
            var returnArray = new List<(int, int)>();
            var root = new NodeInfo() { Node = tree.GetRoot() };
            buffer.Enqueue(root);

            while (buffer.Count != 0)
            {
                var element = buffer.Dequeue();
                returnArray.Add(element);

                var depth = element.Depth + 1;

                if (element.Node.LeftChild != null)
                {
                    var left = new NodeInfo(depth, element.Node.LeftChild);
                    buffer.Enqueue(left);
                }

                if (element.Node.RightChild == null) continue;

                var right = new NodeInfo(depth, element.Node.RightChild);
                buffer.Enqueue(right);
            }

            return returnArray.ToArray();
        }
    }
}
