using Lab2_1;
using SFML.Window;

class Program
{
    static void Main()
    {
        string path = "C:\\Users\\dimas\\Code\\Volgatech\\OOD\\Lab2_1\\input.txt";

        MyWindow window = new(new VideoMode(1920, 1080), "Geometric Shapes");
        window.SetVerticalSyncEnabled(true);

        Application application = Application.GetInstance(window, path);
        application.ReadFigures();

        while (window.IsOpen)
        {
            Event e;
            while (window.TryPollEvent(out e))
            {
                application.Process(e);
            }

            window.Clear();
            application.Draw();
            window.Display();
        }

        application.PrintFiguresInfo();
    }
}