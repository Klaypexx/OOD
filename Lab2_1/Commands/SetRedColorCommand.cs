using Lab2_1.Toolbars;
using SFML.Graphics;

namespace Lab2_1.Commands;

internal class SetRedColorCommand : Command
{
    private readonly Toolbar _toolbar;

    public SetRedColorCommand( Toolbar toolbar )
    {
        _toolbar = toolbar;
    }

    public override void Execute()
    {
        _toolbar.SetColor(Color.Red);
    }
}
