using Dominio.Entidades;
using Dominio.Interfaces.Repositorio.Comum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace Dominio.Interfaces.Repositorio
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        Usuario ObterPorLoginSenha(string login, string senha);
        Usuario PersistirUsuarioSegmento(Usuario usuario, int idSegmento, IDbTransaction transaction = null, int? commandTimeout = default(int?));
        Usuario AtualizarUsuarioSegmento(Usuario usuario, Usuario usuarioAntigo, int idSegmento, IDbTransaction transaction = null, int? commandTimeout = null);
        IList<Usuario> ObterUsuariosPorParametros(string query, List<object> parametros);
        
        
    }
}
