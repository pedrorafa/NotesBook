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
    public partial class CursosPage : ContentPage
    {
        private User _user;
        public CursosPage(User user)
        {
            InitializeComponent();
            _user = user;

            //Remove a page de login do facebook da pilha
            App.Current.MainPage.Navigation.RemovePage
                (App.Current.MainPage.Navigation.NavigationStack[1]);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new CursosViewModel(_user);
            (this.BindingContext as CursosViewModel).LoadCursos();
        }

        private void SelecionarCurso(object sender, SelectedItemChangedEventArgs e)
        {
            (BindingContext as CursosViewModel)?.SelecionarCommand.Execute(((sender as ListView)?.SelectedItem as Curso));
        }

        private void ConcluirClicked(object sender, EventArgs e)
        {
            (BindingContext as CursosViewModel)?.ConcluirCommand.Execute((sender as MenuItem).BindingContext as Curso);
        }
        private void DeletarClicked(object sender, EventArgs e)
        {
            (BindingContext as CursosViewModel)?.DeletarCommand.Execute((sender as MenuItem).BindingContext as Curso);
        }
        private void EditarClicked(object sender, EventArgs e)
        {
            (BindingContext as CursosViewModel)?.EditarCommand.Execute((sender as MenuItem).BindingContext as Curso);
        }
    }
}