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

namespace Infra.Repositorio.Dapper
{
    public class PerfilRepositorio : Repositorio<Perfil>, IPerfilRepositorio
    {
        public new IDbConnection Conn { get; set; }
        public new IDapperContexto Context { get; private set; }

        public PerfilRepositorio(IDapperContexto context) : base(context)
        {
            Context = context;
            Conn = context.Connection;
            InicializaMapperDapper();
        }
    }
}
