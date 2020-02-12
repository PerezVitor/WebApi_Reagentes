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
    public class LoginController : Controller
    {
        HttpClient client = new HttpClient();

        public LoginController()
        {
            client.BaseAddress = new Uri("http://localhost:49975/api/Usuarios");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        //POST: Login
        [HttpPost]
        public ActionResult Login(string login, string senha)
        {
            HttpResponseMessage response = client.GetAsync("/api/Usuarios").Result;
            if(response.IsSuccessStatusCode)
            {
                List<Usuario> usuarios = new List<Usuario>();
                usuarios = response.Content.ReadAsAsync<List<Usuario>>().Result;
                Usuario usuarioLogado = usuarios.Where(u => u.Login.Equals(login) && u.Senha.Equals(senha)).FirstOrDefault();
                if (usuarioLogado != null)
                {
                    Session["Id_Usuario"] = usuarioLogado.Id.ToString();
                    Session["Nm_Usuario"] = usuarioLogado.Nome.ToString();
                    return RedirectToAction("Home");
                }
            }            
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Usuarios()
        {
            return RedirectToAction("Index", "Usuarios");
        }

        public ActionResult Reagentes()
        {
            return RedirectToAction("Index", "Reagentes");
        }

        public ActionResult Emprestimos()
        {
            return RedirectToAction("Index", "Usuarios");
        }

        public ActionResult Logout()
        {
            Session["Id_Usuario"] = null;
            Session["Nm_Usuario"] = null;
            return RedirectToAction("Login");
        }

        //GET
        public ActionResult Registrar()
        {
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Registrar(Usuario usuario)
        {
            HttpResponseMessage response = client.PostAsJsonAsync("/api/Usuarios", usuario).Result;
            if(response.StatusCode == HttpStatusCode.Created)
            {
                return RedirectToAction("Login");
            }
            return View(usuario);
        }

        //GET
        public ActionResult AlterarSenha()
        {
            HttpResponseMessage response = client.GetAsync("/api/Usuarios").Result;
            List<Usuario> usuarios = new List<Usuario>();
            usuarios = response.Content.ReadAsAsync<List<Usuario>>().Result;
            Usuario usuario = usuarios.Where(u => u.Id == int.Parse(Session["Id_Usuario"].ToString())).FirstOrDefault();
            
            if(usuario != null)
            {
                return View(usuario);
            }
            return View();
        }

        //PUT
        [HttpPost]
        public ActionResult AlterarSenha(Usuario usuario)
        {
            HttpResponseMessage response = client.PutAsJsonAsync($"/api/Usuarios/{usuario.Id}", usuario).Result;
            if(response.StatusCode == HttpStatusCode.NoContent)
            {
                Session["Id_Usuario"] = null;
                Session["Nm_Usuario"] = null;
                return RedirectToAction("Login");
            }
            return View(usuario);
        }
    }
}