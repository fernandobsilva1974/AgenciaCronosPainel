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
    public class ApiIntegrantes
    {
        public IEnumerable<Integrantes> ListaIntegrantes()
        {
            var model = new List<Integrantes>();

            //  string accesstoken = Settings.AccessToken;

            var URL = "https://localhost:44322/api/Integrantes/getintegrantes";

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
                        List<Integrantes> mockItems = JsonConvert.DeserializeObject<List<Integrantes>>(conteudo)
                            .OrderBy(c => c.Nome).ToList();

                        model = new List<Integrantes>();
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