using System;

public class TodoTask : IComparable<TodoTask>
{
    public string Title { get; private set; }
    public int Priority { get; private set; }
    public string DueDate { get; private set; }
    public bool IsCompleted { get; private set; }

    public TodoTask(string title, int priority, string dueDate)
    {
        Title = title;
        Priority = priority;
        DueDate = dueDate;
    }

    public int CompareTo(TodoTask other)
    {
        if (Priority.CompareTo(other.Priority) != 0) return other.Priority.CompareTo(Priority);
        if (DueDate.CompareTo(other.DueDate) != 0) return DueDate.CompareTo(other.DueDate);
        if (Title.CompareTo(other.Title) != 0) return Title.CompareTo(other.Title);
        return 1;
    }

    public override string ToString() => $" [우선순위 {Priority}] {Title} (마감: {DueDate})";
}