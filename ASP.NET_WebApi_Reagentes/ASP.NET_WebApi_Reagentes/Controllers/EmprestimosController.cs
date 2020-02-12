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
    public class EmprestimosController : Controller
    {
        HttpClient client = new HttpClient();

        public EmprestimosController()
        {
            client.BaseAddress = new Uri("http://localhost:49975/api/Emprestimo");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: Emprestimos
        public ActionResult Index()
        {
            HttpResponseMessage response = client.GetAsync("/api/Emprestimo").Result;
            List<Emprestimo> emprestimos = new List<Emprestimo>();
            if(response.IsSuccessStatusCode)
            {
                emprestimos = response.Content.ReadAsAsync<List<Emprestimo>>().Result;
                return View(emprestimos);
            }
            return View(emprestimos);
        }

        // GET: Emprestimos
        public ActionResult Create()
        {
            return View();
        }

        //POST: Emprestimos
        [HttpPost]
        public ActionResult Create(Emprestimo emprestimo)
        {
            HttpResponseMessage response = client.PostAsJsonAsync("/api/Emprestimo", emprestimo).Result;
            if(response.StatusCode == HttpStatusCode.Created)
            {
                return RedirectToAction("Index");
            }
            return View(emprestimo);
        }

        //GET: Emprestimos
        public ActionResult Details(int id)
        {
            HttpResponseMessage response = client.GetAsync($"/api/Emprestimo/{id}").Result;
            if(response.IsSuccessStatusCode)
            {
                Emprestimo emprestimo = response.Content.ReadAsAsync<Emprestimo>().Result;
                if(emprestimo == null)
                {
                    return HttpNotFound();
                }
                return View(emprestimo);
            }
            return View();
        }

        //GET: Emprestimos
        public ActionResult Edit(int id)
        {
            HttpResponseMessage response = client.GetAsync($"/api/Emprestimo/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                Emprestimo emprestimo = response.Content.ReadAsAsync<Emprestimo>().Result;
                if (emprestimo == null)
                {
                    return HttpNotFound();
                }
                return View(emprestimo);
            }
            return HttpNotFound();
        }

        //POST: Emprestimos
        [HttpPost]
        public ActionResult Edit(Emprestimo emprestimo)
        {
            HttpResponseMessage response = client.PutAsJsonAsync($"/api/Emprestimo/{emprestimo.Id}", emprestimo).Result;
            if(response.StatusCode == HttpStatusCode.NoContent)
            {
                return RedirectToAction("Index");
            }
            return View(response.RequestMessage);
        }

        //GET: EMprestimos
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = client.GetAsync($"/api/Emprestimo/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                Emprestimo emprestimo = response.Content.ReadAsAsync<Emprestimo>().Result;
                if (emprestimo == null)
                {
                    return HttpNotFound();
                }
                return View(emprestimo);
            }
            return HttpNotFound();
        }

        //POST: Emprestimo
        [HttpPost]
        public ActionResult Delete(Emprestimo emprestimo)
        {
            HttpResponseMessage response = client.DeleteAsync($"/api/Emprestimo/{emprestimo.Id}").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return RedirectToAction("Index");
            }
            return View(response.RequestMessage);
        }
    }
}