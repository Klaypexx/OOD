using SFML.Graphics;
using SFML.System;

namespace Lab2_1.Shapes;

public class Shape
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid GetId() => Id;
    public void SetId(Guid id)
    {
        Id = id;
    }

    public virtual Vector2f GetPosition() => throw new NotImplementedException();
    public virtual Color GetFillColor() => throw new NotImplementedException();   
    public virtual Color GetOutlineColor() => throw new NotImplementedException();
    public virtual Drawable GetDrawable() => throw new NotImplementedException();
    public virtual FloatRect GetGlobalBounds() => throw new NotImplementedException();
    public virtual void SetPosition( float x, float y ) => throw new NotImplementedException();
    public virtual void SetFillColor( Color color ) => throw new NotImplementedException();
    public virtual void SetOutlineColor( Color color ) => throw new NotImplementedException();
    public virtual void SetOutlineThickness( float thickness ) => throw new NotImplementedException();
    public virtual void SetSize( float width, float height ) => throw new NotImplementedException();
    public virtual void Draw( RenderWindow window ) => throw new NotImplementedException();
}
