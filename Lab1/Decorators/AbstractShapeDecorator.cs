using Lab1.Interfaces;
using SFML.Graphics;

namespace Lab1.Decorators;

public class AbstractShapeDecorator : IShape
{
    protected IShape _shape;
    public AbstractShapeDecorator( IShape shape )
    {
        _shape = shape;
    }

    public Drawable GetDrawable()
    {
        return _shape.GetDrawable();
    }
}
