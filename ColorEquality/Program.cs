using System;
using System.Collections.Generic;

Console.WriteLine(@$"
=== 동등성 비교 ===
RGB(255, 0, 0) == RGB(255, 0, 0): {new Color(255, 0, 0).Equals(new Color(255, 0, 0))}
RGB(255, 0, 0) == RGB(0, 0, 255): {new Color(255, 0, 0).Equals(new Color(0, 0, 255))}

=== 유사 색상 판정 ===
RGB(255, 0, 0)과 RGB(250, 5, 3)은 유사한가 (임계값 10): {new Color(255, 0, 0).IsSimilar(new Color(255, 0, 3), 10)}
RGB(255, 0, 0)과 RGB(200, 50, 50)은 유사한가 (임계값 10): {new Color(255, 0, 0).IsSimilar(new Color(200, 50, 50), 10)}");

HashSet<Color> set = new()
{
    new Color(255,0,0),
    new Color(0,255,0),
    new Color(0,0,255),
    new Color(255,0,0),
    new Color(0,0,255),
};
Console.WriteLine(@$"
=== HashSet 중복 제거 ===
팔레트에 추가된 색상:
{string.Join("\n", set)}
색상 수: {set.Count}

RGB(255, 0, 0) 포함 여부: {set.Contains(new(255, 0, 0))}");