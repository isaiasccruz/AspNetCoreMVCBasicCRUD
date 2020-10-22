using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Infra.Contexto.Interfaces;
using Infra.Repositorio.Dapper.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Dapper;
using DapperExtensions;
using Infra.Contexto;
using System.Data.SqlClient;
using System.Transactions;

namespace Infra.Repositorio.Dapper
{
    public class LeilaoRepositorio : Repositorio<Leilao>, ILeilaoRepositorio
    {
        public new IDbConnection Conn { get; set; }
        public new IDapperContexto Context { get; private set; }
        public IDbTransaction transaction { get; private set; }
        private readonly IUnitOfWork _uow;

        public LeilaoRepositorio(IDapperContexto context) : base(context)
        {
            _uow = new UnitOfWork(context);

            Context = context;
            Conn = context.Connection;
            InicializaMapperDapper();
        }        

        
    }
}
