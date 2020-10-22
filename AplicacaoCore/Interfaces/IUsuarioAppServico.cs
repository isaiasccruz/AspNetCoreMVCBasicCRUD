using System.Data;
using Aplicacao.Interfaces.Comum;
using Dominio.Entidades;
using System.Collections.Generic;

namespace Aplicacao.Interfaces
{
    public interface IUsuarioAppServico : IAppServico<Usuario>
    {
        Usuario ObterPorLoginSenha(string login, string senha);
        IList<Usuario> ObterUsuariosPorParametros(string query, List<object> parametros);
    }
}
