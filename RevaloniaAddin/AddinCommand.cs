using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Avalonia.Controls;
using RevaloniaAddin.Addins.Models;
using RevaloniaAddin.Addins.ViewModels;
using RevaloniaAddin.Addins.Views;
using System.Collections.Generic;

namespace RevaloniaAddin
{

    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]


    public partial class AddinCommand : IExternalCommand
    {
        public static UIApplication RevitApp;
        public static string Request { get; set; }
        public static Document CurrentDoc => RevitApp.ActiveUIDocument.Document;
        public static Window MainWindow { get; set; }
        public static MainViewModel MainViewModel { get; set; }
        public static LevelDifferenceViewModel LevelDifferenceViewModel { get; set; }   

        public class WindowManager
        {
            public static List<Window> AddinWindow = new List<Window>();
        }


        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Get application and document objects

            RevitApp = commandData.Application;

            if (WindowManager.AddinWindow.Count == 0)
            {
                // Create & show MainWindow
                MainViewModel = new MainViewModel();

                var MainWindow = new MainWindow
                {
                    DataContext = MainViewModel

                };
                MainWindow.Show();
                MainWindow.Activate();

                //Create ExternalEventHandlers for each commands
                IExternalEventHandler _twoSpotsElevationEventHandler = new TwoSpotsElevation();
                IExternalEventHandler _reselectFirstPointEventHandler = new ReselectFirstPoint();
                IExternalEventHandler _reselectSecondPointEventHandler = new ReselectSecondPoint();
                IExternalEventHandler _deleteSelectedSpotDimsEventHandler = new DeleteSelectedSpotDims();


                ExternalEvent _twoSpotsElevationEvent = ExternalEvent.Create(_twoSpotsElevationEventHandler);
                ExternalEvent _reselectFirstPointEvent = ExternalEvent.Create(_reselectFirstPointEventHandler);
                ExternalEvent _reselectSecondPoinEvent = ExternalEvent.Create(_reselectSecondPointEventHandler);
                ExternalEvent _deleteSelectedSpotDimsEvent = ExternalEvent.Create(_deleteSelectedSpotDimsEventHandler);


                MainViewModel.LevelDifferenceEvent = _twoSpotsElevationEvent;
                MainViewModel.ReselectFirstPointEvent = _reselectFirstPointEvent;
                MainViewModel.ReselectSecondPointEvent = _reselectSecondPoinEvent;
                MainViewModel.DeleteSelectedSpotDimsEvent = _deleteSelectedSpotDimsEvent;
            }

            else
            {
                foreach (var window in WindowManager.AddinWindow)
                {
                    window.Show();
                    window.Activate();
                }
            }

            return Result.Succeeded;

        }
    }
}
