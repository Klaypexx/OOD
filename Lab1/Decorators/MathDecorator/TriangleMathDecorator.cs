using Lab1.Interfaces;
using Lab1.Shapes.Triangles;
using SFML.System;

namespace Lab1.Decorators.MathDecorator;

public class TriangleMathDecorator : AbstractShapeDecorator, IMathShape
{
    private readonly float _v1, _v2, _v3;

    public TriangleMathDecorator( TriangleShape triangle ) : base( triangle )
    {
        List<Vector2f> points = triangle.GetPoints();

        _v1 = GetVectorLength( points[ 0 ], points[ 1 ] );
        _v2 = GetVectorLength( points[ 1 ], points[ 2 ] );
        _v3 = GetVectorLength( points[ 0 ], points[ 2 ] );
    }

    public float Area()
    {
        float s = ( _v1 + _v2 + _v3 ) / 2;

        float area = ( float )Math.Sqrt( s * ( s - _v1 ) * ( s - _v2 ) * ( s - _v3 ) );

        return area;
    }

    public float Perimeter()
    {
        var perimeter = _v1 + _v2 + _v3;

        return perimeter;
    }

    private static float GetVectorLength( Vector2f a, Vector2f b ) =>
        ( float )Math.Sqrt( Math.Pow( b.X - a.X, 2 ) + Math.Pow( b.Y - a.Y, 2 ) );
}
