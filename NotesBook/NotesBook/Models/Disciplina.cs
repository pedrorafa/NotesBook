namespace NotesBook.Models
{
    public class Disciplina
    {
        public int Id { get; set; }
        public int IdCurso { get; set; }

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string IconUrl { get; set; }

        public int Fase { get; set; }
    }
}
