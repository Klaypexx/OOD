using Lab2_1.Shapes;

namespace Lab2_1.Memento;

public class FigureMemento
{
    private readonly List<Shape> _figures;
    private readonly List<Guid> _selectedFiguresIds;
    private Shape? _globalFrame;

    public FigureMemento( List<Shape> figures,
        List<Guid> selectedFiguresIds,
        Shape? globalFrame )
    {
        _figures = figures;
        _selectedFiguresIds = selectedFiguresIds;
        _globalFrame = globalFrame;
    }

    public List<Guid> GetSelectedFigureIds()
    {
        return _selectedFiguresIds;
    }

    public List<Shape> GetFigures()
    {
        return _figures;
    }

    public Shape? GetGlobalFrame()
    {
        return _globalFrame;
    }
}
