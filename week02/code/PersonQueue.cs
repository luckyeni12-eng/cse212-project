public class PersonQueue
{
    private readonly List<Person> _queue = new();

    public int Length => _queue.Count;

    public void Enqueue(Person person)
    {
        _queue.Add(person); // FIXED: add to back, not front
    }

    public Person Dequeue()
    {
        var person = _queue[0];
        _queue.RemoveAt(0);
        return person;
    }

    public bool IsEmpty()
    {
        return Length == 0;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}