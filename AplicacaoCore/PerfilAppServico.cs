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
    public class PerfilAppServico : IPerfilAppServico
    {
        private IPerfilServico _servico;

        public IDapperContexto _dapperContext;
        public IUnitOfWork _uow;

        public PerfilAppServico(IPerfilServico perfilServico)
        {
            _servico = perfilServico;
        }

        //public void Adicionar(Perfil entity, IDapperContexto dapperContext)
        public Perfil Adicionar(Perfil entity)
        {
            //_dapperContext = dapperContext;
            //_uow = new UnitOfWork(_dapperContext);

            try
            {
                return _servico.Adicionar(entity, _uow.BeginTransaction());
                //_uow.Commit();
            }
            catch (Exception ex)
            {
                _uow.Rollback();
                throw ex;
            }
        }

        public void Atualizar(Perfil entity)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Perfil entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Perfil ObterPorId(int id)
        {
            return _servico.ObterPorId(id);
        }

        public IEnumerable<Perfil> ObterTodos()
        {
            return _servico.ObterTodos();
        }
    }
}
