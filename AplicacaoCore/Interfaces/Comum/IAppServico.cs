using Infra.Contexto.Interfaces;
using System;
using System.Collections.Generic;

namespace Aplicacao.Interfaces.Comum
{
    public interface IAppServico<TEntity> : IDisposable where TEntity : class
    {
        TEntity ObterPorId(int id);
        IEnumerable<TEntity> ObterTodos();
        //void Adicionar(TEntity entity, IDapperContexto dapperContext);
        TEntity Adicionar(TEntity entity);
        void Atualizar(TEntity entity);
        void Deletar(TEntity entity);        
    }
}
