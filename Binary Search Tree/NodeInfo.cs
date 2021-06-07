namespace Binary_Search_Tree
{
    public class NodeInfo
    {
        public int Depth { get; set; }
        public TreeNode Node { get; set; }
        public NodeInfo() { }
        public NodeInfo(int depth, TreeNode node)
        {
            Depth = depth;
            Node = node;
        }

        public static implicit operator (int, int)(NodeInfo nodeInfo)
        {
            return (nodeInfo.Depth, nodeInfo.Node.Value);
        }
    }
}
