namespace ConsoleApp3;

public class Side : IEquatable<Side>
{
    private const double Accuracy = 0.000001;
    
    private readonly double _length;

    public Side(double length)
    {
        _length = length;
    }

    public bool Equals(Side? otherSide)
    {
        if (ReferenceEquals(null, otherSide)) return false;
        if (ReferenceEquals(this, otherSide)) return true;

        return Math.Abs(_length - otherSide._length) <= Accuracy;
    }

    public Side Sqr() => new(_length * _length);
    public Side Sqrt() => new(Math.Sqrt(_length));

    public static bool operator ==(Side? side1, Side? side2) => side1?.Equals(side2) ?? false;
    public static bool operator !=(Side? side1, Side? side2) => !(side1 == side2);
    public static Side operator +(Side side1, Side side2) => new(side1._length + side2._length);
    public static Side operator +(Side side1, double num) => new(side1._length + num);
    public static Side operator -(Side side1, Side side2) => new(side1._length - side2._length);
    public static Side operator -(Side side1, double num) => new(side1._length - num);
    public static Side operator *(Side side1, Side side2) => new(side1._length * side2._length);
    public static Side operator *(Side side1, double num) => new(side1._length * num);
    public static Side operator *(double num, Side side1) => new(side1._length * num);
    public static Side operator /(Side side1, double num) => new(side1._length / num);

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Side) obj);
    }

    public override int GetHashCode()
    {
        return _length.GetHashCode();
    }
}