using LinearDataStructures.Logic;

#nullable disable

namespace LinearDataStructures.UnitTest
{
    /// <summary>
    /// Represents a mock implementation of a universal queue that supports both queue and stack behaviors.
    /// </summary>
    /// <typeparam name="T">The type of elements in the queue.</typeparam>
    internal class MockUniversalQueue<T> : IUniversalQueue<T>
    {
        private readonly LinkedList<T> _items = new LinkedList<T>();

        /// <summary>
        /// Gets a value indicating whether the collection is empty.
        /// </summary>
        /// <value>
        /// <c>true</c> if the collection contains no items; otherwise, <c>false</c>.
        /// </value>
        public bool IsEmpty => _items.Count == 0;

        /// <summary>
        /// Gets the number of items in the collection.
        /// </summary>
        /// <value>
        /// The total count of items in the collection.
        /// </value>
        public int Count => _items.Count;

        /// <summary>
        /// Clears all items from the collection.
        /// </summary>
        /// <remarks>
        /// This method removes all elements from the underlying collection,
        /// effectively resetting it to an empty state.
        /// </remarks>
        public void Clear()
        {
            _items.Clear();
        }

        /// <summary>
        /// Adds an item to the end of the queue.
        /// </summary>
        /// <param name="item">The item to be added to the queue.</param>
        /// <remarks>
        /// This method follows the queue behavior by adding the specified item
        /// to the end of the collection.
        /// </remarks>
        public void Enqueue(T item)
        {
            _items.AddLast(item); // Queue-Verhalten, fügt am Ende hinzu
        }

        /// <summary>
        /// Removes and returns the object at the front of the queue.
        /// </summary>
        /// <returns>
        /// The object at the front of the queue.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the queue is empty.
        /// </exception>
        public T Dequeue()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Queue is empty");

            T item = _items.First.Value; // Entfernt das erste Element (FIFO)

            _items.RemoveFirst();
            return item;
        }

        /// <summary>
        /// Adds an item to the top of the stack.
        /// </summary>
        /// <param name="item">The item to be added to the stack.</param>
        /// <remarks>
        /// This method follows the stack behavior by adding the item to the beginning of the collection.
        /// </remarks>
        public void Push(T item)
        {
            _items.AddFirst(item); // Stack-Verhalten, fügt am Anfang hinzu
        }

        /// <summary>
        /// Retrieves the element at the front of the queue without removing it.
        /// </summary>
        /// <returns>
        /// The element at the front of the queue.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the queue is empty.
        /// </exception>
        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Queue is empty");

            return _items.First.Value; // Gibt das oberste Element zurück
        }

        /// <summary>
        /// Removes and returns the item at the front of the queue.
        /// </summary>
        /// <returns>
        /// The item at the front of the queue.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the queue is empty.
        /// </exception>
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
