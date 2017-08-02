using NotesBook.Models;
using NotesBook.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotesBook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditAnotacaoPage : ContentPage
    {
        public EditAnotacaoPage(ref Anotacao item)
        {
            InitializeComponent();
            BindingContext = new EditAnotacaoViewModel(ref item);
        }

        public EditAnotacaoPage(ref ObservableCollection<Anotacao> anotacaos, int idDisciplina)
        {
            InitializeComponent();
            BindingContext = new EditAnotacaoViewModel(ref anotacaos, idDisciplina);
        }
    }
}