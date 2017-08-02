using NotesBook.Models;
using NotesBook.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotesBook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TarefasPage : ContentPage
    {
        public TarefasPage(int idDisciplina)
        {
            InitializeComponent();
            BindingContext = new TarefasViewModel(idDisciplina);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (this.BindingContext as TarefasViewModel).LoadTarefas();
        }

        private void SelecionarTarefa(object sender, SelectedItemChangedEventArgs e)
        {
            (BindingContext as TarefasViewModel)?.SelecionarCommand.Execute(((sender as ListView).SelectedItem as Tarefa));
        }
        private void ConcluirClicked(object sender, EventArgs e)
        {
            (BindingContext as TarefasViewModel)?.ConcluirCommand.Execute((sender as MenuItem).BindingContext as Tarefa);
        }
        private void DeletarClicked(object sender, EventArgs e)
        {
            (BindingContext as TarefasViewModel)?.DeletarCommand.Execute((sender as MenuItem).BindingContext as Tarefa);
        }
        private void EditarClicked(object sender, EventArgs e)
        {
            (BindingContext as TarefasViewModel)?.EditarCommand.Execute((sender as MenuItem).BindingContext as Tarefa);
        }
    }
}