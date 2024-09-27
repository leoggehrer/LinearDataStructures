namespace LinearDataStructures.Logic
{
    /// <summary>
    /// Represents a universal queue that supports various queue operations.
    /// </summary>
    /// <typeparam name="T">The type of elements in the queue.</typeparam>
    public interface IUniversalQueue<T>
    {
        /// <summary>
        /// Gets a value indicating whether the collection is empty.
        /// </summary>
        /// <value>
        /// <c>true</c> if the collection contains no elements; otherwise, <c>false</c>.
        /// </value>
        bool IsEmpty { get; }

        /// <summary>
        /// Gets the number of items.
        /// </summary>
        /// <value>
        /// The total count of items.
        /// </value>
        int Count { get; }

        /// <summary>
        /// Clears the contents or state of the object.
        /// </summary>
        /// <remarks>
        /// This method resets any internal data or state to its initial condition,
        /// effectively removing all items or values that may have been added or set
        /// previously. It is typically used to prepare the object for reuse or to
        /// ensure that no residual data affects future operations.
        /// </remarks>
        void Clear();

        /// <summary>
        /// Adds an item to the end of the queue.
        /// </summary>
        /// <param name="item">The item to be added to the queue.</param>
        /// <remarks>
        /// This method increases the size of the queue by one. If the queue has a fixed capacity,
        /// it may throw an exception if the capacity is exceeded.
        /// </remarks>
        void Enqueue(T item);

        /// <summary>
        /// Removes and returns the object at the front of the queue.
        /// </summary>
        /// <returns>
        /// The object that is removed from the front of the queue.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the queue is empty.
        /// </exception>
        T Dequeue();

        /// <summary>
        /// Adds an item to the collection.
        /// </summary>
        /// <param name="item">The item to be added to the collection.</param>
        /// <remarks>
        /// This method pushes the specified item onto the collection, increasing its size by one.
        /// If the collection has a maximum limit, an exception may be thrown if the limit is exceeded.
        /// </remarks>
        void Push(T item);

        /// <summary>
        /// Retrieves the object at the top of the collection without removing it.
        /// </summary>
        /// <returns>
        /// The object at the top of the collection.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the collection is empty.
        /// </exception>
        T Peek();

        /// <summary>
        /// Removes and returns the object at the top of the collection.
        /// </summary>
        /// <returns>
        /// The object that is removed from the top of the collection.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the collection is empty.
        /// </exception>
        T Pop();
    }
}
