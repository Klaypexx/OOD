using SFML.Graphics;
using SFML.System;

namespace Lab2_1.Shapes.Circles;

public class CircleShape : Shape
{
    private readonly SFML.Graphics.CircleShape _shape;

    public CircleShape(Vector2f center, float radius)
    {
        _shape = new SFML.Graphics.CircleShape(radius)
        {
            Position = new Vector2f(center.X - radius, center.Y - radius),
            FillColor = Color.Blue
        };
    }

    public override FloatRect GetGlobalBounds()
    {
        return _shape.GetGlobalBounds();
    }

    public override Vector2f GetPosition()
    {
        return _shape.Position;
    }

    public override Drawable GetDrawable()
    {
        return _shape;
    }

    public override void SetPosition( float x, float y )
    {
        _shape.Position = new Vector2f(x, y);
    }

    public override void SetFillColor( Color color )
    {
        _shape.FillColor = color;
    }

    public override void SetOutlineColor( Color color )
    {
        _shape.OutlineColor = color;
        _shape.OutlineThickness = 5.0f;
    }

    public float GetRadius()
    {
        return _shape.Radius;
    }
}
