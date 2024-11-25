using Lab2_1.Decorator;
using Lab2_1.Handlers;
using Lab2_1.States;
using Lab2_1.Toolbars;
using SFML.Graphics;
using SFML.Window;

namespace Lab2_1;

public class Application
{
    private static Application? _instance;
    private static readonly object _lock = new();

    private readonly FiguresHandler _figuresHandler;
    private readonly Toolbar _toolbar;
    private readonly RenderWindow _window;
    private readonly string _filePath;

    // Приватный конструктор
    private Application( RenderWindow window, string path )
    {
        _figuresHandler = new FiguresHandler(window);
        _toolbar = new Toolbar(window, _figuresHandler);
        _filePath = path;
        _window = window;
    }

    // Публичный статический метод для получения экземпляра
    public static Application GetInstance( RenderWindow window, string path )
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Application(window, path);
                }
            }
        }
        return _instance;
    }


    public void ReadFigures()
    {
        _figuresHandler.ReadFigures(_filePath);
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
                            if (_toolbar.GetState() is DragAndDropState)
                            {
                                _figuresHandler.SelectFigures();
                            }
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

                            if (_toolbar.GetState() is DragAndDropState )
                            {
                                _figuresHandler.SelectFigure();
                            }

                            if (_toolbar.GetState() is FillShapeState)
                            {
                                _figuresHandler.SetFillColor(_toolbar.GetColor());
                            }

                            if (_toolbar.GetState() is FillOutlineState)
                            {
                                _figuresHandler.SetOutlineColor(_toolbar.GetColor());
                            }

                            if (_toolbar.GetState() is DragAndDropState || _toolbar.GetState() is FillShapeState || _toolbar.GetState() is FillOutlineState)
                            {
                                _figuresHandler.ChangeOutlineThickness(_toolbar.GetOutlineThickness());
                            }
                        }
                    }
                }
                break;

            case EventType.KeyPressed:

                if (Keyboard.IsKeyPressed(Keyboard.Key.LControl))
                {
                    if (Keyboard.IsKeyPressed(Keyboard.Key.G))
                    {
                        if (_toolbar.GetState() is DragAndDropState)
                        {
                            _figuresHandler.GroupFigures();
                        }
                    }

                    if (Keyboard.IsKeyPressed(Keyboard.Key.U))
                    {
                        if (_toolbar.GetState() is DragAndDropState)
                        {
                            _figuresHandler.UngroupFigures();
                        }
                    }
                }

                break;

            case EventType.MouseMoved:
                if (Mouse.IsButtonPressed(Mouse.Button.Left))
                {
                    if (_toolbar.GetState() is DragAndDropState)
                    {
                        _figuresHandler.Move();
                    }
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
