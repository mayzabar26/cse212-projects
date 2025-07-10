using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add one item to the queue and check if count is 1
    // Expected Result: Make a queue of priority tests with value 1
    // Defect(s) Found: The test fails because it doesn't have any implementations yet.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        // Add an item 
        priorityQueue.Enqueue("Task 1", 1);

        // Verify if count is equal to 1
        Assert.AreEqual("[Task 1 (Pri:1)]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Add two itens with different priorities and check dequeue and returns the correct one
    // Expected Result: Return the item with higher priority
    // Defect(s) Found: The test fails because it doesn't have any implementations yet.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        //Adding tasks
        priorityQueue.Enqueue("Low Priority Task", 5);
        priorityQueue.Enqueue("Higher Priority Task", 1);

        //Dequeue priority 1
        var item = priorityQueue.Dequeue();

        //Verify if correct item was returned
        Assert.AreEqual("Low Priority Task", item);
    }

    // Add more test cases as needed below.
    [TestMethod]
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        //Adding items 
        priorityQueue.Enqueue("Task Low", 1);
        priorityQueue.Enqueue("Task Medium", 5);
        priorityQueue.Enqueue("Task High", 10);

        //Dequeue item "Task High"
        var item = priorityQueue.Dequeue();

        Assert.AreEqual("Task High", item);
    }

    [TestMethod]
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        //Add items with the same priority
        priorityQueue.Enqueue("Task A", 5);
        priorityQueue.Enqueue("Task B", 5);
        priorityQueue.Enqueue("Task C", 5);

        //Dequeue "Task A"
        var item = priorityQueue.Dequeue();

        Assert.AreEqual("Task A", item);
    }
}