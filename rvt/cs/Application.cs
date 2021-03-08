/*
** An external revit application
** C# Google Style Guide
*/

using System;
using UI = Autodesk.Revit.UI;
using DB = Autodesk.Revit.DB;

namespace Kkozlov {
  class Application : UI.IExternalApplication {
    public UI.Result OnStartup(UI.UIControlledApplication app) {
      app.CreateRibbonTab("External Application Template");
      return UI.Result.Succeeded;
    }

    public UI.Result OnShutdown(UI.UIControlledApplication app) {
      return UI.Result.Succeeded;
    }
  }
}
