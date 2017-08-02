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
    public partial class AnotacoesPage : ContentPage
    {
        public AnotacoesPage(int idDisciplina)
        {
            InitializeComponent();
            BindingContext = new AnotacaosViewModel(idDisciplina);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (this.BindingContext as AnotacaosViewModel).LoadAnotacaos();
        }

        private void SelecionarAnotacao(object sender, SelectedItemChangedEventArgs e)
        {
            (BindingContext as AnotacaosViewModel)?.SelecionarCommand.Execute(((sender as ListView).SelectedItem as Anotacao));
        }

        private void DeletarClicked(object sender, EventArgs e)
        {
            (BindingContext as AnotacaosViewModel)?.DeletarCommand.Execute((sender as MenuItem).BindingContext as Anotacao);
        }
        private void EditarClicked(object sender, EventArgs e)
        {
            (BindingContext as AnotacaosViewModel)?.EditarCommand.Execute((sender as MenuItem).BindingContext as Anotacao);
        }
    }
}