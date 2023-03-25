using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using Avalonia;
using Avalonia.ReactiveUI;
using System;


namespace RevaloniaAppBuilder
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class App : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            // do nothing
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            InitAvalonia();
            return Result.Succeeded;
        }
       

        public static void InitAvalonia()
        {
            BuildAvaloniaApp().SetupWithoutStarting();
        }

        public static AppBuilder BuildAvaloniaApp()
             => AppBuilder
                .Configure<RevaloniaApp>()
                .UsePlatformDetect()
                .LogToTrace()
                .UseReactiveUI();
    }
}
