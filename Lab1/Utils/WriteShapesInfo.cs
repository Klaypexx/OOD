using Lab1.Decorators.MathDecorator;
using Lab1.Interfaces;
using Lab1.Shapes.Circles;
using Lab1.Shapes.Rectangles;
using Lab1.Shapes.Triangles;

namespace Lab1.Utils;

public static class WriteShapesInfo
{
    public static void Write( IShape shape )
    {
        string circleAreaText = "Circle Area: ";
        string circlePerimaterText = "Circle Perimeter: ";
        string rectangleAreaText = "Rectangle Area: ";
        string rectanglePerimaterText = "Rectangle Perimeter: ";
        string triangleAreaText = "Triangle Area: ";
        string trianglePerimaterText = "Triangle Perimeter: ";

        switch ( shape )
        {
            case CircleShape circle:
                CircleMathDecorator mathCircle = new( circle );
                Console.WriteLine( $"{circleAreaText} {mathCircle.Area():F2}" );
                Console.WriteLine( $"{circlePerimaterText} {mathCircle.Perimeter():F2}" );
                break;
            case RectangleShape rectangle:
                RectangleMathDecorator mathRectangle = new( rectangle );
                Console.WriteLine( $"{rectangleAreaText} {mathRectangle.Area():F2}" );
                Console.WriteLine( $"{rectanglePerimaterText} {mathRectangle.Perimeter():F2}" );
                break;
            case TriangleShape triangle:
                TriangleMathDecorator mathTriangle = new( triangle );
                Console.WriteLine( $"{triangleAreaText} {mathTriangle.Area():F2}" );
                Console.WriteLine( $"{trianglePerimaterText} {mathTriangle.Perimeter():F2}" );
                break;
            default:
                break;
        }
    }
}
