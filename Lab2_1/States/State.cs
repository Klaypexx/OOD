using Lab2_1.Handlers;
using Lab2_1.Toolbars;

namespace Lab2_1.States;

public class State
{
    public virtual void OnLeftMouseButton( FiguresHandler figuresHandler, Toolbar toolbar ) { }

    public virtual void OnLeftMouseButtonWithShift( FiguresHandler figuresHandler ) { }

    public virtual void OnGroup( FiguresHandler figuresHandler ) { }

    public virtual void OnUngroup( FiguresHandler figuresHandler ) { }

    public virtual void OnMouseMove( FiguresHandler figuresHandler ) { }

    public virtual void OnUndo( FiguresHandler figuresHandler ) { }
}
