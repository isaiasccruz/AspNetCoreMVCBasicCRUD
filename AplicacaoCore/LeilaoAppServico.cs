using Aplicacao.Interfaces;
using System;
using System.Collections.Generic;
using Dominio.Entidades;
using Dominio.Interfaces.Servicos;
using Infra.Contexto.Interfaces;
using Infra.Contexto;
using Dominio.Interfaces.InjecaoDependencia;
using Dominio.Servicos;

namespace Aplicacao
{
    public class LeilaoAppServico : ILeilaoAppServico
    {
        private ILeilaoServico _servico;
        public IDapperContexto _dapperContext;
        //private readonly IUnitOfWork _uow;

        public LeilaoAppServico(ILeilaoServico servico)
        {
            _servico = servico;
        }

        public LeilaoAppServico()
        {
        }

        //public void Adicionar(Usuario entity, IDapperContexto dapperContext)
        public Leilao Adicionar(Leilao entity)
        {
            try
            {
                //_servico.Adicionar(entity, _uow.BeginTransaction());
                return _servico.Adicionar(entity);
                //_uow.Commit();
            }
            catch (Exception ex)
            {
                //_uow.Rollback();
                throw ex;

            }
        }

        public void Atualizar(Leilao entity)
        {
            try
            {
                _servico.Atualizar(entity);
            }
            catch (Exception ex)
            {
                //_uow.Rollback();
                throw ex;
            }


            //return ValidationResult;
        }

        public void Deletar(Leilao entity)
        {
            _servico.Deletar(entity);

            //return ValidationResult;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Leilao ObterPorId(int id)
        {
            return _servico.ObterPorId(id);
        }

        public IEnumerable<Leilao> ObterTodos()
        {
            return _servico.ObterTodos();
        }   
     


    }
}
