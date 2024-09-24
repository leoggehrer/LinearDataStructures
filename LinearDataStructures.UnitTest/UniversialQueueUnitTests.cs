using LinearDataStructures.Logic;

#nullable disable

namespace LinearDataStructures.UnitTest
{
    /// <summary>
    /// Contains unit tests for the <see cref="IUniversalQueue{T}"/> interface implementation.
    /// This class tests various functionalities of the universal queue, including
    /// enqueueing, dequeueing, pushing, popping, and checking the state of the queue.
    /// </summary>
    [TestClass]
    public class UniversalQueueUnitTests
    {
        private IUniversalQueue<int> _queue;

        /// <summary>
        /// Creates a new instance of a universal queue.
        /// </summary>
        /// <typeparam name="T">The type of elements in the universal queue.</typeparam>
        /// <returns>An instance of <see cref="IUniversalQueue{T}"/> containing the specified type.</returns>
        private static IUniversalQueue<T> CreateUniversalQueue<T>()
        {
            return DataStructuresFactory.CreateUniversalQueue<T>();
        }

        /// <summary>
        /// Initializes the test environment before each test method is run.
        /// This method sets up a universal queue for integer values.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            _queue = CreateUniversalQueue<int>();
        }

        // 1. Test IsEmpty when queue is newly created
        /// <summary>
        /// Tests that a newly created queue is empty.
        /// </summary>
        /// <remarks>
        /// This test verifies that the <see cref="_queue"/> has its <see cref="IsEmpty"/> property set to true
        /// when the queue is instantiated and has not yet had any items added to it.
        /// </remarks>
        /// <exception cref="AssertFailedException">
        /// Thrown when the <see cref="_queue.IsEmpty"/> property does not return true.
        /// </exception>
        [TestMethod]
        public void IsEmpty_ShouldBeTrue_WhenQueueIsNew()
        {
            Assert.IsTrue(_queue.IsEmpty);
        }

        // 2. Test IsEmpty after Enqueue
        /// <summary>
        /// Tests that the <see cref="_queue"/> is not empty after an item is enqueued.
        /// </summary>
        /// <remarks>
        /// This test method enqueues an integer value (1) into the queue and asserts that
        /// the <see cref="IsEmpty"/> property returns false, indicating that the queue
        /// contains at least one item.
        /// </remarks>
        [TestMethod]
        public void IsEmpty_ShouldBeFalse_AfterEnqueue()
        {
            _queue.Enqueue(1);
            Assert.IsFalse(_queue.IsEmpty);
        }

        // 3. Test Count when queue is newly created
        /// <summary>
        /// Verifies that the count of items in a newly instantiated queue is zero.
        /// </summary>
        /// <remarks>
        /// This test method checks the initial state of the queue to ensure that it is empty
        /// upon creation. It asserts that the <see cref="_queue.Count"/> property returns 0
        /// when the queue has just been initialized.
        /// </remarks>
        [TestMethod]
        public void Count_ShouldBeZero_WhenQueueIsNew()
        {
            Assert.AreEqual(0, _queue.Count);
        }

        // 4. Test Count after Enqueue
        /// <summary>
        /// Tests that the count of the queue increases by one after an item is enqueued.
        /// </summary>
        /// <remarks>
        /// This test method enqueues a single integer item (1) into the queue
        /// and asserts that the count of the queue is equal to 1, verifying
        /// that the enqueue operation is functioning as expected.
        /// </remarks>
        [TestMethod]
        public void Count_ShouldIncrease_AfterEnqueue()
        {
            _queue.Enqueue(1);
            Assert.AreEqual(1, _queue.Count);
        }

        // 5. Test Dequeue returns first enqueued item
        /// <summary>
        /// Tests that the <see cref="Queue{T}.Dequeue"/> method returns the first item that was enqueued.
        /// </summary>
        /// <remarks>
        /// This test enqueues two integers (1 and 2) into the queue and then dequeues an item.
        /// It asserts that the first dequeued item is equal to the first enqueued item (1).
        /// </remarks>
        [TestMethod]
        public void Dequeue_ShouldReturnFirstEnqueuedItem()
        {
            _queue.Enqueue(1);
            _queue.Enqueue(2);
            Assert.AreEqual(1, _queue.Dequeue());
        }

        // 6. Test Dequeue removes the first item
        /// <summary>
        /// Tests the <see cref="Queue{T}.Dequeue"/> method to ensure that it removes the first item from the queue.
        /// </summary>
        /// <remarks>
        /// This test enqueues two items (1 and 2) into the queue, then calls the <see cref="Queue{T}.Dequeue"/> method.
        /// It verifies that the count of the queue is 1 after the dequeue operation and that the next item to be dequeued is 2.
        /// </remarks>
        [TestMethod]
        public void Dequeue_ShouldRemoveFirstItem()
        {
            _queue.Enqueue(1);
            _queue.Enqueue(2);
            _queue.Dequeue();
            Assert.AreEqual(1, _queue.Count);
            Assert.AreEqual(2, _queue.Peek());
        }

