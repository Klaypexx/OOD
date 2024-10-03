using Lab1.Interfaces;
using Lab1.Shapes.Rectangles;
using SFML.System;

namespace Lab1.Decorators.MathDecorator;

public class RectangleMathDecorator : AbstractShapeDecorator, IMathShape
{
    private readonly Vector2f _size;

    public RectangleMathDecorator( RectangleShape rectangle ) : base( rectangle )
    {
        _size = rectangle.GetSize();
    }

    public float Area()
    {
        return _size.X * _size.Y;
    }

    public float Perimeter()
    {
        return 2 * ( _size.X + _size.Y );
    }
}
