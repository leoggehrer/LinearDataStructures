namespace LinearDataStructures.Logic
{
    /// <summary>
    /// Represents a universal queue interface with standard queue operations.
    /// </summary>
    /// <typeparam name="T">The type of elements in the queue.</typeparam>
    public interface IUniversalQueue<T>
    {
        /// <summary>
        /// Gets a value indicating whether the queue is empty.
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        /// Gets the number of items in the queue.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Removes all items from the queue.
        /// </summary>
        void Clear();

        /// <summary>
        /// Adds an item to the end of the queue.
        /// </summary>
        /// <param name="item">The item to add.</param>
        void Enqueue(T item);

        /// <summary>  
        /// Removes and returns the item at the front of the queue.  
        /// </summary>  
        /// <returns>The item at the front of the queue.</returns>  
        T Dequeue();

        /// <summary>
        /// Adds an item to the top of the queue.
        /// </summary>
        /// <param name="item">The item to push onto the queue.</param>
        void Push(T item);

        /// <summary>
        /// Returns the item at the top of the queue without removing it.
        /// </summary>
        /// <returns>The item at the top of the queue.</returns>
        T Peek();

        /// <summary>
        /// Removes and returns the item at the top of the queue.
        /// </summary>
        /// <returns>The item removed from the top of the queue.</returns>
        T Pop();
    }
}
