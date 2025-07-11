using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: enqueue three itmes with distinct properties
    // Expected Result: Dequeue returns the item with the highest priority first, then next highest, finally lowest
    // Defect(s) Found: The code never removed items, hand an off by one loop and used >= so later dups would "win" ties
    public void TestPriorityQueue_BasicOrdering()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("low", 1);
        pq.Enqueue("high", 5);
        pq.Enqueue("mid", 3);

        Assert.AreEqual("high", pq.Dequeue());
        Assert.AreEqual("mid",  pq.Dequeue());
        Assert.AreEqual("low",  pq.Dequeue());

        // Now is empty
        Assert.ThrowsException<InvalidOperationException>(
            () => pq.Dequeue(),
            "The queue is empty."
        );
    }

    [TestMethod]
    // Scenario: enqueue items where two share the top priority
    // Expected Result: among ties, the one enqueued earliest is dequeued first
    // Defect(s) Found: use of >= flipped tie order; last element was never examined.
    public void TestPriorityQueue_TieBreaksByFIFO()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 2);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 5);
        pq.Enqueue("D", 3);

        // B and C tie at 5, B was enqueued first
        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
        Assert.AreEqual("D", pq.Dequeue());
        Assert.AreEqual("A", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: dequeue on an empty queue
    // Expected Result: throws InvalidOperationException("The queue is empty.")
    // Defect(s) Found: none once fixed
    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue();
        var ex = Assert.ThrowsException<InvalidOperationException>(
            () => pq.Dequeue()
        );
        Assert.AreEqual("The queue is empty.", ex.Message);
    }
}