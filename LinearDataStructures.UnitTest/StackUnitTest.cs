using LinearDataStructures.Logic;

#nullable disable

namespace LinearDataStructures.UnitTest
{
    /// <summary>
    /// Unit tests for the <see cref="IStack{T}"/> implementation, specifically for the <see cref="int"/> type.
    /// This class contains various test methods to validate the behavior of stack operations such as Push, Pop, Peek,
    /// IsEmpty, and Clear. Each test method checks specific functionality and expected outcomes to ensure the stack
    /// operates correctly in various scenarios.
    /// </summary>
    [TestClass]
    public class StackUnitTests
    {
        private IStack<int> _stack;

        /// <summary>
        /// Creates a new instance of a stack of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of elements that the stack will hold.</typeparam>
        /// <returns>An instance of <see cref="IStack{T}"/> containing elements of type <typeparamref name="T"/>.</returns>
        private static IStack<T> CreateStack<T>()
        {
            return DataStructuresFactory.CreateStack<T>();
        }

        /// <summary>
        /// Initializes the test environment before each test is run.
        /// This method sets up a new instance of a stack for testing purposes.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            _stack = CreateStack<int>();
        }

        // 1. Test IsEmpty when stack is newly created
        /// <summary>
        /// Tests that a newly created stack is empty.
        /// </summary>
        /// <remarks>
        /// This test method verifies that the <see cref="_stack"/> instance's <see cref="IsEmpty"/> property returns true
        /// when the stack has just been instantiated and no elements have been added to it.
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
        /// Tests that the <see cref="_stack"/> is not empty after an item is pushed onto it.
        /// </summary>
        /// <remarks>
        /// This test method verifies that the <see cref="IsEmpty"/> property returns false
        /// after pushing an integer value onto the stack, indicating that the stack contains
        /// at least one element.
        /// </remarks>
        [TestMethod]
        public void IsEmpty_ShouldBeFalse_AfterPush()
        {
            _stack.Push(1);
            Assert.IsFalse(_stack.IsEmpty);
        }

        // 3. Test IsEmpty after popping the last item
        /// <summary>
        /// Tests that the stack is empty after the last item is popped.
        /// </summary>
        /// <remarks>
        /// This test method pushes an integer onto the stack, then pops it off,
        /// and asserts that the stack is empty afterward.
        /// </remarks>
        [TestMethod]
        public void IsEmpty_ShouldBeTrue_AfterPopLastItem()
        {
            _stack.Push(1);
            _stack.Pop();
            Assert.IsTrue(_stack.IsEmpty);
        }

        // 4. Test Clear should empty the stack
        /// <summary>
        /// Tests that the <see cref="_stack"/> is emptied when the <see cref="Clear"/> method is called.
        /// </summary>
        /// <remarks>
        /// This test pushes two integers onto the stack, then clears the stack, and asserts that the stack is empty afterwards.
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
        /// Tests that an item can be added to the stack using the <see cref="Stack{T}.Push(T)"/> method.
        /// </summary>
        /// <remarks>
        /// This test verifies that after pushing an item onto the stack, the <see cref="Stack{T}.Peek()"/> method
        /// returns the item that was added, confirming that the item is correctly placed on top of the stack.
        /// </remarks>
        [TestMethod]
        public void Push_ShouldAddItemToStack()
        {
            _stack.Push(1);
            Assert.AreEqual(1, _stack.Peek());
        }

        // 6. Test Peek should return the last pushed item
        /// <summary>
        /// Tests that the <see cref="Stack{T}.Peek"/> method returns the last item pushed onto the stack.
        /// </summary>
        /// <remarks>
        /// This test pushes two integers onto the stack and asserts that the last pushed item (2) is returned
        /// when calling the <see cref="Stack{T}.Peek"/> method.
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
        /// This test verifies that after calling <see cref="Stack{T}.Peek"/>, the stack remains non-empty.
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
        /// This test pushes two integers (1 and 2) onto the stack and then verifies that the <see cref="Stack{T}.Pop"/> method
        /// returns the last pushed item, which should be 2.
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
        /// Tests that the <see cref="Stack{T}.Pop"/> method removes the last item that was pushed onto the stack.
        /// </summary>
        /// <remarks>
        /// This test pushes two integers onto the stack, then pops the last item.
        /// It asserts that the next item on the stack is the first integer that was pushed.
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
        /// Tests that an <see cref="InvalidOperationException"/> is thrown when attempting to pop an element
        /// from an empty stack.
        /// </summary>
        /// <remarks>
        /// This test verifies the behavior of the <see cref="Stack{T}.Pop"/> method under the condition
        /// where the stack is empty. The expected outcome is that an <see cref="InvalidOperationException"/>
        /// is raised, indicating that the operation cannot be performed.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the stack is empty and a pop operation is attempted.
        /// </exception>
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
        /// <remarks>
        /// This test method verifies the behavior of the <see cref="Stack{T}.Peek"/> method
        /// when the stack is empty. The expected outcome is that an <see cref="InvalidOperationException"/>
        /// is thrown, indicating that the operation is invalid due to the empty state of the stack.
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Peek_ShouldThrowException_WhenStackIsEmpty()
        {
            _stack.Peek();
        }

