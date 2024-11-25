using SFML.Graphics;
using SFML.Window;

namespace Lab2_1;

public class MyWindow : RenderWindow
{
    public MyWindow( VideoMode mode, string title ) : base(mode, title)
    {
    }

    public bool TryPollEvent( out Event e )
    {
        return this.PollEvent(out e);
    }
}
