using LinearDataStructures.Logic;

#nullable disable

namespace LinearDataStructures.UnitTest
{
    /// <summary>
    /// Contains unit tests for the <see cref="IQueue{T}"/> implementation, specifically for integer queues.
    /// </summary>
    /// <remarks>
    /// This class tests various functionalities of a queue, including enqueueing, dequeueing, counting elements,
    /// and clearing the queue. Each test method ensures that the queue behaves as expected under different scenarios.
    /// </remarks>
    [TestClass]
    public class QueueTests
    {
        private IQueue<int> _queue;

        /// <summary>
        /// Creates a new instance of a queue of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of elements in the queue.</typeparam>
        /// <returns>An instance of <see cref="IQueue{T}"/> containing elements of type <typeparamref name="T"/>.</returns>
        private static IQueue<T> CreateQueue<T>()
        {
            return DataStructuresFactory.CreateQueue<T>();
        }

        /// <summary>
        /// Initializes the test environment by creating a new queue instance.
        /// This method is called before each test method is executed.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            _queue = CreateQueue<int>();
        }

        // 1. Test Count is zero when queue is newly created
        /// <summary>
        /// Verifies that the count of the queue is zero when the queue is newly instantiated.
        /// </summary>
        /// <remarks>
        /// This test method checks the initial state of the queue to ensure that it starts with a count of zero,
        /// which is the expected behavior for a newly created queue instance.
        /// </remarks>
        [TestMethod]
        public void Count_ShouldBeZero_WhenQueueIsNew()
        {
            Assert.AreEqual(0, _queue.Count);
        }

        // 2. Test Count increases after Enqueue
        /// <summary>
        /// Tests that the count of the queue increases by one after an item is enqueued.
        /// </summary>
        /// <remarks>
        /// This test method enqueues a single integer value (1) into the queue
        /// and asserts that the count of the queue is equal to 1, verifying
        /// that the enqueue operation is functioning correctly.
        /// </remarks>
        [TestMethod]
        public void Count_ShouldIncrease_AfterEnqueue()
        {
            _queue.Enqueue(1);
            Assert.AreEqual(1, _queue.Count);
        }

        // 3. Test Count decreases after Dequeue
        /// <summary>
        /// Tests that the count of the queue decreases by one after an item is dequeued.
        /// </summary>
        /// <remarks>
        /// This test enqueues two items into the queue, then dequeues one item,
        /// and asserts that the count of the queue is equal to 1.
        /// </remarks>
        [TestMethod]
        public void Count_ShouldDecrease_AfterDequeue()
        {
            _queue.Enqueue(1);
            _queue.Enqueue(2);
            _queue.Dequeue();
            Assert.AreEqual(1, _queue.Count);
        }

        // 4. Test Dequeue returns the first enqueued item
        /// <summary>
        /// Tests that the <see cref="Queue{T}.Dequeue"/> method returns the first item that was enqueued.
        /// </summary>
        /// <remarks>
        /// This test enqueues two integers (1 and 2) and asserts that calling <see cref="Queue{T}.Dequeue"/>
        /// returns the first enqueued item (1).
        /// </remarks>
        [TestMethod]
        public void Dequeue_ShouldReturnFirstEnqueuedItem()
        {
            _queue.Enqueue(1);
            _queue.Enqueue(2);
            Assert.AreEqual(1, _queue.Dequeue());
        }

        // 5. Test Dequeue on an empty queue throws exception
        /// <summary>
        /// Tests that an <see cref="InvalidOperationException"/> is thrown when attempting to dequeue an item from an empty queue.
        /// </summary>
        /// <remarks>
        /// This test method verifies the behavior of the <see cref="Queue{T}.Dequeue"/> method when the queue is empty.
        /// It is expected to throw an <see cref="InvalidOperationException"/> to indicate that the operation cannot be performed.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the queue is empty and a dequeue operation is attempted.
        /// </exception>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Dequeue_ShouldThrowException_WhenQueueIsEmpty()
        {
            _queue.Dequeue();
        }

        // 6. Test Clear empties the queue
        /// <summary>
        /// Tests that the <see cref="Queue{T}.Clear"/> method empties the queue.
        /// </summary>
        /// <remarks>
        /// This test enqueues two items into the queue, calls the <see cref="Queue{T}.Clear"/> method,
        /// and asserts that the count of items in the queue is zero afterward.
        /// </remarks>
        [TestMethod]
        public void Clear_ShouldEmptyTheQueue()
        {
            _queue.Enqueue(1);
            _queue.Enqueue(2);
            _queue.Clear();
            Assert.AreEqual(0, _queue.Count);
        }

