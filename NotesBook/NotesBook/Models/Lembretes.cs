using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesBook.Models
{
    public class Lembretes
    {
        public int Id { get; set; }
        public int IdUser { get; set; }

        public string Nome { get; set; }
        public string Descricao { get; set; }

        public DateTime DataDoLembrete { get; set; }
        public bool DeleteDepois { get; set; } 

    }
}
