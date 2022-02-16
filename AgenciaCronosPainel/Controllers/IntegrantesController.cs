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
    public class IntegrantesController : Controller
    {
        // GET: Integrantes
        private ApiIntegrantes _apiServices = new ApiIntegrantes();

        // GET: Servicos
        public ActionResult Index()
        {
            var model = _apiServices.ListaIntegrantes();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Details(long id = 0)
        {
            var model = (from a in _apiServices.ListaIntegrantes() where a.Id == id select a).FirstOrDefault();

            return View(model);
        }

        public ActionResult Edit(long id = 0)
        {
            var model = (from a in _apiServices.ListaIntegrantes() where a.Id == id select a).FirstOrDefault();

            return View(model);
        }

        public ActionResult Delete(long id = 0)
        {
            var model = (from a in _apiServices.ListaIntegrantes() where a.Id == id select a).FirstOrDefault();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Integrantes serv)
        {
            Integrantes bm = new Integrantes();
            bm.Celular = serv.Celular;
            bm.Cpf = serv.Cpf;
            bm.Email = serv.Email;
            bm.Nome = serv.Nome;
            bm.DataCriacao = System.DateTime.Now;

            string json = JsonConvert.SerializeObject(bm);
            var URL = "https://localhost:44322/api/Integrantes/postintegrantes";
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

            return RedirectToAction("Index", "Integrantes");
        }

        [HttpPost]
        public ActionResult Delete(Integrantes serv)
        {
            Integrantes bm = new Integrantes();
            bm.Id = serv.Id;

            string json = JsonConvert.SerializeObject(bm);
            var URL = "https://localhost:44322/api/Integrantes/postdeleteintegrantes";
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

            return RedirectToAction("Index", "Integrantes");
        }

        [HttpPost]
        public ActionResult Edit(Integrantes serv)
        {
            Integrantes bm = new Integrantes();
            bm.Id = serv.Id;
            bm.Celular = serv.Celular;
            bm.Cpf = serv.Cpf;
            bm.Email = serv.Email;
            bm.Nome = serv.Nome;

            string json = JsonConvert.SerializeObject(bm);
            var URL = "https://localhost:44322/api/Integrantes/posteditintegrantes";
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

            return RedirectToAction("Details/" + serv.Id, "Integrantes");
        }
    }
}