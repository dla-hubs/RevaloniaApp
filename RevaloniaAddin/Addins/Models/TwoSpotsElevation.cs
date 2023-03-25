using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using RevaloniaAddin.Addins.ViewModels;
using System;

namespace RevaloniaAddin.Addins.Models
{
    [Transaction(TransactionMode.Manual)]
    public class TwoSpotsElevation : IExternalEventHandler
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

            // Get second object and set to the property
            Reference selTwo = uidoc.Selection.PickObject(ObjectType.Element, selFilter, "Pick the second dimension");
            Element eTwo = doc.GetElement(selTwo.ElementId);
            viewModel.SecondPointElementId = eTwo.Id;
            SpotDimension spotDimensionTwo = eTwo as SpotDimension;
            XYZ pointTwo = spotDimensionTwo.Origin;
            double levelTwo = Math.Round(304.8 * pointTwo.Z, 1);
            string levelTwoDisplay = string.Format("{0:N}mm", levelTwo);
            viewModel.SecondPoint = levelTwo;
            viewModel.SecondPointDisplay = "Second Point: " + levelTwoDisplay;

            // Calculate and set the level difference
            double levelDifference = viewModel.FirstPoint - viewModel.SecondPoint;
            string levelDifferenceDisplay = string.Format("{0:N}mm", levelDifference);
            viewModel.LevelDifference = levelDifference;
            viewModel.LevelDifferenceDisplay = levelDifferenceDisplay;

            viewModel.CanPressReselect = true;
            viewModel.CanPressDelete = true;

        }


        public string GetName()
        {
            return "TwoSpotsElevation";
        }


        public class SpotDimensionsFilter : ISelectionFilter
        {
            public bool AllowElement(Element element)
            {

                if (element is null) return false;

                BuiltInCategory builtInCategory = (BuiltInCategory)GetCategoryIdAsInteger(element);
                if (builtInCategory == BuiltInCategory.OST_SpotSlopes |
                    builtInCategory == BuiltInCategory.OST_SpotCoordinates |
                    builtInCategory == BuiltInCategory.OST_SpotElevations)
                    return true;

                return false;
            }

            public bool AllowReference(Reference refer, XYZ point)
            {
                return false;
            }

            private int GetCategoryIdAsInteger(Element element)
            {
                return element?.Category?.Id?.IntegerValue ?? -1;
            }
        }


    }
}
