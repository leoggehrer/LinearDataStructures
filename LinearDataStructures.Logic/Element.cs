namespace LinearDataStructures.Logic
{
    /// <summary>
    /// Represents an element in a linked list, containing a value and a reference to the next element.
    /// </summary>
    /// <typeparam name="T">The type of the value contained in the element.</typeparam>
    internal class Element<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Element{T}"/> class.
        /// </summary>
        /// <param name="value">The value to be stored in the element.</param>
        /// <param name="next">The next element in the linked list, or <c>null</c> if there is no next element.</param>
        public Element(T value, Element<T>? next)
        {
            Data = value;
            Next = next;
        }
        /// <summary>
        /// Gets or sets the data of type <typeparamref name="T"/>.
        /// </summary>
        /// <value>
        /// The data of type <typeparamref name="T"/>.
        /// </value>
        /// <typeparam name="T">The type of the data.</typeparam>
        public T Data { get; set; }
        /// <summary>
        /// Gets or sets the next element in the sequence.
        /// </summary>
        /// <value>
        /// An instance of <see cref="Element{T}"/> representing the next element, or <c>null</c> if there is no next element.
        /// </value>
        public Element<T>? Next { get; set; }
    }
}
