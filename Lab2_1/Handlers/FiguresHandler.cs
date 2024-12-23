using Lab2_1.Composites;
using Lab2_1.Memento;
using Lab2_1.Shapes.Circles;
using Lab2_1.Shapes.Rectangles;
using Lab2_1.Shapes.Triangle;
using Lab2_1.Visitors;
using SFML.Graphics;
using SFML.System;

namespace Lab2_1.Handlers;

public class FiguresHandler
{
    private List<Shapes.Shape> _figures;
    private List<Shapes.Shape> _selectedFigures;
    private Shapes.Shape? _globalFrame = null;
    private readonly RenderWindow _window;
    private readonly List<FigureMemento> _history;

    private Vector2i _cursorPosition, _previousCursorPosition;

    public FiguresHandler( RenderWindow window )
    {
        _window = window;
        _figures = [];
        _selectedFigures = [];
        _history = [];

        UpdateFrameBound();
    }

    public void ReadFigures( string path )
    {
        string[] lines = File.ReadAllLines(path);

        CreateFigures(lines);
    }

    public void CreateFigures( string[] lines )
    {
        foreach (string line in lines)
        {
            string[] parts = line.Split(": ");
            string type = parts[0];
            string[] points = parts[1].Split(";");

            if (type == "TRIANGLE")
            {
                _figures.Add(TriangleCreator.Create(points));
            }
            else if (type == "RECTANGLE")
            {
                _figures.Add(RectangleCreator.Create(points));
            }
            else if (type == "CIRCLE")
            {
                _figures.Add(CircleCreator.Create(points));
            }
        }
    }

    public List<Shapes.Shape> CreateFigures( List<Shapes.Shape> figures )
    {
        List<Shapes.Shape> newFigures = new List<Shapes.Shape>();

        foreach (Shapes.Shape figure in figures)
        {
            if (figure is Shapes.Rectangles.RectangleShape rectangleShape)
            {
                Shapes.Rectangles.RectangleShape newRectangleShape = new Shapes.Rectangles.RectangleShape(rectangleShape);

                newFigures.Add(newRectangleShape);
            }
            else if (figure is Shapes.Circles.CircleShape circleShape)
            {
                Shapes.Circles.CircleShape newRectangleShape = new Shapes.Circles.CircleShape(circleShape);

                newFigures.Add(newRectangleShape);
            }
            else if (figure is TriangleShape triangleShape)
            {
                TriangleShape newTriangleShape = new TriangleShape(triangleShape);

                newFigures.Add(newTriangleShape);
            }
            else if (figure is FigureComposite figureComposite)
            {
                FigureComposite newComposite = new FigureComposite(figureComposite);

                newFigures.Add(newComposite);
            }
        }

        return newFigures;
    }

    public Shapes.Shape CreateFigure( Shapes.Shape? figure )
    {
        Shapes.Shape newFigure = new Shapes.Shape();

        if (figure is Shapes.Rectangles.RectangleShape)
        {
            Shapes.Rectangles.RectangleShape newRectangleShape = new Shapes.Rectangles.RectangleShape((Shapes.Rectangles.RectangleShape)figure);

            newFigure = newRectangleShape;
        }

        return newFigure;
    }

    public List<Shapes.Shape> GetFigures()
    {
        return _figures;
    }

    public void CreateRectangle()
    {
        SaveHistory();
        CreateFigures(["RECTANGLE: P1=200,200; P2=300,300;"]);
    }

    public void CreateTriangle()
    {
        SaveHistory();
        CreateFigures(["TRIANGLE: P1=100,400; P2=100,500; P3=300,600;"]);
    }

    public void CreateCircle()
    {
        SaveHistory();
        CreateFigures(["CIRCLE: C=100,100; R=50;"]);
    }

    public void Draw()
    {
        foreach (Shapes.Shape figure in _figures)
        {
            figure.Draw(_window);
        }

        if (_globalFrame is not null)
        {
            _globalFrame.Draw(_window);
        }
    }

    public void SetCursorPosition( Vector2i position )
    {
        _previousCursorPosition = _cursorPosition;
        _cursorPosition = position;
    }

    public void Visit(FigureVisitor visitor)
    {
        SaveHistory();
        foreach (Shapes.Shape figure in _selectedFigures)
        {
            visitor.Visit(figure);
        }
    }

    public void GlobalFrameVisit(FigureVisitor visitor)
    {
        SaveHistory();
        if (_globalFrame is null)
        {
            return;
        }
        visitor.Visit(_globalFrame);
    }

    public void SelectFigures()
    {
        foreach (Shapes.Shape figure in _figures)
        {
            if (figure.GetGlobalBounds().Contains(_cursorPosition.X, _cursorPosition.Y))
            {
                if (_selectedFigures.Contains(figure))
                {
                    continue;
                }

                SaveHistory();

                _selectedFigures.Add(figure);
                Console.WriteLine(string.Join(", ", _selectedFigures.Select(x => x.ToString())));

                SelectedFiguresCount();
                UpdateFrameBound();
            }
        }
    }

