using LinearDataStructures.Logic;

#nullable disable

namespace LinearDataStructures.UnitTest
{
    /// <summary>
    /// Contains unit tests for the <see cref="IStack{T}"/> implementation.
    /// This class tests the behavior of stack operations such as Push, Pop,
    /// Peek, IsEmpty, and Clear, ensuring they function correctly under
    /// various conditions.
    /// </summary>
    [TestClass]
    public class StackUnitTests
    {
        private IStack<int> _stack;

        /// <summary>
        /// Creates a new instance of a stack of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of elements in the stack.</typeparam>
        /// <returns>An instance of <see cref="IStack{T}"/> containing the specified type.</returns>
        private static IStack<T> CreateStack<T>()
        {
            return DataStructuresFactory.CreateStack<T>();
        }

        /// <summary>
        /// Initializes the test environment by creating a new instance of a stack for integer values.
        /// This method is called before each test method is executed.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            _stack = CreateStack<int>();
        }

        // 1. Test IsEmpty when stack is newly created
        /// <summary>
        /// Verifies that a newly created stack is empty.
        /// </summary>
        /// <remarks>
        /// This test method checks the <see cref="_stack"/> instance to ensure that the
        /// <see cref="Stack{T}.IsEmpty"/> property returns true when the stack has just been initialized.
        /// </remarks>
        /// <example>
        /// <code>
        /// var stack = new Stack<int>();
        /// Assert.IsTrue(stack.IsEmpty);
        /// </code>
        /// </example>
        [TestMethod]
        public void IsEmpty_ShouldBeTrue_WhenStackIsNew()
        {
            Assert.IsTrue(_stack.IsEmpty);
        }

        // 2. Test IsEmpty after pushing an item
        /// <summary>
        /// Tests that the stack is not empty after an item is pushed onto it.
        /// </summary>
        /// <remarks>
        /// This test method pushes an integer onto the stack and asserts that the
        /// <see cref="_stack.IsEmpty"/> property returns false, indicating that
        /// the stack contains at least one item.
        /// </remarks>
        [TestMethod]
        public void IsEmpty_ShouldBeFalse_AfterPush()
        {
            _stack.Push(1);
            Assert.IsFalse(_stack.IsEmpty);
        }

        // 3. Test IsEmpty after popping the last item
        /// <summary>
        /// Tests that the stack is empty after the last item has been popped.
        /// </summary>
        /// <remarks>
        /// This test pushes an integer onto the stack, then pops it off, and asserts
        /// that the stack is empty afterward.
        /// </remarks>
        /// <example>
        /// <code>
        /// // Example usage in a test suite
        /// [TestMethod]
        /// public void TestStackIsEmptyAfterPop()
        /// {
        ///     _stack.Push(1);
        ///     _stack.Pop();
        ///     Assert.IsTrue(_stack.IsEmpty);
        /// }
        /// </code>
        /// </example>
        [TestMethod]
        public void IsEmpty_ShouldBeTrue_AfterPopLastItem()
        {
            _stack.Push(1);
            _stack.Pop();
            Assert.IsTrue(_stack.IsEmpty);
        }

        // 4. Test Clear should empty the stack
        /// <summary>
        /// Tests that the <see cref="_stack"/> is emptied after calling the <see cref="Clear"/> method.
        /// </summary>
        /// <remarks>
        /// This test pushes two elements onto the stack, clears the stack, and asserts that the stack is empty.
        /// </remarks>
        [TestMethod]
        public void Clear_ShouldEmptyTheStack()
        {
            _stack.Push(1);
            _stack.Push(2);
            _stack.Clear();
            Assert.IsTrue(_stack.IsEmpty);
        }

        // 5. Test Push adds item to the stack
        /// <summary>
        /// Tests that an item can be successfully added to the stack.
        /// </summary>
        /// <remarks>
        /// This test verifies that after pushing an item onto the stack,
        /// the top item of the stack is equal to the item that was pushed.
        /// </remarks>
        [TestMethod]
        public void Push_ShouldAddItemToStack()
        {
            _stack.Push(1);
            Assert.AreEqual(1, _stack.Peek());
        }

