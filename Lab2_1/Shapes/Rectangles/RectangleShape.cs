using SFML.Graphics;
using SFML.System;

namespace Lab2_1.Shapes.Rectangles;

public class RectangleShape : Shape
{
    private readonly SFML.Graphics.RectangleShape _shape;

    public RectangleShape( Vector2f topLeft, Vector2f bottomRight )
    {
        Vector2f size = new(bottomRight.X - topLeft.X, bottomRight.Y - topLeft.Y);

        _shape = new SFML.Graphics.RectangleShape(size)
        {
            Position = topLeft,
            FillColor = Color.Yellow
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

    public Vector2f GetSize()
    {
        return _shape.Size;
    }

    public void SetSize( float width, float height )
    {
        _shape.Size = new Vector2f(width, height);
    }

    public void SetOutlineThickness( float thickness )
    {
        _shape.OutlineThickness = thickness;
    }
}
