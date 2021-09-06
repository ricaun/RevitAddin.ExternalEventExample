using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RevitAddin.ExternalEventExample.Services;
using System;

namespace RevitAddin.ExternalEventExample.ExternalEvents
{
    public class DeleteExternalEventHandler : IExternalEventHandler
    {
        /// <summary>
        /// This method is called to handle the external event.
        /// </summary>
        /// <param name="uiapp"></param>
        public void Execute(UIApplication uiapp)
        {
            new DeleteController(uiapp).Delete();
        }

        /// <summary>
        /// String identification of the event handler.
        /// </summary>
        public string GetName()
        {
            return this.GetType().Name;
        }

        /// <summary>
        /// Create <see cref="Autodesk.Revit.UI.ExternalEvent"/> a new <see cref="DeleteExternalEventHandler"/>
        /// </summary>
        public static ExternalEvent Create()
        {
            return ExternalEvent.Create(new DeleteExternalEventHandler());
        }
    }
}