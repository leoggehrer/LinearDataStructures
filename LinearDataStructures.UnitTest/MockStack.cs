using LinearDataStructures.Logic;

namespace LinearDataStructures.UnitTest
{
    /// <summary>
    /// Represents a mock implementation of a stack data structure.
    /// </summary>
    /// <typeparam name="T">The type of elements in the stack.</typeparam>
    internal class MockStack<T> : IStack<T>
    {
        private readonly List<T> _items = new List<T>();

        /// <summary>
        /// Gets a value indicating whether the collection is empty.
        /// </summary>
        /// <value>
        /// <c>true</c> if the collection contains no items; otherwise, <c>false</c>.
        /// </value>
        public bool IsEmpty => _items.Count == 0;

        /// <summary>
        /// Clears all items from the collection.
        /// </summary>
        /// <remarks>
        /// This method removes all elements from the underlying collection, making it empty.
        /// </remarks>
        public void Clear()
        {
            _items.Clear();
        }

        /// <summary>
        /// Adds an item to the collection.
        /// </summary>
        /// <param name="item">The item to be added to the collection.</param>
        /// <remarks>
        /// This method increases the size of the collection by one and does not perform any checks
        /// for duplicate items or capacity limits. Ensure that the collection can accommodate
        /// additional items before calling this method.
        /// </remarks>
        public void Push(T item)
        {
            _items.Add(item);
        }

        /// <summary>
        /// Retrieves the object at the top of the stack without removing it.
        /// </summary>
        /// <returns>
        /// The object at the top of the stack.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the stack is empty.
        /// </exception>
        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty");
            return _items.Last();
        }

        /// <summary>
        /// Removes and returns the item at the top of the stack.
        /// </summary>
        /// <returns>The item that was removed from the top of the stack.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the stack is empty.</exception>
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
