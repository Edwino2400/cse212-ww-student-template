
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities, then dequeue.
    // Expected Result: The value with the highest priority should be returned ("C").
    // Defect(s) Found: 
    //   1. Loop did not check the last element (highest priority item could be ignored).
    //   2. Dequeue did not remove the item from the list.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 3);

        string result = priorityQueue.Dequeue();
        Assert.AreEqual("C", result);
    }

    [TestMethod]
    // Scenario: Verify that dequeue removes the element from the queue.
    // Expected Result: After dequeuing once, queue should have 2 remaining items.
    // Defect(s) Found:
    //   1. Dequeue never removed the returned item.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 1);
        priorityQueue.Enqueue("C", 3);

        _ = priorityQueue.Dequeue(); // remove highest priority ("A")

        // The queue should now contain only B and C
        string toString = priorityQueue.ToString();
        Assert.IsTrue(toString.Contains("B"));
        Assert.IsTrue(toString.Contains("C"));
        Assert.IsFalse(toString.Contains("A")); // "A" should be gone
    }

    [TestMethod]
    // Scenario: Multiple items have the same highest priority.
    // Expected Result: The LAST highest-priority item should be dequeued 
    //                  due to the >= comparison rule.
    // Defect(s) Found:
    //   1. Last element was not checked because of incorrect loop boundary.
    public void TestPriorityQueue_TieBreaker_LastHighestWins()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 5);  // same priority as B but added later

        string result = priorityQueue.Dequeue();
        Assert.AreEqual("C", result); // last highest priority element wins
    }

    [TestMethod]
    // Scenario: Calling dequeue on an empty queue.
    // Expected Result: Throws InvalidOperationException.
    // Defect(s) Found:
    //   - None in this case; original code handled this properly.
    public void TestPriorityQueue_EmptyQueueThrows()
    {
        var priorityQueue = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }
}
