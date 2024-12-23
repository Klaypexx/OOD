using Lab2_1.Shapes.Rectangles;
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

    public CircleShape(CircleShape circleShape)
    {
        this.SetId(circleShape.GetId());

        _shape = new SFML.Graphics.CircleShape()
        {
            Radius = circleShape.GetRadius(),
            Position = circleShape.GetPosition(),
            FillColor = circleShape.GetFillColor(),
            OutlineColor = circleShape.GetOutlineColor()
        };
    }

    public override Vector2f GetPosition()
    {
        return _shape.Position;
    }

    public override Color GetFillColor()
    {
        return _shape.FillColor;
    }

    public override Color GetOutlineColor()
    {
        return _shape.OutlineColor;
    }

    public override Drawable GetDrawable()
    {
        return _shape;
    }

    public override FloatRect GetGlobalBounds()
    {
        return _shape.GetGlobalBounds();
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

    public override void Draw( RenderWindow window )
    {
        window.Draw(GetDrawable());
    }

    public float GetRadius()
    {
        return _shape.Radius;
    }
}
