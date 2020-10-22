using Dominio.Entidades;
using Dominio.Interfaces.Servicos;
using Dominio.Servicos.Comum;
using Dominio.Interfaces.Repositorio;

namespace Dominio.Servicos
{
    public class PerfilServico : Servico<Perfil>, IPerfilServico
    {
        private readonly IPerfilRepositorio _repositorio;

        public PerfilServico(IPerfilRepositorio perfilRepositorio) : base(perfilRepositorio)
        {
            _repositorio = perfilRepositorio;
        }
    }
}
