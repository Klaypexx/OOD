using Lab2_1.Toolbars;

namespace Lab2_1.Commands;

public class ChangeOutlineThicknessCommand : Command
{
    private readonly Toolbar _toolbar;

    public ChangeOutlineThicknessCommand( Toolbar toolbar )
    {
        _toolbar = toolbar;
    }

    public override void Execute()
    {
        _toolbar.SetChangeThicknessVisible();
    }
}
