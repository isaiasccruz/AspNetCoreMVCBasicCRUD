using System;
using System.Net;
using Aplicacao.Interfaces;
using BasicCRUDAspNETMVCAuctionApp.Models;
using Dominio.Entidades;
using Dominio.Interfaces.InjecaoDependencia;
using Infra.CrossCutting.IoC;
using Microsoft.AspNetCore.Mvc;

namespace BasicCRUDAspNETMVCAuctionApp.Controllers
{
    public class GerenciadorDeLeiloesController : CustomController
    {

        private void InicializarServicos()
        {
            IoC.Inicializar(InjetorDependencia.Instancia());
        }

        public ActionResult Index()
        {
            InicializarServicos();

            var leiloes = IoC.Resolver<ILeilaoAppServico>().ObterTodos();

            return View(leiloes);
        }

        public ActionResult Listar()
        {
            return View(new Leilao());
        }


        [Route("CriarNovoLeilao")]
        [HttpGet]
        public ActionResult CriarNovoLeilao()
        {
            LeilaoModel model = new LeilaoModel();
            try
            {

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return View(model);
        }


        [Route("CriarNovoLeilao")]
        [HttpPost]
        public ActionResult CriarNovoLeilao(LeilaoModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Dados de criação Invalidos.";
                ModelState.Clear();
                return View("CriarNovoLeilao");
            }
            try
            {
                Leilao entity = new Leilao();
                entity.IdUsuarioResponsavel = LoginController.user.Id;
                entity.NomeLeilao = model.NomeLeilao;
                entity.ValorInicial = model.ValorInicial;
                entity.EstadoDoItem = model.EstadoDoItem;
                entity.DataAbertura = model.DataAbertura;
                entity.DataFechamento = model.DataFechamento;
               
                var ret = IoC.Resolver<ILeilaoAppServico>().Adicionar(entity);

                if (ret != null)
                {
                    ViewBag.Message = "Sucesso!";

                    return RedirectToAction("PaginaInicial", "Home");
                }
                else
                {
                    ViewBag.ErrorMessage = "Dados de criacao Invalidos.";
                    ModelState.Clear();
                    return View("CriarNovoLeilao");
                }


            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return View("CriarNovoLeilao");
        }

        [Route("EditarLeilao")]
        [HttpGet]
        public ActionResult EditarLeilao(int id)
        {
            if (id == -1 || id == 0)
            {
                return new StatusCodeResult(400);
            }

            var leilao = IoC.Resolver<ILeilaoAppServico>().ObterPorId(id);
            LeilaoModel model = new LeilaoModel();

            if (leilao == null)
            {
                return new StatusCodeResult(404);
            }
            else
            {
                
                model.Id = leilao.Id;
                model.IdUsuarioResponsavel = leilao.IdUsuarioResponsavel;
                model.NomeLeilao = leilao.NomeLeilao;
                model.EstadoDoItem = leilao.EstadoDoItem;
                model.ValorInicial = leilao.ValorInicial;
                model.ValorFinal = leilao.ValorFinal;
                model.DataAbertura = leilao.DataAbertura;                
                model.DataFechamento = leilao.DataFechamento;
            }
            
            return View(model);
        }

        [Route("EditarLeilao")]
        [HttpPost]
        public ActionResult Editar(LeilaoModel model)
        {
            if (ModelState.IsValid)
            {
                
                if (model == null)
                {
                    return new StatusCodeResult(400);
                }
                else
                {                    
                    Leilao leilao = new Leilao();
                    leilao.Id = model.Id;
                    leilao.IdUsuarioResponsavel = model.IdUsuarioResponsavel;
                    leilao.NomeLeilao = model.NomeLeilao;
                    leilao.EstadoDoItem = model.EstadoDoItem;
                    leilao.ValorInicial = model.ValorInicial;
                    leilao.ValorFinal = model.ValorFinal;
                    leilao.DataAbertura = model.DataAbertura;
                    leilao.DataFechamento = model.DataFechamento;

                    if (model.DataFechamento != null)
                    {
                        if (model.DataAbertura < model.DataFechamento)
                        {
                            //ok
                            IoC.Resolver<ILeilaoAppServico>().Atualizar(leilao);

                            ViewBag.Message = "Sucesso!";
                        }
                        else
                        {
                            ViewBag.ErrorMessage = "Data de fechamento não pode ser inferior a data de abertura!";
                            ModelState.Clear();
                            return View("EditarLeilao", model);
                        }
                    }

                    
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Dados invalidos!";
                ModelState.Clear();
                return View("EditarLeilao", model);
            }

            return RedirectToAction("PaginaInicial", "Home");
        }


        [Route("DeletarLeilao")]
        [HttpGet]
        public ActionResult DeletarLeilao(int id)
        {
            if (id == -1 || id == 0)
            {
                return new StatusCodeResult(400);
            }

            var leilao = IoC.Resolver<ILeilaoAppServico>().ObterPorId(id);
            IoC.Resolver<ILeilaoAppServico>().Deletar(leilao);

            return RedirectToAction("PaginaInicial", "Home");
        }


    }

}