using LinearDataStructures.Logic;

#nullable disable

namespace LinearDataStructures.UnitTest
{
    [TestClass]
    public class UniversalQueueUnitTests
    {
        private IUniversalQueue<int> _queue;

        private static IUniversalQueue<T> CreateUniversalQueue<T>()
        {
            return new MockUniversalQueue<T>();
        }

        [TestInitialize]
        public void SetUp()
        {
            _queue = CreateUniversalQueue<int>();
        }

        // 1. Test IsEmpty when queue is newly created
        [TestMethod]
        public void IsEmpty_ShouldBeTrue_WhenQueueIsNew()
        {
            Assert.IsTrue(_queue.IsEmpty);
        }

        // 2. Test IsEmpty after Enqueue
        [TestMethod]
        public void IsEmpty_ShouldBeFalse_AfterEnqueue()
        {
            _queue.Enqueue(1);
            Assert.IsFalse(_queue.IsEmpty);
        }

        // 3. Test Count when queue is newly created
        [TestMethod]
        public void Count_ShouldBeZero_WhenQueueIsNew()
        {
            Assert.AreEqual(0, _queue.Count);
        }

        // 4. Test Count after Enqueue
        [TestMethod]
        public void Count_ShouldIncrease_AfterEnqueue()
        {
            _queue.Enqueue(1);
            Assert.AreEqual(1, _queue.Count);
        }

        // 5. Test Dequeue returns first enqueued item
        [TestMethod]
        public void Dequeue_ShouldReturnFirstEnqueuedItem()
        {
            _queue.Enqueue(1);
            _queue.Enqueue(2);
            Assert.AreEqual(1, _queue.Dequeue());
        }

        // 6. Test Dequeue removes the first item
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
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Dequeue_ShouldThrowException_WhenQueueIsEmpty()
        {
            _queue.Dequeue();
        }

        // 8. Test Clear should make queue empty
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
        [TestMethod]
        public void Push_ShouldAddItemToFront()
        {
            _queue.Push(1);
            _queue.Push(2);
            Assert.AreEqual(2, _queue.Peek());
        }

        // 11. Test Pop removes the item at the front (LIFO behavior)
        [TestMethod]
        public void Pop_ShouldRemoveFrontItem_LIFOOrder()
        {
            _queue.Push(1);
            _queue.Push(2);
            Assert.AreEqual(2, _queue.Pop());
            Assert.AreEqual(1, _queue.Peek());
        }

        // 12. Test Pop on empty queue throws exception
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_ShouldThrowException_WhenQueueIsEmpty()
        {
            _queue.Pop();
        }

        // 13. Test Peek returns item at the front without removing it
        [TestMethod]
        public void Peek_ShouldReturnFrontItemWithoutRemovingIt()
        {
            _queue.Enqueue(1);
            Assert.AreEqual(1, _queue.Peek());
            Assert.AreEqual(1, _queue.Peek()); // Should not remove item
        }

        // 14. Test Peek on empty queue throws exception
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Peek_ShouldThrowException_WhenQueueIsEmpty()
        {
            _queue.Peek();
        }

        // 15. Test Count increases after multiple Push operations
        [TestMethod]
        public void Count_ShouldIncrease_AfterMultiplePushes()
        {
            _queue.Push(1);
            _queue.Push(2);
            _queue.Push(3);
            Assert.AreEqual(3, _queue.Count);
        }

        // 16. Test Count decreases after multiple Pops
        [TestMethod]
        public void Count_ShouldDecrease_AfterMultiplePops()
        {
            _queue.Push(1);
            _queue.Push(2);
            _queue.Pop();
            Assert.AreEqual(1, _queue.Count);
        }

        // 17. Test Enqueue followed by Peek and Dequeue
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
