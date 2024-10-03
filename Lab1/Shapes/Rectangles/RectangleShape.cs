using Lab1.Interfaces;
using SFML.Graphics;
using SFML.System;

namespace Lab1.Shapes.Rectangles;

public class RectangleShape : IShape
{
    private readonly SFML.Graphics.RectangleShape _shape;
    private readonly Vector2f _topLeft, _bottomRight;

    public RectangleShape( Vector2f topLeft, Vector2f bottomRight )
    {
        Vector2f size = new( bottomRight.X - topLeft.X, bottomRight.Y - topLeft.Y );

        _shape = new SFML.Graphics.RectangleShape( size )
        {
            Position = topLeft,
            FillColor = Color.Yellow
        };
    }

    public Vector2f GetSize()
    {
        return _shape.Size;
    }

    public Drawable GetDrawable() => _shape;
}