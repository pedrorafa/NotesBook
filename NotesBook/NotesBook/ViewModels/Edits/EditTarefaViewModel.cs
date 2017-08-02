using NotesBook.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NotesBook.ViewModels.Edits
{
    public class EditTarefaViewModel:BaseViewModel
    {
        public ObservableCollection<Tarefa> _tarefas;
        public Tarefa _tarefa;

        public Command ConcluirCommand { get; }

        #region Variaveis
        private bool IsEdit; //Ação atual é edição?
        Tarefa novo;//Variavel para novo item

        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set
            {
                if (SetProperty(ref _nome, value))
                {
                    ConcluirCommand.ChangeCanExecute();
                }
            }
        }

        private string _descricao;
        public string Descricao
        {
            get { return _descricao; }
            set
            {
                if (SetProperty(ref _descricao, value))
                {
                    ConcluirCommand.ChangeCanExecute();
                }
            }
        }

        private DateTime _prazo;
        public DateTime Prazo
        {
            get { return _prazo; }
            set
            {
                if (SetProperty(ref _prazo, value))
                {
                    ConcluirCommand.ChangeCanExecute();
                }
            }
        }
        #endregion

        /// <summary>
        /// Construtor para adiciona novo item a lista
        /// </summary>
        /// <param name="tarefas"></param>
        /// <param name="idDisciplina"></param>
        public EditTarefaViewModel(ref ObservableCollection<Tarefa> tarefas, int idDisciplina)
        {
            ConcluirCommand = new Command(ExecuteConcluirCommand, CanExecuteConcluirCommand);
            Prazo = DateTime.Now;

            IsEdit = false;
            _tarefas = tarefas;
            novo = new Tarefa();
            novo.IdDisciplina = idDisciplina;
            novo.Concluida = false;
        }
        /// <summary>
        /// Construtor para editar item já existente na lista
        /// </summary>
        /// <param name="tarefa"></param>
        public EditTarefaViewModel(ref Tarefa tarefa)
        {
            ConcluirCommand = new Command(ExecuteConcluirCommand, CanExecuteConcluirCommand);

            Nome = tarefa.Nome;
            Descricao = tarefa.Descricao;
            Prazo = tarefa.Prazo;

            IsEdit = true;
            _tarefa = tarefa;
        }

        /// <summary>
        /// Comandos de conclusão de edição
        /// </summary>
        /// <returns></returns>
        private bool CanExecuteConcluirCommand()
        {
            return (!string.IsNullOrEmpty(_nome) && !string.IsNullOrEmpty(_descricao));
        }
        private async void ExecuteConcluirCommand()
        {
            //Se estiver editando item
            if (IsEdit)
            {
                _tarefa.Nome = Nome;
                _tarefa.Descricao = Descricao;

                if (!await ApiService.PutTarefa(_tarefa))
                {
                    //Todo
                }
                else
                    await Navigation_Service.PopAsyc();
            }
            //Se adicionar novo item
            else
            {
                novo.Nome = Nome;
                novo.Descricao = Descricao;
                novo.Prazo = DateTime.Now;

                if (!await ApiService.PostTarefa(novo))
                {
                    //Todo
                }
                else
                {
                    _tarefas.Add(novo);
                    await Navigation_Service.PopAsyc();
                }
            }
        }
    }
}
