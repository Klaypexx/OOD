using Lab2_1.Shapes;
using SFML.System;

namespace Lab2_1.Decorator;

public class FigureDecorator : BaseFigureDecorator
{
    private readonly Shape _shape;

    public FigureDecorator(Shape shape)
    {
        _shape = shape;
    }

    public override SFML.Graphics.FloatRect GetGlobalBounds()
    {
        return _shape.GetGlobalBounds();
    }

    public override Vector2f GetPosition()
    {
        return _shape.GetPosition();
    }

    public override SFML.Graphics.Drawable GetDrawable()
    {
        return _shape.GetDrawable();
    }

    public override void Draw( SFML.Graphics.RenderWindow window )
    {
        window.Draw(GetDrawable());
    }

    public override void SetPosition( float x, float y )
    {
        _shape.SetPosition(x, y);
    }

    public override void SetFillColor( SFML.Graphics.Color color )
    {
        _shape.SetFillColor(color);
    }

    public override void SetOutlineColor( SFML.Graphics.Color color )
    {
        _shape.SetOutlineColor(color);
    }
}
