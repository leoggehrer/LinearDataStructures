using LinearDataStructures.Logic;

#nullable disable

namespace LinearDataStructures.UnitTest
{
    internal class MockUniversalQueue<T> : IUniversalQueue<T>
    {
        private readonly LinkedList<T> _items = new LinkedList<T>();

        public bool IsEmpty => _items.Count == 0;

        public int Count => _items.Count;

        public void Clear()
        {
            _items.Clear();
        }

        public void Enqueue(T item)
        {
            _items.AddLast(item); // Queue-Verhalten, fügt am Ende hinzu
        }

        public T Dequeue()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Queue is empty");

            T item = _items.First.Value; // Entfernt das erste Element (FIFO)

            _items.RemoveFirst();
            return item;
        }

        public void Push(T item)
        {
            _items.AddFirst(item); // Stack-Verhalten, fügt am Anfang hinzu
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Queue is empty");

            return _items.First.Value; // Gibt das oberste Element zurück
        }

        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Queue is empty");

            T item = _items.First.Value; // Entfernt das erste Element (wie Stack)

            _items.RemoveFirst();
            return item;
        }
    }
}
