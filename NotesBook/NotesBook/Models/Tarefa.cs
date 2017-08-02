using System;

namespace NotesBook.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public int IdDisciplina { get; set; }

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string IconUrl { get; set; }

        public DateTime Prazo { get; set; }
        public bool Concluida { get; set; }
    }
}