        // 12. Test pushing multiple items
        /// <summary>
        /// Tests the <see cref="Stack{T}.Push(T)"/> method to ensure that multiple items can be added to the stack.
        /// </summary>
        /// <remarks>
        /// This test pushes three integers onto the stack and then verifies that the top item is the last item pushed.
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
        /// Tests that popping all items from the stack results in an empty stack.
        /// </summary>
        /// <remarks>
        /// This test pushes two items onto the stack, then pops both of them off.
        /// It asserts that the stack is empty after the operations are completed.
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
        /// Tests that the <see cref="Stack{T}.Clear"/> method does not throw an exception
        /// when the stack is empty.
        /// </summary>
        /// <remarks>
        /// This test verifies that invoking the <see cref="Stack{T}.Clear"/> method
        /// on an empty stack maintains the stack's empty state without any exceptions.
        /// </remarks>
        [TestMethod]
        public void Clear_ShouldNotThrowException_WhenStackIsEmpty()
        {
            _stack.Clear();
            Assert.IsTrue(_stack.IsEmpty);
        }

        // 15. Test Pop returns items in LIFO order
        /// <summary>
        /// Tests that the <see cref="_stack"/> correctly returns items in Last In, First Out (LIFO) order.
        /// </summary>
        /// <remarks>
        /// This test pushes three integers onto the stack and then pops them off,
        /// asserting that they are returned in the reverse order of their addition.
        /// </remarks>
        /// <example>
        /// <code>
        /// _stack.Push(1);
        /// _stack.Push(2);
        /// _stack.Push(3);
        /// Assert.AreEqual(3, _stack.Pop()); // Should return 3
        /// Assert.AreEqual(2, _stack.Pop()); // Should return 2
        /// Assert.AreEqual(1, _stack.Pop()); // Should return 1
        /// </code>
        /// </
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
        /// Tests the <see cref="Stack{T}.Peek"/> method to ensure that it does not change the state of the stack.
        /// </summary>
        /// <remarks>
        /// This test pushes an item onto the stack, then calls <see cref="Stack{T}.Peek"/> to retrieve the top item.
        /// It verifies that the returned item is the expected value and that the stack's state remains unchanged
        /// after the peek operation.
        /// </remarks>
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
        /// Tests that the <see cref="IStack{T}.Push"/> method allows null values
        /// when the type parameter is a nullable type.
        /// </summary>
        /// <remarks>
        /// This test verifies that when a null value is pushed onto the stack,
        /// the <see cref="IStack{T}.Peek"/> method returns null, indicating
        /// that the stack correctly accommodates null values for nullable types.
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
        /// This test first pushes an item onto the stack, then clears the stack, and finally attempts
        /// to pop an item, which should result in an exception being thrown.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the <see cref="Pop"/> method is called on an empty stack.
        /// </exception>
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
        /// Tests that an <see cref="InvalidOperationException"/> is thrown when attempting to
        /// peek at the top element of the stack after it has been cleared.
        /// </summary>
        /// <remarks>
        /// This test method first pushes an integer onto the stack, then clears the stack,
        /// and finally attempts to peek at the top element, which should result in an exception.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the stack is empty and a peek operation is attempted.
        /// </exception>
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
        /// Tests that the <see cref="_stack"/> can successfully push an element after it has been cleared.
        /// </summary>
        /// <remarks>
        /// This test method first pushes an integer value onto the stack,
        /// then clears the stack, and subsequently pushes another integer value.
        /// It asserts that the top element of the stack is the value that was pushed after the clear operation.
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