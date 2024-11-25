using Lab2_1.Toolbars;

namespace Lab2_1.Commands;

public class FillShapeCommand : Command
{
    private readonly Toolbar _toolbar;

    public FillShapeCommand( Toolbar toolbar )
    {
        _toolbar = toolbar;
    }

    public override void Execute()
    {
        _toolbar.FillShape();
    }
}
