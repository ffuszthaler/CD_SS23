using System;
using System.Globalization;
using System.IO;
using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using System.Xml;
using System.Xml.Serialization;

namespace CRC_CSD_10
{
  class Program
  {

    static void WorkWithEncoding()
    {
      // set console encoding
      Console.WriteLine("Console.OutputEncoding = {0}", Console.OutputEncoding);
      Console.OutputEncoding = System.Text.Encoding.UTF8;
      Console.WriteLine("Console.OutputEncoding = {0}", Console.OutputEncoding);

      CultureInfo globalization = CultureInfo.CurrentCulture;
      CultureInfo localization = CultureInfo.CurrentUICulture;

      Console.WriteLine("The current globalization culture is {0}: {1}", globalization.Name, globalization.DisplayName);

      Console.WriteLine("The current localization culture is {0}: {1}", localization.Name, localization.DisplayName);
      Console.WriteLine();

      // select a culture code
      Console.WriteLine("en-US: English (US)");
      Console.WriteLine("da-UK: Danish (Denmark)");
      Console.WriteLine("de-AT: German (Austria)");
      Console.WriteLine("Enter an ISO culture code: ");
      string? newCulture = Console.ReadLine();

      if (!string.IsNullOrEmpty(newCulture))
      {
        CultureInfo ci = new CultureInfo(newCulture);
        CultureInfo.CurrentCulture = ci;
        CultureInfo.CurrentUICulture = ci;
      }

      Console.WriteLine();
      Console.Write("Enter your name: ");
      string? name = Console.ReadLine();

      Console.Write("Enter your birthday: ");
      string? birthday = Console.ReadLine();

      Console.Write("Enter your salary: ");
      string? salary = Console.ReadLine();

      if (name != null && birthday != null && salary != null)
      {
        DateTime date = DateTime.Parse(birthday);
        int minutes = (int)DateTime.Today.Subtract(date).TotalMinutes;
        decimal earns = decimal.Parse(salary);

        Console.WriteLine("{0} was born on a {1:ddddd}, is {2:N0} minutes old, and earns {3:C}.", name, date, minutes, earns);
      }
    }

    static void WorkWithDirectories()
    {
      // define a filepath for a new folder
      string newFolder = Combine(GetFolderPath(SpecialFolder.Personal), "Desktop", "MyNewFolder");
      Console.WriteLine("Working with: {newFolder}");
      Console.WriteLine($"Does it exist? {Exists(newFolder)}");

      // create directory
      Console.WriteLine("Creating a folder...");
      CreateDirectory(newFolder);
      Console.WriteLine($"Does it exist? {Exists(newFolder)}");
      Console.WriteLine("Confirm if the directory exits, and then press ENTER.");
      Console.ReadLine();

      // delete directory
      Console.WriteLine("Deleting a folder...");
      Delete(newFolder, true);
      Console.WriteLine($"Does it exist? {Exists(newFolder)}");
    }

    static string[] callsigns = new string[] { "ABC", "TEST", "BCC", "BMT" };

    static void WorkWithText()
    {
      string textFile = Combine(CurrentDirectory, "streams.txt");

      // create a text file and return a helper writer
      StreamWriter text = File.CreateText(textFile);

      foreach (string item in callsigns)
      {
        text.WriteLine(item);
      }

      // release the resources
      text.Close();

      Console.WriteLine("{0} contains {1:N0} bytes.", arg0: textFile, arg1: new FileInfo(textFile).Length);
      Console.WriteLine(File.ReadAllText(textFile));
    }

    static void WorkWithXML()
    {
      // define a file to write to
      string xmlFile = Combine(CurrentDirectory, "streams.xml");

      FileStream xmlFileStream = File.Create(xmlFile);
      // wrap the file stream in an xml writer
      // and automatically indent nested elements
      XmlWriter xml = XmlWriter.Create(xmlFileStream, new XmlWriterSettings { Indent = true });

      // write xml declaration
      xml.WriteStartDocument();
      // write root element
      xml.WriteStartElement("callsigns");

      foreach (string item in callsigns)
      {
        xml.WriteElementString("callsign", item);
      }

      // write close root element
      xml.WriteEndElement();

      // close the writer & streams
      xml.Close();
      xmlFileStream.Close();

      // output content of streams.xml
      Console.WriteLine("{0} contains {1:N0} bytes.", arg0: xmlFile, arg1: new FileInfo(xmlFile).Length);
      Console.WriteLine(File.ReadAllText(xmlFile));

      // xml reader
      using (XmlReader reader = XmlReader.Create("streams.xml"))
      {
        while (reader.Read())
        {
          // check if we are on an element node named callsign
          if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "callsign"))
          {
            reader.Read();
            Console.WriteLine($"{reader.Value}");
          }
        }
      }
    }

    static void Main(string[] args)
    {
      // WorkWithEncoding();
      // WorkWithDirectories();
      // WorkWithText();
      // WorkWithXML();

      List<Person> people = new List<Person> {
        new Person("Yun", 30000M),
        new Person("Markus", 50000M),
        new Person("Victor", 40000M),
      };

      // create object that will format a list of person as xml
      XmlSerializer xs = new XmlSerializer(typeof(List<Person>));

      // create a file to write to
      string path = Combine(CurrentDirectory, "people.xml");

      using (FileStream stream = File.Create(path))
      {
        // serialize the object graph to the stream
        xs.Serialize(stream, people);
      }
    }
  }
}