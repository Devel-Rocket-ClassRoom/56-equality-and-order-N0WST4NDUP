using System;
using System.Collections.Generic;

List<TodoTask> todo = new()
{
    new("보고서 작성", 3, "2026-03-15"),
    new("이메일 확인", 1, "2026-03-10"),
    new("버그 수정", 3, "2026-03-10"),
    new("회의 준비", 2, "2026-03-12"),
    new("코드 리뷰", 3, "2026-03-10"),
};

Console.WriteLine(@$"
=== 정렬 전 ===
{string.Join("\n", todo)}");

todo.Sort((a, b) => a.CompareTo(b));
Console.WriteLine(@$"
=== 정렬 후 ===
{string.Join("\n", todo)}");