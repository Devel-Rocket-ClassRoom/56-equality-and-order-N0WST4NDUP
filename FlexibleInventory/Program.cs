using System;
using System.Collections.Generic;

List<Item> items = new()
{
    new("불꽃 검", "무기", "전설"),
    new("철 갑옷", "방어구", "일반"),
    new("체력 물약", "소비", "일반"),
    new("얼음 단검", "무기", "희귀"),
    new("미스릴 방패", "방어구", "희귀"),
};

Dictionary<Item, List<Item>> inventory1 = new(new ItemTypeComparer());
foreach (var item in items)
{
    var group = inventory1.GetValueOrDefault(item, new());
    group.Add(item);
    inventory1[item] = group;
}

Console.WriteLine("=== 타입별 그룹핑 ===");
foreach (var key in inventory1.Keys)
{
    Console.WriteLine($"[{key.Type}]");
    foreach (var item in inventory1[key])
    {
        Console.WriteLine($"  - {item.Name} ({item.Grade})");
    }
}
Console.WriteLine();

Dictionary<Item, List<Item>> inventory2 = new(new ItemGradeComparer());
foreach (var item in items)
{
    var group = inventory2.GetValueOrDefault(item, new());
    group.Add(item);
    inventory2[item] = group;
}

Console.WriteLine("=== 등급별 그룹핑 ===");
foreach (var key in inventory2.Keys)
{
    Console.WriteLine($"[{key.Grade}]");
    foreach (var item in inventory2[key])
    {
        Console.WriteLine($"  - {item.Name} ({item.Type})");
    }
}