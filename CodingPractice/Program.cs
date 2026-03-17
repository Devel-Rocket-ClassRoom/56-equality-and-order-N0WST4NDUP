using System;
using System.Collections.Generic;

// 1. 참조 동등성과 값 동등성
// string s1 = "hello";
// string s2 = "hello";
// string s3 = new string("hello".ToCharArray());

// Console.WriteLine(s1 == s2); 
// Console.WriteLine(s1 == s3);         

// // 참조 동등성 확인
// Console.WriteLine(object.ReferenceEquals(s1, s2));  
// Console.WriteLine(object.ReferenceEquals(s1, s3)); 

// 2. 클래스의 기본 동등성 비교
// Player p1 = new Player("Hero", 10);
// Player p2 = new Player("Hero", 10);
// Player p3 = p1;

// Console.WriteLine($"p1 == p2: {p1 == p2}");
// Console.WriteLine($"p1 == p3: {p1 == p3}");
// Console.WriteLine($"p1.Equals(p2): {p1.Equals(p2)}");
// Console.WriteLine($"p1.Equals(p3): {p1.Equals(p3)}");

// class Player
// {
//     public string Name;
//     public int Level;

//     public Player(string name, int level)
//     {
//         Name = name;
//         Level = level;
//     }
// }

// 3. 구조체의 기본 동등성 비교
// Position pos1 = new Position(10, 20);
// Position pos2 = new Position(10, 20);
// Position pos3 = new Position(30, 40);

// Console.WriteLine($"pos1.Equals(pos2): {pos1.Equals(pos2)}");  // 값 비교
// Console.WriteLine($"pos1.Equals(pos3): {pos1.Equals(pos3)}");  // 값 비교

// // 위치 정보를 담는 구조체
// struct Position
// {
//     public int X;
//     public int Y;

//     public Position(int x, int y)
//     {
//         X = x;
//         Y = y;
//     }
// }

// 4. IEquatable<T> 구현하기
// Item item1 = new Item("Sword", 1);
// Item item2 = new Item("Sword", 1);
// Item item3 = new Item("Shield", 2);

// Console.WriteLine($"item1.Equals(item2): {item1.Equals(item2)}");
// Console.WriteLine($"item1.Equals(item3): {item1.Equals(item3)}");

// // HashSet에서 동등성 비교 활용
// HashSet<Item> inventory = new HashSet<Item>();
// inventory.Add(item1);
// Console.WriteLine($"inventory.Contains(item2): {inventory.Contains(item2)}");

// class Item : IEquatable<Item>
// {
//     public string Name;
//     public int Id;

//     public Item(string name, int id)
//     {
//         Name = name;
//         Id = id;
//     }

//     // IEquatable<Item> 구현
//     public bool Equals(Item other)
//     {
//         if (other == null)
//         {
//             return false;
//         }
//         return Id == other.Id && Name == other.Name;
//     }

//     // object.Equals() 오버라이드 (일관성을 위해 함께 구현)
//     public override bool Equals(object obj)
//     {
//         return Equals(obj as Item);
//     }

//     // GetHashCode() 오버라이드 (Equals를 오버라이드하면 반드시 함께 구현)
//     public override int GetHashCode()
//     {
//         return HashCode.Combine(Name, Id);
//     }
// }

// 5. GetHashCode의 중요성
// BadItem b1 = new BadItem("Potion");
// BadItem b2 = new BadItem("Potion");

// Console.WriteLine($"b1.Equals(b2): {b1.Equals(b2)}");

// // Dictionary에서 문제 발생
// Dictionary<BadItem, int> stock = new Dictionary<BadItem, int>();
// stock[b1] = 10;
// Console.WriteLine($"stock.ContainsKey(b2): {stock.ContainsKey(b2)}");  // 예상과 다름!

// class BadItem
// {
//     public string Name;

//     public BadItem(string name)
//     {
//         Name = name;
//     }

//     public override bool Equals(object obj)
//     {
//         BadItem other = obj as BadItem;
//         if (other == null)
//         {
//             return false;
//         }
//         return Name == other.Name;
//     }

