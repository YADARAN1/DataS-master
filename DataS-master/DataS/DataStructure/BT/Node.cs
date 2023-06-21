namespace DataS.DataStructure.BT
{
    public class Node<T> where T : IComparable
    {
        public T Value { get; }

        public Node<T> Left;

        public Node<T> Right;

        public Node(T value) => Value = value;
    }
}