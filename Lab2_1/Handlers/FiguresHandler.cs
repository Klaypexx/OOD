using Lab2_1.Composites;
using Lab2_1.Decorator;
using Lab2_1.Decorator.Circles;
using Lab2_1.Decorator.Rectangles;
using Lab2_1.Decorator.Triangles;
using Lab2_1.Shapes.Circles;
using Lab2_1.Shapes.Rectangles;
using Lab2_1.Shapes.Triangle;
using Lab2_1.Visitors;
using SFML.Graphics;
using SFML.System;

namespace Lab2_1.Handlers;

public class FiguresHandler
{
    private readonly List<BaseFigureDecorator> _figures;
    private readonly HashSet<BaseFigureDecorator> _selectedFigures;
    private BaseFigureDecorator? _globalFrame = null;
    private readonly RenderWindow _window;

    private Vector2i _cursorPosition, _previousCursorPosition;

    public FiguresHandler( RenderWindow window )
    {
        _window = window;
        _figures = [];
        _selectedFigures = [];
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
                _figures.Add((BaseFigureDecorator)new TriangleDecorator(TriangleCreator.Create(points)));
            }
            else if (type == "RECTANGLE")
            {
                _figures.Add((BaseFigureDecorator)new RectangleDecorator(RectangleCreator.Create(points)));
            }
            else if (type == "CIRCLE")
            {
                _figures.Add((BaseFigureDecorator)new CircleDecorator(CircleCreator.Create(points)));
            }
        }
    }

    public List<BaseFigureDecorator> GetFigures()
    {
        return _figures;
    }

    public void CreateRectangle()
    {
        CreateFigures(["RECTANGLE: P1=200,200; P2=300,300;"]);
    }

    public void CreateTriangle()
    {
        CreateFigures(["TRIANGLE: P1=100,400; P2=100,500; P3=300,600;"]);
    }

    public void CreateCircle()
    {
        CreateFigures(["CIRCLE: C=100,100; R=50;"]);
    }

    public void Draw()
    {
        foreach (BaseFigureDecorator figure in _figures)
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

    public void Visit(FigureDecoratorVisitor visitor)
    {
        foreach (BaseFigureDecorator figure in _selectedFigures)
        {
            visitor.Visit(figure);
        }
    }

    public void GlobalFrameVisit(FigureDecoratorVisitor visitor)
    {
        if (_globalFrame is null)
        {
            return;
        }

        visitor.Visit(_globalFrame);
    }

    public void SelectFigures()
    {
        foreach (BaseFigureDecorator figure in _figures)
        {
            if (figure.GetGlobalBounds().Contains(_cursorPosition.X, _cursorPosition.Y))
            {
                if (_selectedFigures.Contains(figure))
                {
                    continue;
                }
                _selectedFigures.Add(figure);
                Console.WriteLine(string.Join(", ", _selectedFigures.Select(x => x.ToString())));
                SelectedFiguresCount();
                UpdateFrameBound();
            }
        }
    }

    public void SelectFigure()
    {
        foreach (BaseFigureDecorator figure in _figures)
        {
            if (figure.GetGlobalBounds().Contains(_cursorPosition.X, _cursorPosition.Y))
            {
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
            FigureComposite figureComposite = new();

            foreach (var figure in _selectedFigures)
            {
                {
                    figureComposite.Add(figure);
                }
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

            // Определяем границы панели инструментов
            float toolbarHeight = 40.0f; // высота панели инструментов

            // Перемещаем каждую выбранную фигуру
            foreach (BaseFigureDecorator figure in _selectedFigures)
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


    private void UpdateFrameBound()
    {
        if (_selectedFigures.Count > 0)
        {
            // Инициализируем координаты для topLeft и bottomRight
            float left = float.MaxValue, top = float.MaxValue;
            float right = float.MinValue, bottom = float.MinValue;

            // Перебираем все выбранные фигуры, чтобы найти границы
            foreach (BaseFigureDecorator figure in _selectedFigures)
            {
                var bounds = figure.GetGlobalBounds();
                if (bounds.Left < left) left = bounds.Left;
                if (bounds.Top < top) top = bounds.Top;
                if (bounds.Left + bounds.Width > right) right = bounds.Left + bounds.Width;
                if (bounds.Top + bounds.Height > bottom) bottom = bounds.Top + bounds.Height;
            }

            if (_globalFrame is null)
            {
                Shapes.Rectangles.RectangleShape rectangleShape = new(new(0, 0), new(0, 0));
                rectangleShape.SetFillColor(Color.Transparent);
                rectangleShape.SetOutlineColor(Color.Red);
                rectangleShape.SetOutlineThickness(1);

                _globalFrame = new RectangleDecorator(rectangleShape);
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

    private void UnselectFigure( BaseFigureDecorator figure )
    {
        _selectedFigures.Remove(figure);
    }

    public void UnselectFigure()
    {
        if (_selectedFigures.Count() > 0)
        {
            _selectedFigures.Clear();
            UpdateFrameBound();
        }
    }
}