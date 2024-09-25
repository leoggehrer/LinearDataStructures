namespace LinearDataStructures.Logic
{
    /// <summary>
    /// Represents a node in a linked list, containing a value and a reference to the next node.
    /// </summary>
    /// <typeparam name="T">The type of the value stored in the element.</typeparam>
    internal class Element<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Element{T}"/> class.
        /// </summary>
        /// <param name="value">The value of the element.</param>
        /// <param name="next">The next element in the linked list, or <c>null</c> if there is no next element.</param>
        public Element(T value, Element<T>? next)
        {
            Data = value;
            Next = next;
        }
        /// <summary>
        /// Gets or sets the value of the property.
        /// </summary>
        /// <value>
        /// The value of type <typeparamref name="T"/>.
        /// </value>
        public T Data { get; set; }
        /// <summary>
        /// Gets or sets the next element in a linked structure.
        /// </summary>
        /// <value>
        /// An <see cref="Element{T}"/> that represents the next element;
        /// or <c>null</c> if there is no next element.
        /// </value>
        public Element<T>? Next { get; set; }
    }
}
