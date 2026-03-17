using System;
using System.Collections.Generic;

List<AuctionItem> list = new()
{
    new AuctionItem("전설의 검", 50000, 12, "무기"),
    new AuctionItem("미스릴 갑옷", 35000, 8, "방어구"),
    new AuctionItem("불꽃 반지", 28000, 15, "장신구"),
    new AuctionItem("회복 물약", 5000, 3, "소비"),
    new AuctionItem("만능 물약", 5000, 20, "소비")
};

list.Sort(new BidComparer());
Console.WriteLine(@$"
=== 입찰가 기준 정렬 (BidComparer) ===
{string.Join("\n", list)}");

var comparer = Comparer<AuctionItem>.Create(
    (x, y) => y.BidCount.CompareTo(x.BidCount)
);
list.Sort(comparer);
Console.WriteLine(@$"
=== 입찰가 기준 정렬 (Create 람다) ===
{string.Join("\n", list)}");
