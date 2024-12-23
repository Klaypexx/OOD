using Lab2_1.Shapes;

namespace Lab2_1.Decorator;

public class FigureDecorator : BaseFigureDecorator
{
    private readonly Shape _shape;

    public FigureDecorator(Shape shape)
    {
        _shape = shape;
    }
}
