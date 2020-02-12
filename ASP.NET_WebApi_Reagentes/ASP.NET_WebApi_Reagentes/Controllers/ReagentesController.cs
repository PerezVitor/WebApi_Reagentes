using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Headers;
using ASP.NET_WebApi_Reagentes.Models;
using System.Net;

namespace ASP.NET_WebApi_Reagentes.Controllers
{
    public class ReagentesController : Controller
    {
        HttpClient client = new HttpClient();

        public ReagentesController()
        {
            client.BaseAddress = new Uri("http://localhost:49975/api/Reagente");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: Reagentes
        public ActionResult Index()
        {
            HttpResponseMessage response = client.GetAsync("/api/Reagente").Result;
            List<Reagentes> reagentes = new List<Reagentes>();
            if (response.IsSuccessStatusCode)
            {
                reagentes = response.Content.ReadAsAsync<List<Reagentes>>().Result;
                return View(reagentes); 
            }
            return View(reagentes);
        }

        // GET: Reagentes/Details/5
        public ActionResult Details(int id)
        {
            HttpResponseMessage response = client.GetAsync("/api/Reagente").Result;
            if(response.IsSuccessStatusCode)
            {
                List<Reagentes> reagentes = new List<Reagentes>();
                reagentes = response.Content.ReadAsAsync<List<Reagentes>>().Result;
                Reagentes reagente = reagentes.Where(r => r.Id == id).FirstOrDefault();
                return View(reagente);
            }
            return View();
        }

        // GET: Reagentes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reagentes/Create
        [HttpPost]
        public ActionResult Create(Reagentes reagente)
        {
            try
            {
                HttpResponseMessage response = client.PostAsJsonAsync("/api/Reagente", reagente).Result;
                if(response.StatusCode == HttpStatusCode.Created)
                {
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Reagentes/Edit/5
        public ActionResult Edit(int id)
        {
            HttpResponseMessage response = client.GetAsync("/api/Reagente").Result;
            if(response.IsSuccessStatusCode)
            {
                List<Reagentes> reagentes = new List<Reagentes>();
                reagentes = response.Content.ReadAsAsync<List<Reagentes>>().Result;
                Reagentes reagente = reagentes.Where(r => r.Id == id).FirstOrDefault();
                return View(reagente);
            }
            return View();
        }

        // POST: Reagentes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Reagentes reagente)
        {
            try
            {
                HttpResponseMessage response = client.PutAsJsonAsync($"/api/Reagente/{id}", reagente).Result;
                if(response.StatusCode == HttpStatusCode.NoContent)
                {
                    return RedirectToAction("Index");
                }
                return View(reagente);
            }
            catch
            {
                return View(reagente);
            }
        }

        // GET: Reagentes/Delete/5
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = client.GetAsync("/api/Reagente").Result;
            if (response.IsSuccessStatusCode)
            {
                List<Reagentes> reagentes = new List<Reagentes>();
                reagentes = response.Content.ReadAsAsync<List<Reagentes>>().Result;
                Reagentes reagente = reagentes.Where(r => r.Id == id).FirstOrDefault();
                return View(reagente);
            }
            return View();
        }

        // POST: Reagentes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Reagentes reagente)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync($"/api/Reagente/{id}").Result;
                if(response.StatusCode == HttpStatusCode.OK)
                {
                    return RedirectToAction("Index");
                }
                return View(reagente);
            }
            catch
            {
                return View(reagente);
            }
        }
    }
}
