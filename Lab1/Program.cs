using Lab1.Interfaces;
using Lab1.Shapes;
using Lab1.Utils;

class Program
{
    static void Main()
    {
        string path = "C:\\Users\\dimas\\Code\\Volgatech\\OOD\\Lab1\\input.txt";

        List<IShape> shapes = [];

        string[] lines = File.ReadAllLines( path );

        foreach ( string line in lines )
        {
            shapes.Add( ShapesCreator.Create( line ) );
        }

        foreach ( IShape shape in shapes )
        {
            WriteShapesInfo.Write( shape );
        }

        DrawShapes.Draw( shapes );
    }
}