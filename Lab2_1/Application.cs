using Lab2_1.Decorator;
using Lab2_1.Handlers;
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

    // Приватный конструктор
    private Application( MyWindow window )
    {
        _figuresHandler = new FiguresHandler(window);
        _toolbar = new Toolbar(window, _figuresHandler);
        _filePath = path;
        _window = window;

        _state = _toolbar.GetState();
    }

    // Публичный статический метод для получения экземпляра
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
                _window.Close();
                break;
            case EventType.MouseButtonPressed:
                if (Keyboard.IsKeyPressed(Keyboard.Key.LShift))
                {
                    if (e.Type == EventType.MouseButtonPressed)
                    {
                        if (e.MouseButton.Button == Mouse.Button.Left)
                        {
                            _state.OnLeftMouseButtonWithShift(_figuresHandler);
                        }
                    }
                }
                else
                {
                    if (e.Type == EventType.MouseButtonPressed)
                    {
                        if (e.MouseButton.Button == Mouse.Button.Left)
                        {
                            _toolbar.PressToolButton();
                            _state = _toolbar.GetState();

                            _state.OnLeftMouseButton(_figuresHandler, _toolbar);
                        }
                    }
                }
                break;

            case EventType.KeyPressed:

                if (Keyboard.IsKeyPressed(Keyboard.Key.LControl))
                {
                    if (Keyboard.IsKeyPressed(Keyboard.Key.G))
                    {
                        _state.OnGroup(_figuresHandler);
                    }

                    if (Keyboard.IsKeyPressed(Keyboard.Key.U))
                    {
                        _state.OnUngroup(_figuresHandler);
                    }
                }

                break;

            case EventType.MouseMoved:
                if (Mouse.IsButtonPressed(Mouse.Button.Left))
                {
                    _state.OnMouseMove(_figuresHandler);
                }
                break;
        }
    }

    public void PrintFiguresInfo()
    {
        List<BaseFigureDecorator> figures = _figuresHandler.GetFigures();

        foreach (BaseFigureDecorator figure in figures)
        {
            Console.WriteLine(figure.GetDescription());
        }
    }

    public void Draw()
    {
        _figuresHandler.Draw();
        _toolbar.Draw();
    }
}
