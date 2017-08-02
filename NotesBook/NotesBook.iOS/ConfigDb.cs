using System;
using NotesBook;
using Xamarin.Forms;
using System.IO;

[assembly: Dependency(typeof(IConfigDb))]
namespace NotesBook.iOS
{
    public class ConfigDb : IConfigDb
    {
        public string GetPathDb(string fileName)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, fileName);
        }
    }
}