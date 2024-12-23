namespace Lab2_1.Visitors;

public class ChangeOutlineThicknessVisitor: FigureVisitor
{
    private readonly float _outlineThickness;

    public ChangeOutlineThicknessVisitor(float outlineThickness)
    {
        _outlineThickness = outlineThickness;
    }

    public override void Visit( Shapes.Shape figure )
    {
        figure.SetOutlineThickness( _outlineThickness );
    }
}
