using Lab2_1.Decorator;
using Lab2_1.Decorator.Circles;
using Lab2_1.Decorator.Rectangles;
using Lab2_1.Decorator.Triangles;
using Lab2_1.Handlers;
using Lab2_1.Shapes;
using Lab2_1.Shapes.Circles;
using Lab2_1.Shapes.Rectangles;
using Lab2_1.Shapes.Triangle;
using Lab2_1.States;
using Lab2_1.Toolbars;
using SFML.Window;

namespace Lab2_1;

public class Application
{
    private readonly string path = "C:\\Users\\dimas\\Code\\Volgatech\\OOD\\Lab2_1\\input.txt";

    private static Application? _instance;
    private static readonly object _lock = new();

    private readonly FiguresHandler _figuresHandler;
    private readonly Toolbar _toolbar;
    private readonly MyWindow _window;
    private readonly string _filePath;

    private State _state;

    private Application( MyWindow window )
    {
        _figuresHandler = new FiguresHandler(window);
        _toolbar = new Toolbar(window, _figuresHandler);
        _filePath = path;
        _window = window;

        _state = _toolbar.GetState();
    }

    public static Application GetInstance( MyWindow window )
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Application(window);
                }
            }
        }
        return _instance;
    }


    public void ReadFigures()
    {
        _figuresHandler.ReadFigures(_filePath);
    }

    public void Run()
    {
        while (_window.IsOpen)
        {
            Event e;
            while (_window.TryPollEvent(out e))
            {
                Process(e);
            }

            _window.Clear();
            Draw();
            _window.Display();
        }
    }

    public void Process( Event e )
    {
        _figuresHandler.SetCursorPosition(Mouse.GetPosition(_window));
        _toolbar.SetCursorPosition(Mouse.GetPosition(_window));

        switch (e.Type)
        {
            case EventType.Closed:
                HandleClosedEvent();
                break;
            case EventType.MouseButtonPressed:
                HandleMouseButtonPressedEvent(e);
                break;
            case EventType.KeyPressed:
                HandleKeyPressedEvent();
                break;
            case EventType.MouseMoved:
                HandleMouseMovedEvent();
                break;
        }
    }

    public void PrintFiguresInfo()
    {
        List<Shape> figures = _figuresHandler.GetFigures();

        if (figures.Count < 0)
        {
            return;
        }

        List<BaseFigureDecorator> figureDecorators = new List<BaseFigureDecorator>();

        foreach (Shape figure in figures)
        {
            if (figure is RectangleShape)
            {
                figureDecorators.Add(new RectangleDecorator((RectangleShape)figure));
            }
            else if (figure is CircleShape)
            {
                figureDecorators.Add(new CircleDecorator((CircleShape)figure));
            }    
            else if (figure is TriangleShape)
            {
                figureDecorators.Add(new TriangleDecorator((TriangleShape)figure));
            }
        }

        foreach (BaseFigureDecorator figure in figureDecorators)
        {
            Console.WriteLine(figure.GetDescription());
        }
    }

    private void Draw()
    {
        _figuresHandler.Draw();
        _toolbar.Draw();
    }

    private void HandleClosedEvent()
    {
        _window.Close();
    }

    private void HandleMouseButtonPressedEvent( Event e )
    {
        if (Keyboard.IsKeyPressed(Keyboard.Key.LShift))
        {
            if (e.MouseButton.Button == Mouse.Button.Left)
            {
                _state.OnLeftMouseButtonWithShift(_figuresHandler);
            }
        }
        else
        {
            if (e.MouseButton.Button == Mouse.Button.Left)
            {
                _toolbar.PressToolButton();
                _state = _toolbar.GetState();
                _state.OnLeftMouseButton(_figuresHandler, _toolbar);
            }
        }
    }

    private void HandleKeyPressedEvent()
    {
        if (Keyboard.IsKeyPressed(Keyboard.Key.LControl))
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.G))
            {
                _state.OnGroup(_figuresHandler);
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.U))
            {
                _state.OnUngroup(_figuresHandler);
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Z))
            {
                _figuresHandler.Undo();
            }
        }
    }

    private void HandleMouseMovedEvent()
    {
        if (Mouse.IsButtonPressed(Mouse.Button.Left))
        {
            _state.OnMouseMove(_figuresHandler);
        }
    }
}
