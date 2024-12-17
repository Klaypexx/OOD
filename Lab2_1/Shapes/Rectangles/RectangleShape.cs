using SFML.Graphics;
using SFML.System;
using System.Drawing;

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
            FillColor = SFML.Graphics.Color.Yellow
        };
    }

    public RectangleShape( RectangleShape rectangleShape )
    {
        _shape = new SFML.Graphics.RectangleShape()
        {
            Size = rectangleShape.GetSize(),
            Position = rectangleShape.GetPosition(),
            FillColor = rectangleShape.GetFillColor(),
            OutlineColor = rectangleShape.GetOutlineColor(),
            OutlineThickness = rectangleShape.GetOutlineThickness()
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

    public override SFML.Graphics.Color GetFillColor()
    {
        return _shape.FillColor;
    }

    public override SFML.Graphics.Color GetOutlineColor()
    {
        return _shape.OutlineColor;
    }

    public override void SetPosition( float x, float y )
    {
        _shape.Position = new Vector2f(x, y);
    }

    public override void SetFillColor( SFML.Graphics.Color color )
    {
        _shape.FillColor = color;
    }

    public override void SetOutlineColor( SFML.Graphics.Color color )
    {
        _shape.OutlineColor = color;
        _shape.OutlineThickness = 5.0f;
    }

    public Vector2f GetSize()
    {
        return _shape.Size;
    }

    public float GetOutlineThickness()
    {
        return _shape.OutlineThickness;
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
