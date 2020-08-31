using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace VueAdmin.Log.Repositories
{
    /// <summary>
    /// ILogRepository
    /// </summary>
    public interface ILogRepository : IRepository<LogEntity, Guid>
    {
        Task AddAsync(LogEntity entity);
    }
}
