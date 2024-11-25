using Lab2_1.States;
using Lab2_1.Toolbars;

namespace Lab2_1.Commands;

public class ReduceThicknessCommand : Command
{
    private readonly Toolbar _toolbar;

    public ReduceThicknessCommand( Toolbar toolbar )
    {
        _toolbar = toolbar;
    }

    public override void Execute()
    {
        _toolbar.ReduceOutlineThickness();
    }
}
