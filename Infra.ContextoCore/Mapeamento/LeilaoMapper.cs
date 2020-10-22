using DapperExtensions.Mapper;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra.Contexto.Mapeamento
{
    public class LeilaoMapper : ClassMapper<Leilao>
    {
        public LeilaoMapper()
        {
            Table("tLeilao");

            Map(l => l.Id).Column("Id").Key(KeyType.Identity);
            Map(l => l.IdUsuarioResponsavel).Column("IdUsuarioResponsavel");
            Map(l => l.NomeLeilao).Column("NomeLeilao");
            Map(l => l.ValorInicial).Column("ValorInicial");
            Map(l => l.ValorFinal).Column("ValorFinal");
            Map(l => l.EstadoDoItem).Column("EstadoDoItem");
            Map(l => l.DataAbertura).Column("DataAbertura");
            Map(l => l.DataFechamento).Column("DataFechamento");
        }

    }
}
