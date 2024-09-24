using LinearDataStructures.Logic;

namespace LinearDataStructures.UnitTest
{
    /// <summary>
    /// Represents a mock stack data structure that implements the <see cref="IStack{T}"/> interface.
    /// </summary>
    /// <typeparam name="T">The type of elements in the stack.</typeparam>
    /// <remarks>
    /// This class provides basic stack operations such as <c>Push</c>, <c>Pop</c>, <c>Peek</c>, and <c>Clear</c>.
    /// </remarks>
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
        /// This method removes all elements from the underlying collection,
        /// leaving it empty. After calling this method, the collection will
        /// contain no items.
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
        /// This method modifies the internal state of the collection by adding the specified item.
        /// </remarks>
        public void Push(T item)
        {
            _items.Add(item);
        }

        /// <summary>
        /// Returns the object at the top of the stack without removing it.
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
