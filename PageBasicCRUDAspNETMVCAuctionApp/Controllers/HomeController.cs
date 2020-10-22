using Dominio.Interfaces.InjecaoDependencia;
using Infra.CrossCutting.IoC;
using System;
using Aplicacao.Interfaces;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace BasicCRUDAspNETMVCAuctionApp.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            //InicializarServicos();

            var _usuarioPrincipal = HttpContext.Session.GetString("userId");

            if (_usuarioPrincipal == null)
            {               
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return RedirectToAction("Home", "Index");
            }
            
        }

        [Route("PaginaInicial")]
        [HttpGet]
        public IActionResult PaginaInicial()
        {           

            try
            {
                ModelState.Clear();

                return RedirectToAction("Index", "GerenciadorDeLeiloes");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return View();
        }

    }
}
