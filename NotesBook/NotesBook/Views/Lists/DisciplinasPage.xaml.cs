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
    public partial class DisciplinasPage : ContentPage
    {
        public DisciplinasPage(int idCurso, int quatidadePeriodos, int fase)
        {
            InitializeComponent();
            BindingContext = new DisciplinasViewModel(idCurso, quatidadePeriodos, fase);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (this.BindingContext as DisciplinasViewModel).LoadDisciplinas();
        }

        private void SelecionarDisciplina(object sender, SelectedItemChangedEventArgs e)
        {
            (BindingContext as DisciplinasViewModel)?.SelecionarCommand.Execute(((sender as ListView).SelectedItem as Disciplina).Id);
        }

        private void DeletarClicked(object sender, EventArgs e)
        {
            (BindingContext as DisciplinasViewModel)?.DeletarCommand.Execute((sender as MenuItem).BindingContext as Disciplina);
        }
        private void EditarClicked(object sender, EventArgs e)
        {
            (BindingContext as DisciplinasViewModel)?.EditarCommand.Execute((sender as MenuItem).BindingContext as Disciplina);
        }
    }
}