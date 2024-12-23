using Lab2_1.Shapes.Rectangles;
using SFML.System;

namespace Lab2_1.Decorator.Rectangles;

public class RectangleDecorator : FigureDecorator
{
    private readonly RectangleShape _rectangleShape;
    private readonly Vector2f _size;

    public RectangleDecorator(RectangleShape rectangleShape) : base(rectangleShape)
    {
        _rectangleShape = rectangleShape;

        _size = _rectangleShape.GetSize();
    }

    public override float GetArea()
    {
        return _size.X * _size.Y;
    }

    public override float GetPerimeter()
    {
        return 2 * (_size.X + _size.Y);
    }

    public override string GetDescription()
    {
        return _rectangleShape.GetType().Name + " | Perimeter: " + GetPerimeter() + " | Area: " + GetArea();
    }
}
