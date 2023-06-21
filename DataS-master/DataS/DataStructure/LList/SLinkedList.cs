using System.Collections;

namespace DataS.DataStructure.LList
{
    public class SLinkedList<T> : IEnumerable<T>
    {
        public int Count { get; private set; }

        private Node<T> _first;

        private Node<T> _last;

        public void Add(T value)
        {
            Node<T> node = new() { Value = value };
            if (Count == 0)
            {
                _first = node;
                _last = node;
                _first.Next = _last;
            }
            else
            {
                _last.Next = node;
                _last = node;
            }

            Count++;
        }

        public void AddFirst(T value)
        {
            Node<T> node = new() { Value = value };
            if (Count == 0)
            {
                _first = node;
                _last = node;
                _first.Next = _last;
            }
            else
            {
                if (_first == _last)
                    _first.Next = null;

                node.Next = _first;
                _first = node;
            }

            Count++;
        }

        public void RemoveFromLinkedList(T value)
        {
            if (_first is null)
                return;

            if (_first.Value.Equals(value))
            {
                _first = _first.Next;
                Count--;
                return;
            }

            var current = _first.Next;
            Node<T> prev = _first;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    prev.Next = current.Next;

                    if (current == _last)
                        _last = prev;

                    Count--;
                    return;
                }

                prev = current;
                current = current.Next;
            }
        }

        public void RemoveFirst()
        {
            if (Count == 0)
                return;
            if (Count == 1)
            {
                _first = null;
                _last = null;
            }
            else
                _first = _first.Next;

            Count--;
        }

        public bool IsContains(T value)
        {
            var current = _first;
            while (current != _first)
            {
                if (current.Value.Equals(value))
                    return true;

                current = current.Next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = _first;
            while(current != null)
            {
                yield return current.Value;

                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}