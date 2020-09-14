using System;
using Volo.Abp.Domain.Repositories;

namespace VueAdmin.Domain.System.Repositories
{
    /// <summary>
    /// ILogRepository
    /// </summary>
    public interface ILogRepository : IRepository<LogEntity, Guid>
    {

    }
}
