using Lab2_1.Handlers;
using Lab2_1.Toolbars;
using Lab2_1.Visitors;

namespace Lab2_1.States;

public class FillOutlineState : State
{
    public override void OnLeftMouseButton( FiguresHandler figuresHandler, Toolbar toolbar )
    {
        figuresHandler.Visit(new SetOutlineColorVisitor(toolbar.GetColor()));
    }

    public override void OnUndo( FiguresHandler figuresHandler )
    {
        figuresHandler.Undo();
    }
}
