namespace LinearDataStructures.Logic
{
    /// <summary>
    /// Represents a universal queue that allows both queue and stack operations.
    /// </summary>
    /// <typeparam name="T">The type of elements in the queue.</typeparam>
    internal class UniversalQueue<T> : IUniversalQueue<T>
    {
        #region fields
        private Element<T>? _first = null;
        private Element<T>? _last = null;
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
                return _first == null;
            }
        }
        /// <summary>
        /// Gets the number of elements in the collection.
        /// </summary>
        /// <returns>
        /// The total count of elements in the collection.
        /// </returns>
        /// <remarks>
        /// This property iterates through the linked list to count the number of elements.
        /// It has a time complexity of O(n), where n is the number of elements in the collection.
        /// </remarks>
        public int Count
        {
            get
            {
                int result = 0;
                Element<T>? current = _first;

                while (current != null)
                {
                    result++;
                    current = current.Next;
                }

                return result;
            }
        }
        #endregion properties

        #region methods
        /// <summary>
        /// Clears the contents of the collection by setting the first and last elements to null.
        /// </summary>
        public void Clear()
        {
            _first = null;
            _last = null;
        }

        /// <summary>
        /// Removes and returns the object at the beginning of the queue.
        /// </summary>
        /// <returns>
        /// The object at the front of the queue.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">
        /// Thrown when the queue is empty.
        /// </exception>
        public T Dequeue()
        {
            if (_first == null)
            {
                throw new System.InvalidOperationException("The queue is empty.");
            }

            T value = _first.Data;

            _first = _first.Next;
            if (_first == null)
            {
                _last = null;
            }
            return value;
        }

        /// <summary>
        /// Adds an item to the end of the queue.
        /// </summary>
        /// <param name="item">The item to be added to the queue.</param>
        /// <remarks>
        /// If the queue is empty, the item becomes both the first and last element.
        /// If the queue already contains elements, the item is added to the end of the queue.
        /// </remarks>
        public void Enqueue(T item)
        {
            if (_first == null)
            {
                _first = new Element<T>(item, null);
                _last = _first;
            }
            else
            {
                _last!.Next = new Element<T>(item, null);
                _last = _last!.Next;
            }
        }

        /// <summary>
        /// Retrieves the data at the front of the queue without removing it.
        /// </summary>
        /// <returns>
        /// The data of the first element in the queue.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the queue is empty.
        /// </exception>
        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            return _first!.Data;
        }

        /// <summary>
        /// Removes and returns the top element of the stack.
        /// </summary>
        /// <returns>
        /// The value of the top element in the stack.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when attempting to pop an element from an empty stack.
        /// </exception>
        public T Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            T value = _first!.Data;

            _first = _first!.Next;
            if (_first == null)
            {
                _last = null;
            }
            return value;
        }

        /// <summary>
        /// Adds an item to the front of the collection.
        /// </summary>
        /// <param name="item">The item to be added to the collection.</param>
        /// <remarks>
        /// This method creates a new element containing the specified item and updates the first element of the collection.
        /// If the collection was previously empty (i.e., <c>_last</c> is null), it also updates the last element to point to the new item.
        /// </remarks>
        public void Push(T item)
        {
            _first = new Element<T>(item, _first);
            if (_last == null)
            {
                _last = _first;
            }
        }
        #endregion methods
    }
}
