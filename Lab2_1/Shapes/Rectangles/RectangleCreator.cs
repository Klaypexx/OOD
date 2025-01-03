﻿using SFML.System;

namespace Lab2_1.Shapes.Rectangles;

public static class RectangleCreator
{
    public static RectangleShape Create( string[] points )
    {
        string[] p1 = points[0].Split("=")[1].Split(",");
        string[] p2 = points[1].Split("=")[1].Split(",");

        return new RectangleShape(
            new Vector2f(float.Parse(p1[0]), float.Parse(p1[1])),
            new Vector2f(float.Parse(p2[0]), float.Parse(p2[1]))
        );
    }
}
