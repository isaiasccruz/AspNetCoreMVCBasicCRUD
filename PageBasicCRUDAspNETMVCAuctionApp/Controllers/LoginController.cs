using System;
using Microsoft.AspNetCore.Mvc;
using BasicCRUDAspNETMVCAuctionApp.Models;
using Dominio.Interfaces.InjecaoDependencia;
using Infra.CrossCutting.IoC;
using Aplicacao.Interfaces;
using Microsoft.AspNetCore.Http;
using Infra.Utils.Infra.Utils;

namespace BasicCRUDAspNETMVCAuctionApp.Controllers
{
    public class LoginController : Controller
    {
        public static Dominio.Entidades.Usuario user;

        public static bool usuarioLogado = false;
        public static int idPerfilUsuario;

        void IniciarServicos()
        {
            IoC.Inicializar(InjetorDependencia.Instancia());
        }

        [HttpGet]
        public IActionResult Index()
        {

            IniciarServicos();

            LoginModel model = new LoginModel();
            return View(model);
        }

        [Route("Login")]
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Dados de Login Invalidos.";
                ModelState.Clear();
                return View("Index");
            }
            try
            {
                string senhaCript = Criptografia.Criptografar(model.Senha);

                user = IoC.Resolver<IUsuarioAppServico>().ObterPorLoginSenha(model.Usuario, senhaCript);

                if (user != null)
                {
                    HttpContext.Session.SetString("userId", user.Id.ToString());


                    user.Logado = true;
                    user.UltimaConexao = DateTime.Now;
                    IoC.Resolver<IUsuarioAppServico>().Atualizar(user);

                    usuarioLogado = true;
                    idPerfilUsuario = user.IdPerfil;

                    return RedirectToAction("PaginaInicial", "Home");
                }
                else
                {
                    ViewBag.ErrorMessage = "Dados de Login Invalidos.";
                    ModelState.Clear();
                    return View("Index");
                }

                
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return View();
        }

        [Route("Logout")]
        [HttpGet]
        public IActionResult Logout()
        {

            user.Logado = false;
            IoC.Resolver<IUsuarioAppServico>().Atualizar(user);

            HttpContext.Session.SetString("userId", "");

            usuarioLogado = false;

            return View("Index");

        }
    }
}
