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
    public class PostsController : Controller
    {
        private ApiPosts _apiServices = new ApiPosts();

        // GET: Servicos
        public ActionResult Index()
        {
            var model = _apiServices.ListaPosts();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Details(long id = 0)
        {
            var model = (from a in _apiServices.ListaPosts() where a.Id == id select a).FirstOrDefault();

            return View(model);
        }

        public ActionResult Edit(long id = 0)
        {
            var model = (from a in _apiServices.ListaPosts() where a.Id == id select a).FirstOrDefault();

            return View(model);
        }

        public ActionResult Delete(long id = 0)
        {
            var model = (from a in _apiServices.ListaPosts() where a.Id == id select a).FirstOrDefault();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Posts serv)
        {
            Posts bm = new Posts();
            bm.Titulo = serv.Titulo;
            bm.Descritivo = serv.Descritivo;
            bm.DataCriacao = System.DateTime.Now;

            string json = JsonConvert.SerializeObject(bm);
            var URL = "https://localhost:44322/api/Posts/createpost";
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

            return RedirectToAction("Index", "Posts");
        }

        [HttpPost]
        public ActionResult Delete(Posts serv)
        {
            Posts bm = new Posts();
            bm.Id = serv.Id;

            string json = JsonConvert.SerializeObject(bm);
            var URL = "https://localhost:44322/api/Posts/postdeleteposts";
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

            return RedirectToAction("Index", "Posts");
        }

        [HttpPost]
        public ActionResult Edit(Posts serv)
        {
            Posts bm = new Posts();
            bm.Id = serv.Id;
            bm.Titulo = serv.Titulo;
            bm.Descritivo = serv.Descritivo;

            string json = JsonConvert.SerializeObject(bm);
            var URL = "https://localhost:44322/api/Posts/posteditposts";
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

            return RedirectToAction("Details/" + serv.Id, "Posts");
        }
    }
}