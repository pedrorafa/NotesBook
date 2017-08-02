using NotesBook.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NotesBook.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Text;
using Xamarin.Forms;
using SQLite;

[assembly: Dependency(typeof(NotesBook.Services.NotesBookApiService))]
namespace NotesBook.Services
{
    public class NotesBookApiService //: INotesBookApiService
    {
        /// <summary>
        /// Url base de acesso API, no momento local, altere para a url de host da api
        /// </summary>
        private const string BaseUrl = "http://localhost:49899/api/";

        /// <summary>
        /// Variavel de conexão ao banco de dados local
        /// </summary>
        readonly SQLiteAsyncConnection dataBase;

        /// <summary>
        /// Construtor de inicialização dos serviços SQLite 
        /// </summary>
        public NotesBookApiService()
        {
            var config = DependencyService.Get<IConfigDb>();
            dataBase = new SQLiteAsyncConnection(config.GetPathDb("NotesDB.db3"));

            dataBase.CreateTableAsync<User>().Wait();
            dataBase.CreateTableAsync<Curso>().Wait();
            dataBase.CreateTableAsync<Disciplina>().Wait();
            dataBase.CreateTableAsync<Anotacao>().Wait();
            dataBase.CreateTableAsync<Tarefa>().Wait();
        }

        #region get
        /// <summary>
        /// Metodos Get da API RESt
        /// </summary>
        /// <returns>Objeto ou Lista de objetos</returns>
        public async Task<User> GetUser(string id)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync($"{BaseUrl}Users/GetById/{id}").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<User>(
                        await new StreamReader(responseStream)
                            .ReadToEndAsync().ConfigureAwait(false));
                }
            }

            return null;
        }
        public async Task<List<Curso>> GetCursos(int idUser)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync($"{BaseUrl}Cursos/GetByUser/{idUser}").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<List<Curso>>(
                        await new StreamReader(responseStream)
                            .ReadToEndAsync().ConfigureAwait(false));
                }
            }

            return null;
        }
        public async Task<List<Disciplina>> GetDisciplinas(int idCurso)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync($"{BaseUrl}Disciplinas/GetByCurso/{idCurso}").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<List<Disciplina>>(
                        await new StreamReader(responseStream)
                            .ReadToEndAsync().ConfigureAwait(false));
                }
            }

            return null;
        }
        public async Task<List<Anotacao>> GetAnotacaos(int idDisciplina)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync($"{BaseUrl}Anotacaos/GetByDisciplina/{idDisciplina}").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<List<Anotacao>>(
                        await new StreamReader(responseStream)
                            .ReadToEndAsync().ConfigureAwait(false));
                }
            }

            return null;
        }
        public async Task<List<Tarefa>> GetTarefas(int idDisciplina)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync($"{BaseUrl}Tarefas/GetByDisciplina/{idDisciplina}").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<List<Tarefa>>(
                        await new StreamReader(responseStream)
                            .ReadToEndAsync().ConfigureAwait(false));
                }
            }

            return null;
        }
        public async Task<List<Tarefa>> GetTarefasByCurso(int idCurso)
        {
            throw new NotImplementedException();
        }//Não implementado
        public async Task<List<Tarefa>> GetTarefasByUser(int idUser)
        {
            throw new NotImplementedException();
        }//não implementado
        #endregion

        #region post
        /// <summary>
        /// Metodos Get da API RESt
        /// </summary>
        /// <returns>posta um objeto no banco da API</returns>
        public async Task<bool> PostUserAsync(User usuario)
        {
            VerificarConexao();
            string json = JsonConvert.SerializeObject(usuario);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync($"{BaseUrl}Users/Post", httpContent);

                return true;
            }
        }

        public async Task<bool> PostCurso(Curso curso)
        {
            VerificarConexao();
            string json = JsonConvert.SerializeObject(curso);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync($"{BaseUrl}Cursos/Post",httpContent);

                return true;
            }
        }
        public async Task<bool> PostDisciplina(Disciplina disciplina)
            {
                VerificarConexao();
                string json = JsonConvert.SerializeObject(disciplina);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await httpClient.PostAsync($"{BaseUrl}Disciplinas/Post", httpContent);

                    return true;
                }
            }
        public async Task<bool> PostAnotacao(Anotacao anotacao)
            {
                VerificarConexao();
                string json = JsonConvert.SerializeObject(anotacao);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await httpClient.PostAsync($"{BaseUrl}Anotacaos/Post", httpContent);

                    return true;
                }
            }
        public async Task<bool> PostTarefa(Tarefa tarefa)
            {
                VerificarConexao();
                string json = JsonConvert.SerializeObject(tarefa);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await httpClient.PostAsync($"{BaseUrl}Tarefas/Post", httpContent);

                    return true;
                }
            }
        #endregion

        #region put
        /// <summary>
        /// Metodos Put da API RESt
        /// </summary>
        /// <returns>Atualiza um objeto no banco da API</returns>
        public async Task<bool> PutCurso(Curso curso)
        {
            VerificarConexao();
            string json = JsonConvert.SerializeObject(curso);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.PutAsync($"{BaseUrl}Cursos/Put/{curso.Id}", httpContent);

                return true;
            }
        }
        public async Task<bool> PutDisciplina(Disciplina disciplina)
        {
            VerificarConexao();
            string json = JsonConvert.SerializeObject(disciplina);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await httpClient.PutAsync($"{BaseUrl}Disciplinas/Put/{disciplina.Id}", httpContent);

                return true;
            }
        }
        public async Task<bool> PutAnotacao(Anotacao anotacao)
        {
            VerificarConexao();
            string json = JsonConvert.SerializeObject(anotacao);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await httpClient.PutAsync($"{BaseUrl}Anotacaos/Put/{anotacao.Id}", httpContent);

                return true;
            }
        }
        public async Task<bool> PutTarefa(Tarefa tarefa)
        {
            VerificarConexao();
            string json = JsonConvert.SerializeObject(tarefa);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await httpClient.PutAsync($"{BaseUrl}Tarefas/Put/{tarefa.Id}", httpContent);

                return true;
            }
        }
        #endregion

        #region delete
        /// <summary>
        /// Metodos DELETE da API RESt
        /// </summary>
        /// <returns>Deleta um objeto do banco da API</returns>
        public async Task<bool> DeleteCurso(int id)
        {
            bool conexao = await VerificarConexao();
            if (conexao)
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var response = await httpClient.DeleteAsync($"{BaseUrl}Cursos/Delete/{id}");

                    return true;
                }
            }
            var resultado = await dataBase.DeleteAsync(dataBase.Table<Curso>().Where(i => i.Id == id).FirstOrDefaultAsync());
            return Convert.ToBoolean(resultado.ToString());
        }
        public async Task<bool> DeleteDisciplina(int id)
        {
            bool conexao = await VerificarConexao();
            if (conexao)
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var response = await httpClient.DeleteAsync($"{BaseUrl}Disciplinas/Delete/{id}");

                    return true;
                }
            }
            var resultado = await dataBase.DeleteAsync(dataBase.Table<Disciplina>().Where(i => i.Id == id).FirstOrDefaultAsync());
            return Convert.ToBoolean(resultado.ToString());
        }
        public async Task<bool> DeleteAnotacao(int id)
        {
            bool conexao = await VerificarConexao();
            if (conexao)
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var response = await httpClient.DeleteAsync($"{BaseUrl}Anotacaos/Delete/{id}");

                    return true;
                }
            }
            var resultado = await dataBase.DeleteAsync(dataBase.Table<Anotacao>().Where(i => i.Id == id).FirstOrDefaultAsync());
            return Convert.ToBoolean(resultado.ToString());
        }
        public async Task<bool> DeleteTarefa(int id)
        {
            bool conexao = await VerificarConexao();
            if (conexao)
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var response = await httpClient.DeleteAsync($"{BaseUrl}Tarefas/Delete/{id}");

                    return true;
                }
            }
            var resultado = await dataBase.DeleteAsync(dataBase.Table<Tarefa>().Where(i => i.Id == id).FirstOrDefaultAsync());
            return Convert.ToBoolean(resultado.ToString());
        }
        #endregion

        public async Task MensagemDeErro(string menssage)
        {
            await App.Current.MainPage.DisplayAlert("Houve um erro!",menssage , "Fechar");
        }
        private async Task<bool> VerificarConexao()
        {
            var e = Plugin.Connectivity.CrossConnectivity.Current;
            var host = await Plugin.Connectivity.CrossConnectivity.Current.IsReachable("http://localhost:49899/", 5000);

            if (!e.IsConnected || host)
            {
                return false;
            }
            return true;
        }
     
        public void Dispose()
        {
            SQLiteAsyncConnection.ResetPool();
        }
    }
}
