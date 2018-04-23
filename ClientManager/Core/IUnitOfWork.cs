using ClientManager.Core.Repositories;
using System;

namespace ClientManager.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonRepository People { get; }
        IReportRepository Reports { get; }
        int Complete();

    }
}
