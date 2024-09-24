
namespace LinearDataStructures.Logic
{
    /// <summary>
    /// Represents a generic queue interface.
    /// </summary>
    /// <typeparam name="T">The type of elements in the queue.</typeparam>
    public interface IQueue<T>
    {
        /// <summary>
        /// Gets the number of items in the queue.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Removes all items from the queue.
        /// </summary>
        void Clear();

        /// <summary>
        /// Adds an item to the end of the queue.
        /// </summary>
        /// <param name="item">The item to add.</param>
        void Enqueue(T item);

        /// <summary>  
        /// Removes and returns the item at the front of the queue.  
        /// </summary>  
        /// <returns>The item at the front of the queue.</returns>  
        T Dequeue();
    }
}
