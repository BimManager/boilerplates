// Copyright 2021 kkozlov

using System;
using System.Collections.Generic;
using System.Reflection;
using IO = System.IO;
using Xml = System.Xml.Linq;

namespace Kkozlov {
  class AddInElements {
    public string Type { get; set; }
    public string Assembly { get; set; }
    public string AddInId { get; set; }
    public string FullClassName { get; set; }
    public string VendorId { get; set; }
    public string VendorDescription { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string VisibilityMode { get; set; }
    public string Discipline { get; set; }
    public string AvailabilityClassName { get; set; }
    public string LargeImage { get; set; }
    public string SmallImage { get; set; }
    public string LongDescription { get; set; }
    public string ToolTipImage { get; set; }
    public string LanguageType { get; set; }
    public string AllowLoadIntoExistingSession { get; set; }
  }
  
  class Program {
    static void Main() {
      AddInElements data = new AddInElements();
      data.Type = "Command";
      data.Assembly = "Foo.dll";
      data.AddInId = Guid.NewGuid().ToString();
      data.VendorId = "Kkozlov";
      data.VendorDescription = "N/A";
      GenerateManifestFile(data);
    }

    static void GenerateManifestFile(AddInElements data) {
      Xml.XElement addin = new Xml.XElement(
          "Addin", new Xml.XAttribute("Type", data.Type));
      Type type = data.GetType();
      PropertyInfo[] props = type.GetProperties();
      foreach (PropertyInfo prop in props) {
        object value = prop.GetValue(data);
        if (null != value) addin.SetElementValue(prop.Name, (string)value);
      }
      Xml.XElement xmlTree = new Xml.XElement("RevitAddIns", addin);
      IO.StreamWriter sw = IO.File.CreateText(
          IO.Path.GetFileName(data.Assembly)
          .Replace(IO.Path.GetExtension(data.Assembly), ".addin"));
      sw.Write(xmlTree);
      sw.Close();
      Console.WriteLine(xmlTree);
    }
  }
}
