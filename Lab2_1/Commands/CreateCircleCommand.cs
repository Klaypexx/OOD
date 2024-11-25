using Lab2_1.Toolbars;

namespace Lab2_1.Commands;

public class CreateCircleCommand : Command
{
    private readonly Toolbar _toolbar;

    public CreateCircleCommand( Toolbar toolbar )
    {
        _toolbar = toolbar;
    }

    public override void Execute()
    {
        _toolbar.CreateCircle();
    }
}
