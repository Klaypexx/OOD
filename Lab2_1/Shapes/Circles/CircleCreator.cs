using SFML.System;

namespace Lab2_1.Shapes.Circles;

public static class CircleCreator
{
    public static CircleShape Create( string[] points )
    {
        string[] c = points[0].Split("=")[1].Split(",");
        string rStr = points[1].Split("=")[1];

        return new CircleShape(
            new Vector2f(float.Parse(c[0]), float.Parse(c[1])),
            float.Parse(rStr)
        );
    }
}
