using Lab2_1;
using SFML.Window;

class Program
{
    static void Main()
    {
        MyWindow window = new(new VideoMode(1920, 1080), "Geometric Shapes");
        window.SetVerticalSyncEnabled(true);

        Application application = Application.GetInstance(window);

        application.ReadFigures();
        application.Run();
        application.PrintFiguresInfo();
    }
}