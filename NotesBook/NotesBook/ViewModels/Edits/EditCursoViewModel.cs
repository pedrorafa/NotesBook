using NotesBook.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace NotesBook.ViewModels
{
    public class EditCursoViewModel:BaseViewModel
    {
        public ObservableCollection<Curso> _cursos;
        public Curso _curso;

        public Command ConcluirCommand { get; }

    #region Variaveis
        private bool IsEdit;//Ação atual é edição?
        Curso novo;//Variavel para novo item

        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set
            {
                if(SetProperty(ref _nome, value))
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
                if(SetProperty(ref _descricao, value))
                {
                    ConcluirCommand.ChangeCanExecute();
                }
            }
        }

        private int _qutdFases;
        public int QutdFases
        {
            get { return _qutdFases; }
            set
            {
                if (value >= oldQutdFases)
                    if (SetProperty(ref _qutdFases, value))
                    {
                        ConcluirCommand.ChangeCanExecute();
                    }
            }
        }

        private int oldQutdFases = 1;//Variavel para quantidade de fases atual do curso min.1
    #endregion

        /// <summary>
        /// Construtor para adiciona novo item a lista
        /// </summary>
        /// <param name="cursos"></param>
        /// <param name="idUser"></param>
        public EditCursoViewModel(ref ObservableCollection<Curso> cursos, int idUser)
        {
            ConcluirCommand = new Command(ExecuteConcluirCommand, CanExecuteConcluirCommand);

            IsEdit = false;
            QutdFases = oldQutdFases;
            _cursos = cursos;
            novo = new Curso();
            novo.IdUser = idUser;
        }
        /// <summary>
        /// Construtor para editar item já existente na lista
        /// </summary>
        /// <param name="curso"></param>
        public EditCursoViewModel(ref Curso curso)
        {
            ConcluirCommand = new Command(ExecuteConcluirCommand, CanExecuteConcluirCommand);

            IsEdit = true;
            oldQutdFases = curso.QutdFases;
            QutdFases = oldQutdFases;
            _curso = curso;
            Nome = _curso.Nome;
            Descricao = _curso.Descricao;
        }

        /// <summary>
        /// Comandos de conclusão de edição
        /// </summary>
        /// <returns></returns>
        bool CanExecuteConcluirCommand()
        {
            return (!string.IsNullOrEmpty(_nome) && !string.IsNullOrEmpty(_descricao) && _qutdFases >= oldQutdFases);
        }
        private async void ExecuteConcluirCommand()
        {
            if (IsEdit)
            {
                _curso.Nome = Nome;
                _curso.Descricao = Descricao;
                _curso.QutdFases = QutdFases;

                if(!await ApiService.PutCurso(_curso))
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
                novo.QutdFases = QutdFases;
                novo.IsConcluido = false;

               if (!await ApiService.PostCurso(novo))
                {
                    //Todo
                }
                else
                {
                    _cursos.Add(novo);
                    await Navigation_Service.PopAsyc();
                }
            }
        }
    }
}
