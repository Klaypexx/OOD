using Lab2_1.Shapes.Triangle;
using SFML.System;

namespace Lab2_1.Decorator.Triangles;

public class TriangleDecorator : FigureDecorator
{
    private readonly TriangleShape _triangleShape;
    private readonly float _v1, _v2, _v3;

    public TriangleDecorator(TriangleShape triangleShape) : base(triangleShape)
    {
        _triangleShape = triangleShape;

        List<Vector2f> points = _triangleShape.GetPoints();

        _v1 = GetVectorLength(points[0], points[1]);
        _v2 = GetVectorLength(points[1], points[2]);
        _v3 = GetVectorLength(points[0], points[2]);
    }

    public override float GetArea()
    {
        float s = (_v1 + _v2 + _v3) / 2;

        float area = (float)Math.Sqrt(s * (s - _v1) * (s - _v2) * (s - _v3));

        return area;
    }

    public override float GetPerimeter()
    {
        var perimeter = _v1 + _v2 + _v3;

        return perimeter;
    }

    public override string GetDescription()
    {
        return _triangleShape.GetType().Name + " | Perimeter: " + GetPerimeter() + " | Area: " + GetArea();
    }

    private static float GetVectorLength(Vector2f a, Vector2f b) =>
        (float)Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));
}
