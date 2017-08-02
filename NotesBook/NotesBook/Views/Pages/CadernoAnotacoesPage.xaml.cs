using NotesBook.Models;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotesBook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadernoAnotacoesPage : CarouselPage
    {
        public CadernoAnotacoesPage(List<Anotacao> anotacoes, Anotacao inicial)
        {
            InitializeComponent();

            int posicaoInicial = anotacoes.IndexOf(inicial);

            foreach (Anotacao i in anotacoes)
            {
                this.Children.Add(new ConteudoAnotacaoPage(i));
            }

            this.CurrentPage = this.Children[posicaoInicial];
        }
    }
}