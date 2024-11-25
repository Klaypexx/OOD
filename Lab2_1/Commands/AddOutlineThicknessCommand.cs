using Lab2_1.States;
using Lab2_1.Toolbars;

namespace Lab2_1.Commands;

public class AddOutlineThicknessCommand : Command
{
    private readonly Toolbar _toolbar;

    public AddOutlineThicknessCommand( Toolbar toolbar )
    {
        _toolbar = toolbar;
    }

    public override void Execute()
    {
        _toolbar.AddOutlineThickness();
    }
}
