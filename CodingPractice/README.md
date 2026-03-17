# 코딩 연습 - 동등성과 순서 비교

`Program.cs`에 아래 과제들의 코드를 순서대로 작성하세요.
모든 과제를 작성한 후 실행하면 각 과제의 실행 결과가 순서대로 출력됩니다.

> 💡 변수 이름이 겹치는 경우 중괄호 `{ }`로 코드를 감싸면 각 블록에서 같은 이름을 사용할 수 있습니다.

---

## 1. 참조 동등성과 값 동등성

문자열 `s1`, `s2`에 `"hello"`를 할당하고, `s3`는 `new string("hello".ToCharArray())`으로 생성하세요. `==` 연산자와 `object.ReferenceEquals()`로 비교한 결과를 출력하세요.

**실행 결과**

```
True
True
True
False
```

---

## 2. 클래스의 기본 동등성 비교

`Player` 클래스를 작성하세요. `Name`과 `Level` 필드, 생성자를 포함합니다. 같은 이름과 레벨을 가진 두 인스턴스 `p1`, `p2`를 생성하고, `p3 = p1`으로 같은 참조를 만든 뒤 `==`와 `Equals()`로 비교한 결과를 출력하세요.

**실행 결과**

```
p1 == p2: False
p1 == p3: True
p1.Equals(p2): False
p1.Equals(p3): True
```

---

## 3. 구조체의 기본 동등성 비교

`Position` 구조체를 작성하세요. `X`, `Y` 필드와 생성자를 포함합니다. `pos1(10, 20)`, `pos2(10, 20)`, `pos3(30, 40)`을 생성하고 `Equals()`로 비교한 결과를 출력하세요.

**실행 결과**

```
pos1.Equals(pos2): True
pos1.Equals(pos3): False
```

---

## 4. IEquatable<T> 구현하기

`Item` 클래스를 작성하세요. `Name`, `Id` 필드를 포함하고 `IEquatable<Item>`을 구현합니다. `object.Equals()`와 `GetHashCode()`도 오버라이드하세요. 같은 값을 가진 `item1`, `item2`를 비교하고, `HashSet<Item>`에서 동등성 비교가 동작하는지 확인하세요.

**실행 결과**

```
item1.Equals(item2): True
item1.Equals(item3): False
inventory.Contains(item2): True
```

---

## 5. GetHashCode의 중요성

`BadItem` 클래스를 작성하세요. `Equals()`만 오버라이드하고 `GetHashCode()`는 오버라이드하지 않습니다. 같은 이름의 `b1`, `b2`를 생성하고 `Equals()` 비교 결과와 `Dictionary`에서의 검색 결과를 출력하세요.

**실행 결과**

```
b1.Equals(b2): True
stock.ContainsKey(b2): False
```

---

## 6. IComparable<T> 구현하기

`Monster` 클래스를 작성하세요. `Name`, `Power` 필드를 포함하고 `IComparable<Monster>`를 구현하여 전투력 기준으로 비교합니다. `ToString()`을 오버라이드하세요. 몬스터 리스트를 `Sort()`로 정렬하고 전후 결과를 출력하세요.

**실행 결과**

```
정렬 전:
  Goblin(전투력:30)
  Dragon(전투력:100)
  Slime(전투력:10)
  Orc(전투력:50)

정렬 후:
  Slime(전투력:10)
  Goblin(전투력:30)
  Orc(전투력:50)
  Dragon(전투력:100)
```

---

## 7. 다중 기준 정렬

`Student` 클래스를 작성하세요. `Name`, `Grade`, `Score` 필드를 포함하고 `IComparable<Student>`를 구현하여 학년 → 점수(내림차순) → 이름 순으로 정렬합니다. 학생 리스트를 정렬하고 결과를 출력하세요.

**실행 결과**

```
정렬 결과:
  1학년 이영희 (92점)
  1학년 정수진 (88점)
  2학년 최동훈 (90점)
  2학년 김철수 (85점)
  2학년 박민수 (85점)
```

---

## 8. EqualityComparer<T> 상속하기

