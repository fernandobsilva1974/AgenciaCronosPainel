using AgenciaCronosPainel.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace AgenciaCronosPainel.Services
{
    public class ApiPosts
    {
        public IEnumerable<Posts> ListaPosts()
        {
            var model = new List<Posts>();

            //  string accesstoken = Settings.AccessToken;

            var URL = "https://localhost:44322/api/Posts/getposts";

            try
            {
                HttpClient requisicao = new HttpClient();
                // requisicao.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);
                HttpResponseMessage resposta = requisicao.GetAsync(URL).GetAwaiter().GetResult();

                if (resposta.StatusCode == HttpStatusCode.OK)
                {
                    string conteudo = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    if (conteudo.Length > 2)
                    {
                        List<Posts> mockItems = JsonConvert.DeserializeObject<List<Posts>>(conteudo)
                            .OrderBy(c => c.Titulo).ToList();

                        model = new List<Posts>();
                        foreach (var item in mockItems)
                        {
                            model.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }

            return model;
        }
    }
}