using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Interfaces.InjecaoDependencia
{
    public interface IInjetorDependencia
    {
        T Resolver<T>();
        T Resolver<T>(Type type);
    }
}