`Customer` 클래스와 `CustomerNameComparer` 비교기를 작성하세요. `Customer`에 `LastName`, `FirstName` 필드를 포함합니다. 기본 Dictionary와 커스텀 비교기를 사용하는 Dictionary에서 검색 결과를 비교하세요.

**실행 결과**

```
기본 Dictionary - c2 검색: False
커스텀 Dictionary - c2 검색: True
```

---

## 9. 대소문자 무시 문자열 비교기

`StringComparer.OrdinalIgnoreCase`를 사용하는 Dictionary를 생성하고, 대소문자를 무시하여 키를 검색하세요. 일반 Dictionary와의 차이도 확인하세요.

**실행 결과**

```
apple 검색: 100
Banana 검색: 200

일반 Dictionary에서 'apple' 존재 여부: False
```

---

## 10. Comparer<T> 상속하기

`Quest` 클래스와 두 개의 비교기(`QuestPriorityComparer`, `QuestRewardComparer`)를 작성하세요. 퀘스트 리스트를 우선순위 기준과 보상 기준(내림차순)으로 각각 정렬하여 출력하세요.

**실행 결과**

```
우선순위 기준 정렬:
  [우선순위1] 드래곤 처치 (보상:10000골드)
  [우선순위2] 마을 방어 (보상:500골드)
  [우선순위2] 보물 찾기 (보상:3000골드)
  [우선순위3] 약초 수집 (보상:100골드)

보상 기준 정렬 (내림차순):
  [우선순위1] 드래곤 처치 (보상:10000골드)
  [우선순위2] 보물 찾기 (보상:3000골드)
  [우선순위2] 마을 방어 (보상:500골드)
  [우선순위3] 약초 수집 (보상:100골드)
```

---

## 11. StringComparer 정렬

문자열 배열 `{ "apple", "Banana", "CHERRY", "date", "Elderberry" }`를 `StringComparer.Ordinal`과 `StringComparer.OrdinalIgnoreCase`로 각각 정렬하여 출력하세요.

**실행 결과**

```
Ordinal 정렬 (대소문자 구분):
Banana, CHERRY, Elderberry, apple, date

OrdinalIgnoreCase 정렬:
apple, Banana, CHERRY, date, Elderberry
```

---

## 12. Comparer<T>.Create() 메서드

`Product` 클래스를 작성하세요. `Name`, `Price` 필드를 포함합니다. `Comparer<Product>.Create()`로 가격 오름차순, 이름 내림차순 비교기를 각각 생성하여 정렬 결과를 출력하세요.

**실행 결과**

```
가격 오름차순:
  마우스: 30000원
  키보드: 50000원
  헤드셋: 80000원
  모니터: 300000원

이름 내림차순:
  헤드셋: 80000원
  키보드: 50000원
  모니터: 300000원
  마우스: 30000원
```

---

## 13. SortedDictionary와 비교기

점수 역순으로 정렬되는 `SortedDictionary<int, string>`을 생성하세요. `Comparer<int>.Create()`를 사용하여 내림차순 비교기를 전달합니다. 점수와 이름을 추가하고 순위표를 출력하세요.

**실행 결과**

```
점수 순위표:
  1위: Choi (92점)
  2위: Kim (85점)
  3위: Park (78점)
```

---

## 14. HashSet과 동등성 비교

`Equipment` 클래스와 `EquipmentTypeComparer` 비교기를 작성하세요. 타입 기준으로 중복을 제거하는 `HashSet<Equipment>`를 생성하고 장비를 추가하세요.

**실행 결과**

```
장착된 장비:
  무기: 불꽃 검
  방어구: 철 갑옷
  장갑: 가죽 장갑
```

---

## 15. EqualityComparer<T>.Default

제네릭 메서드 `Contains<T>(T[] array, T target)`을 작성하세요. `EqualityComparer<T>.Default`를 사용하여 배열에서 요소를 검색합니다. 정수 배열과 문자열 배열에서 각각 테스트하세요.

**실행 결과**

```
numbers에 3 포함: True
numbers에 10 포함: False
words에 'banana' 포함: True
words에 'grape' 포함: False
```
