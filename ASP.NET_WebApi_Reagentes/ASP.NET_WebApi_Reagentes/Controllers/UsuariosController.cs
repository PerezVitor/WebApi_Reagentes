using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using ASP.NET_WebApi_Reagentes.Models;
using System.Net.Http.Headers;
using System.Collections.Generic;

namespace ASP.NET_WebApi_Reagentes.Controllers
{
    public class UsuariosController : Controller
    {
        HttpClient client = new HttpClient();

        public UsuariosController()
        {
            client.BaseAddress = new Uri("http://localhost:49975/api/Usuarios");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: Usuarios
        public ActionResult Index()
        {
            HttpResponseMessage response = client.GetAsync("/api/Usuarios").Result;
            if (response.IsSuccessStatusCode)
            {
                List<Usuario> usuarios = new List<Usuario>();
                usuarios = response.Content.ReadAsAsync<List<Usuario>>().Result;
                return View(usuarios);
            }
            return View();
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            HttpResponseMessage response = client.GetAsync($"/api/Usuarios").Result;
            if (response.IsSuccessStatusCode)
            {
                List<Usuario> usuarios = new List<Usuario>();
                usuarios = response.Content.ReadAsAsync<List<Usuario>>().Result;
                Usuario user = usuarios.Where(u => u.Id == id).FirstOrDefault();

                return View(user);
            }
            return HttpNotFound();
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            HttpResponseMessage response = client.PostAsJsonAsync("/api/Usuarios", usuario).Result;
            if (response.StatusCode == HttpStatusCode.Created)
            {
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            HttpResponseMessage response = client.GetAsync("/api/Usuarios").Result;
            List<Usuario> usuarios = new List<Usuario>();
            usuarios = response.Content.ReadAsAsync<List<Usuario>>().Result;

            Usuario usuario = usuarios.Where(u => u.Id == id).FirstOrDefault();
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuario)
        {
            HttpResponseMessage response = client.PutAsJsonAsync($"/api/Usuarios/{usuario.Id}", usuario).Result;
            if(response.StatusCode == HttpStatusCode.NoContent)
            {
                return RedirectToAction("Index");
            }                
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        //Retorna View com os dados do item a ser excluído
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            HttpResponseMessage response = client.GetAsync("/api/Usuarios").Result;
            List<Usuario> usuarios = new List<Usuario>();
            usuarios = response.Content.ReadAsAsync<List<Usuario>>().Result;
            Usuario usuario = usuarios.Where(u => u.Id == id).FirstOrDefault();
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        // Faz a exclusão do item após clique no botão
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HttpResponseMessage response = client.DeleteAsync($"/api/Usuarios/{id}").Result;
            if(response.StatusCode == HttpStatusCode.OK)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
