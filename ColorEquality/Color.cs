using System;

public class Color : IEquatable<Color>
{
    public int R { get; private set; }
    public int G { get; private set; }
    public int B { get; private set; }

    public Color(int r, int g, int b)
    {
        R = r;
        G = g;
        B = b;
    }

    public bool IsSimilar(Color other, int threshold)
    {
        return Math.Abs(R - other.R) < threshold && Math.Abs(G - other.G) < threshold && Math.Abs(B - other.B) < threshold;
    }

    public bool Equals(Color other)
    {
        return R == other.R && G == other.G && B == other.B;
    }

    public override int GetHashCode() => HashCode.Combine(R, G, B);

    public override string ToString() => $"RGB({R}, {G}, {B})";
}