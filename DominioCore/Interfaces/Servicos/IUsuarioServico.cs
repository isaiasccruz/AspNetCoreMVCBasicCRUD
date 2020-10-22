using Dominio.Entidades;
using Dominio.Interfaces.Servicos.Comum;
using System.Collections.Generic;
using System.Data;

namespace Dominio.Interfaces.Servicos
{
    public interface IUsuarioServico:IServico<Usuario>
    {
        Usuario ObterPorLoginSenha(string login, string senha);
        IList<Usuario> ObterUsuariosPorParametros(string query, List<object> parametros);
    }
}
