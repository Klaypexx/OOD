using Lab2_1.Toolbars;

namespace Lab2_1.States;

public abstract class State
{
    public virtual void DragAndDrop( Toolbar toolbar ) => throw new NotImplementedException();
    public virtual void FillShape( Toolbar toolbar ) => throw new NotImplementedException();
    public virtual void FillOutline( Toolbar toolbar ) => throw new NotImplementedException();
}
