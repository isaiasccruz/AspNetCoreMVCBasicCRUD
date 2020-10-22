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
    public class UsuarioAppServico : IUsuarioAppServico
    {
        private IUsuarioServico _servico;
        public IDapperContexto _dapperContext;
        //public IUnitOfWork _uow;
        //private readonly IUnitOfWork _uow;

        public UsuarioAppServico(IUsuarioServico servico)
        {
            _servico = servico;
        }

        public UsuarioAppServico()
        {
        }

        //public void Adicionar(Usuario entity, IDapperContexto dapperContext)
        public Usuario Adicionar(Usuario entity)
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

        public void Atualizar(Usuario entity)
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

        public void Deletar(Usuario entity)
        {
            _servico.Deletar(entity);

            //return ValidationResult;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Usuario ObterPorId(int id)
        {
            return _servico.ObterPorId(id);
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            return _servico.ObterTodos();
        }

        public Usuario ObterPorLoginSenha(string login, string senha)
        {
            return _servico.ObterPorLoginSenha(login, senha);
        }

        public IList<Usuario> ObterUsuariosPorParametros(string query, List<object> parametros)
        {
            try
            {
                var users = _servico.ObterUsuariosPorParametros(query, parametros);               
                MontaDetailEdicaoUsuario(ref users);

                return users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void MontaDetailEdicaoUsuario(ref IList<Usuario> users)
        {
            foreach (Usuario user in users)
            {
                user.Nome = "<a href='\\Usuario\\Details\\" + user.Id + "'>" + user.Nome;
            }
        }
     


    }
}
