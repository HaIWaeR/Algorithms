namespace BinarySearchTreeTrain
{
    class BinarySearchTree
    {
        class TreeNode
        {
            public int Value;
            public TreeNode? Left = null;
            public TreeNode? Right = null;
            public TreeNode(int value) => Value = value;
        }
        private TreeNode? root = null;
        // -------------------------------------------------------------------------------------------
        private TreeNode Insert(TreeNode? node, int value)
        {
            if (node == null)
                return new TreeNode(value);

            if (value < node.Value)
            {
                node.Left = Insert(node.Left, value);
            }
            else
            {
                if (value > node.Value)
                {
                    node.Right = Insert(node.Right, value);
                }
            }
            return node;
        }
        public void Insert(int value)
        {
            root = Insert(root, value);
        }
        // -------------------------------------------------------------------------------------------
        private bool Contains(TreeNode? node, int value)
        {
            if (node == null) return false;
            if (value == node.Value) return true;
            return value < node.Value ? Contains(node.Left, value) : Contains(node.Right, value);
        }
        public bool Contains(int value)
        {
            return Contains(root, value);
        }
        // -------------------------------------------------------------------------------------------
        private int FindMin(TreeNode node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }
            return node.Value;
        }
        private TreeNode? Remove(TreeNode? node, int value)
        {
            if (node == null) return null;

            if (value < node.Value)
            {
                node.Left = Remove(node.Left, value);
                return node;
            }

            if (value > node.Value)
            {
                node.Right = Remove(node.Right, value);
                return node;
            }

            if (node.Left == null) return node.Right;
            if (node.Right == null) return node.Left;

            int successor = FindMin(node.Right);
            node.Value = successor;
            node.Right = Remove(node.Right, successor);
            return node;
        }
        public void Remove(int value)
        {
            root = Remove(root, value);
        }
        // -------------------------------------------------------------------------------------------
        private void InOrder(TreeNode? node, List<int> result)
        {
            if (node == null) return;

            InOrder(node.Left, result);
            result.Add(node.Value);
            InOrder(node.Right, result);
        }
        public List<int> InOrderTraversal()
        {
            List<int> list = new List<int>();
            InOrder(root, list);
            return list;
        }
        // ---------------------------
        private void PreOrder(TreeNode? node, List<int> result)
        {
            if (node == null) return;

            result.Add(node.Value);
            PreOrder(node.Left, result);
            PreOrder(node.Right, result);
        }
        public List<int> PreOrderTraversal()
        {
            List<int> result = new List<int>();
            PreOrder(root, result);
            return result;
        }
        // ---------------------------
        private void PostOrder(TreeNode? node, List<int> result)
        {
            if (node == null) return;

            PostOrder(node.Left, result);
            PostOrder(node.Right, result);
            result.Add(node.Value);
        }
        public List<int> PostOrderTraversal()
        {
            List<int> result = new List<int>();
            PostOrder(root, result);
            return result;
        }
    }
}