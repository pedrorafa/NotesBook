using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NotesBook.ViewModels
{
    public class MainViewModel:BaseViewModel
    {
        public Command LogarCommand { get; }

        public MainViewModel()
        {
            LogarCommand = new Command(ExecuteLogarCommand);
        }

        private async void ExecuteLogarCommand()
        {

            await Navigation_Service.NavigateTo(new FacebookLoginPage());
        }
    }
}
