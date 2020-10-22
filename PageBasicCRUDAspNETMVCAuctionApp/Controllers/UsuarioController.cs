using System;
using Microsoft.AspNetCore.Mvc;
using BasicCRUDAspNETMVCAuctionApp.Models;
using Dominio.Entidades;
using Aplicacao.Interfaces;
using Dominio.Interfaces.InjecaoDependencia;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Infra.Utils.Infra.Utils;

namespace BasicCRUDAspNETMVCAuctionApp.Controllers
{
    public class UsuarioController : Controller
    {


        [HttpGet]
        public IActionResult Index()
        {
            
            var model = IoC.Resolver<IUsuarioAppServico>().ObterTodos();
            

            return View(model);
        }

        [Route("CriarNovoUsuario")]
        [HttpGet]
        public ActionResult CriarNovoUsuario()
        {
            UsuarioModel model = new UsuarioModel();
            ViewBag.Perfil = new SelectList(IoC.Resolver<IPerfilAppServico>().ObterTodos().ToList(), "Id", "DescPerfil");
            return View(model);            
        }

        [Route("CriarNovoUsuario")]
        [HttpPost]
        public ActionResult CriarNovoUsuario(UsuarioModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Dados de criação Invalidos.";
                ModelState.Clear();
                return View("CriarNovoUsuario");
            }
            try
            {
                string senhaCript = Criptografia.Criptografar(model.Senha);

                Usuario entity = new Usuario();
                entity.IdPerfil = model.IdPerfil;
                entity.Nome = model.Nome;
                entity.Login = model.Login;
                entity.Senha = senhaCript;
                entity.Ativo = model.Ativo;

                var ret = IoC.Resolver<IUsuarioAppServico>().Adicionar(entity);

                if (ret != null)
                {
                    ViewBag.Message = "Sucesso!";

                    return RedirectToAction("Index", "Usuario");
                }
                else
                {
                    ViewBag.ErrorMessage = "Dados de criacao Invalidos.";
                    ModelState.Clear();
                    return View("CriarNovoUsuario");
                }


            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return View("CriarNovoUsuario");
        }

        [Route("EditarUsuario")]
        [HttpGet]
        public ActionResult EditarUsuario(int id)
        {
            if (id == -1 || id == 0)
            {
                return new StatusCodeResult(400);
            }

            var user = IoC.Resolver<IUsuarioAppServico>().ObterPorId(id);
            string senhaCript = Criptografia.Decriptografar(user.Senha);

            UsuarioModel model = new UsuarioModel();
            if (user == null)
            {
                return new StatusCodeResult(404);
            }
            else
            {
                
                model.Id = user.Id;
                model.IdPerfil = user.IdPerfil;
                model.Nome = user.Nome;
                model.Login = user.Login;
                model.Senha = senhaCript;
                model.Ativo = user.Ativo;
            }

            return View(model);
        }

        [Route("EditarUsuario")]
        [HttpPost]
        public ActionResult EditarUsuario(UsuarioModel model)
        {
            if (ModelState.IsValid)
            {

                if (model == null)
                {
                    return new StatusCodeResult(400);
                }
                else
                {

                    string senhaCript = Criptografia.Criptografar(model.Senha);

                    Usuario user = new Usuario();
                    user.Nome = model.Nome;
                    user.Login = model.Login;
                    user.Senha = senhaCript;
                    user.IdPerfil = model.IdPerfil;
                    user.Ativo = model.Ativo;


                    IoC.Resolver<IUsuarioAppServico>().Atualizar(user);
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Dados invalidos!";
                ModelState.Clear();
                return View("EditarUsuario", model);
            }

            return RedirectToAction("Index", "Usuario");
        }

        [Route("DeletarUsuario")]
        [HttpGet]
        public ActionResult DeletarUsuario(int id)
        {
            if (id == -1 || id == 0)
            {
                return new StatusCodeResult(400);
            }

            var usuario = IoC.Resolver<IUsuarioAppServico>().ObterPorId(id);
            string senhaCript = Criptografia.Criptografar(usuario.Senha);
            usuario.Senha = senhaCript;
            IoC.Resolver<IUsuarioAppServico>().Deletar(usuario);

            return RedirectToAction("Index", "Usuario");
        }

    }
}
