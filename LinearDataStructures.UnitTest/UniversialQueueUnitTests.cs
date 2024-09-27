using LinearDataStructures.Logic;

#nullable disable

namespace LinearDataStructures.UnitTest
{
    /// <summary>
    /// Unit tests for the <see cref="IUniversalQueue{T}"/> implementation.
    /// This class contains tests to verify the functionality of the Universal Queue,
    /// including operations such as Enqueue, Dequeue, Push, Pop, and Peek.
    /// </summary>
    [TestClass]
    public class UniversalQueueUnitTests
    {
        private IUniversalQueue<int> _queue;

        /// <summary>
        /// Creates a new instance of a universal queue.
        /// </summary>
        /// <typeparam name="T">The type of elements held in the queue.</typeparam>
        /// <returns>An instance of <see cref="IUniversalQueue{T}"/> containing the specified type.</returns>
        private static IUniversalQueue<T> CreateUniversalQueue<T>()
        {
            return DataStructuresFactory.CreateUniversalQueue<T>();
        }

        /// <summary>
        /// Initializes the test environment before each test method is executed.
        /// This method sets up a universal queue of integers.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            _queue = CreateUniversalQueue<int>();
        }

        // 1. Test IsEmpty when queue is newly created
        /// <summary>
        /// Tests that a newly instantiated queue is empty.
        /// </summary>
        /// <remarks>
        /// This test method verifies that the <see cref="_queue"/> instance has its <see cref="IsEmpty"/>
        /// property set to true when the queue is first created. It asserts that the queue's state
        /// reflects that it contains no elements.
        /// </remarks>
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
        /// This test method enqueues an integer value (1) into the queue and asserts that the
        /// <see cref="IsEmpty"/> property returns <c>false</c>, indicating that the queue contains elements.
        /// </remarks>
        [TestMethod]
        public void IsEmpty_ShouldBeFalse_AfterEnqueue()
        {
            _queue.Enqueue(1);
            Assert.IsFalse(_queue.IsEmpty);
        }

        // 3. Test Count when queue is newly created
        /// <summary>
        /// Verifies that the count of the queue is zero when the queue is newly instantiated.
        /// </summary>
        /// <remarks>
        /// This test method checks the initial state of the queue to ensure that it is empty.
        /// </remarks>
        /// <exception cref="AssertFailedException">
        /// Thrown if the count of the queue is not equal to zero.
        /// </exception>
        [TestMethod]
        public void Count_ShouldBeZero_WhenQueueIsNew()
        {
            Assert.AreEqual(0, _queue.Count);
        }

        // 4. Test Count after Enqueue
        /// <summary>
        /// Tests that the count of the queue increases after an item is enqueued.
        /// </summary>
        /// <remarks>
        /// This test verifies that when an integer is added to the queue using the
        /// <see cref="Queue{T}.Enqueue(T)"/> method, the <see cref="Queue{T}.Count"/>
        /// property reflects the correct number of items in the queue.
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
        /// This test enqueues two items (1 and 2) into the queue and then dequeues one item.
        /// It asserts that the dequeued item is equal to the first enqueued item (1).
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
        /// Tests the <see cref="Queue{T}.Dequeue"/> method to ensure that it correctly removes the first item from the queue.
        /// </summary>
        /// <remarks>
        /// This test enqueues two items (1 and 2), then dequeues the first item.
        /// It asserts that the queue count is reduced to 1 and that the next item in the queue is 2.
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
        /// Tests that an <see cref="InvalidOperationException"/> is thrown when attempting to dequeue an item
        /// from an empty queue.
        /// </summary>
        /// <remarks>
        /// This method is marked with the <see cref="TestMethodAttribute"/> to indicate that it is a unit test.
        /// The <see cref="ExpectedExceptionAttribute"/> specifies that an exception of type <see cref="InvalidOperationException"/>
        /// is expected to be thrown during the execution of this test.
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Dequeue_ShouldThrowException_WhenQueueIsEmpty()
        {
            _queue.Dequeue();
        }

