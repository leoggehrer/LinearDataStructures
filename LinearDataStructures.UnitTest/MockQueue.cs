using LinearDataStructures.Logic;

namespace LinearDataStructures.UnitTest
{
    /// <summary>
    /// Represents a mock implementation of a queue data structure.
    /// </summary>
    /// <typeparam name="T">The type of elements in the queue.</typeparam>
    internal class MockQueue<T> : IQueue<T>
    {
        private readonly List<T> _items = new List<T>();

        /// <summary>
        /// Gets the number of items in the collection.
        /// </summary>
        /// <value>
        /// The total count of items.
        /// </value>
        public int Count => _items.Count;

        /// <summary>
        /// Clears all items from the collection.
        /// </summary>
        /// <remarks>
        /// This method removes all elements from the internal collection, resulting in an empty collection.
        /// </remarks>
        public void Clear()
        {
            _items.Clear();
        }

        /// <summary>
        /// Adds an item to the end of the queue.
        /// </summary>
        /// <param name="item">The item to be added to the queue.</param>
        public void Enqueue(T item)
        {
            _items.Add(item);
        }

        /// <summary>
        /// Removes and returns the object at the front of the queue.
        /// </summary>
        /// <returns>
        /// The object that is removed from the front of the queue.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the queue is empty.
        /// </exception>
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