//     // GetHashCode를 오버라이드하지 않음 - 잘못된 예!
// }

// 6. IComparable<T> 구현하기
// List<Monster> monsters = new List<Monster>
// {
//     new Monster("Goblin", 30),
//     new Monster("Dragon", 100),
//     new Monster("Slime", 10),
//     new Monster("Orc", 50)
// };

// Console.WriteLine("정렬 전:");
// foreach (Monster m in monsters)
// {
// Console.WriteLine($"  {m}");
// }

// monsters.Sort();  // IComparable<T> 사용

// Console.WriteLine("\n정렬 후:");
// foreach (Monster m in monsters)
// {
// Console.WriteLine($"  {m}");
// }

// class Monster : IComparable<Monster>
// {
//     public string Name;
//     public int Power;

//     public Monster(string name, int power)
//     {
//         Name = name;
//         Power = power;
//     }

//     // 전투력 기준으로 비교
//     public int CompareTo(Monster other)
//     {
//         if (other == null)
//         {
//             return 1;  // null보다 항상 큼
//         }
//         return Power.CompareTo(other.Power);
//     }

//     public override string ToString()
//     {
//         return $"{Name}(전투력:{Power})";
//     }
// }

// 7. 다중 기준 정렬
// List<Student> students = new List<Student>
// {
//     new Student("김철수", 2, 85),
//     new Student("이영희", 1, 92),
//     new Student("박민수", 2, 85),
//     new Student("정수진", 1, 88),
//     new Student("최동훈", 2, 90)
// };

// students.Sort();

// Console.WriteLine("정렬 결과:");
// foreach (Student s in students)
// {
// Console.WriteLine($"  {s}");
// }

// class Student : IComparable<Student>
// {
//     public string Name;
//     public int Grade;
//     public int Score;

//     public Student(string name, int grade, int score)
//     {
//         Name = name;
//         Grade = grade;
//         Score = score;
//     }

//     // 학년 → 점수(내림차순) → 이름 순으로 정렬
//     public int CompareTo(Student other)
//     {
//         if (other == null)
//         {
//             return 1;
//         }

//         // 1차: 학년 비교
//         int result = Grade.CompareTo(other.Grade);
//         if (result != 0)
//         {
//             return result;
//         }

//         // 2차: 점수 비교 (내림차순 = 순서 반대)
//         result = other.Score.CompareTo(Score);
//         if (result != 0)
//         {
//             return result;
//         }

//         // 3차: 이름 비교
//         return Name.CompareTo(other.Name);
//     }

//     public override string ToString()
//     {
//         return $"{Grade}학년 {Name} ({Score}점)";
//     }
// }

// 8. EqualityComparer<T> 상속하기
// Customer c1 = new Customer("Kim", "Cheolsu");
// Customer c2 = new Customer("Kim", "Cheolsu");

// // 기본 Dictionary - 참조 비교
// Dictionary<Customer, string> dict1 = new Dictionary<Customer, string>();
// dict1[c1] = "VIP";
// Console.WriteLine($"기본 Dictionary - c2 검색: {dict1.ContainsKey(c2)}");

// // 커스텀 비교기 사용 Dictionary - 값 비교
// Dictionary<Customer, string> dict2 = new Dictionary<Customer, string>(new CustomerNameComparer());
// dict2[c1] = "VIP";
// Console.WriteLine($"커스텀 Dictionary - c2 검색: {dict2.ContainsKey(c2)}");

// 고객 정보 클래스
// class Customer
// {
//     public string LastName;
//     public string FirstName;

//     public Customer(string lastName, string firstName)
//     {
//         LastName = lastName;
//         FirstName = firstName;
//     }

//     public override string ToString()
//     {
//         return $"{LastName} {FirstName}";
//     }
// }

// // 이름 기준 동등성 비교기
// class CustomerNameComparer : EqualityComparer<Customer>
// {
//     public override bool Equals(Customer x, Customer y)
//     {
//         if (x == null && y == null)
//         {
//             return true;
//         }
//         if (x == null || y == null)
//         {
//             return false;
//         }
//         return x.LastName == y.LastName && x.FirstName == y.FirstName;
//     }

