using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three items with different priorities to the queue.
    // Expected Result: Items are stored in the order they were added, but Dequeue() 
    // returns the item with the highest priority first.
    // Defect(s) Found: Dequeue() returns the highest-priority item but does not
    // remove it from the queue, so the same item is returned again.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);

        Assert.AreEqual("[A (Pri:1), B (Pri:5), C (Pri:3)]", priorityQueue.ToString());

        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add multiple items with the same highest priority.
    // Expected Result: Items with the same priority are removed in FIFO order.
    // Defect(s) Found: Dequeue() uses >= when comparing priorities, causing a later
    // item with the same priority to be selected before an earlier item.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    // Add more test cases as needed below.
    [TestMethod]
    // Scenario: Add three items where the highest priority item is at the back of the queue.
    // Expected Result: The item at the back with the highest priority is removed first.
    // Defect(s) Found: The loop that searches for the highest priority stops before
    // checking the last item in the queue.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 10);

        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue an item from an empty priority queue.
    // Expected Result: InvalidOperationException is thrown with the message
    // "The queue is empty."
    // Defect(s) Found: No defect found. The test passed.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                    e.GetType(), e.Message)
            );
        }
    }
}