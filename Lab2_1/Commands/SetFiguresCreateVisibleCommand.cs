using Lab2_1.Toolbars;

namespace Lab2_1.Commands;

public class SetFiguresCreateVisibleCommand : Command
{
    private readonly Toolbar _toolbar;

    public SetFiguresCreateVisibleCommand(Toolbar toolbar)
    {
        _toolbar = toolbar;
    }

    public override void Execute()
    {
        _toolbar.SetFiguresCreateVisible();
    }
}
