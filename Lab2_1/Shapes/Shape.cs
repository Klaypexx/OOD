using SFML.Graphics;
using SFML.System;

namespace Lab2_1.Shapes;

public abstract class Shape
{
    public abstract Vector2f GetPosition();
    public abstract FloatRect GetGlobalBounds();
    public abstract Drawable GetDrawable();
    public abstract void SetPosition( float x, float y );
    public abstract void SetFillColor( Color color );
    public abstract void SetOutlineColor( Color color );
}
