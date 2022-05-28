using ConsoleApp3;

var triangles = new Triangle[2];

for (var i = 0; i < 2; i++)
{
    Console.WriteLine($"Trojuhelnik #{i + 1}:");
    var lineParsed = (Console.ReadLine() ?? string.Empty).Split(" ");
    var method = lineParsed[0];
    var arguments = lineParsed.Skip(1).Select(double.Parse).ToArray();

    triangles[i] = method switch
    {
        "SSS" => Triangle.InitThreeSides(arguments[0], arguments[1], arguments[2]),
        "SUS" => Triangle.InitTwoSides(arguments[0], arguments[1], arguments[2]),
        "USU" => Triangle.InitOneSide(arguments[0], arguments[1], arguments[2]),
        _ => throw new Exception()
    };
}

Console.WriteLine(triangles[0] == triangles[1] ? "Trojuhelniky jsou shodne." : "Trojuhelniky nejsou shodne.");
