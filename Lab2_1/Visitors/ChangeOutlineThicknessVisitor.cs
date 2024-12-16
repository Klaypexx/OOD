using Lab2_1.Decorator;

namespace Lab2_1.Visitors;

public class ChangeOutlineThicknessVisitor: FigureDecoratorVisitor
{
    private readonly float _outlineThickness;

    public ChangeOutlineThicknessVisitor(float outlineThickness)
    {
        _outlineThickness = outlineThickness;
    }

    public override void Visit( BaseFigureDecorator figure )
    {
        figure.SetOutlineThickness( _outlineThickness );
    }
}
