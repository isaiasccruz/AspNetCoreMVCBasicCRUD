using System.Collections.Generic;
using System.Data;

namespace Dominio.Interfaces.Servicos.Comum
{
    public interface IServico<TEntity> where TEntity : class
    {
        TEntity Adicionar(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null);
        void Atualizar(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null);
        void Deletar(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null);
        TEntity ObterPorId(int id);
        IEnumerable<TEntity> ObterTodos();
    }
}
