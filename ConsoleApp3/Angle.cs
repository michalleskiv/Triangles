namespace ConsoleApp3;

public class Angle : IEquatable<Angle>
{
    private const double Accuracy = 0.000001;

    private readonly double _degrees;
    private readonly double _radians;

    public Angle(double degrees)
    {
        _degrees = degrees;
        _radians = degrees * 180 / Math.PI;
    }

    public bool Equals(Angle? otherAngle)
    {
        if (ReferenceEquals(null, otherAngle)) return false;
        if (ReferenceEquals(this, otherAngle)) return true;

        return Math.Abs(_degrees - otherAngle._degrees) <= Accuracy;
    }

    public static bool operator ==(Angle? angle1, Angle? angle2)
    {
        return angle1?.Equals(angle2) ?? false;
    }

    public static bool operator !=(Angle? angle1, Angle? angle2)
    {
        return !(angle1 == angle2);
    }

    public static Angle operator -(Angle angle1, Angle angle2) => new(angle1._degrees - angle2._degrees);
    public static Angle operator -(Angle angle, double number) => new(angle._degrees - number);
    public static Angle operator *(Angle angle, double number) => new(angle._degrees * number);
    public static Angle operator *(double number, Angle angle) => new(angle._degrees * number);
    public static Angle operator /(Angle angle, double number) => new(angle._degrees / number);
    public double Sin() => Math.Sin(_radians);
    public double Cos() => Math.Cos(_radians);

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Angle) obj);
    }

    public override int GetHashCode()
    {
        return _degrees.GetHashCode();
    }
}