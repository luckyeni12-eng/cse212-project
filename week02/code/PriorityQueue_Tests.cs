using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: enqueue 3 items with different priorities → dequeue.
    // Expected Result: Highest priority item ("B" with 5) removed first.
    // Defect(s) Found: 
    // 1. Code did not remove the dequeued item.
    // 2. Loop skipped last element.
    public void TestPriorityQueue_1()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 3);

        var result = pq.Dequeue();
        Assert.AreEqual("B", result);
    }

    [TestMethod]
    // Scenario: Two items share same priority → FIFO should apply.
    // Expected Result: First "A" removed, not "C".
    // Defect(s) Found:
    // 1. Equal priority incorrectly allowed later item to override earlier.
    public void TestPriorityQueue_2()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 5);
        pq.Enqueue("B", 1);
        pq.Enqueue("C", 5);

        var result = pq.Dequeue();
        Assert.AreEqual("A", result);
    }

    [TestMethod]
    // Scenario: Dequeue repeatedly until empty.
    // Expected Result: After all removals, next dequeue throws.
    // Defect(s) Found:
    // 1. Incorrect or missing exception message.
    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue();

        try
        {
            pq.Dequeue();
            Assert.Fail("Expected exception.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }

    [TestMethod]
    // Scenario: Ensure queue removes in correct order across multiple operations.
    // Expected Result: B, D, A, C (based on priorities)
    // Defect(s) Found: none after fixes.
    public void TestPriorityQueue_MixedOrder()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 2);
        pq.Enqueue("B", 9);
        pq.Enqueue("C", 1);
        pq.Enqueue("D", 9);

        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("D", pq.Dequeue());
        Assert.AreEqual("A", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
    }
}