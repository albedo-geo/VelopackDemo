using System.Runtime.CompilerServices;
using System.Windows;
using Velopack;

namespace VelopackDemo;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        try
        {
            await UpdateMyAppAsync();
        }
        catch (Exception ex)
        {
            // 检查更新失败，或其他问题
            MessageBox.Show($"检查更新失败。原因：\n{ex}", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private async Task UpdateMyAppAsync()
    {
        var mgr = new UpdateManager("https://github.com/albedo-geo/VelopackDemo/releases");

        if (!mgr.IsInstalled)
            return;

        var newVersion = await mgr.CheckForUpdatesAsync();
        if (newVersion is null)
            return;

        await Application.Current.Dispatcher.InvokeAsync(() => this.Title += $" - v{newVersion}");

        var result = MessageBox.Show($"发现新版本：{newVersion}\n当前版本：{mgr.CurrentVersion}\n是否更新？", "版本更新", MessageBoxButton.YesNo);
        if (result == MessageBoxResult.Yes)
        {
            await mgr.DownloadUpdatesAsync(newVersion);
            mgr.ApplyUpdatesAndRestart(newVersion);
        }
    }
}