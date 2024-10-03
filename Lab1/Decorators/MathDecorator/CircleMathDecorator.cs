using Lab1.Interfaces;
using Lab1.Shapes.Circles;

namespace Lab1.Decorators.MathDecorator;

public class CircleMathDecorator : AbstractShapeDecorator, IMathShape
{
    private readonly float _radius;

    public CircleMathDecorator( CircleShape circle ) : base( circle )
    {
        _radius = circle.GetRadius();
    }

    public float Area()
    {
        return ( float )( Math.PI * Math.Pow( _radius, 2 ) );
    }

    public float Perimeter()
    {
        return ( float )( 2 * Math.PI * _radius );
    }
}
