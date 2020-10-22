using DapperExtensions.Mapper;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra.Contexto.Mapeamento
{
    public class UsuarioMapper : ClassMapper<Usuario>
    {
        public UsuarioMapper()
        {
            Table("tUsuario");

            Map(u => u.Id).Column("Id").Key(KeyType.Identity);
            Map(u => u.Nome).Column("Nome");
            Map(u => u.Login).Column("Login");
            Map(u => u.Senha).Column("Senha");
            Map(u => u.IdPerfil).Column("IdPerfil");
            Map(u => u.Ativo).Column("Ativo");
            Map(u => u.Logado).Column("Logado");
            Map(u => u.UltimaConexao).Column("UltimaConexao");

        }
    }
}
