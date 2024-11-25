using Lab2_1.Toolbars;

namespace Lab2_1.States;

public class FillOutlineState : State
{
    public override void DragAndDrop( Toolbar toolbar )
    {
        toolbar.SetState(new DragAndDropState());
    }

    public override void FillShape( Toolbar toolbar )
    {
        toolbar.SetState(new FillShapeState());
    }

    public override void FillOutline( Toolbar toolbar ) { }
}
