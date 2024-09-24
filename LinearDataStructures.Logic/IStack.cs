using System;
namespace LinearDataStructures.Logic
{
    /// <summary>
    /// Represents a generic stack interface.
    /// </summary>
    /// <typeparam name="T">The type of elements in the stack.</typeparam>
    public interface IStack<T>
    {
        /// <summary>
        /// Gets a value indicating whether the stack is empty.
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        /// Removes all items from the stack.
        /// </summary>
        void Clear();

        /// <summary>
        /// Adds an item to the top of the stack.
        /// </summary>
        /// <param name="item">The item to push onto the stack.</param>
        void Push(T item);

        /// <summary>
        /// Returns the item at the top of the stack without removing it.
        /// </summary>
        /// <returns>The item at the top of the stack.</returns>
        T Peek();

        /// <summary>
        /// Removes and returns the item at the top of the stack.
        /// </summary>
        /// <returns>The item removed from the top of the stack.</returns>
        T Pop();
    }
}
