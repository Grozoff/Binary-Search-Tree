using System;
using System.Collections.Generic;

namespace Binary_Search_Tree
{
    public static class TreeHelper
    {
        public static int answer = 0;

        /// <summary>
        /// Найти путь с максимальной суммой значений ноды. <br/>
        /// Значения в нодах могут быть отрицательными. <br/>
        /// Не обязательно доходить до последнего листа.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int MaxPathSumHardVersion(this TreeNode root)
        {
            Helper(root);
            return answer;
        }

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

        /// <summary>
        /// Найти путь с максимальной суммой значений нодов.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int MaxPathSum(this TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int maxLeftPath = MaxPathSum(root.LeftChild);
            int maxRightPath = MaxPathSum(root.RightChild);

            return Math.Max(maxLeftPath, maxRightPath) + root.Value;
        }

        private static int Helper(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int maxLeftPath = Math.Max(Helper(root.LeftChild), 0);
            int maxRightPath = Math.Max(Helper(root.RightChild), 0);
            answer = Math.Max(answer, maxLeftPath + maxRightPath + root.Value);
            return Math.Max(maxLeftPath, maxRightPath) + root.Value;
        }
    }
}
