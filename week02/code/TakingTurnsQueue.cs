
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    /// <summary>
    /// Add a new person to the queue with a name and number of turns.
    /// </summary>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Dequeues the next person. 
    /// - People with turns > 1: decrement and re-enqueue.
    /// - People with turns == 1: do NOT re-enqueue.
    /// - People with turns <= 0: infinite turns → always re-enqueue.
    /// Throws exception if queue is empty.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person person = _people.Dequeue();

        if (person.Turns <= 0)
        {
            // Infinite turns — rejoin unchanged
            _people.Enqueue(person);
        }
        else if (person.Turns > 1)
        {
            // Has remaining turns — decrement and rejoin
            person.Turns -= 1;
            _people.Enqueue(person);
        }
        // else if person.Turns == 1 → last turn → Do NOT re-enqueue

        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}