        // 7. Test Enqueue adds items in FIFO order
        /// <summary>
        /// Tests the <see cref="Queue{T}.Enqueue(T)"/> method to ensure that items are added
        /// in a First-In-First-Out (FIFO) order.
        /// </summary>
        /// <remarks>
        /// This test enqueues two integers (1 and 2) and then dequeues them to verify
        /// that they are returned in the order they were added.
        /// </remarks>
        [TestMethod]
        public void Enqueue_ShouldAddItemsInFIFOOrder()
        {
            _queue.Enqueue(1);
            _queue.Enqueue(2);
            Assert.AreEqual(1, _queue.Dequeue());
            Assert.AreEqual(2, _queue.Dequeue());
        }

        // 8. Test Dequeue removes the item from the queue
        /// <summary>
        /// Tests that an item is removed from the queue when the <see cref="Dequeue"/> method is called.
        /// </summary>
        /// <remarks>
        /// This test enqueues an item into the queue, then calls the <see cref="Dequeue"/> method,
        /// and verifies that the count of items in the queue is zero after the operation.
        /// </remarks>
        [TestMethod]
        public void Dequeue_ShouldRemoveItemFromQueue()
        {
            _queue.Enqueue(1);
            _queue.Dequeue();
            Assert.AreEqual(0, _queue.Count);
        }

        // 9. Test Count remains correct after multiple Enqueues and Dequeues
        /// <summary>
        /// Tests that the count of the queue remains correct after multiple enqueue and dequeue operations.
        /// </summary>
        /// <remarks>
        /// This test method performs the following operations:
        /// 1. Enqueues three integers (1, 2, and 3).
        /// 2. Dequeues one integer from the queue.
        /// 3. Enqueues another integer (4).
        /// Finally, it asserts that the count of the queue is equal to 3,
        /// which verifies that the queue's count is correctly maintained after the operations.
        /// </remarks>
        [TestMethod]
        public void Count_ShouldRemainCorrect_AfterMultipleEnqueuesAndDequeues()
        {
            _queue.Enqueue(1);
            _queue.Enqueue(2);
            _queue.Enqueue(3);
            _queue.Dequeue();
            _queue.Enqueue(4);
            Assert.AreEqual(3, _queue.Count);
        }

        // 10. Test Enqueue allows multiple data types (for generic queue)
        /// <summary>
        /// Tests that the <see cref="IQueue{T}.Enqueue(T)"/> method allows enqueuing
        /// different data types, specifically verifying the functionality with a string data type.
        /// </summary>
        /// <remarks>
        /// This test method creates an instance of a queue for strings, enqueues a test string,
        /// and asserts that the count of the queue is as expected after the operation.
        /// </remarks>
        [TestMethod]
        public void Enqueue_ShouldAllowDifferentDataTypes()
        {
            IQueue<string> stringQueue = CreateQueue<string>();
            stringQueue.Enqueue("Test");
            Assert.AreEqual(1, stringQueue.Count);
        }

        // 11. Test Dequeue after Clear throws exception
        /// <summary>
        /// Tests that an <see cref="InvalidOperationException"/> is thrown when attempting to dequeue
        /// from a queue that has been cleared.
        /// </summary>
        /// <remarks>
        /// This test method enqueues an integer value, clears the queue, and then attempts to dequeue an item.
        /// It is expected that the <see cref="InvalidOperationException"/> will be thrown after the queue is cleared.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// Thrown when attempting to dequeue from an empty queue.
        /// </exception>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Dequeue_ShouldThrowException_AfterClear()
        {
            _queue.Enqueue(1);
            _queue.Clear();
            _queue.Dequeue();
        }

        // 12. Test multiple Enqueues followed by multiple Dequeues
        /// <summary>
        /// Tests the <see cref="Queue{T}.Enqueue(T)"/> and <see cref="Queue{T}.Dequeue()"/> methods
        /// by performing multiple enqueue and dequeue operations.
        /// </summary>
        /// <remarks>
        /// This test verifies that items are enqueued and dequeued in the correct order,
        /// ensuring the queue maintains its FIFO (First In, First Out) behavior.
        /// </remarks>
        /// <exception cref="AssertFailedException">
        /// Thrown if the expected values do not match the dequeued values.
        /// </exception>
        [TestMethod]
        public void EnqueueAndDequeue_MultipleOperations_ShouldWorkCorrectly()
        {
            _queue.Enqueue(1);
            _queue.Enqueue(2);
            _queue.Enqueue(3);
            Assert.AreEqual(1, _queue.Dequeue());
            Assert.AreEqual(2, _queue.Dequeue());
            Assert.AreEqual(3, _queue.Dequeue());
        }

        // 13. Test Clear does not throw exception when queue is empty
        /// <summary>
        /// Tests that invoking the <see cref="Queue{T}.Clear"/> method does not throw an exception when the queue is empty.
        /// </summary>
        /// <remarks>
        /// This test verifies that the count of the queue remains 0 after calling the Clear method on an empty queue.
        /// </remarks>
        [TestMethod]
        public void Clear_ShouldNotThrowException_WhenQueueIsEmpty()
        {
            _queue.Clear();
            Assert.AreEqual(0, _queue.Count);
        }

