using Lab2_1.Toolbars;
using SFML.Graphics;

namespace Lab2_1.Commands;

internal class SetGreenColorCommand : Command
{
    private readonly Toolbar _toolbar;

    public SetGreenColorCommand( Toolbar toolbar )
    {
        _toolbar = toolbar;
    }

    public override void Execute()
    {
        _toolbar.SetColor(Color.Green);
    }
}