        // 7. Test Dequeue on empty queue throws exception
        /// <summary>
        /// Tests that an <see cref="InvalidOperationException"/> is thrown when attempting to dequeue
        /// an element from an empty queue.
        /// </summary>
        /// <remarks>
        /// This method is marked with the <see cref="TestMethodAttribute"/> to indicate that it is a unit test.
        /// It is also marked with the <see cref="ExpectedExceptionAttribute"/> to specify that an
        /// <see cref="InvalidOperationException"/> is expected to be thrown during its execution.
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Dequeue_ShouldThrowException_WhenQueueIsEmpty()
        {
            _queue.Dequeue();
        }

        // 8. Test Clear should make queue empty
        /// <summary>
        /// Tests the <see cref="Queue{T}.Clear"/> method to ensure it empties the queue.
        /// </summary>
        /// <remarks>
        /// This test enqueues two items into the queue, invokes the <see cref="Queue{T}.Clear"/> method,
        /// and asserts that the queue is empty and its count is zero.
        /// </remarks>
        [TestMethod]
        public void Clear_ShouldMakeQueueEmpty()
        {
            _queue.Enqueue(1);
            _queue.Enqueue(2);
            _queue.Clear();
            Assert.IsTrue(_queue.IsEmpty);
            Assert.AreEqual(0, _queue.Count);
        }

        // 9. Test Enqueue and Dequeue operations in FIFO order
        /// <summary>
        /// Tests that the <see cref="_queue"/> correctly enqueues and dequeues items in a First-In-First-Out (FIFO) order.
        /// </summary>
        /// <remarks>
        /// This test method enqueues three integers (1, 2, and 3) into the queue and then dequeues them,
        /// asserting that they are returned in the same order they were added.
        /// </remarks>
        /// <example>
        /// <code>
        /// EnqueueAndDequeue_ShouldWorkInFIFOOrder();
        /// </code>
        /// </example>
        [TestMethod]
        public void EnqueueAndDequeue_ShouldWorkInFIFOOrder()
        {
            _queue.Enqueue(1);
            _queue.Enqueue(2);
            _queue.Enqueue(3);
            Assert.AreEqual(1, _queue.Dequeue());
            Assert.AreEqual(2, _queue.Dequeue());
            Assert.AreEqual(3, _queue.Dequeue());
        }

        // 10. Test Push adds item to the front of the queue (Stack behavior)
        /// <summary>
        /// Tests that the <see cref="_queue"/> correctly adds an item to the front when the <see cref="Push"/> method is called.
        /// </summary>
        /// <remarks>
        /// This test pushes two integers onto the queue and verifies that the most recently added item (2) is at the front of the queue.
        /// </remarks>
        [TestMethod]
        public void Push_ShouldAddItemToFront()
        {
            _queue.Push(1);
            _queue.Push(2);
            Assert.AreEqual(2, _queue.Peek());
        }

        // 11. Test Pop removes the item at the front (LIFO behavior)
        /// <summary>
        /// Tests that the <see cref="_queue.Pop()"/> method removes the front item from the queue in a Last In, First Out (LIFO) order.
        /// </summary>
        /// <remarks>
        /// This test first pushes two items onto the queue (1 and 2).
        /// It then verifies that calling <see cref="_queue.Pop()"/> returns the last item pushed (2),
        /// and subsequently checks that the next item in the queue (the front item) is now 1 using <see cref="_queue.Peek()"/>.
        /// </remarks>
        [TestMethod]
        public void Pop_ShouldRemoveFrontItem_LIFOOrder()
        {
            _queue.Push(1);
            _queue.Push(2);
            Assert.AreEqual(2, _queue.Pop());
            Assert.AreEqual(1, _queue.Peek());
        }

        // 12. Test Pop on empty queue throws exception
        /// <summary>
        /// Tests that an <see cref="InvalidOperationException"/> is thrown when attempting to pop an item from an empty queue.
        /// </summary>
        /// <remarks>
        /// This test method verifies the behavior of the <see cref="Queue{T}.Pop"/> method when the queue is empty.
        /// It expects an <see cref="InvalidOperationException"/> to be thrown, indicating that the operation is not valid.
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_ShouldThrowException_WhenQueueIsEmpty()
        {
            _queue.Pop();
        }

        // 13. Test Peek returns item at the front without removing it
        /// <summary>
        /// Tests the <see cref="Queue{T}.Peek"/> method to ensure that it returns the front item
        /// of the queue without removing it.
        /// </summary>
        /// <remarks>
        /// This test enqueues a single item (1) into the queue and verifies that calling
        /// <see cref="Queue{T}.Peek"/> returns the expected item without modifying the queue's state.
        /// The test checks that the item remains in the queue after the peek operation.
        /// </remarks>
        [TestMethod]
        public void Peek_ShouldReturnFrontItemWithoutRemovingIt()
        {
            _queue.Enqueue(1);
            Assert.AreEqual(1, _queue.Peek());
            Assert.AreEqual(1, _queue.Peek()); // Should not remove item
        }

