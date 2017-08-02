using NotesBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesBook.Interfaces
{
    public interface INotesBookApiService
    {
        Task<User> GetUser(string id);
        Task<List<Curso>> GetCursos(int idUser);
        Task<List<Disciplina>> GetDisciplinas(int idCurso);
        Task<List<Anotacao>> GetAnotacaos(int idDisciplina);
        Task<List<Tarefa>> GetTarefas(int idDisciplina);

        Task<List<Tarefa>> GetTarefasByCurso(int idCurso);
        Task<List<Tarefa>> GetTarefasByUser(int idUser);

        Task<bool> PostCurso(Curso curso);
        Task<bool> PostDisciplina(Disciplina disciplina);
        Task<bool> PostAnotacao(Anotacao curso);
        Task<bool> PostTarefa(Tarefa curso);
        Task<bool> PostUserAsync(User usuario);

        Task<bool> PutCurso(Curso curso);
        Task<bool> PutDisciplina(Disciplina disciplina);
        Task<bool> PutAnotacao(Anotacao anotacao);
        Task<bool> PutTarefa(Tarefa tarefa);

        Task<bool> DeleteCurso(int id);
        Task<bool> DeleteDisciplina(int id);
        Task<bool> DeleteAnotacao(int id);
        Task<bool> DeleteTarefa(int id);

        Task MensagemDeErro(string menssage);

    }
}
