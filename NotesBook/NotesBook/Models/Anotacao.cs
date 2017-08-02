using System;

namespace NotesBook.Models
{
    public class Anotacao
    {
        public int Id { get; set; }
        public int IdDisciplina { get; set; }

        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public string IconUrl { get; set; }

        public DateTime Data { get; set; }
    }
}
