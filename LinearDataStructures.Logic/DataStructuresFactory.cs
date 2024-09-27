namespace LinearDataStructures.Logic
{
    /// <summary>
    /// A factory class for creating instances of data structures.
    /// </summary>
    /// <remarks>
    /// This class provides static methods to create generic stack, queue, and universal queue instances.
    /// </remarks>
    public static class DataStructuresFactory
    {
        /// <summary>
        /// Creates a new instance of a stack of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of elements in the stack.</typeparam>
        /// <returns>A new instance of <see cref="IStack{T}"/> containing no elements.</returns>
        public static IStack<T> CreateStack<T>()
        {
            return new Stack<T>();
        }
        /// <summary>
        /// Creates a new instance of a queue of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of elements in the queue.</typeparam>
        /// <returns>A new instance of <see cref="IQueue{T}"/> containing the elements of type <typeparamref name="T"/>.</returns>
        public static IQueue<T> CreateQueue<T>()
        {
            return new Queue<T>();
        }
        /// <summary>
        /// Creates a new instance of a universal queue.
        /// </summary>
        /// <typeparam name="T">The type of elements held in the queue.</typeparam>
        /// <returns>An instance of <see cref="IUniversalQueue{T}"/> containing the specified type.</returns>
        public static IUniversalQueue<T> CreateUniversalQueue<T>()
        {
            return new UniversalQueue<T>();
        }
    }
}
