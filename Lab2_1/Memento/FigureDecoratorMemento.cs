using Lab2_1.Decorator;

namespace Lab2_1.Memento;

public class FigureDecoratorMemento
{
    private readonly List<BaseFigureDecorator> _figures;
    private readonly List<BaseFigureDecorator> _selectedFigures;
    private BaseFigureDecorator? _globalFrame;

    public FigureDecoratorMemento( List<BaseFigureDecorator> figures,
        List<BaseFigureDecorator> selectedFigures,
        BaseFigureDecorator? globalFrame )
    {
        _figures = figures;
        _selectedFigures = selectedFigures;
        _globalFrame = globalFrame;
    }

    public List<BaseFigureDecorator> GetFigures()
    {
        return _figures;
    }

    public List<BaseFigureDecorator> GetSelectedFigures()
    {
        return _selectedFigures;
    }

    public BaseFigureDecorator? GetGlobalFrame()
    {
        return _globalFrame;
    }
}
