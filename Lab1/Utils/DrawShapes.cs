using Lab1.Interfaces;
using SFML.Graphics;
using SFML.Window;

namespace Lab1.Utils;

public static class DrawShapes
{
    public static void Draw( List<IShape> shapes )
    {
        RenderWindow window = new( new VideoMode( 800, 600 ), "Geometric Shapes" );

        while ( window.IsOpen )
        {
            window.DispatchEvents();
            window.Clear();

            foreach ( IShape shape in shapes )
            {
                window.Draw( shape.GetDrawable() );
            }

            window.Display();
        }
    }
}
