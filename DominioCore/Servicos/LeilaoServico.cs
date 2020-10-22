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
    public class LeilaoServico : Servico<Leilao>, ILeilaoServico
    {

        private readonly ILeilaoRepositorio _repositorio;

        public LeilaoServico(ILeilaoRepositorio repositorio) : base(repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
