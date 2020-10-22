using Dominio.Interfaces.Repositorio.Comum;
using Dominio.Interfaces.Servicos.Comum;
using System.Collections.Generic;
using System.Data;

namespace Dominio.Servicos.Comum
{
    public class Servico<TEntity> : IServico<TEntity> where TEntity : class
    {

        private readonly IRepositorio<TEntity> _repositorio;

        public Servico(IRepositorio<TEntity> repositorio)
        {
            _repositorio = repositorio;
        }


        public TEntity Adicionar(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = default(int?))
        {            
            return _repositorio.Adicionar(entity, transaction);           
        }

        public void Atualizar(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = default(int?))
        {
            _repositorio.Atualizar(entity, transaction);

        }

        public void Deletar(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = default(int?))
        {
            _repositorio.Deletar(entity, transaction);
        }

        public TEntity ObterPorId(int id)
        {
            return _repositorio.ObterPorId(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return _repositorio.ObterTodos();
        }
    }
}
