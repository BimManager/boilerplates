/*
** A template for a Revit external command
** C# Google Style Guide
*/

using System;
using UI = Autodesk.Revit.UI;
using DB = Autodesk.Revit.DB;
using ATTR = Autodesk.Revit.Attributes;

namespace Kkozlov {
  [ATTR.TransactionAttribute(ATTR.TransactionMode.Manual)]
  public class Command : UI.IExternalCommand {
    public UI.Result Execute(UI.ExternalCommandData commandData,
                             ref string message, DB.ElementSet elements) {
      return Run(commandData, ref message, elements);
    }

    private UI.Result Run(UI.ExternalCommandData commandData,
                          ref string message, DB.ElementSet elements) {
      UI.TaskDialog.Show("RevitApi", "Hello, world!");
      return UI.Result.Succeeded;
    }
  }
}