        // 6. Test Peek should return the last pushed item
        /// <summary>
        /// Tests the <see cref="Stack{T}.Peek"/> method to ensure it returns the last pushed item.
        /// </summary>
        /// <remarks>
        /// This test pushes two integers onto the stack and verifies that the last item pushed (2)
        /// is returned by the <see cref="Stack{T}.Peek"/> method.
        /// </remarks>
        [TestMethod]
        public void Peek_ShouldReturnLastPushedItem()
        {
            _stack.Push(1);
            _stack.Push(2);
            Assert.AreEqual(2, _stack.Peek());
        }

        // 7. Test Peek without modifying the stack
        /// <summary>
        /// Tests that the <see cref="Stack{T}.Peek"/> method does not remove an item from the stack.
        /// </summary>
        /// <remarks>
        /// This test pushes an integer onto the stack, calls the Peek method,
        /// and asserts that the stack is not empty afterward, ensuring that
        /// the Peek operation does not alter the stack's state.
        /// </remarks>
        [TestMethod]
        public void Peek_ShouldNotRemoveItem()
        {
            _stack.Push(1);
            _stack.Peek();
            Assert.IsFalse(_stack.IsEmpty);
        }

        // 8. Test Pop returns the last pushed item
        /// <summary>
        /// Tests that the <see cref="Stack{T}.Pop"/> method returns the last item that was pushed onto the stack.
        /// </summary>
        /// <remarks>
        /// This test pushes two integers onto the stack and then pops one item off.
        /// It asserts that the item returned by the pop operation is equal to the last item pushed,
        /// which in this case is <c>2</c>.
        /// </remarks>
        [TestMethod]
        public void Pop_ShouldReturnLastPushedItem()
        {
            _stack.Push(1);
            _stack.Push(2);
            Assert.AreEqual(2, _stack.Pop());
        }

        // 9. Test Pop removes the item from the stack
        /// <summary>
        /// Tests that the <see cref="Stack{T}.Pop"/> method removes the last pushed item from the stack.
        /// </summary>
        /// <remarks>
        /// This test pushes two integers onto the stack, then pops the last item.
        /// It asserts that the top item of the stack is the one that was pushed before the last one.
        /// </remarks>
        [TestMethod]
        public void Pop_ShouldRemoveLastPushedItem()
        {
            _stack.Push(1);
            _stack.Push(2);
            _stack.Pop();
            Assert.AreEqual(1, _stack.Peek());
        }

        // 10. Test Pop on empty stack throws exception
        /// <summary>
        /// Tests that an <see cref="InvalidOperationException"/> is thrown when attempting to pop an item from an empty stack.
        /// </summary>
        /// <remarks>
        /// This test method verifies the behavior of the <see cref="Stack{T}.Pop"/> method when the stack is empty.
        /// It is expected to throw an <see cref="InvalidOperationException"/> to indicate that the operation is not valid.
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_ShouldThrowException_WhenStackIsEmpty()
        {
            _stack.Pop();
        }

        // 11. Test Peek on empty stack throws exception
        /// <summary>
        /// Tests that an <see cref="InvalidOperationException"/> is thrown when attempting to
        /// peek at the top element of an empty stack.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the stack is empty and a peek operation is attempted.
        /// </exception>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Peek_ShouldThrowException_WhenStackIsEmpty()
        {
            _stack.Peek();
        }

        // 12. Test pushing multiple items
        /// <summary>
        /// Tests that multiple items can be added to the stack using the <see cref="Push"/> method.
        /// </summary>
        /// <remarks>
        /// This test pushes three integers onto the stack and verifies that the top item is the last item added.
        /// </remarks>
        [TestMethod]
        public void Push_ShouldAddMultipleItems()
        {
            _stack.Push(1);
            _stack.Push(2);
            _stack.Push(3);
            Assert.AreEqual(3, _stack.Peek());
        }

