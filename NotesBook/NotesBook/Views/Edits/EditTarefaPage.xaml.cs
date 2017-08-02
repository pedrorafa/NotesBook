using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesBook.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NotesBook.ViewModels.Edits;

namespace NotesBook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditTarefaPage : ContentPage
    {

        public EditTarefaPage(ref Tarefa item)
        {
            InitializeComponent();
            BindingContext = new EditTarefaViewModel(ref item);

        }

        public EditTarefaPage(ref ObservableCollection<Tarefa> tarefas, int idDisciplina)
        {
            InitializeComponent();
            BindingContext = new EditTarefaViewModel(ref tarefas, idDisciplina);

        }
    }
}