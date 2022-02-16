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
    public class ApiServicos
    {
        public IEnumerable<Servicos> ListaServicos()
        {
            var model = new List<Servicos>();

            //  string accesstoken = Settings.AccessToken;

            var URL = "https://localhost:44322/api/Servicos/getservicos";

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
                        List<Servicos> mockItems = JsonConvert.DeserializeObject<List<Servicos>>(conteudo)
                            .OrderBy(c => c.CodServico).ToList();

                        model = new List<Servicos>();
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