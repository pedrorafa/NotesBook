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
    public class EditAnotacaoViewModel:BaseViewModel
    {
        public ObservableCollection<Anotacao> _anotacaos;
        public Anotacao _anotacao;

        public Command ConcluirCommand { get; }

        #region Variaveis
        private bool IsEdit; //Ação atual é edição?
        Anotacao novo;//Variavel para novo item

        private string _titulo;
        public string Titulo
        {
            get { return _titulo; }
            set
            {
                if(SetProperty(ref _titulo, value))
                {
                    ConcluirCommand.ChangeCanExecute();
                }
            }
        }

        private string _conteudo;
        public string Conteudo
        {
            get { return _conteudo; }
            set
            {
                if(SetProperty(ref _conteudo, value))
                {
                    ConcluirCommand.ChangeCanExecute();
                }
            }
        }
    #endregion

        /// <summary>
        /// Construtor para adiciona novo item a lista
        /// </summary>
        /// <param name="anotacaos"></param>
        /// <param name="idDisciplina"></param>
        public EditAnotacaoViewModel(ref ObservableCollection<Anotacao> anotacaos, int idDisciplina)
        {
            ConcluirCommand = new Command(ExecuteConcluirCommand, CanExecuteConcluirCommand);

            IsEdit = false;
            _anotacaos = anotacaos;
            novo = new Anotacao();
            novo.IdDisciplina = idDisciplina;
        }
        /// <summary>
        /// Construtor para editar item já existente na lista
        /// </summary>
        /// <param name="anotacao"></param>
        public EditAnotacaoViewModel(ref Anotacao anotacao)
        {
            ConcluirCommand = new Command(ExecuteConcluirCommand, CanExecuteConcluirCommand);

            Titulo = anotacao.Titulo;
            Conteudo = anotacao.Conteudo;

            IsEdit = true;
            _anotacao = anotacao;
        }

        /// <summary>
        /// Comandos de conclusão de edição
        /// </summary>
        /// <returns></returns>
        private bool CanExecuteConcluirCommand()
        {
            return (!string.IsNullOrEmpty(_titulo) && !string.IsNullOrEmpty(_conteudo));
        }
        private async void ExecuteConcluirCommand()
        {
            if (IsEdit)
            {
                _anotacao.Titulo = Titulo;
                _anotacao.Conteudo = Conteudo;

                if (!await ApiService.PutAnotacao(_anotacao))
                {
                    //Todo
                }
                else
                    await Navigation_Service.PopAsyc();
            }
            else
            {
                novo.Titulo = Titulo;
                novo.Conteudo = Conteudo;
                novo.Data = DateTime.Now;

                if (!await ApiService.PostAnotacao(novo))
                {
                    //Todo
                }
                else
                {
                    _anotacaos.Add(novo);
                    await Navigation_Service.PopAsyc();
                }
            }
        }
    }
}
