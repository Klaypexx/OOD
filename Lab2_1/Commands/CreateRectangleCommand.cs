using Lab2_1.Toolbars;

namespace Lab2_1.Commands;

public class CreateRectangleCommand : Command
{
    private readonly Toolbar _toolbar;

    public CreateRectangleCommand( Toolbar toolbar )
    {
        _toolbar = toolbar;
    }

    public override void Execute()
    {
        _toolbar.CreateRectangle();
    }
}
