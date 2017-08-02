using NotesBook.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NotesBook.ViewModels
{
    public class TarefasViewModel:BaseViewModel
    {
        ///Propriedade com a lista dos tarefas
        private ObservableCollection<Tarefa> tarefas;
        public ObservableCollection<Tarefa> Tarefas { get; }

        public Command SelecionarCommand { get; }
        public Command AdicionarCommand { get; }
        public Command EditarCommand { get; }
        public Command ConcluirCommand { get; }
        public Command DeletarCommand { get; }

        private int idDisciplina;

        public TarefasViewModel(int _idDisciplina)
        {
            idDisciplina = _idDisciplina;
            tarefas = new ObservableCollection<Tarefa>();
            Tarefas = tarefas;

            SelecionarCommand = new Command<Tarefa>(ExecuteSelecionarCommand);
            AdicionarCommand = new Command(ExecuteAdicionarCommand);
            EditarCommand = new Command<Tarefa>(ExecuteEditarCommand);
            ConcluirCommand = new Command<Tarefa>(ExecuteConcluirCommand);
            DeletarCommand = new Command<Tarefa>(ExecuteDeletarCommand);
        }

        private void ExecuteSelecionarCommand(Tarefa item)
        {
            ExecuteEditarCommand(item);
        }
        private async void ExecuteConcluirCommand(Tarefa item)
        {
            item.Concluida = true;
            if (!await ApiService.PutTarefa(item))
            {
                //Todo
            }
            LoadTarefas();
        }
        private async void ExecuteDeletarCommand(Tarefa item)
        {
            if (!await ApiService.DeleteTarefa(item.Id))
            {
                //Todo
            }
            tarefas.Remove(item);
        }
        private async void ExecuteAdicionarCommand()
        {
            await Navigation_Service.NavigateTo(new EditTarefaPage(ref tarefas, idDisciplina));
        }
        private async void ExecuteEditarCommand(Tarefa item)
        {
            await Navigation_Service.NavigateTo(new EditTarefaPage(ref item));
        }

        /// <summary>
        /// Comando para atualizar lista
        /// </summary>
        public async void LoadTarefas()
        {
            List<Tarefa> tarefasDb = await ApiService.GetTarefas(idDisciplina);
            tarefas.Clear();

            if (tarefasDb != null)
            {
                foreach (Tarefa i in tarefasDb)
                    if (!i.Concluida)
                    {
                        tarefas.Add(i);
                    }
            }
        }
    }
}
