using Lab2_1.Decorator;
using SFML.Graphics;

namespace Lab2_1.Visitors;

public class SetFillColorVisitor : FigureDecoratorVisitor
{
    private readonly Color _color;

    public SetFillColorVisitor(Color color)
    {
        _color = color;
    }

    public override void Visit( BaseFigureDecorator figure )
    {
        figure.SetFillColor(_color);
    }
}
