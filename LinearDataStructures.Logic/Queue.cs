namespace LinearDataStructures.Logic
{
    /// <summary>
    /// Represents a generic queue data structure that allows for adding and removing elements in a first-in, first-out (FIFO) manner.
    /// </summary>
    /// <typeparam name="T">The type of elements in the queue.</typeparam>
    internal class Queue<T> : IQueue<T>
    {
        #region fields
        private Element<T>? _top = null;
        private Element<T>? _bottom = null;
        #endregion fields

        #region properties
        /// <summary>
        /// Gets the number of elements in the collection.
        /// </summary>
        /// <value>
        /// The total count of elements. This property traverses the entire collection to calculate the count.
        /// </value>
        /// <remarks>
        /// This property has a time complexity of O(n), where n is the number of elements in the collection.
        /// </remarks>
        public int Count
        {
            get
            {
                int result = 0;
                Element<T>? current = _top;

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
        /// Clears the contents of the data structure by setting the top and bottom references to null.
        /// </summary>
        public void Clear()
        {
            _top = null;
            _bottom = null;
        }

        /// <summary>
        /// Removes and returns the value at the front of the queue.
        /// </summary>
        /// <returns>
        /// The value at the front of the queue.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">
        /// Thrown when the queue is empty.
        /// </exception>
        public T Dequeue()
        {
            if (_top == null)
            {
                throw new System.InvalidOperationException("The queue is empty.");
            }

            T value = _top.Value;

            _top = _top.Next;
            if (_top == null)
            {
                _bottom = null;
            }
            return value;
        }

        /// <summary>
        /// Adds an item to the end of the queue.
        /// </summary>
        /// <param name="item">The item to be added to the queue.</param>
        /// <remarks>
        /// If the queue is empty, the new item becomes both the top and bottom of the queue.
        /// If the queue is not empty, the new item is added to the end of the queue.
        /// </remarks>
        public void Enqueue(T item)
        {
            if (_top == null)
            {
                _top = new Element<T>(item, null);
                _bottom = _top;
            }
            else
            {
                _bottom!.Next = new Element<T>(item, null);
                _bottom = _bottom!.Next;
            }
        }
        #endregion methods
    }
}
