using Lab2_1.Shapes;
using SFML.Graphics;
using SFML.System;

namespace Lab2_1.Decorator;

public class BaseFigureDecorator
{
    public virtual FloatRect GetGlobalBounds() => throw new NotImplementedException();

    public virtual Vector2f GetPosition() => throw new NotImplementedException();

    public virtual Drawable GetDrawable() => throw new NotImplementedException();

    public virtual string GetDescription() => throw new NotImplementedException();

    public virtual float GetPerimeter() => throw new NotImplementedException();

    public virtual float GetArea() => throw new NotImplementedException();
    public virtual Shapes.Shape GetShape() => throw new NotImplementedException(); 

    public virtual void SetPosition( float left, float top ) => throw new NotImplementedException();

    public virtual void SetFillColor( Color color ) => throw new NotImplementedException(); 

    public virtual void SetOutlineColor( Color color ) => throw new NotImplementedException();

    public virtual void SetSize( float width, float height ) => throw new NotImplementedException();

    public virtual void SetOutlineThickness( float thickness ) => throw new NotImplementedException();

    public virtual void Draw( RenderWindow window ) => throw new NotImplementedException();
}
