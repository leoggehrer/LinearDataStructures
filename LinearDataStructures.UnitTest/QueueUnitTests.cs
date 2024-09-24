using LinearDataStructures.Logic;

#nullable disable

namespace LinearDataStructures.UnitTest
{
    /// <summary>
    /// Contains unit tests for the <see cref="IQueue{T}"/> implementation, specifically for the integer queue.
    /// </summary>
    /// <remarks>
    /// This class includes various test cases to verify the behavior of queue operations such as Enqueue, Dequeue,
    /// Count, and Clear. It ensures that the queue adheres to the First-In-First-Out (FIFO) principle and handles
    /// edge cases appropriately.
    /// </remarks>
    [TestClass]
    public class QueueTests
    {
        private IQueue<int> _queue;

        /// <summary>
        /// Creates a new instance of a queue of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the queue.</typeparam>
        /// <returns>A new instance of <see cref="IQueue{T}"/>.</returns>
        private static IQueue<T> CreateQueue<T>()
        {
            return DataStructuresFactory.CreateQueue<T>();
        }

        /// <summary>
        /// Initializes the test environment before each test is run.
        /// This method sets up the testing queue by creating an instance of a queue for integers.
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
        /// This test method ensures that the initial state of the queue has a count of zero,
        /// indicating that it is empty and ready for use.
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
        /// This test method enqueues a single item (the integer 1) into the queue
        /// and asserts that the count of the queue is equal to 1, confirming that
        /// the enqueue operation is functioning as expected.
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
        /// This test method enqueues two items into the queue, dequeues one item,
        /// and then asserts that the count of the queue is equal to one.
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
        /// Tests the <see cref="Queue{T}.Dequeue"/> method to ensure that it returns
        /// the first item that was enqueued.
        /// </summary>
        /// <remarks>
        /// This test enqueues two items (1 and 2) and then dequeues one item.
        /// It asserts that the dequeued item is equal to 1, which is the first
        /// item that was enqueued.
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
        /// Tests that the <see cref="Queue{T}.Dequeue"/> method throws an
        /// <see cref="InvalidOperationException"/> when the queue is empty.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown when attempting to dequeue an item from an empty queue.
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
        /// The test enqueues two elements into the queue, then calls the <see cref="Queue{T}.Clear"/> method,
        /// and asserts that the count of the queue is zero afterward.
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
        /// The test enqueues two integers, 1 and 2, and then dequeues them to verify that
        /// they are returned in the order they were added. The first call to <see cref="Queue{T}.Dequeue()"/>
        /// should return 1, followed by a call that returns 2.
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
        /// Tests that the <see cref="Queue{T}.Dequeue"/> method removes an item from the queue.
        /// </summary>
        /// <remarks>
        /// This test enqueues an item into the queue and then dequeues it,
        /// verifying that the count of items in the queue is zero after the operation.
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
        /// This test method enqueues three items into the queue, dequeues one item, and then enqueues another item.
        /// It asserts that the count of items in the queue is as expected after these operations.
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
        /// Tests that the <see cref="IQueue{T}.Enqueue(T)"/> method allows enqueuing of different data types.
        /// </summary>
        /// <remarks>
        /// This test specifically verifies that a string can be enqueued into a queue designed for strings,
        /// and checks that the count of the queue is updated accordingly.
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
        /// Tests that the <see cref="Queue{T}.Dequeue"/> method throws an
        /// <see cref="InvalidOperationException"/> after the queue has been cleared.
        /// </summary>
        /// <remarks>
        /// This test method enqueues an item, clears the queue, and then attempts to
        /// dequeue an item, which is expected to result in an exception.
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
        /// following the First In First Out (FIFO) principle of the queue.
        /// </remarks>
        /// <example>
        /// <code>
        /// _queue.Enqueue(1);
        /// _queue.Enqueue(2);
        /// _queue.Enqueue(3);
        /// Assert.AreEqual(1, _queue.Dequeue()); // First item should be 1
        /// Assert.AreEqual(2, _queue.Dequeue()); // Second item should be
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
        /// Tests that clearing the queue does not throw an exception when the queue is empty.
        /// </summary>
        /// <remarks>
        /// This test method verifies that invoking the <see cref="Queue{T}.Clear"/> method
        /// on an empty queue results in a count of zero without any exceptions being thrown.
        /// </remarks>
        [TestMethod]
        public void Clear_ShouldNotThrowException_WhenQueueIsEmpty()
        {
            _queue.Clear();
            Assert.AreEqual(0, _queue.Count);
        }

        // 14. Test Dequeue returns items in FIFO order
        /// <summary>
        /// Tests that the <see cref="_queue"/> dequeues items in First-In-First-Out (FIFO) order.
        /// </summary>
        /// <remarks>
        /// This test enqueues three integers (1, 2, and 3) into the queue and then dequeues them.
        /// The expected order of dequeued items is 1, 2, and then 3, verifying that the queue
        /// maintains the correct FIFO behavior.
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
        /// This test enqueues two integers (1 and 2) into the queue, invokes the <see cref="Queue{T}.Clear"/> method,
        /// and then asserts that the count of the queue is 0, indicating that the queue has been successfully cleared.
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
        /// <summary>
        /// Tests the <see cref="Queue{T}.Dequeue"/> method to ensure that it does not alter the order of other elements in the queue.
        /// </summary>
        /// <remarks>
        /// This test enqueues three elements (1, 2, 3), dequeues one element, and then asserts that the next two dequeued elements are as expected (2 and 3).
        /// </remarks>
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
        /// This test enqueues three elements into the queue, dequeues one element,
        /// and then asserts that the count of the queue is as expected.
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
        /// verifying that the clear operation did not impact the ability to enqueue new items.
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
        /// Tests the behavior of the <see cref="_queue"/> when items are enqueued, cleared, and then enqueued again.
        /// Specifically, it verifies that after enqueuing an item, clearing the queue, and then enqueuing another item,
        /// the <see cref="Dequeue"/> method returns the last enqueued item.
        /// </summary>
        /// <remarks>
        /// This test ensures that the <see cref="_queue"/> correctly handles the enqueue and clear operations,
        /// maintaining the expected FIFO (First In, First Out) behavior.
        /// </remarks>
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
        /// Tests that an item can be added to the queue after an item has been dequeued.
        /// </summary>
        /// <remarks>
        /// This test method enqueues an item, dequeues it, and then enqueues another item.
        /// It asserts that the count of the queue is equal to 1 after the operations,
        /// verifying that the first item was removed and the second item was added successfully.
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
