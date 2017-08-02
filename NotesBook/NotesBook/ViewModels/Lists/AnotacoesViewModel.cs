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
    public class AnotacaosViewModel : BaseViewModel
    {
        ///Propriedade com a lista dos anotacaos
        private ObservableCollection<Anotacao> anotacaos;
        public ObservableCollection<Anotacao> Anotacaos { get; }

        public Command SelecionarCommand { get; }
        public Command AdicionarCommand { get; }
        public Command EditarCommand { get; }
        public Command DeletarCommand { get; }

        private int idDisciplina;

        public AnotacaosViewModel(int _idDisciplina)
        {
            idDisciplina = _idDisciplina;
            anotacaos = new ObservableCollection<Anotacao>();
            Anotacaos = anotacaos;

            SelecionarCommand = new Command<Anotacao>(ExecuteSelecionarCommand);
            AdicionarCommand = new Command(ExecuteAdicionarCommand);
            EditarCommand = new Command<Anotacao>(ExecuteEditarCommand);
            DeletarCommand = new Command<Anotacao>(ExecuteDeletarCommand);
        }

        private async void ExecuteSelecionarCommand(Anotacao AnotacaoInicial)
        {
            await Navigation_Service.NavigateTo(new CadernoAnotacoesPage(Anotacaos.ToList(),AnotacaoInicial));
        }
        private async void ExecuteDeletarCommand(Anotacao item)
        {
            if (!await ApiService.DeleteAnotacao(item.Id))
            {
                //Todo
            }
            anotacaos.Remove(item);
        }
        private async void ExecuteAdicionarCommand()
        {
            await Navigation_Service.NavigateTo(new EditAnotacaoPage(ref anotacaos, idDisciplina));
        }
        private async void ExecuteEditarCommand(Anotacao item)
        {
            await Navigation_Service.NavigateTo(new EditAnotacaoPage(ref item));
        }

        /// <summary>
        /// Comando para atualizar lista
        /// </summary>
        public async void LoadAnotacaos()
        {
            List<Anotacao> anotacaosDb = await ApiService.GetAnotacaos(idDisciplina);
            anotacaos.Clear();

            if (anotacaosDb != null)
            {
                foreach (Anotacao i in anotacaosDb)
                {
                    anotacaos.Add(i);
                }
            }
        }
    }
}
