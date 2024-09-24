using LinearDataStructures.Logic;

#nullable disable

namespace LinearDataStructures.UnitTest
{
    [TestClass]
    public class StackUnitTests
    {
        private IStack<int> _stack;

        private static IStack<T> CreateStack<T>()
        {
            return new MockStack<T>();
        }

        [TestInitialize]
        public void SetUp()
        {
            _stack = CreateStack<int>();
        }

        // 1. Test IsEmpty when stack is newly created
        [TestMethod]
        public void IsEmpty_ShouldBeTrue_WhenStackIsNew()
        {
            Assert.IsTrue(_stack.IsEmpty);
        }

        // 2. Test IsEmpty after pushing an item
        [TestMethod]
        public void IsEmpty_ShouldBeFalse_AfterPush()
        {
            _stack.Push(1);
            Assert.IsFalse(_stack.IsEmpty);
        }

        // 3. Test IsEmpty after popping the last item
        [TestMethod]
        public void IsEmpty_ShouldBeTrue_AfterPopLastItem()
        {
            _stack.Push(1);
            _stack.Pop();
            Assert.IsTrue(_stack.IsEmpty);
        }

        // 4. Test Clear should empty the stack
        [TestMethod]
        public void Clear_ShouldEmptyTheStack()
        {
            _stack.Push(1);
            _stack.Push(2);
            _stack.Clear();
            Assert.IsTrue(_stack.IsEmpty);
        }

        // 5. Test Push adds item to the stack
        [TestMethod]
        public void Push_ShouldAddItemToStack()
        {
            _stack.Push(1);
            Assert.AreEqual(1, _stack.Peek());
        }

        // 6. Test Peek should return the last pushed item
        [TestMethod]
        public void Peek_ShouldReturnLastPushedItem()
        {
            _stack.Push(1);
            _stack.Push(2);
            Assert.AreEqual(2, _stack.Peek());
        }

        // 7. Test Peek without modifying the stack
        [TestMethod]
        public void Peek_ShouldNotRemoveItem()
        {
            _stack.Push(1);
            _stack.Peek();
            Assert.IsFalse(_stack.IsEmpty);
        }

        // 8. Test Pop returns the last pushed item
        [TestMethod]
        public void Pop_ShouldReturnLastPushedItem()
        {
            _stack.Push(1);
            _stack.Push(2);
            Assert.AreEqual(2, _stack.Pop());
        }

        // 9. Test Pop removes the item from the stack
        [TestMethod]
        public void Pop_ShouldRemoveLastPushedItem()
        {
            _stack.Push(1);
            _stack.Push(2);
            _stack.Pop();
            Assert.AreEqual(1, _stack.Peek());
        }

        // 10. Test Pop on empty stack throws exception
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_ShouldThrowException_WhenStackIsEmpty()
        {
            _stack.Pop();
        }

        // 11. Test Peek on empty stack throws exception
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Peek_ShouldThrowException_WhenStackIsEmpty()
        {
            _stack.Peek();
        }

        // 12. Test pushing multiple items
        [TestMethod]
        public void Push_ShouldAddMultipleItems()
        {
            _stack.Push(1);
            _stack.Push(2);
            _stack.Push(3);
            Assert.AreEqual(3, _stack.Peek());
        }

        // 13. Test popping all items should empty the stack
        [TestMethod]
        public void Pop_AllItems_ShouldEmptyStack()
        {
            _stack.Push(1);
            _stack.Push(2);
            _stack.Pop();
            _stack.Pop();
            Assert.IsTrue(_stack.IsEmpty);
        }

        // 14. Test Clear does not throw exception when stack is already empty
        [TestMethod]
        public void Clear_ShouldNotThrowException_WhenStackIsEmpty()
        {
            _stack.Clear();
            Assert.IsTrue(_stack.IsEmpty);
        }

        // 15. Test Pop returns items in LIFO order
        [TestMethod]
        public void Pop_ShouldReturnItemsInLIFOOrder()
        {
            _stack.Push(1);
            _stack.Push(2);
            _stack.Push(3);
            Assert.AreEqual(3, _stack.Pop());
            Assert.AreEqual(2, _stack.Pop());
            Assert.AreEqual(1, _stack.Pop());
        }

        // 16. Test Peek does not change the state of the stack
        [TestMethod]
        public void Peek_ShouldNotChangeStackState()
        {
            _stack.Push(1);
            var item = _stack.Peek();
            Assert.AreEqual(1, item);
            Assert.AreEqual(1, _stack.Peek());  // Stack should remain the same
        }

        // 17. Test pushing null item (if nullable type is allowed)
        [TestMethod]
        public void Push_ShouldAllowNull_WhenTypeIsNullable()
        {
            IStack<string> stringStack = CreateStack<string>();
            stringStack.Push(null);
            Assert.IsNull(stringStack.Peek());
        }

        // 18. Test Pop after Clear throws exception
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_ShouldThrowException_AfterClear()
        {
            _stack.Push(1);
            _stack.Clear();
            _stack.Pop();
        }

        // 19. Test Peek after Clear throws exception
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Peek_ShouldThrowException_AfterClear()
        {
            _stack.Push(1);
            _stack.Clear();
            _stack.Peek();
        }

        // 20. Test pushing items after Clear works correctly
        [TestMethod]
        public void Push_ShouldWorkAfterClear()
        {
            _stack.Push(1);
            _stack.Clear();
            _stack.Push(2);
            Assert.AreEqual(2, _stack.Peek());
        }
    }
}