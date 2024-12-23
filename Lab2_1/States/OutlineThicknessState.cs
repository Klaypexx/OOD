﻿using Lab2_1.Handlers;
using Lab2_1.Toolbars;
using Lab2_1.Visitors;

namespace Lab2_1.States;

public class OutlineThicknessState: State
{
    public override void OnLeftMouseButton( FiguresHandler figuresHandler, Toolbar toolbar )
    {
        figuresHandler.GlobalFrameVisit(new ChangeOutlineThicknessVisitor(toolbar.GetOutlineThickness()));
        toolbar.ResetState();
    }
}
