using System;
namespace LinearDataStructures.Logic
{
    /// <summary>
    /// Represents a generic stack data structure that follows the Last In First Out (LIFO) principle.
    /// </summary>
    /// <typeparam name="T">The type of elements in the stack.</typeparam>
    public interface IStack<T>
    {
        /// <summary>
        /// Gets a value indicating whether the collection is empty.
        /// </summary>
        /// <value>
        /// <c>true</c> if the collection is empty; otherwise, <c>false</c>.
        /// </value>
        bool IsEmpty { get; }

        /// <summary>
        /// Clears the current state or contents of the object.
        /// </summary>
        /// <remarks>
        /// This method resets all relevant fields or properties to their default values,
        /// effectively emptying or resetting the object to its initial state.
        /// </remarks>
        void Clear();

        /// <summary>
        /// Adds an item to the collection.
        /// </summary>
        /// <param name="item">The item to be added to the collection.</param>
        /// <remarks>
        /// This method pushes the specified item onto the collection.
        /// If the collection has a maximum capacity, it may throw an exception
        /// if the item cannot be added.
        /// </remarks>
        void Push(T item);

        /// <summary>
        /// Retrieves the object at the top of the collection without removing it.
        /// </summary>
        /// <returns>
        /// The object at the top of the collection.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the collection is empty.
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
