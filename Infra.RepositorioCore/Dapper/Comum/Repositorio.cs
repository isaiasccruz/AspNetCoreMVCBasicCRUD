using DapperExtensions;
using Dominio.Interfaces.InjecaoDependencia;
using Dominio.Interfaces.Repositorio.Comum;
using Infra.Contexto;
using Infra.Contexto.Interfaces;
using Infra.Contexto.Mapeamento;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Infra.Repositorio.Dapper.Comum
{
    public class Repositorio<TEntity> : IRepositorio<TEntity>, IDisposable where TEntity : class
    {
        public IDbConnection Conn { get; set; }
        public IDapperContexto Context { get; private set; }

        private readonly IUnitOfWork _uow;

        public Repositorio(IDapperContexto context)
        {
            _uow = new UnitOfWork(context);
            Context = context;
            Conn = context.Connection;
            InicializaMapperDapper();
        }

        public static void InicializaMapperDapper()
        {
            DapperExtensions.DapperExtensions.SetMappingAssemblies(new[] { typeof(UsuarioMapper).Assembly });
        }

        public TEntity Adicionar(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            try
            {               
                Conn.Insert(entity, _uow.BeginTransaction(), commandTimeout);

                _uow.Commit();

                return entity;
            }
            catch (Exception ex)
            {
                _uow.Rollback();
                throw ex;
            }
            
        }

        public void Atualizar(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            Conn.Update(entity, transaction, commandTimeout);
        }

        public void Deletar(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            Conn.Delete(entity, transaction, commandTimeout);
        }

        public TEntity ObterPorId(int id)
        {
            return Conn.Get<TEntity>(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return Conn.GetList<TEntity>();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
