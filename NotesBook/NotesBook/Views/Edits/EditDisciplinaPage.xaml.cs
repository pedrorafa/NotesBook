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
    public partial class EditDisciplinaPage : ContentPage
    {
        public EditDisciplinaPage(ref Disciplina item, int quatidadePeriodos)
        {
            InitializeComponent();
            BindingContext = new EditDisciplinaViewModel(ref item, quatidadePeriodos);
        }

        public EditDisciplinaPage(ref ObservableCollection<Disciplina> disciplinas, int idUser, int quatidadePeriodos)
        {
            InitializeComponent();
            BindingContext = new EditDisciplinaViewModel(ref disciplinas, idUser, quatidadePeriodos);
        }
    }
}