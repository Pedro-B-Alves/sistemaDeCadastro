using Newtonsoft.Json;
using SistemaDeCadastro.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeCadastro.Service
{
    public class DataService
    {
        HttpClient client = new HttpClient();
        public async Task<List<Usuario>> GetUserAsync()
        {
            try
            {
                string url = "http://192.168.0.104:5000/api/Usuarios/";
                var response = await client.GetStringAsync(url);
                var usuarios = JsonConvert.DeserializeObject<List<Usuario>>(response);
                return usuarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task AddUserAsync(Usuario usuario)
        {
            try
            {
                string url = "http://192.168.0.104:5000/api/Usuarios/";
                var data = JsonConvert.SerializeObject(usuario);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                response = await client.PostAsync(url, content);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Erro ao incluir usuário" + response);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task UpdateUserAsync(Usuario usuario)
        {
            string url = "http://192.168.0.104:5000/api/Usuarios/{0}";
            var uri = new Uri(string.Format(url, usuario.id));
            var data = JsonConvert.SerializeObject(usuario);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            response = await client.PutAsync(uri, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Erro ao atualizar usuário");
            }
        }
        public async Task DeletaUserAsync(Usuario usuario)
        {
            string url = "http://192.168.0.104:5000/api/Usuarios/{0}";
            var uri = new Uri(string.Format(url, usuario.id));
            await client.DeleteAsync(uri);
        }
    }
}
