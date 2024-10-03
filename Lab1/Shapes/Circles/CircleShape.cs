using Lab1.Interfaces;
using SFML.Graphics;
using SFML.System;

namespace Lab1.Shapes.Circles;

public class CircleShape : IShape
{
    private readonly SFML.Graphics.CircleShape _shape;

    public CircleShape( Vector2f center, float radius )
    {
        _shape = new SFML.Graphics.CircleShape( radius )
        {
            Position = new Vector2f( center.X - radius, center.Y - radius ),
            FillColor = Color.Blue
        };
    }

    public float GetRadius()
    {
        return _shape.Radius;
    }

    public Drawable GetDrawable() => _shape;
}
