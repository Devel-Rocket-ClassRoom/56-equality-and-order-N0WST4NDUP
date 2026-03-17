using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

public class Item
{
    public string Name { get; private set; }
    public string Type { get; private set; }
    public string Grade { get; private set; }

    public Item(string name, string type, string grade)
    {
        Name = name;
        Type = type;
        Grade = grade;
    }
}

public class ItemTypeComparer : EqualityComparer<Item>
{
    public override bool Equals(Item x, Item y)
    {
        return x.Type == y.Type;
    }

    public override int GetHashCode([DisallowNull] Item obj)
    {
        return HashCode.Combine(obj.Type);
    }
}

public class ItemGradeComparer : EqualityComparer<Item>
{
    public override bool Equals(Item x, Item y)
    {
        if (x == null && y == null)
        {
            return true;
        }
        if (x == null || y == null)
        {
            return false;
        }

        return x.Grade == y.Grade;
    }

    public override int GetHashCode([DisallowNull] Item obj)
    {
        return HashCode.Combine(obj.Grade);
    }
}