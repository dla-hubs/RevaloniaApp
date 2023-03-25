using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using Avalonia;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Media;
using System.Windows.Media.Imaging;



namespace RevaloniaAddin
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]

    public class App : IExternalApplication
    {



        string tabName = "Revalonia";

        public static object commandData { get; internal set; }

        public Result OnShutdown(UIControlledApplication application)
        {
            // do nothing
            return Result.Succeeded;
        }




        private void CreateButtonForAddinCommand(UIControlledApplication application)
        {
            string path = typeof(App).Assembly.Location;

            RibbonPanel revaloniaPanel = application.CreateRibbonPanel(tabName, "AddinCommand");
            PushButton pusuButton = revaloniaPanel.AddItem(new PushButtonData(
                "Revalonia",
                "AddinCommand",
                typeof(App).Assembly.Location,
                typeof(AddinCommand).FullName)
                ) as PushButton;

            pusuButton.Image = LoadPngIcon("Revalonia.Assets.avalonia16.png", path);
            pusuButton.LargeImage = LoadPngIcon("Revalonia.Assets.avalonia32.png", path);
            pusuButton.ToolTip = "Minimum template to create AvaloniaApp";
            pusuButton.ToolTipImage = LoadPngIcon("Revalonia.Assets.avalonia32.png", path);
        }




        public Result OnStartup(UIControlledApplication application)
        {


            application.CreateRibbonTab(tabName);
            CreateButtonForAddinCommand(application);

            return Result.Succeeded;
        }




        private ImageSource LoadPngIcon(string sourceName, string path)
        {
            try
            {
                var assembly = Assembly.LoadFrom(Path.Combine(path));
                var icon = assembly.GetManifestResourceStream(sourceName);
                PngBitmapDecoder m_decorder = new PngBitmapDecoder(icon, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                ImageSource m_source = m_decorder.Frames[0];
                return (m_source);
            }

            catch { }

            return null;
        }
    }
}
