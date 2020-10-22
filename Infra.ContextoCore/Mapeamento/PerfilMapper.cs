using DapperExtensions.Mapper;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra.Contexto.Mapeamento
{
    public class PerfilMapper : ClassMapper<Perfil>
    {
        public PerfilMapper()
        {
            Table("tPerfil");

            Map(p => p.Id).Column("Id").Key(KeyType.Identity);
            Map(p => p.DescPerfil).Column("DescPerfil");
        }

    }
}
