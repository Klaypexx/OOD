using Lab2_1.Buttons;
using Lab2_1.Commands;
using Lab2_1.Handlers;
using Lab2_1.States;
using SFML.Graphics;
using SFML.System;

namespace Lab2_1.Toolbars;

public class Toolbar
{
    private readonly List<Button> _buttons = new();
    private readonly RenderWindow _window;
    private readonly FiguresHandler _figreHandler;

    private State _state;
    private Vector2i _cursorPosition;

    private float _outlineThickness = 1;
    private Color _color = Color.Red;

    public Toolbar( RenderWindow window, FiguresHandler figureHandler ) 
    {
        _window = window;   

        _state = new DragAndDropState();

        _figreHandler = figureHandler;

        _buttons.Add(new(0, new Vector2f(125, 30), new Vector2f(10, 0), new Vector2f(10, 0), "Drag & Drop", 22, Color.White, new DragAndDropCommand(this), true));

        _buttons.Add(new(1, new Vector2f(180, 30), new Vector2f(150, 0), new Vector2f(150, 0), "Create Figures", 22, Color.White, new SetFiguresCreateVisibleCommand(this), true));
        _buttons.Add(new(2, new Vector2f(180, 30), new Vector2f(150, 35), new Vector2f(150, 35), "Create Rectangle", 22, Color.White, new CreateRectangleCommand(this), false));
        _buttons.Add(new(2, new Vector2f(180, 30), new Vector2f(150, 70), new Vector2f(150, 70),  "Create Triangle", 22, Color.White, new CreateTriangleCommand(this), false));
        _buttons.Add(new(2, new Vector2f(180, 30), new Vector2f(150, 105), new Vector2f(150, 105), "Create Circle", 22, Color.White, new CreateCircleCommand(this), false));

        _buttons.Add(new(3, new Vector2f(180, 30), new Vector2f(340, 0), new Vector2f(340, 0), "Fill shape", 22, Color.White, new FillShapeCommand(this), true));

        _buttons.Add(new(4, new Vector2f(180, 30), new Vector2f(530, 0), new Vector2f(530, 0), "Fill outline", 22, Color.White, new FillOutlineCommand(this), true));

        _buttons.Add(new(5, new Vector2f(180, 30), new Vector2f(720, 0), new Vector2f(720, 0), "Change thickness", 22, Color.White, new ChangeOutlineThicknessCommand(this), true));
        _buttons.Add(new(6, new Vector2f(50, 30), new Vector2f(720, 35), new Vector2f(740, 35), "-", 22, Color.White, new ReduceThicknessCommand(this), false));
        _buttons.Add(new(6, new Vector2f(50, 30), new Vector2f(850, 35), new Vector2f(870, 35), "+", 22, Color.White, new AddOutlineThicknessCommand(this), false));

        _buttons.Add(new(7, new Vector2f(60, 30), new Vector2f(950, 0), null, null, 22, Color.Red, new SetRedColorCommand(this), true));
        _buttons.Add(new(7, new Vector2f(60, 30), new Vector2f(1020, 0), null, null, 22, Color.Green, new SetGreenColorCommand(this), true));
        _buttons.Add(new(7, new Vector2f(70, 30), new Vector2f(1090, 0), null, null, 22, Color.Blue, new SetBlueColorCommand(this), true));
    }

    public void SetCursorPosition( Vector2i position )
    {
        _cursorPosition = position;
    }

    public void SetFiguresCreateVisible()
    {
        foreach (Button button in _buttons)
        {
            if (button.GetId() == 2)
            {
                button.SetVisibleState();
            }
        }
    }

    public void SetChangeThicknessVisible()
    {
        _state = new OutlineThicknessState();

        foreach (Button button in _buttons)
        {
            if (button.GetId() == 6)
            {
                button.SetVisibleState();
            }
        }
    }

    public void AddOutlineThickness()
    {
        _state = new OutlineThicknessState();

        if (_outlineThickness >= 5)
        {
            return;
        }

        _outlineThickness++;
    }

    public void ReduceOutlineThickness()
    {
        _state = new OutlineThicknessState();

        if (_outlineThickness <= 1)
        {
            return;
        }

        _outlineThickness--;
    }

    public void DragAndDrop()
    {
        _state = new DragAndDropState();
    }

    public void FillShape()
    {
        _state = new FillShapeState();
    }

    public void FillOutline()
    {
        _state = new FillOutlineState();
    }

    public void SetColor( Color color )
    {
        _color = color;
        Console.WriteLine(_color.ToString());
    }

    public void CreateRectangle()
    {
        _figreHandler.CreateRectangle();
    }

    public void CreateTriangle()
    {
        _figreHandler.CreateTriangle();
    }

    public void CreateCircle()
    {
        _figreHandler.CreateCircle();
    }

    public void SetState( State state )
    {
        _state = state;
        Console.WriteLine(GetState());
    }

    public void ResetState()
    {
        _state = new();
    }

    public State GetState()
    {
        return _state;
    }

    public Color GetColor()
    {
        return _color;
    }

    public float GetOutlineThickness()
    {
        return _outlineThickness;
    }

    public bool PressToolButton()
    {
        foreach( Button button in _buttons )
        {
            if (button.GetGlobalBounds().Contains(_cursorPosition.X, _cursorPosition.Y))
            {
                button.PressButton();
                return true;
            }
        }
        return false;
    }

    public void Draw()
    {
        foreach( Button button in _buttons )
        {
            if (button.GetVisibleState())
            {
                button.Draw(_window);
            }
        }
    }
}
