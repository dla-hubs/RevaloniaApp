using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
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

    public class ReselectSecondPoint : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            UIDocument uidoc = app.ActiveUIDocument;
            MainViewModel viewModel = AddinCommand.MainViewModel;

            ISelectionFilter selFilter = new SpotDimensionsFilter();

            // Get second object and set to the property
            Reference selOne = uidoc.Selection.PickObject(ObjectType.Element, selFilter, "Pick the second spot dimension");
            Element eTwo = doc.GetElement(selOne.ElementId);
            viewModel.SecondPointElementId = eTwo.Id;
            SpotDimension spotDimensionOne = eTwo as SpotDimension;
            XYZ pointTwo = spotDimensionOne.Origin;
            double levelTwo = Math.Round(304.8 * pointTwo.Z, 1);
            string levelOneDisplay = string.Format("{0:N}mm", levelTwo);
            viewModel.SecondPoint = levelTwo;
            viewModel.SecondPointDisplay = "Second Point: " + levelOneDisplay;


            // Calculate and set the level difference
            double levelDifference = viewModel.FirstPoint - viewModel.SecondPoint;
            string levelDifferenceDisplay = string.Format("{0:N}mm", levelDifference);
            viewModel.LevelDifference = levelDifference;
            viewModel.LevelDifferenceDisplay = levelDifferenceDisplay;
        }

        public string GetName()
        {
            return "ReselectSecondPoint";
        }
    }
}
