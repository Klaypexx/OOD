using Lab2_1.Toolbars;

namespace Lab2_1.States;

public class DragAndDropState : State
{
    public override void DragAndDrop( Toolbar toolbar ) {}

    public override void FillShape( Toolbar toolbar )
    {
        toolbar.SetState(new FillShapeState());
    }

    public override void FillOutline( Toolbar toolbar )
    {
        toolbar.SetState(new FillOutlineState());
    }
}
