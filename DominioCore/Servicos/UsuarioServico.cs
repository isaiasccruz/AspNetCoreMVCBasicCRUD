using Dominio.Entidades;
using Dominio.Interfaces.Servicos;
using Dominio.Servicos.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Interfaces.Repositorio.Comum;
using Dominio.Interfaces.Repositorio;
using System.Data;

namespace Dominio.Servicos
{
    public class UsuarioServico : Servico<Usuario>, IUsuarioServico
    {

        private readonly IUsuarioRepositorio _repositorio;

        public UsuarioServico(IUsuarioRepositorio repositorio) : base(repositorio)
        {
            _repositorio = repositorio;
        }
        public Usuario ObterPorLoginSenha(string login, string senha)
        {
            return _repositorio.ObterPorLoginSenha(login, senha);
        }
        public IList<Usuario> ObterUsuariosPorParametros(string query, List<object> parametros)
        {
            return _repositorio.ObterUsuariosPorParametros(query, parametros);
        }
    }
}
