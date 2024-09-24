using LinearDataStructures.Logic;

namespace LinearDataStructures.UnitTest
{
    internal class MockQueue<T> : IQueue<T>
    {
        private readonly List<T> _items = new List<T>();

        public int Count => _items.Count;

        public void Clear()
        {
            _items.Clear();
        }

        public void Enqueue(T item)
        {
            _items.Add(item);
        }

        public T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException("Queue is empty");

            T item = _items[0];

            _items.RemoveAt(0);
            return item;
        }
    }
}
