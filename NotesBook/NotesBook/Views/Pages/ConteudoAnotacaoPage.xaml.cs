using NotesBook.Models;
using NotesBook.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotesBook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConteudoAnotacaoPage : ContentPage
    {
        private Anotacao itemAtual;
        public ConteudoAnotacaoPage(Anotacao anotacao)
        {
            InitializeComponent();
            itemAtual = anotacao;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new ConteudoAnotacaoViewModel(itemAtual);
        }
    }
}