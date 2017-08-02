
using NotesBook.ViewModels;
using Xamarin.Forms;

namespace NotesBook
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}
