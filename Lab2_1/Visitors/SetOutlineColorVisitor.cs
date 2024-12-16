using Lab2_1.Decorator;
using SFML.Graphics;

namespace Lab2_1.Visitors;

public class SetOutlineColorVisitor: FigureDecoratorVisitor
{
    private readonly Color _color;

    public SetOutlineColorVisitor( Color color )
    {
        _color = color;
    }

    public override void Visit( BaseFigureDecorator figure )
    {
        figure.SetOutlineColor(_color);
    }
}
