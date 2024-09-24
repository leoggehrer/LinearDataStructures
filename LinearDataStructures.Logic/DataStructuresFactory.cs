namespace LinearDataStructures.Logic
{
    /// <summary>
    /// A factory class for creating various data structure instances.
    /// This class provides static methods to create implementations of stack, queue, and universal queue.
    /// </summary>
    public static class DataStructuresFactory
    {
        /// <summary>
        /// Creates a new instance of a stack of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of elements in the stack.</typeparam>
        /// <returns>An instance of <see cref="IStack{T}"/> containing elements of type <typeparamref name="T"/>.</returns>
        /// <exception cref="NotImplementedException">Thrown when the method is called, as it is not yet implemented.</exception>
        public static IStack<T> CreateStack<T>()
        {
            return new Stack<T>();
        }
        /// <summary>
        /// Creates a new instance of a queue of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of elements in the queue.</typeparam>
        /// <returns>An instance of <see cref="IQueue{T}"/> containing elements of type <typeparamref name="T"/>.</returns>
        /// <exception cref="NotImplementedException">Always thrown as the method is not implemented.</exception>
        public static IQueue<T> CreateQueue<T>()
        {
            return new Queue<T>();
        }
        /// <summary>
        /// Creates a new instance of a universal queue of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of elements in the universal queue.</typeparam>
        /// <returns>An instance of <see cref="IUniversalQueue{T}"/>.</returns>
        /// <exception cref="NotImplementedException">Thrown when the method is called, as the implementation is not provided.</exception>
        public static IUniversalQueue<T> CreateUniversalQueue<T>()
        {
            return new UniversalQueue<T>();
        }
    }
}