//     public override int GetHashCode(Customer obj)
//     {
//         if (obj == null)
//         {
//             return 0;
//         }
//         return HashCode.Combine(obj.LastName, obj.FirstName);
//     }
// }

// 9. 대소문자 무시 문자열 비교기
// Dictionary<string, int> caseInsensitive =
//     new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

// caseInsensitive["Apple"] = 100;
// caseInsensitive["BANANA"] = 200;

// Console.WriteLine($"apple 검색: {caseInsensitive["apple"]}");
// Console.WriteLine($"Banana 검색: {caseInsensitive["Banana"]}");

// // 일반 딕셔너리와 비교
// Dictionary<string, int> caseSensitive = new Dictionary<string, int>();
// caseSensitive["Apple"] = 100;

// Console.WriteLine($"\n일반 Dictionary에서 'apple' 존재 여부: {caseSensitive.ContainsKey("apple")}");

// 10. Comparer<T> 상속하기
// List<Quest> quests = new List<Quest>
// {
//     new Quest("드래곤 처치", 1, 10000),
//     new Quest("약초 수집", 3, 100),
//     new Quest("마을 방어", 2, 500),
//     new Quest("보물 찾기", 2, 3000)
// };

// Console.WriteLine("우선순위 기준 정렬:");
// quests.Sort(new QuestPriorityComparer());
// foreach (Quest q in quests)
// {
// Console.WriteLine($"  {q}");
// }

// Console.WriteLine("\n보상 기준 정렬 (내림차순):");
// quests.Sort(new QuestRewardComparer());
// foreach (Quest q in quests)
// {
// Console.WriteLine($"  {q}");
// }

// // 게임 퀘스트 클래스
// class Quest
// {
//     public string Name;
//     public int Priority;      // 낮을수록 중요
//     public int RewardGold;

//     public Quest(string name, int priority, int rewardGold)
//     {
//         Name = name;
//         Priority = priority;
//         RewardGold = rewardGold;
//     }

//     public override string ToString()
//     {
//         return $"[우선순위{Priority}] {Name} (보상:{RewardGold}골드)";
//     }
// }

// // 우선순위 기준 비교기
// class QuestPriorityComparer : Comparer<Quest>
// {
//     public override int Compare(Quest x, Quest y)
//     {
//         if (x == null && y == null)
//         {
//             return 0;
//         }
//         if (x == null)
//         {
//             return -1;
//         }
//         if (y == null)
//         {
//             return 1;
//         }
//         return x.Priority.CompareTo(y.Priority);
//     }
// }

// // 보상 기준 비교기 (내림차순)
// class QuestRewardComparer : Comparer<Quest>
// {
//     public override int Compare(Quest x, Quest y)
//     {
//         if (x == null && y == null)
//         {
//             return 0;
//         }
//         if (x == null)
//         {
//             return -1;
//         }
//         if (y == null)
//         {
//             return 1;
//         }
//         // 내림차순: y와 x의 순서를 바꿈
//         return y.RewardGold.CompareTo(x.RewardGold);
//     }
// }

// 11. StringComparer 정렬
// string[] fruits = { "apple", "Banana", "CHERRY", "date", "Elderberry" };

// Console.WriteLine("Ordinal 정렬 (대소문자 구분):");
// Array.Sort(fruits, StringComparer.Ordinal);
// Console.WriteLine(string.Join(", ", fruits));

// Console.WriteLine("\nOrdinalIgnoreCase 정렬:");
// fruits = new[] { "apple", "Banana", "CHERRY", "date", "Elderberry" };
// Array.Sort(fruits, StringComparer.OrdinalIgnoreCase);
// Console.WriteLine(string.Join(", ", fruits));

// 12. Comparer<T>.Create() 메서드
// List<Product> products = new List<Product>
// {
//     new Product("키보드", 50000),
//     new Product("마우스", 30000),
//     new Product("모니터", 300000),
//     new Product("헤드셋", 80000)
// };

