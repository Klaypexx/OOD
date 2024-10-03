using Lab1.Interfaces;
using Lab1.Shapes.Circles;
using Lab1.Shapes.Rectangles;
using Lab1.Shapes.Triangles;

namespace Lab1.Shapes;

public static class ShapesCreator
{
    public static IShape Create( string line )
    {
        string[] parts = line.Split( ": " );
        string type = parts[ 0 ];
        string[] points = parts[ 1 ].Split( ";" );

        switch ( type )
        {
            case "TRIANGLE":
                return TriangleCreator.Create( points );
            case "RECTANGLE":
                return RectangleCreator.Create( points );
            case "CIRCLE":
                return CircleCreator.Create( points );
            default:
                return null;
        }
    }
}