        // 13. Test popping all items should empty the stack
        /// <summary>
        /// Tests the behavior of the <see cref="_stack"/> when all items are popped from it.
        /// </summary>
        /// <remarks>
        /// This test method pushes two items onto the stack, then pops both items off.
        /// It asserts that the stack is empty after all items have been removed.
        /// </remarks>
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
        /// <summary>
        /// Tests that calling the <see cref="Clear"/> method on an empty stack does not throw an exception.
        /// </summary>
        /// <remarks>
        /// This test verifies that the stack remains empty after the <see cref="Clear"/> method is invoked.
        /// </remarks>
        [TestMethod]
        public void Clear_ShouldNotThrowException_WhenStackIsEmpty()
        {
            _stack.Clear();
            Assert.IsTrue(_stack.IsEmpty);
        }

        // 15. Test Pop returns items in LIFO order
        /// <summary>
        /// Tests the <see cref="Stack{T}.Pop"/> method to ensure that items are returned in Last In, First Out (LIFO) order.
        /// </summary>
        /// <remarks>
        /// This test pushes three integers onto the stack and then pops them off, verifying that the order of retrieval
        /// is the reverse of the order of insertion. Specifically, it checks that the last item pushed (3) is the first
        /// to be popped, followed by the second (2), and finally the first item pushed (1).
        /// </remarks>
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
        /// <summary>
        /// Tests the <see cref="Stack{T}.Peek"/> method to ensure that it returns the top item
        /// of the stack without modifying the stack's state.
        /// </summary>
        /// <remarks>
        /// This test verifies that after calling <see cref="Stack{T}.Peek"/>, the stack remains unchanged.
        /// </remarks>
        /// <example>
        /// <code>
        /// _stack.Push(1);
        /// var item = _stack.Peek();
        /// Assert.AreEqual(1, item);
        /// Assert.AreEqual(1, _stack.Peek());  // Stack should remain the same
        /// </code>
        /// </example>
        [TestMethod]
        public void Peek_ShouldNotChangeStackState()
        {
            _stack.Push(1);
            var item = _stack.Peek();
            Assert.AreEqual(1, item);
            Assert.AreEqual(1, _stack.Peek());  // Stack should remain the same
        }

        // 17. Test pushing null item (if nullable type is allowed)
        /// <summary>
        /// Tests that a <see cref="IStack{T}"/> implementation allows pushing a null value
        /// when the type is nullable.
        /// </summary>
        /// <remarks>
        /// This test verifies that the stack can accept null as a valid value for a nullable type
        /// and that the <see cref="IStack{T}.Peek"/> method returns null after pushing a null value.
        /// </remarks>
        [TestMethod]
        public void Push_ShouldAllowNull_WhenTypeIsNullable()
        {
            IStack<string> stringStack = CreateStack<string>();
            stringStack.Push(null);
            Assert.IsNull(stringStack.Peek());
        }

        // 18. Test Pop after Clear throws exception
        /// <summary>
        /// Tests that an <see cref="InvalidOperationException"/> is thrown when attempting to pop an item
        /// from the stack after it has been cleared.
        /// </summary>
        /// <remarks>
        /// This test first pushes an item onto the stack, then clears the stack, and finally attempts to
        /// pop an item from the now-empty stack, which should result in an exception being thrown.
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_ShouldThrowException_AfterClear()
        {
            _stack.Push(1);
            _stack.Clear();
            _stack.Pop();
        }

        // 19. Test Peek after Clear throws exception
        /// <summary>
        /// Tests that an <see cref="InvalidOperationException"/> is thrown when
        /// attempting to peek at the top element of the stack after it has been cleared.
        /// </summary>
        /// <remarks>
        /// This method first pushes an integer onto the stack, then clears the stack,
        /// and finally attempts to peek at the top element, which should result in an
        /// <see cref="InvalidOperationException"/> being thrown.
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Peek_ShouldThrowException_AfterClear()
        {
            _stack.Push(1);
            _stack.Clear();
            _stack.Peek();
        }

        // 20. Test pushing items after Clear works correctly
        /// <summary>
        /// Tests that the <see cref="_stack"/> can successfully push a new element after it has been cleared.
        /// </summary>
        /// <remarks>
        /// The test first pushes the value 1 onto the stack, then clears the stack, and finally pushes the value 2.
        /// It asserts that the top element of the stack is now 2, verifying that the stack behaves correctly after being cleared.
        /// </remarks>
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