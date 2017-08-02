using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using System.IO;
using NotesBook;
using NotesBook.Droid;

[assembly: Dependency(typeof(ConfigDb))]
namespace NotesBook.Droid
{
    public class ConfigDb : IConfigDb
    {
        public string GetPathDb(string fileName)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, fileName);
        }
    }
}