namespace DataS.DataStructure.BT
{
    public class BinaryTree<T> where T : IComparable
    {
        public int Count { get; private set; }

        private Node<T> _root;

        public void Add(T value)
        {
            if (_root is null)
            {
                _root = new Node<T>(value);
            }
            else
            {
                var current = _root;

                while (current is not null)
                {
                    if (value.CompareTo(current.Value) < 0)
                    {
                        if (current.Left is not null)
                        {
                            current = current.Left;
                        }
                        else
                        {
                            current.Left = new Node<T>(value);
                            break;
                        }
                    }
                    else
                    {
                        if (current.Right is not null)
                        {
                            current = current.Right;
                        }
                        else
                        {
                            current.Right = new Node<T>(value);
                            break;
                        }
                    }
                }
            }

            Count++;
        }

        public bool IsContains(T value)
        {
            var current = _root;
            while (current is not null)
            {
                if (value.CompareTo(current.Value) == 0)
                    return true;

                current = value.CompareTo(current.Value) < 0 ? current.Left : current.Right;
            }

            return false;
        }

        public bool IsContainsRecursion(T value)
        {
            return RecursiveSearch(_root, value);
        }

        public bool RecursiveSearch(Node<T> node, T value)
        {
            if (node == null)
            {
                return false;
            }

            if (value.CompareTo(node.Value) == 0)
            {
                return true;
            }

            if (value.CompareTo(node.Value) < 0)
            {
                return RecursiveSearch(node.Left, value);
            }
            else
            {
                return RecursiveSearch(node.Right, value);
            }
        }
    }
}
