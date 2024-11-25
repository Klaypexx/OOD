using Lab2_1.Commands;
using SFML.Graphics;
using SFML.System;

namespace Lab2_1.Buttons;

public class Button
{
    private readonly RectangleShape _rectangle;
    private readonly Text? _text;
    private readonly Font _font;
    private readonly int _id; 
    private readonly Command? _command = null;

    private bool _isVisible;

    public Button( 
        int id, 
        Vector2f buttonSize,
        Vector2f buttonPosition,
        Vector2f? textPosition,
        string? buttonText, 
        uint fontSize, 
        Color color,
        Command? command,
        bool isVisible )
    {
        _id = id;

        _font = new("C:\\Users\\dimas\\Code\\Volgatech\\OOD\\Lab2_1\\Roboto-Regular.ttf");

        _rectangle = new(buttonSize)
        {
            Position = buttonPosition,
            FillColor = color,
        };

        if (buttonText != null
            && textPosition != null )
        {
            _text = new()
            {
                Position = (Vector2f)textPosition,
                DisplayedString = buttonText,
                FillColor = Color.Black,
                CharacterSize = fontSize,
                Font = _font,
            };
        }

        _isVisible = isVisible;

        _command = command;
    }

    public bool GetVisibleState()
    {
        return _isVisible;
    }

    public void SetVisibleState()
    {
        _isVisible = !_isVisible;
    }

    public FloatRect GetGlobalBounds()
    {
        return _rectangle.GetGlobalBounds();
    }

    public int GetId()
    {
        return _id;
    }

    public void Draw( SFML.Graphics.RenderWindow window )
    {
        window.Draw(_rectangle);

        if (_text != null )
        {
            window.Draw( _text );       
        }
    }

    public void PressButton()
    {
        if (_command != null)
        {
            _command.Execute();
        }
    }
}