        // 14. Test Dequeue returns items in FIFO order
        /// <summary>
        /// Tests the <see cref="Queue{T}.Dequeue"/> method to ensure it returns items in First-In-First-Out (FIFO) order.
        /// </summary>
        /// <remarks>
        /// This test enqueues three integers (1, 2, and 3) into the queue, then dequeues them and asserts that they are returned in the same order they were added.
        /// </remarks>
        [TestMethod]
        public void Dequeue_ShouldReturnItemsInFIFOOrder()
        {
            _queue.Enqueue(1);
            _queue.Enqueue(2);
            _queue.Enqueue(3);
            Assert.AreEqual(1, _queue.Dequeue());
            Assert.AreEqual(2, _queue.Dequeue());
            Assert.AreEqual(3, _queue.Dequeue());
        }

        // 15. Test Clear after Enqueue should reset queue
        /// <summary>
        /// Tests that the <see cref="Queue{T}.Clear"/> method resets the queue after items have been enqueued.
        /// </summary>
        /// <remarks>
        /// This test enqueues two items into the queue, calls the <see cref="Queue{T}.Clear"/> method,
        /// and asserts that the count of the queue is zero after the clear operation.
        /// </remarks>
        [TestMethod]
        public void Clear_ShouldResetQueue_AfterEnqueue()
        {
            _queue.Enqueue(1);
            _queue.Enqueue(2);
            _queue.Clear();
            Assert.AreEqual(0, _queue.Count);
        }

        // 16. Test Dequeue does not alter other elements in the queue

        [TestMethod]
        public void Dequeue_ShouldNotAlterOtherElements()
        {
            _queue.Enqueue(1);
            _queue.Enqueue(2);
            _queue.Enqueue(3);
            _queue.Dequeue();
            Assert.AreEqual(2, _queue.Dequeue());
            Assert.AreEqual(3, _queue.Dequeue());
        }

        // 17. Test Count remains correct after partial Dequeues
        /// <summary>
        /// Tests that the count of the queue remains correct after performing partial dequeues.
        /// </summary>
        /// <remarks>
        /// This test enqueues three items into the queue, dequeues one item, and then asserts that the count
        /// of the queue is equal to 2, verifying that the count reflects the expected number of items remaining.
        /// </remarks>
        [TestMethod]
        public void Count_ShouldRemainCorrect_AfterPartialDequeues()
        {
            _queue.Enqueue(1);
            _queue.Enqueue(2);
            _queue.Enqueue(3);
            _queue.Dequeue();
            Assert.AreEqual(2, _queue.Count);
        }

        // 18. Test Clear does not affect future Enqueues
        /// <summary>
        /// Tests that clearing the queue does not affect future enqueues.
        /// </summary>
        /// <remarks>
        /// This test enqueues an item, clears the queue, and then enqueues another item.
        /// It asserts that the count of the queue is 1 after the second enqueue,
        /// demonstrating that the clear operation did not affect subsequent operations.
        /// </remarks>
        [TestMethod]
        public void Clear_ShouldNotAffectFutureEnqueues()
        {
            _queue.Enqueue(1);
            _queue.Clear();
            _queue.Enqueue(2);
            Assert.AreEqual(1, _queue.Count);
        }

        // 19. Test Dequeue after Enqueue and Clear works correctly
        /// <summary>
        /// Tests the behavior of the <see cref="_queue"/> when an item is enqueued,
        /// the queue is cleared, and then a new item is enqueued and dequeued.
        /// </summary>
        /// <remarks>
        /// This test verifies that after enqueuing an item, clearing the queue,
        /// and then enqueuing another item, the <see cref="Dequeue"/> method
        /// correctly returns the most recently enqueued item.
        /// </remarks>
        /// <example>
        /// <code>
        /// _queue.Enqueue(1);
        /// _queue.Enqueue(2);
        /// _queue.Clear();
        /// _queue.Enqueue(3);
        /// Assert.AreEqual(3, _queue.Dequeue());
        /// </code>
        /// </example>
        [TestMethod]
        public void Dequeue_ShouldWork_AfterEnqueueAndClear()
        {
            _queue.Enqueue(1);
            _queue.Enqueue(2);
            _queue.Clear();
            _queue.Enqueue(3);
            Assert.AreEqual(3, _queue.Dequeue());
        }

        // 20. Test Enqueue adds item after Dequeue
        /// <summary>
        /// Tests that an item is added to the queue after an item has been dequeued.
        /// </summary>
        /// <remarks>
        /// This test verifies that when an item is enqueued, then dequeued, and another item is enqueued,
        /// the queue count reflects the expected state. Specifically, it checks that the count is 1 after
        /// the operations are performed.
        /// </remarks>
        [TestMethod]
        public void Enqueue_ShouldAddItem_AfterDequeue()
        {
            _queue.Enqueue(1);
            _queue.Dequeue();
            _queue.Enqueue(2);
            Assert.AreEqual(1, _queue.Count);
        }
    }
}
