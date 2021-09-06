using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RevitAddin.ExternalEventExample.Services;
using RevitAddin.ExternalEventExample.Views;

namespace RevitAddin.ExternalEventExample.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class ViewCommand : IExternalCommand
    {
        private static DeleteView deleteView { get; set; }

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            UIApplication uiapp = commandData.Application;

            if (deleteView != null)
                deleteView.Close();

            deleteView = new DeleteView();
            deleteView.Show();

            return Result.Succeeded;
        }
    }
}
