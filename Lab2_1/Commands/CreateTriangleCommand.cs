using Lab2_1.Toolbars;

namespace Lab2_1.Commands;

public class CreateTriangleCommand : Command
{
    private readonly Toolbar _toolbar;

    public CreateTriangleCommand( Toolbar toolbar )
    {
        _toolbar = toolbar;
    }

    public override void Execute()
    {
        _toolbar.CreateTriangle();
    }
}
