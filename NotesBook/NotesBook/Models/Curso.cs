using Newtonsoft.Json;

namespace NotesBook.Models
{
    public class Curso
    {
        public int Id { get; set; }

        public int IdUser { get; set; }

        public int IdIntituicao { get; set; }
        public string KeyAuth { get; set; }

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string IconUrl { get; set; }

        public int QutdFases { get; set; }
        public bool IsConcluido { get; set; }
    }
}
