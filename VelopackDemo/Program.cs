using Velopack;

namespace VelopackDemo;

class Program
{
    [STAThread]
    static void Main()
    {
        VelopackApp.Build().Run();

        var app = new App();
        app.InitializeComponent();
        app.Run();
    }
}