        // 14. Test Peek on empty queue throws exception
        /// <summary>
        /// Tests that an <see cref="InvalidOperationException"/> is thrown when attempting to peek at an empty queue.
        /// </summary>
        /// <remarks>
        /// This test method verifies the behavior of the <see cref="Queue{T}.Peek"/> method
        /// when the queue has no elements. It is expected to throw an <see cref="InvalidOperationException"/>
        /// to indicate that the operation cannot be performed on an empty queue.
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Peek_ShouldThrowException_WhenQueueIsEmpty()
        {
            _queue.Peek();
        }

        // 15. Test Count increases after multiple Push operations
        /// <summary>
        /// Verifies that the count of the queue increases correctly after multiple push operations.
        /// </summary>
        /// <remarks>
        /// This test method pushes three integers onto the queue and asserts that the count of items
        /// in the queue is equal to three. It ensures that the <see cref="_queue.Push(int)"/> method
        /// functions as expected by modifying the count of the queue.
        /// </remarks>
        [TestMethod]
        public void Count_ShouldIncrease_AfterMultiplePushes()
        {
            _queue.Push(1);
            _queue.Push(2);
            _queue.Push(3);
            Assert.AreEqual(3, _queue.Count);
        }

        // 16. Test Count decreases after multiple Pops
        /// <summary>
        /// Tests that the count of the queue decreases after multiple pop operations.
        /// </summary>
        /// <remarks>
        /// This test method pushes two elements onto the queue, then pops one element off.
        /// It asserts that the count of the queue is equal to 1 after the pop operation.
        /// </remarks>
        [TestMethod]
        public void Count_ShouldDecrease_AfterMultiplePops()
        {
            _queue.Push(1);
            _queue.Push(2);
            _queue.Pop();
            Assert.AreEqual(1, _queue.Count);
        }

        // 17. Test Enqueue followed by Peek and Dequeue
        /// <summary>
        /// Tests the functionality of enqueueing, peeking, and dequeueing elements in a queue.
        /// </summary>
        /// <remarks>
        /// This test method verifies that after adding elements to the queue,
        /// the first element can be correctly peeked and dequeued,
        /// followed by the next element. It ensures that the queue behaves
        /// according to FIFO (First In, First Out) principles.
        /// </remarks>
        [TestMethod]
        public void Enqueue_Peek_Dequeue_ShouldWorkCorrectly()
        {
            _queue.Enqueue(1);
            _queue.Enqueue(2);
            Assert.AreEqual(1, _queue.Peek());
            Assert.AreEqual(1, _queue.Dequeue());
            Assert.AreEqual(2, _queue.Dequeue());
        }

        // 18. Test Push and Pop operations in LIFO order
        /// <summary>
        /// Tests that the <see cref="_queue"/> operates in a Last In, First Out (LIFO) order.
        /// </summary>
        /// <remarks>
        /// This test pushes three integers onto the queue and then pops them off,
        /// asserting that they are returned in reverse order of their addition.
        /// </remarks>
        [TestMethod]
        public void PushAndPop_ShouldWorkInLIFOOrder()
        {
            _queue.Push(1);
            _queue.Push(2);
            _queue.Push(3);
            Assert.AreEqual(3, _queue.Pop());
            Assert.AreEqual(2, _queue.Pop());
            Assert.AreEqual(1, _queue.Pop());
        }

        // 19. Test Clear after Push and Enqueue operations
        /// <summary>
        /// Tests the <see cref="Queue"/> class's <see cref="Queue.Clear"/> method.
        /// </summary>
        /// <remarks>
        /// This test verifies that after pushing and enqueuing elements into the queue,
        /// calling the <see cref="Queue.Clear"/> method results in an empty queue.
        /// It checks that the <see cref="Queue.IsEmpty"/> property returns true and
        /// the <see cref="Queue.Count"/> property returns 0.
        /// </remarks>
        [TestMethod]
        public void Clear_ShouldWork_AfterPushAndEnqueue()
        {
            _queue.Enqueue(1);
            _queue.Push(2);
            _queue.Push(3);
            _queue.Clear();
            Assert.IsTrue(_queue.IsEmpty);
            Assert.AreEqual(0, _queue.Count);
        }

        // 20. Test IsEmpty after multiple Push and Dequeue operations
        /// <summary>
        /// Tests that the queue is empty after multiple push and dequeue operations.
        /// </summary>
        /// <remarks>
        /// This test method performs the following operations on the queue:
        /// <list type="bullet">
        ///     <item>Pushes the integer 1 onto the queue.</item>
        ///     <item>Pushes the integer 2 onto the queue.</item>
        ///     <item>Enqueues the integer 3 into the queue.</item>
        ///     <item>Dequeues an element from the queue.</item>
        ///     <item>Dequeues another element from the queue.</item>
        ///     <item>Pops an element from the queue.</item>
        /// </list>
        /// After performing these operations, the method asserts that the queue is empty
        [TestMethod]
        public void IsEmpty_ShouldBeTrue_AfterMultiplePushesAndDequeues()
        {
            _queue.Push(1);
            _queue.Push(2);
            _queue.Enqueue(3);
            _queue.Dequeue();
            _queue.Dequeue();
            _queue.Pop();
            Assert.IsTrue(_queue.IsEmpty);
        }
    }
}
