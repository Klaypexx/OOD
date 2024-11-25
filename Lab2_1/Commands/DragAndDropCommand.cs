using Lab2_1.Toolbars;

namespace Lab2_1.Commands;

public class DragAndDropCommand : Command
{
    private readonly Toolbar _toolbar;

    public DragAndDropCommand( Toolbar toolbar )
    {
        _toolbar = toolbar;
    }

    public override void Execute()
    {
        _toolbar.DragAndDrop();
    }
}
