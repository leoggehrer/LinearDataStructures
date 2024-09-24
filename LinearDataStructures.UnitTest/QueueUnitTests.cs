using LinearDataStructures.Logic;

#nullable disable

namespace LinearDataStructures.UnitTest
{
    [TestClass]
    public class QueueTests
    {
        private IQueue<int> _queue;

        private static IQueue<T> CreateQueue<T>()
        {
            return new MockQueue<T>();
        }

        [TestInitialize]
        public void SetUp()
        {
            _queue = CreateQueue<int>();
        }

        // 1. Test Count is zero when queue is newly created
        [TestMethod]
        public void Count_ShouldBeZero_WhenQueueIsNew()
        {
            Assert.AreEqual(0, _queue.Count);
        }

        // 2. Test Count increases after Enqueue
        [TestMethod]
        public void Count_ShouldIncrease_AfterEnqueue()
        {
            _queue.Enqueue(1);
            Assert.AreEqual(1, _queue.Count);
        }

        // 3. Test Count decreases after Dequeue
        [TestMethod]
        public void Count_ShouldDecrease_AfterDequeue()
        {
            _queue.Enqueue(1);
            _queue.Enqueue(2);
            _queue.Dequeue();
            Assert.AreEqual(1, _queue.Count);
        }

        // 4. Test Dequeue returns the first enqueued item
        [TestMethod]
        public void Dequeue_ShouldReturnFirstEnqueuedItem()
        {
            _queue.Enqueue(1);
            _queue.Enqueue(2);
            Assert.AreEqual(1, _queue.Dequeue());
        }

        // 5. Test Dequeue on an empty queue throws exception
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Dequeue_ShouldThrowException_WhenQueueIsEmpty()
        {
            _queue.Dequeue();
        }

        // 6. Test Clear empties the queue
        [TestMethod]
        public void Clear_ShouldEmptyTheQueue()
        {
            _queue.Enqueue(1);
            _queue.Enqueue(2);
            _queue.Clear();
            Assert.AreEqual(0, _queue.Count);
        }

        // 7. Test Enqueue adds items in FIFO order
        [TestMethod]
        public void Enqueue_ShouldAddItemsInFIFOOrder()
        {
            _queue.Enqueue(1);
            _queue.Enqueue(2);
            Assert.AreEqual(1, _queue.Dequeue());
            Assert.AreEqual(2, _queue.Dequeue());
        }

        // 8. Test Dequeue removes the item from the queue
        [TestMethod]
        public void Dequeue_ShouldRemoveItemFromQueue()
        {
            _queue.Enqueue(1);
            _queue.Dequeue();
            Assert.AreEqual(0, _queue.Count);
        }

        // 9. Test Count remains correct after multiple Enqueues and Dequeues
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
        [TestMethod]
        public void Enqueue_ShouldAllowDifferentDataTypes()
        {
            IQueue<string> stringQueue = CreateQueue<string>();
            stringQueue.Enqueue("Test");
            Assert.AreEqual(1, stringQueue.Count);
        }

        // 11. Test Dequeue after Clear throws exception
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Dequeue_ShouldThrowException_AfterClear()
        {
            _queue.Enqueue(1);
            _queue.Clear();
            _queue.Dequeue();
        }

        // 12. Test multiple Enqueues followed by multiple Dequeues
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
        [TestMethod]
        public void Clear_ShouldNotThrowException_WhenQueueIsEmpty()
        {
            _queue.Clear();
            Assert.AreEqual(0, _queue.Count);
        }

        // 14. Test Dequeue returns items in FIFO order
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
        [TestMethod]
        public void Clear_ShouldNotAffectFutureEnqueues()
        {
            _queue.Enqueue(1);
            _queue.Clear();
            _queue.Enqueue(2);
            Assert.AreEqual(1, _queue.Count);
        }

        // 19. Test Dequeue after Enqueue and Clear works correctly
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
