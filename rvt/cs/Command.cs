/*
** A template for a Revit external command
** C# Google Style Guide
** The path to a journal 
** "C:\Users\kkozlov\AppData\Local\Autodesk\Revit\Autodesk Revit 20XX\Journals\journa.xxxx.txt"
*/

using System;
using System.Collections.Generic;

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
      IDictionary<string, string> logs = commandData.JournalData;
      logs.Clear();
      logs.Add("Kkozlov", "Hello, world!");
      UI.TaskDialog.Show("RevitApi", "Hello, world!");
      return UI.Result.Succeeded;
    }
  }
}