    public void SelectFigure()
    {
        foreach (Shapes.Shape figure in _figures)
        {
            if (figure.GetGlobalBounds().Contains(_cursorPosition.X, _cursorPosition.Y))
            {
                if (!_selectedFigures.Contains(figure))
                {
                    SaveHistory();
                }

                if (_selectedFigures.Count > 1)
                {
                    _selectedFigures.Clear();
                    UpdateFrameBound();
                }

                _selectedFigures.Clear();
                _selectedFigures.Add(figure);

                SelectedFiguresCount();
                UpdateFrameBound();
            }
        }
    }

    public void GroupFigures()
    {
        if (_selectedFigures.Count > 1)
        {
            SaveHistory();
            FigureComposite figureComposite = new();

            foreach (var figure in _selectedFigures)
            {
                figureComposite.Add(figure);
                _figures.Remove(figure);
            }

            _selectedFigures.Clear();
            _selectedFigures.Add(figureComposite);

            _figures.Add(figureComposite);
        }
    }

    public void UngroupFigures()
    {
        if (_selectedFigures.Count > 0)
        {
            // Находим все композитные фигуры среди выбранных
            var composites = _selectedFigures.OfType<FigureComposite>().ToList();

            if (composites.Count > 0)
            {
                foreach (var composite in composites)
                {
                    SaveHistory();
                    // Удаляем композитную фигуру из списка фигур и выбранных фигур
                    _figures.Remove(composite);
                    _selectedFigures.Remove(composite);

                    // Добавляем все дочерние фигуры обратно в список фигур
                    foreach (var figure in composite.GetFigures())
                    {
                        _figures.Add(figure);
                        _selectedFigures.Add(figure);
                    }
                }
            }
        }
    }

    public void Move()
    {
        if (_selectedFigures.Count > 0)
        {
            // Вычисляем смещение курсора
            Vector2i delta = _cursorPosition - _previousCursorPosition;

            // Перемещаем каждую выбранную фигуру
            foreach (Shapes.Shape figure in _selectedFigures)
            {
                Vector2f currentPosition = figure.GetPosition();
                FloatRect bounds = figure.GetGlobalBounds();

                // Перемещаем фигуру с учетом ограничений
                figure.SetPosition(currentPosition.X + delta.X, currentPosition.Y + delta.Y);
            }

            // Обновляем границы рамки для выбранных фигур
            UpdateFrameBound();
        }
    }

    public void Undo()
    {
        Console.WriteLine(_history.Count);
        if (_history.Count > 0)
        {
            var previousMemento = _history.Last();
            _figures = previousMemento.GetFigures();

            var selectedFigureIds = previousMemento.GetSelectedFigureIds();
            _selectedFigures = _figures.Where(f => selectedFigureIds.Contains(f.GetId())).ToList();

            _globalFrame = previousMemento.GetGlobalFrame();
            _history.RemoveAt(_history.Count - 1);
        }
    }

    private void SaveHistory()
    {
        var selectedFigureIds = _selectedFigures.Select(f => f.GetId()).ToList();
        _history.Add(new FigureMemento(CreateFigures(_figures), selectedFigureIds, CreateFigure(_globalFrame)));
    }

    private void UpdateFrameBound()
    {
        if (_globalFrame is null)
        {
            Shapes.Rectangles.RectangleShape rectangleShape = new(new(0, 0), new(0, 0));
            rectangleShape.SetFillColor(Color.Transparent);
            rectangleShape.SetOutlineColor(Color.Red);
            rectangleShape.SetOutlineThickness(1);

            _globalFrame = rectangleShape;
        }

        if (_selectedFigures.Count > 0)
        {
            // Инициализируем координаты для topLeft и bottomRight
            float left = float.MaxValue, top = float.MaxValue;
            float right = float.MinValue, bottom = float.MinValue;

            // Перебираем все выбранные фигуры, чтобы найти границы
            foreach (Shapes.Shape figure in _selectedFigures)
            {
                var bounds = figure.GetGlobalBounds();
                if (bounds.Left < left) left = bounds.Left;
                if (bounds.Top < top) top = bounds.Top;
                if (bounds.Left + bounds.Width > right) right = bounds.Left + bounds.Width;
                if (bounds.Top + bounds.Height > bottom) bottom = bounds.Top + bounds.Height;
            }


            _globalFrame.SetPosition(left, top);
            _globalFrame.SetSize(right - left, bottom - top);
        }
        else
        {
            _globalFrame.SetPosition(0, 0);
            _globalFrame.SetSize(0, 0);
        }
    }

    private void SelectedFiguresCount()
    {
        Console.WriteLine(_selectedFigures.Count());
    }
}