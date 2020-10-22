using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Dominio.Interfaces.Repositorio.Comum
{
    public interface IRepositorio<TEntity> where TEntity : class
    {
        TEntity Adicionar(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null);
        void Atualizar(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null);
        void Deletar(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null);
        TEntity ObterPorId(int id);
        IEnumerable<TEntity> ObterTodos();
    }
}
