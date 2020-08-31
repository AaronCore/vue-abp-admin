using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using VueAdmin.EntityFrameworkCore;
using VueAdmin.Log;
using VueAdmin.Log.Repositories;

namespace VueAdmin.Repositories.Log
{
    public class LogRepository : EfCoreRepository<VueAdminDbContext, LogEntity, Guid>, ILogRepository
    {
        public LogRepository(IDbContextProvider<VueAdminDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddAsync(LogEntity entity)
        {
            await DbContext.Set<LogEntity>().AddRangeAsync(entity);
            await DbContext.SaveChangesAsync();
        }
    }
}
