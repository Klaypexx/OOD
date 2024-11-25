using Lab2_1.Toolbars;

namespace Lab2_1.Commands;

public class FillOutlineCommand : Command
{
    private readonly Toolbar _toolbar;

    public FillOutlineCommand( Toolbar toolbar )
    {
        _toolbar = toolbar;
    }

    public override void Execute()
    {
        _toolbar.FillOutline();
    }
}
