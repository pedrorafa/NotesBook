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
    public partial class CadernoDisciplinasPage : TabbedPage
    {
        public CadernoDisciplinasPage(int idCurso, int quatidadePeriodos)
        {
            InitializeComponent();

            for (int i = 0; i < quatidadePeriodos; i++)
            {
                this.Children.Add(new DisciplinasPage(idCurso, quatidadePeriodos, i + 1));
                this.Children[i].Title = $"Período {i + 1}";
            }
        }
    }
}