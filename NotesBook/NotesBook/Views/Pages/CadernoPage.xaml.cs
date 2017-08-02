using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotesBook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadernoPage : TabbedPage
    {
        public CadernoPage(int idDisciplina)
        {
            InitializeComponent();
            this.Children.Add(new AnotacoesPage(idDisciplina));
            this.Children.Add(new TarefasPage(idDisciplina));
        }
    }
}