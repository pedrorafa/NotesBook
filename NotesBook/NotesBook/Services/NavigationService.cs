using NotesBook.Interfaces;
using NotesBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(NotesBook.Services.NavigationService))]
namespace NotesBook.Services
{
    public class NavigationService : INavigationService
    {
        public async Task NavigateTo(Page page)
        {
            await App.Current.MainPage.Navigation.PushAsync(page);
        }

        public async Task PopAsyc()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }
        public async Task PopToRootAsync()
        {
            await App.Current.MainPage.Navigation.PopToRootAsync();
        }        
    }
}
