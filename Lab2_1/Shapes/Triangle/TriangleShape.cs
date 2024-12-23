using SFML.Graphics;
using SFML.System;

namespace Lab2_1.Shapes.Triangle;

public class TriangleShape : Shape
{
    private readonly ConvexShape _shape;
    private readonly Vector2f _p1, _p2, _p3;

    public TriangleShape(Vector2f p1, Vector2f p2, Vector2f p3)
    {
        _p1 = p1;
        _p2 = p2;
        _p3 = p3;

        _shape = new ConvexShape(3)
        {
            FillColor = Color.Red,
        };

        _shape.SetPoint(0, p1);
        _shape.SetPoint(1, p2);
        _shape.SetPoint(2, p3);
    }

    public TriangleShape( TriangleShape triangleShape )
    {
        this.SetId(triangleShape.GetId()); 

        List<Vector2f> points = triangleShape.GetPoints();
        _p1 = points[0];
        _p2 = points[1];
        _p3 = points[2];

        _shape = new ConvexShape(3)
        {
            Position = triangleShape.GetPosition(),
            FillColor = triangleShape.GetFillColor(),
            OutlineColor = triangleShape.GetOutlineColor()
        };

        _shape.SetPoint(0, _p1);
        _shape.SetPoint(1, _p2);
        _shape.SetPoint(2, _p3);

    }


    public override Vector2f GetPosition()
    {
        return _shape.Position;
    }

    public override Color GetFillColor()
    {
        return _shape.FillColor;
    }

    public override Color GetOutlineColor()
    {
        return _shape.OutlineColor;
    }

    public override FloatRect GetGlobalBounds()
    {
        return _shape.GetGlobalBounds();
    }

    public override Drawable GetDrawable()
    {
        return _shape;
    }

    public override void SetPosition( float x, float y )
    {
        _shape.Position = new Vector2f(x, y);
    }

    public override void SetFillColor( Color color )
    {
        _shape.FillColor = color;
    }

    public override void SetOutlineColor( Color color )
    {
        _shape.OutlineColor = color;
        _shape.OutlineThickness = 5.0f;
    }

    public override void Draw( RenderWindow window )
    {
        window.Draw(GetDrawable());
    }

    public List<Vector2f> GetPoints()
    {
        return [_p1, _p2, _p3];
    }
}