        // 8. Test Clear should make queue empty
        /// <summary>
        /// Tests that the <see cref="_queue"/> is empty after calling the <see cref="Clear"/> method.
        /// </summary>
        /// <remarks>
        /// This test enqueues two items into the queue, invokes the <see cref="Clear"/> method,
        /// and then asserts that the queue is empty and its count is zero.
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
        /// The expected sequence of dequeued values is 1, 2, and 3.
        /// </remarks>
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
        /// Tests the <see cref="Queue{T}.Push(T)"/> method to ensure that
        /// items are added to the front of the queue.
        /// </summary>
        /// <remarks>
        /// This test pushes two integers onto the queue and verifies
        /// that the item at the front of the queue is the last item pushed.
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
        /// Tests the <see cref="Queue{T}.Pop"/> method to ensure it removes the front item
        /// in a Last In, First Out (LIFO) order.
        /// </summary>
        /// <remarks>
        /// This test pushes two integers onto the queue and then pops the top item.
        /// It asserts that the popped item is the last item pushed, and that the next item
        /// in the queue is the first item that was pushed.
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
        /// Tests that the <see cref="Queue{T}.Pop"/> method throws an <see cref="InvalidOperationException"/>
        /// when attempting to pop an item from an empty queue.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the queue is empty and a pop operation is attempted.
        /// </exception>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_ShouldThrowException_WhenQueueIsEmpty()
        {
            _queue.Pop();
        }

        // 13. Test Peek returns item at the front without removing it
        /// <summary>
        /// Tests the <see cref="Queue{T}.Peek"/> method to ensure it returns the front item
        /// of the queue without removing it.
        /// </summary>
        /// <remarks>
        /// This test enqueues an item (1) into the queue and verifies that the
        /// <see cref="Queue{T}.Peek"/> method returns the correct value (1)
        /// without altering the state of the queue.
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
        /// Tests that an <see cref="InvalidOperationException"/> is thrown when attempting to
        /// peek at an element in an empty queue.
        /// </summary>
        /// <remarks>
        /// This test method verifies that the <see cref="Queue{T}.Peek"/> method correctly
        /// throws an <see cref="InvalidOperationException"/> when the queue is empty.
        /// It is expected that the queue has no elements at the time of the call.
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Peek_ShouldThrowException_WhenQueueIsEmpty()
        {
            _queue.Peek();
        }

        // 15. Test Count increases after multiple Push operations
        /// <summary>
        /// Tests that the count of the queue increases correctly after multiple push operations.
        /// </summary>
        /// <remarks>
        /// This test method pushes three elements onto the queue and verifies that the
        /// count of the queue is equal to three after the operations.
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
        /// This test pushes two items onto the queue and then pops one item,
        /// verifying that the count of the queue is equal to 1 after the operation.
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
        /// Tests the functionality of the Enqueue, Peek, and Dequeue methods
        /// of the queue to ensure they work correctly.
        /// </summary>
        /// <remarks>
        /// This test checks that after enqueuing two integers (1 and 2):
        /// 1. The Peek method returns the first element (1).
        /// 2. The Dequeue method removes and returns the first element (1).
        /// 3. The Dequeue method then removes and returns the next element (2).
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
        /// Tests that the Push and Pop methods of the queue work in Last In, First Out (LIFO) order.
        /// </summary>
        /// <remarks>
        /// This test method pushes three integers onto the queue and then pops them off.
        /// It asserts that the last pushed integer is the first to be popped off,
        /// ensuring the queue behaves as expected in a LIFO manner.
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
        /// Tests the <see cref="Queue{T}.Clear"/> method to ensure that it correctly clears the queue
        /// after elements have been added using both the <see cref="Queue{T}.Enqueue"/> and
        /// <see cref="Queue{T}.Push"/> methods.
        /// </summary>
        /// <remarks>
        /// This test verifies that after calling <see cref="Queue{T}.Clear"/>, the queue is empty
        /// and the count of elements is zero.
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
        /// Tests that the <see cref="_queue"/> is empty after multiple pushes and dequeues.
        /// </summary>
        /// <remarks>
        /// This test method pushes two elements, enqueues one element, and then dequeues two elements
        /// and pops one element from the queue. It asserts that the queue is empty at the end of these operations.
        /// </remarks>
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
