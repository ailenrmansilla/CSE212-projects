using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: There is a queue with three nodes, where the third one is the highest priority one.
    // This test tries to get the next priority node from the queue.
    // queue items = [('Test1', 1), ('Test2', 2), ('Test3', 3)]
    // Expected Result: Test3
    // Defect(s) Found: Returns Test2
    public void TestPriorityQueue_nextHighPriorityItem()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue("test1", 2);
        priorityQueue.Enqueue("test2", 2);
        priorityQueue.Enqueue("test3", 3);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("test3", result, "Dequeue method should return the item with the highest priority.");
    }

    [TestMethod]
    // Scenario: There are five nodes in the queue. Two of them have the same highest priority. 
    // Expected Result: The first node with the highest priority is returned (Test2).
    // Defect(s) Found: It returns Test3
    public void TestPriorityQueue_manyItemsWithSamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("test1", 1);
        priorityQueue.Enqueue("test2", 3);
        priorityQueue.Enqueue("test3", 3);
        priorityQueue.Enqueue("test4", 2);
        priorityQueue.Enqueue("test5", 2);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("test2", result, "Dequeue method should return the first item with the highest priority.");
    }

    [TestMethod]
    // Scenario: There is an empty queue. 
    // Expected Result: An InvalidOperationException should be thrown when calling Dequeue()
    // Defect(s) Found: 
    public void TestPriorityQueue_exceptionWhenEmptyQueue()
    {
        var priorityQueue = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue(), "Dequeue should throw an exception when the queue is empty.");
        
    }

}