using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Avalonia.Controls;
using RevaloniaAddin.Addins.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RevaloniaAddin.Addins.Models.TwoSpotsElevation;

namespace RevaloniaAddin.Addins.Models
{
    [Transaction(TransactionMode.Manual)]

    public class ReselectFirstPoint : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            UIDocument uidoc = app.ActiveUIDocument;
            MainViewModel viewModel = AddinCommand.MainViewModel;

            ISelectionFilter selFilter = new SpotDimensionsFilter();

            // Get first object and set to the property
            Reference selOne = uidoc.Selection.PickObject(ObjectType.Element, selFilter, "Pick the first spot dimension");
            Element eOne = doc.GetElement(selOne.ElementId);
            viewModel.FirstPointElementId = eOne.Id;
            SpotDimension spotDimensionOne = eOne as SpotDimension;
            XYZ pointOne = spotDimensionOne.Origin;
            double levelOne = Math.Round(304.8 * pointOne.Z, 1);
            string levelOneDisplay = string.Format("{0:N}mm", levelOne);
            viewModel.FirstPoint = levelOne;
            viewModel.FirstPointDisplay = "First Point: " + levelOneDisplay;


            // Calculate and set the level difference
            double levelDifference = viewModel.FirstPoint - viewModel.SecondPoint;
            string levelDifferenceDisplay = string.Format("{0:N}mm", levelDifference);
            viewModel.LevelDifference = levelDifference;
            viewModel.LevelDifferenceDisplay = levelDifferenceDisplay;
        }

        public string GetName()
        {
            return "ReselectFirstPoint";
        }
    }
}
