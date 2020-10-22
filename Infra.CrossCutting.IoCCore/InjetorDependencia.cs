using Aplicacao;
using Aplicacao.Interfaces;
using Dominio.Interfaces.InjecaoDependencia;
using Dominio.Interfaces.Repositorio;
using Dominio.Interfaces.Servicos;
using Dominio.Servicos;
using Infra.Contexto;
using Infra.Contexto.Interfaces;
using Infra.Repositorio.Dapper;
using Unity;
using System;

namespace Infra.CrossCutting.IoC
{
    public class InjetorDependencia : IInjetorDependencia
    {
        private readonly IUnityContainer _container;

        private static InjetorDependencia _injetorDependencia;

        private InjetorDependencia()
        {
            _container = new UnityContainer();
            MapearDependencias();
        }

        public static InjetorDependencia Instancia()
        {
            return _injetorDependencia ?? (_injetorDependencia = new InjetorDependencia());
        }

        public T Resolver<T>()
        {
            return _container.Resolve<T>();
        }

        public T Resolver<T>(Type type)
        {
            return (T)_container.Resolve(type);
        }

        private void MapearDependencias()
        {
            _container
                .RegisterType<IDapperContexto, DapperContexto>()
                .RegisterType<IUnitOfWork, UnitOfWork>()

                .RegisterType<IUsuarioRepositorio, UsuarioRepositorio>()
                .RegisterType<IUsuarioServico, UsuarioServico>()
                .RegisterType<IUsuarioAppServico, UsuarioAppServico>()

                .RegisterType<IPerfilRepositorio, PerfilRepositorio>()
                .RegisterType<IPerfilServico, PerfilServico>()
                .RegisterType<IPerfilAppServico, PerfilAppServico>()

                .RegisterType<ILeilaoRepositorio, LeilaoRepositorio>()
                .RegisterType<ILeilaoServico, LeilaoServico>()
                .RegisterType<ILeilaoAppServico, LeilaoAppServico>()


                ;
        }
    }
}
