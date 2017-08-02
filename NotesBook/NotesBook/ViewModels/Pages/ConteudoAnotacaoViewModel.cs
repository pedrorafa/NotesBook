using NotesBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NotesBook.ViewModels
{
    public class ConteudoAnotacaoViewModel:BaseViewModel
    {
        public string Titulo { get; set; }
        public DateTime Data { get; set; }
        public string Conteudo { get; set; }

        public Command EditarCommand { get; }

        private Anotacao item;
        public ConteudoAnotacaoViewModel(Anotacao anotacao)
        {
            item = anotacao;
            Titulo = item.Titulo;
            Data = item.Data;
            Conteudo = item.Conteudo;

            EditarCommand = new Command(ExecuteEditarCommand);
        }


        private async void ExecuteEditarCommand()
        {
            await Navigation_Service.NavigateTo(new EditAnotacaoPage(ref item));
        }
    }
}
