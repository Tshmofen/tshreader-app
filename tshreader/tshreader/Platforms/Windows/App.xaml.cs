using Microsoft.UI;
using Windows.Graphics;
using Microsoft.Maui.Handlers;
using Microsoft.UI.Windowing;
using WinRT.Interop;

// ReSharper disable once CheckNamespace
namespace tshreader.WinUI;

public partial class App
{
    public App()
    {
        WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, _) =>
        {
            var nativeWindow = handler.PlatformView;
            nativeWindow.Activate();

            var windowHandle = WindowNative.GetWindowHandle(nativeWindow);
            var windowId = Win32Interop.GetWindowIdFromWindow(windowHandle);
            var appWindow = AppWindow.GetFromWindowId(windowId);

            appWindow.Resize(new SizeInt32(600, 800));
        });

        InitializeComponent();
    }

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}