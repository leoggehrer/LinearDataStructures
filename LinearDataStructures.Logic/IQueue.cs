namespace LinearDataStructures.Logic
{
    /// <summary>
    /// Represents a first-in, first-out (FIFO) collection of objects.
    /// </summary>
    /// <typeparam name="T">The type of elements in the queue.</typeparam>
    public interface IQueue<T>
    {
        /// <summary>
        /// Gets the number of items.
        /// </summary>
        /// <value>
        /// The total count of items.
        /// </value>
        int Count { get; }

        /// <summary>
        /// Clears the current state or contents of the object.
        /// </summary>
        void Clear();

        /// <summary>
        /// Adds an item to the end of the queue.
        /// </summary>
        /// <param name="item">The item to be added to the queue.</param>
        /// <remarks>
        /// This method increases the size of the queue by one. If the queue has a maximum size,
        /// this method may throw an exception if the queue is full.
        /// </remarks>
        void Enqueue(T item);

        /// <summary>
        /// Removes and returns the object at the front of the queue.
        /// </summary>
        /// <returns>
        /// The object that is removed from the front of the queue.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the queue is empty.
        /// </exception>
        T Dequeue();
    }
}
