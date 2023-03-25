using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RevaloniaAddin.Addins.ViewModels;

namespace RevaloniaAddin.Addins.Models
{
    [Transaction(TransactionMode.Manual)]

    public class DeleteSelectedSpotDims : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            MainViewModel viewModel = AddinCommand.MainViewModel;


            Transaction trans = new Transaction(doc);
            trans.Start("Lab");
        
            if (!(viewModel.FirstPointElementId is null))
            {
                doc.Delete(viewModel.FirstPointElementId);
            }

            if (!(viewModel.SecondPointElementId is null))
            {
                doc.Delete(viewModel.SecondPointElementId);
            }
            trans.Commit();

            viewModel.FirstPointDisplay = "";
            viewModel.SecondPointDisplay = "";
            viewModel.LevelDifferenceDisplay = "";
            viewModel.CanPressReselect = false;
            viewModel.CanPressDelete = false;
 
        }

        public string GetName()
        {
            return "DeleteSelectedSpotDims";
        }
    }
}
