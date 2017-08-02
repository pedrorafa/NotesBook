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
    public partial class EditCursoPage : ContentPage
    {
        /// <summary>
        /// Construtor para adicionar novo curso
        /// </summary>
        /// <param name="cursos"></param>
        public EditCursoPage(ref ObservableCollection<Curso> cursos, int idUser)
        {
            InitializeComponent();
            BindingContext = new EditCursoViewModel(ref cursos, idUser);
        }

        /// <summary>
        /// Construtor para editar curso
        /// </summary>
        /// <param name="curso"></param>
        public EditCursoPage(ref Curso curso)
        {
            InitializeComponent();
            BindingContext = new EditCursoViewModel(ref curso);

        }
    }
}