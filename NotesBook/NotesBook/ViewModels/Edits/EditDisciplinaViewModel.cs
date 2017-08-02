using NotesBook.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace NotesBook.ViewModels
{
    public class EditDisciplinaViewModel:BaseViewModel
    {
        public ObservableCollection<Disciplina> _disciplinas;
        public Disciplina _disciplina;

        public Command ConcluirCommand { get; }

    #region Variaveis
        private bool IsEdit; //Ação atual é edição?
        Disciplina novo;//Variavel para novo item

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

        private int _fase;
        public int Fase
        {
            get { return _fase; }
            set
            {
                if (SetProperty(ref _fase, value))
                {
                    ConcluirCommand.ChangeCanExecute();
                }
            }
        }

        public int QutdFases { get; }//Captura quantidade de fases do curso
        #endregion

        /// <summary>
        /// Construtor para adiciona novo item a lista
        /// </summary>
        /// <param name="disciplinas"></param>
        /// <param name="idCurso"></param>
        /// <param name="quatidadeFases"></param>
        public EditDisciplinaViewModel(ref ObservableCollection<Disciplina> disciplinas, int idCurso, int quatidadeFases)
        {
            ConcluirCommand = new Command(ExecuteConcluirCommand, CanExecuteConcluirCommand);

            IsEdit = false;
            _disciplinas = disciplinas;
            novo = new Disciplina();
            novo.IdCurso = idCurso;
            QutdFases = quatidadeFases;
        }
        /// <summary>
        /// Construtor para editar item já existente na lista
        /// </summary>
        /// <param name="disciplina"></param>
        /// <param name="quatidadeFases"></param>
        public EditDisciplinaViewModel(ref Disciplina disciplina, int quatidadeFases)
        {
            ConcluirCommand = new Command(ExecuteConcluirCommand, CanExecuteConcluirCommand);

            Nome = disciplina.Nome;
            Descricao = disciplina.Descricao;
            Fase = disciplina.Fase;

            IsEdit = true;
            _disciplina = disciplina;
            QutdFases = quatidadeFases;
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
            if (IsEdit)
            {
                _disciplina.Nome = Nome;
                _disciplina.Descricao = Descricao;
                _disciplina.Fase = Fase;

                if (!await ApiService.PutDisciplina(_disciplina))
                {
                    //Todo
                }
                else
                    await Navigation_Service.PopAsyc();
            }
            else
            {
                novo.Nome = Nome;
                novo.Descricao = Descricao;
                novo.Fase = Fase;

                if (!await ApiService.PostDisciplina(novo))
                {
                    //Todo
                }
                else
                {
                    _disciplinas.Add(novo);
                    await Navigation_Service.PopAsyc();
                }
            }
        }
    }
}
