using Lab1.Interfaces;
using SFML.Graphics;
using SFML.System;

namespace Lab1.Shapes.Triangles;

public class TriangleShape : IShape
{
    private readonly ConvexShape _shape;
    private readonly Vector2f _p1, _p2, _p3;

    public TriangleShape( Vector2f p1, Vector2f p2, Vector2f p3 )
    {
        _p1 = p1;
        _p2 = p2;
        _p3 = p3;

        _shape = new ConvexShape( 3 )
        {
            FillColor = Color.Red,
        };

        _shape.SetPoint( 0, p1 );
        _shape.SetPoint( 1, p2 );
        _shape.SetPoint( 2, p3 );
    }

    public List<Vector2f> GetPoints()
    {
        return [ _p1, _p2, _p3 ];
    }

    public Drawable GetDrawable() => _shape;
}