// // 가격 오름차순 비교기 생성
// Comparer<Product> priceAsc = Comparer<Product>.Create(
//     (x, y) => x.Price.CompareTo(y.Price)
// );

// products.Sort(priceAsc);
// Console.WriteLine("가격 오름차순:");
// foreach (Product p in products)
// {
// Console.WriteLine($"  {p}");
// }

// // 이름 내림차순 비교기 생성
// Comparer<Product> nameDesc = Comparer<Product>.Create(
//     (x, y) => y.Name.CompareTo(x.Name)
// );

// products.Sort(nameDesc);
// Console.WriteLine("\n이름 내림차순:");
// foreach (Product p in products)
// {
// Console.WriteLine($"  {p}");
// }

// class Product
// {
//     public string Name;
//     public int Price;

//     public Product(string name, int price)
//     {
//         Name = name;
//         Price = price;
//     }

//     public override string ToString()
//     {
//         return $"{Name}: {Price}원";
//     }
// }

// 13. SortedDictionary와 비교기
// SortedDictionary<int, string> scoreBoard = new SortedDictionary<int, string>(
//     Comparer<int>.Create((x, y) => y.CompareTo(x))  // 내림차순
// );

// scoreBoard[85] = "Kim";
// scoreBoard[92] = "Lee";
// scoreBoard[78] = "Park";
// scoreBoard[92] = "Choi";  // 같은 점수면 덮어씀

// Console.WriteLine("점수 순위표:");
// int rank = 1;
// foreach (KeyValuePair<int, string> entry in scoreBoard)
// {
//     Console.WriteLine($"  {rank}위: {entry.Value} ({entry.Key}점)");
//     rank++;
// }

// 14. HashSet과 동등성 비교
// HashSet<Equipment> equippedItems = new HashSet<Equipment>(new EquipmentTypeComparer());

// equippedItems.Add(new Equipment("불꽃 검", "무기"));
// equippedItems.Add(new Equipment("철 갑옷", "방어구"));
// equippedItems.Add(new Equipment("얼음 검", "무기"));    // 무기 타입 이미 존재
// equippedItems.Add(new Equipment("가죽 장갑", "장갑"));

// Console.WriteLine("장착된 장비:");
// foreach (Equipment e in equippedItems)
// {
// Console.WriteLine($"  {e}");
// }

// class Equipment
// {
//     public string Name;
//     public string Type;

//     public Equipment(string name, string type)
//     {
//         Name = name;
//         Type = type;
//     }

//     public override string ToString()
//     {
//         return $"{Type}: {Name}";
//     }
// }

// // 타입 기준으로 중복 제거하는 비교기
// class EquipmentTypeComparer : EqualityComparer<Equipment>
// {
//     public override bool Equals(Equipment x, Equipment y)
//     {
//         if (x == null && y == null)
//         {
//             return true;
//         }
//         if (x == null || y == null)
//         {
//             return false;
//         }
//         return x.Type == y.Type;  // 타입만 비교
//     }

//     public override int GetHashCode(Equipment obj)
//     {
//         return obj?.Type?.GetHashCode() ?? 0;
//     }
// }

// 15. EqualityComparer<T>.Default
int[] numbers = { 1, 2, 3, 4, 5 };
string[] words = { "apple", "banana", "cherry" };

Console.WriteLine($"numbers에 3 포함: {Contains(numbers, 3)}");
Console.WriteLine($"numbers에 10 포함: {Contains(numbers, 10)}");
Console.WriteLine($"words에 'banana' 포함: {Contains(words, "banana")}");
Console.WriteLine($"words에 'grape' 포함: {Contains(words, "grape")}");

// 제네릭 메서드에서 동등성 비교
static bool Contains<T>(T[] array, T target)
{
    EqualityComparer<T> comparer = EqualityComparer<T>.Default;
    foreach (T item in array)
    {
        if (comparer.Equals(item, target))
        {
            return true;
        }
    }
    return false;
}