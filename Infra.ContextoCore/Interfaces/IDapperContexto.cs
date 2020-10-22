using System;
using System.Data;

namespace Infra.Contexto.Interfaces
{
    public interface IDapperContexto : IDisposable
    {
        IDbConnection Connection { get; }
    }
}
