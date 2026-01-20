
public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    public string Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // Find the index of the highest-priority item
        int highPriorityIndex = 0;
        for (int index = 1; index < _queue.Count; index++) // FIXED: must include last element
        {
            if (_queue[index].Priority >= _queue[highPriorityIndex].Priority)
            {
                highPriorityIndex = index;
            }
        }

        // Remove and return the highest priority item
        var value = _queue[highPriorityIndex].Value;
        _queue.RemoveAt(highPriorityIndex); // FIXED: must remove it

        return value;
    }

    // DO NOT MODIFY
    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    // DO NOT MODIFY
    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}
