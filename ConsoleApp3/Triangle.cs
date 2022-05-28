namespace ConsoleApp3;

public class Triangle : IEquatable<Triangle>
{
    private const double Accuracy = 0.000001;
    
    private readonly Side[] _sides;

    public static Triangle InitThreeSides(double side1Len, double side2Len, double side3Len)
    {   
        var side1 = new Side(side1Len);
        var side2 = new Side(side2Len);
        var side3 = new Side(side3Len);
        
        return new Triangle(new[] { side1, side2, side3});
    }
    
    public static Triangle InitTwoSides(double side1Len, double angle1Val, double side2Len)
    {
        var side1 = new Side(side1Len);
        var side2 = new Side(side2Len);
        var angle1 = new Angle(angle1Val);
        
        var side3 = (side1.Sqr() + side2.Sqr() - 2 * side1 * side2 * angle1.Cos()).Sqrt();
        
        return new Triangle(new[] {side1, side2, side3});
    }
    
    public static Triangle InitOneSide(double angle1Val, double side1Len, double angle2Val)
    {
        var side1 = new Side(side1Len);
        var angle1 = new Angle(angle1Val);
        var angle2 = new Angle(angle2Val);
        
        var angle3 = new Angle(180) - angle1 - angle2;     // angle3 is opposite to side1

        var side2 = side1 * angle2.Sin() / angle3.Sin();
        var side3 = side1 * angle1.Sin() / angle3.Sin();
        
        return new Triangle(new[] {side1, side2, side3});
    }
    
    private Triangle(Side[] sides)
    {
        _sides = sides;
    }

    public bool Equals(Triangle? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        var usedSides = new bool[3];

        foreach (var side in _sides)
        {
            var index = 0;
            
            foreach (var otherSide in other._sides)
            {
                if (!usedSides[index] && side == otherSide)
                {
                    usedSides[index] = true;
                    break;
                }

                index++;
            }
        }

        return usedSides.All(s => s);
    }

    public static bool operator ==(Triangle triangle1, Triangle triangle2)
    {
        return triangle1.Equals(triangle2);
    }

    public static bool operator !=(Triangle triangle1, Triangle triangle2)
    {
        return !(triangle1 == triangle2);
    }
    
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Triangle) obj);
    }

    public override int GetHashCode()
    {
        return _sides.GetHashCode();
    }
}