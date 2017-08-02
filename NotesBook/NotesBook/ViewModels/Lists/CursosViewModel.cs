using NotesBook.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace NotesBook.ViewModels
{
    public class CursosViewModel : BaseViewModel
    {
        ///Propriedade com a lista dos cursos
        private ObservableCollection<Curso> cursos;
        public ObservableCollection<Curso> Cursos { get; }

        public Command SelecionarCommand { get; }
        public Command AdicionarCommand{ get; }
        public Command EditarCommand { get; }
        public Command ConcluirCommand { get; }
        public Command DeletarCommand { get; }

        private User _user;

        public CursosViewModel(User user)
        {
            _user = user;
            VerificarUsuario();
            cursos = new ObservableCollection<Curso>();
            Cursos = cursos;

            SelecionarCommand = new Command<Curso>(ExecuteSelecionarCommand);
            AdicionarCommand = new Command(ExecuteAdicionarCommand);
            EditarCommand = new Command<Curso>(ExecuteEditarCommand);
            ConcluirCommand = new Command<Curso>(ExecuteConcluirCommand);
            DeletarCommand = new Command<Curso>(ExecuteDeletarCommand);

            VerificarUsuario();
        }

        private async void VerificarUsuario()
        {
            var getUser = await ApiService.GetUser(_user.IdSocial);
            if (getUser == null)
            {
                await ApiService.PostUserAsync(_user);
            }
        }

        private async void ExecuteSelecionarCommand(Curso curso)
        {
            await Navigation_Service.NavigateTo(new CadernoDisciplinasPage(curso.Id, curso.QutdFases));
        }
        private async void ExecuteDeletarCommand(Curso item)
        {
            if(!await ApiService.DeleteCurso(item.Id))
            {
                //Todo
            }
            Cursos.Remove(item);
        }
        private async void ExecuteConcluirCommand(Curso item)
        {
            item.IsConcluido = true;
            if (!await ApiService.PutCurso(item))
            {
                //Todo
            }
            LoadCursos();
        }
        private async void ExecuteAdicionarCommand()
        {
            await Navigation_Service.NavigateTo(new EditCursoPage(ref cursos, _user.Id));
        }
        private async void ExecuteEditarCommand(Curso item)
        {
            await Navigation_Service.NavigateTo(new EditCursoPage(ref item));
        }

        /// <summary>
        /// Comando para atualizar lista
        /// </summary>
        public async void LoadCursos()
        {
            List<Curso> cursosDb = await ApiService.GetCursos(_user.Id);
            Cursos.Clear();

            if (cursosDb != null)
            {
                foreach (Curso i in cursosDb)
                {
                    if (!i.IsConcluido)
                    {
                        Cursos.Add(i);
                    }
                }
            }
        }
     
    }
}
