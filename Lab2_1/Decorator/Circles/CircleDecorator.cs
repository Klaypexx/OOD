using Lab2_1.Shapes.Circles;

namespace Lab2_1.Decorator.Circles;

public class CircleDecorator : FigureDecorator
{
    private readonly CircleShape _circleShape;
    private readonly float _radius;

    public CircleDecorator(CircleShape circleShape) : base(circleShape)
    {
        _circleShape = circleShape;

        _radius = _circleShape.GetRadius();
    }

    public override float GetArea()
    {
        return (float)(Math.PI * Math.Pow(_radius, 2));
    }

    public override float GetPerimeter()
    {
        return (float)(2 * Math.PI * _radius);
    }

    public override string GetDescription()
    {
        return _circleShape.GetType().Name + " | Perimeter: " + GetPerimeter() + " | Area: " + GetArea();
    }
}
