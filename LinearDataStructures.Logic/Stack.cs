namespace LinearDataStructures.Logic
{
    /// <summary>
    /// Represents a generic stack data structure that follows the Last In First Out (LIFO) principle.
    /// </summary>
    /// <typeparam name="T">The type of elements stored in the stack.</typeparam>
    internal class Stack<T> : IStack<T>
    {
        #region fields
        private Element<T>? _top = null;
        #endregion fields

        #region properties
        /// <summary>
        /// Gets a value indicating whether the collection is empty.
        /// </summary>
        /// <value>
        /// <c>true</c> if the collection is empty; otherwise, <c>false</c>.
        /// </value>
        public bool IsEmpty
        {
            get
            {
                return _top == null;
            }
        }
        #endregion properties

        #region methods
        /// <summary>
        /// Clears the contents of the data structure by setting the top element to null.
        /// </summary>
        /// <remarks>
        /// This method effectively removes all elements from the data structure, making it empty.
        /// </remarks>
        public void Clear()
        {
            _top = null;
        }

        /// <summary>
        /// Returns the data at the top of the stack without removing it.
        /// </summary>
        /// <typeparam name="T">The type of the data stored in the stack.</typeparam>
        /// <returns>The data at the top of the stack.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the stack is empty.</exception>
        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            return _top!.Data;
        }

        /// <summary>
        /// Removes and returns the top element of the stack.
        /// </summary>
        /// <returns>
        /// The data of the top element of the stack.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the stack is empty.
        /// </exception>
        public T Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            T value = _top!.Data;

            _top = _top!.Next;
            return value;
        }

        /// <summary>
        /// Adds an item to the top of the stack.
        /// </summary>
        /// <param name="item">The item to be added to the stack.</param>
        /// <remarks>
        /// This method creates a new element with the specified item and sets it as the new top of the stack.
        /// </remarks>
        public void Push(T item)
        {
            _top = new Element<T>(item, _top);
        }
        #endregion methods
    }
}
