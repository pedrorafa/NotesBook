using NotesBook.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace NotesBook.ViewModels
{
    public class DisciplinasViewModel : BaseViewModel
    {
        private ObservableCollection<Disciplina> disciplinas;
        public ObservableCollection<Disciplina> Disciplinas { get; }

        public Command SelecionarCommand { get; }
        public Command AdicionarCommand { get; }
        public Command EditarCommand { get; }
        public Command DeletarCommand { get; }

        private int idCurso;
        private int quatidadePeriodos;
        private int fase;
        public DisciplinasViewModel(int _idCurso, int _quatidadePeriodos, int _fase)
        {
            idCurso = _idCurso;
            quatidadePeriodos = _quatidadePeriodos;
            fase = _fase;

            disciplinas = new ObservableCollection<Disciplina>();
            Disciplinas = disciplinas;

            SelecionarCommand = new Command<int>(ExecuteSelecionarCommand);
            AdicionarCommand = new Command(ExecuteAdicionarCommand);
            EditarCommand = new Command<Disciplina>(ExecuteEditarCommand);
            DeletarCommand = new Command<Disciplina>(ExecuteDeletarCommand);
        }

        private async void ExecuteSelecionarCommand(int idDisciplina)
        {
            await Navigation_Service.NavigateTo(new CadernoPage(idDisciplina));
        }
        private async void ExecuteDeletarCommand(Disciplina item)
        {
            if (!await ApiService.DeleteDisciplina(item.Id))
            {
                //Todo
            }
            Disciplinas.Remove(item);
        }
        private async void ExecuteAdicionarCommand()
        {
            await Navigation_Service.NavigateTo(new EditDisciplinaPage(ref disciplinas, idCurso, quatidadePeriodos));
        }
        private async void ExecuteEditarCommand(Disciplina item)
        {
            await Navigation_Service.NavigateTo(new EditDisciplinaPage(ref item, quatidadePeriodos));
        }

        /// <summary>
        /// Comando para atualizar lista
        /// </summary>
        public async void LoadDisciplinas()
        {
            List<Disciplina> DisciplinasDb = await ApiService.GetDisciplinas(idCurso);
            Disciplinas.Clear();

            if (DisciplinasDb != null)
            {
                foreach (Disciplina i in DisciplinasDb)
                {
                    if (i.Fase == fase)
                    {
                        Disciplinas.Add(i);
                    }
                }
            }
        }

    }
}

