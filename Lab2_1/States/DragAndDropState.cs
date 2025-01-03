﻿using Lab2_1.Handlers;
using Lab2_1.Toolbars;

namespace Lab2_1.States;

public class DragAndDropState : State
{
    public override void OnLeftMouseButton( FiguresHandler figuresHandler, Toolbar toolbar )
    {
        figuresHandler.SelectFigure();
    }

    public override void OnLeftMouseButtonWithShift( FiguresHandler figuresHandler )
    {
        figuresHandler.SelectFigures();
    }

    public override void OnGroup( FiguresHandler figuresHandler )
    {
        figuresHandler.GroupFigures();
    }

    public override void OnUngroup( FiguresHandler figuresHandler )
    {
        figuresHandler.UngroupFigures();
    }

    public override void OnMouseMove( FiguresHandler figuresHandler )
    {
        figuresHandler.Move();
    }
}
