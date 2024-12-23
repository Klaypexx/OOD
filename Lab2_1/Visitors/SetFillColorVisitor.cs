using Lab2_1.Decorator;
using SFML.Graphics;

namespace Lab2_1.Visitors;

public class SetFillColorVisitor : FigureVisitor
{
    private readonly Color _color;

    public SetFillColorVisitor(Color color)
    {
        _color = color;
    }

    public override void Visit( Shapes.Shape figure )
    {
        figure.SetFillColor(_color);
    }
}
