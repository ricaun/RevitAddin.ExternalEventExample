using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RevitAddin.ExternalEventExample.Services
{
    public class DeleteController
    {
        #region Constructor
        private readonly UIApplication uiapp;
        public DeleteController(UIApplication uiapp)
        {
            this.uiapp = uiapp;
        }
        #endregion

        public void Delete()
        {
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document document = uidoc.Document;

            var element = PickElement(uidoc);
            while (element != null)
            {
                using (Transaction transaction = new Transaction(document))
                {
                    transaction.Start("Delete Element");
                    document.Delete(element.Id);
                    transaction.Commit();
                }
                element = PickElement(uidoc);
            }

        }

        private Element PickElement(UIDocument uidoc)
        {
            Document document = uidoc.Document;
            Selection selection = uidoc.Selection;
            Element element = null;
            try
            {
                var reference = selection.PickObject(ObjectType.Element);
                element = document.GetElement(reference);
            }
            catch { }
            return element;
        }
    }
}