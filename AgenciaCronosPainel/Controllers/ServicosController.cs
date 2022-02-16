using AgenciaCronosPainel.Models;
using AgenciaCronosPainel.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AgenciaCronosPainel.Controllers
{
    public class ServicosController : Controller
    {
        private ApiServicos _apiServices = new ApiServicos();

        // GET: Servicos
        public ActionResult Index()
        {
            var model = _apiServices.ListaServicos();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Details(long id = 0)
        {
            var model = (from a in _apiServices.ListaServicos() where a.Id == id select a).FirstOrDefault();

            return View(model);
        }

        public ActionResult Edit(long id = 0)
        {
            var model = (from a in _apiServices.ListaServicos() where a.Id == id select a).FirstOrDefault();

            return View(model);
        }

        public ActionResult Delete(long id = 0)
        {
            var model = (from a in _apiServices.ListaServicos() where a.Id == id select a).FirstOrDefault();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Servicos serv)
        {
            Servicos bm = new Servicos();
            bm.CodServico = serv.CodServico;
            bm.DescServico = serv.DescServico;
            bm.DataCriacao = System.DateTime.Now;

            string json = JsonConvert.SerializeObject(bm);
            var URL = "https://localhost:44322/api/Servicos/postservicos";
            //string accesstoken = Settings.AccessToken;

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(URL),
                Content = new StringContent(json, Encoding.UTF8, "application/json"),
            };

            var client = new HttpClient();
            // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);
            var response = client.SendAsync(request);

            return RedirectToAction("Index", "Servicos");
        }

        [HttpPost]
        public ActionResult Delete(Servicos serv)
        {
            Servicos bm = new Servicos();
            bm.Id = serv.Id;

            string json = JsonConvert.SerializeObject(bm);
            var URL = "https://localhost:44322/api/Servicos/postdeleteservicos";
            //string accesstoken = Settings.AccessToken;

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(URL),
                Content = new StringContent(json, Encoding.UTF8, "application/json"),
            };

            var client = new HttpClient();
            // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);
            var response = client.SendAsync(request);

            return RedirectToAction("Index", "Servicos");
        }

        [HttpPost]
        public ActionResult Edit(Servicos serv)
        {
            Servicos bm = new Servicos();
            bm.Id = serv.Id;
            bm.CodServico = serv.CodServico;
            bm.DescServico = serv.DescServico;

            string json = JsonConvert.SerializeObject(bm);
            var URL = "https://localhost:44322/api/Servicos/posteditservicos";
            //string accesstoken = Settings.AccessToken;

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(URL),
                Content = new StringContent(json, Encoding.UTF8, "application/json"),
            };

            var client = new HttpClient();
           // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);
            var response = client.SendAsync(request);

            return RedirectToAction("Details/" + serv.Id, "Servicos");
        }
    }
}