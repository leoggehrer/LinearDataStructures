namespace LinearDataStructures.Logic
{
    /// <summary>
    /// Represents a queue data structure that follows the First In First Out (FIFO) principle.
    /// </summary>
    /// <typeparam name="T">The type of elements in the queue.</typeparam>
    internal class Queue<T> : IQueue<T>
    {
        #region fields
        private Element<T>? _first = null;
        private Element<T>? _last = null;
        #endregion fields

        /// <summary>
        /// Gets the number of elements in the collection.
        /// </summary>
        /// <value>
        /// The total count of elements. This value is updated dynamically as elements are added or removed from the collection.
        /// </value>
        public int Count
        {
            get
            {
                int result = 0;
                Element<T>? run = _first;

                while (run != null)
                {
                    result++;
                    run = run.Next;
                }
                return result;
            }
        }

        /// <summary>
        /// Clears the contents of the collection by setting the first and last elements to null.
        /// </summary>
        public void Clear()
        {
            _first = null;
            _last = null;
        }

        /// <summary>
        /// Removes and returns the object at the front of the queue.
        /// </summary>
        /// <returns>
        /// The object that is removed from the front of the queue.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the queue is empty.
        /// </exception>
        public T Dequeue()
        {
            if (_first == null)
                throw new InvalidOperationException("The queue is empty!");

            Element<T>? removeElement = _first;

            _first = _first.Next;

            if (_first == null)
            {
                _last = null;
            }
            return removeElement.Data;
        }

        /// <summary>
        /// Adds an item to the end of the queue.
        /// </summary>
        /// <param name="item">The item to be added to the queue.</param>
        /// <remarks>
        /// If the queue is empty, the new item becomes both the first and last element.
        /// If the queue is not empty, the new item is added after the current last element.
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
                Element<T> newElement = new Element<T>(item, null);

                _last!.Next = newElement;
                _last = newElement;
            }
        }
    }
}
