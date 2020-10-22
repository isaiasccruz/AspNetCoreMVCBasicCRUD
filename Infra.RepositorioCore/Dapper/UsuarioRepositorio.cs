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
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
        public new IDbConnection Conn { get; set; }
        public new IDapperContexto Context { get; private set; }
        public IDbTransaction transaction { get; private set; }
        private readonly IUnitOfWork _uow;
        Usuario _usuario;

        public UsuarioRepositorio(IDapperContexto context) : base(context)
        {
            _uow = new UnitOfWork(context);

            Context = context;
            Conn = context.Connection;
            InicializaMapperDapper();
        }

        public Usuario ObterPorLoginSenha(string login, string senha)
        {
            var usuario = new Usuario();
            return usuario = Conn.Query<Usuario>("SELECT * FROM tUsuario WHERE Login = @Login AND Senha = @Senha", new { login, senha }).FirstOrDefault();
        }

        public IList<Usuario> ObterUsuariosPorParametros(string query, List<object> parametros)
        {
            try
            {
                List<Usuario> listaUsuarios = new List<Usuario>();

                foreach (SqlParameter parametro in parametros)
                {
                    query = query.Replace(Convert.ToString(parametro.ParameterName), "'" + Convert.ToString(parametro.SqlValue) + "'");
                }                

                return listaUsuarios = Conn.Query<Usuario>("SELECT * FROM tUsuario " + query + "ORDER BY Nome").ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Usuario PersistirUsuarioSegmento(Usuario usuario, int idSegmento, IDbTransaction transaction = null, int? commandTimeout = default(int?))
        {
            try
            {
                Conn.Insert(usuario, _uow.BeginTransaction(), commandTimeout);//insere no banco normal
                _uow.Commit();
                int id = usuario.Id;
                _usuario = usuario;
                
                return _usuario;
            }
            catch (Exception ex)
            {
                _uow.Rollback();
                throw ex;
            }
        }

        public Usuario AtualizarUsuarioSegmento(Usuario usuario, Usuario usuarioAntigo, int idSegmento, IDbTransaction transaction = null, int? commandTimeout = default(int?))
        {
            try
            {
                                
                Conn.Update(usuario, _uow.BeginTransaction(), commandTimeout);//insere no banco normal
                _uow.Commit();
                _usuario = usuario;
                                                    
            }
            catch(Exception ex)
            { throw ex; }

            return _usuario;
        }

        
    }
}
