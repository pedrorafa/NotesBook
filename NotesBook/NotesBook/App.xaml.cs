using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace NotesBook
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var a = new Models.Curso();
            MainPage = new NavigationPage(new EditCursoPage(ref a));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
