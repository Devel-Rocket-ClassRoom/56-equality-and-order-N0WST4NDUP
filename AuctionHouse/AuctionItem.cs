using System.Collections.Generic;

public class AuctionItem
{
    public string Name { get; private set; }
    public int CurrentBid { get; private set; }
    public int BidCount { get; private set; }
    public string Category { get; private set; }

    public AuctionItem(string name, int currentBid, int bidCount, string category)
    {
        Name = name;
        CurrentBid = currentBid;
        BidCount = bidCount;
        Category = category;
    }

    public override string ToString() => $"  {Name} [{Category}] - 입찰가: {CurrentBid}골드 (입찰 {BidCount}회)";
}

public class BidComparer : Comparer<AuctionItem>
{
    public override int Compare(AuctionItem x, AuctionItem y)
    {
        if (x == null && y == null)
        {
            return 0;
        }
        if (x == null)
        {
            return 1;
        }
        if (y == null)
        {
            return -1;
        }
        int bidCompare = y.CurrentBid.CompareTo(x.CurrentBid);
        return bidCompare == 0 ? x.Name.CompareTo(y.Name) : bidCompare;
    }
}