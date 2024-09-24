using LinearDataStructures.Logic;

namespace LinearDataStructures.UnitTest
{
    internal class MockStack<T> : IStack<T>
    {
        private readonly List<T> _items = new List<T>();

        public bool IsEmpty => _items.Count == 0;

        public void Clear()
        {
            _items.Clear();
        }

        public void Push(T item)
        {
            _items.Add(item);
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty");
            return _items.Last();
        }

        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty");

            T item = _items.Last();
            _items.RemoveAt(_items.Count - 1);
            return item;
        }
    }
}
