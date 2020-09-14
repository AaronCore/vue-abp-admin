using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using VueAdmin.Domain.System;
using VueAdmin.Domain.System.Repositories;
using VueAdmin.EntityFrameworkCore.EntityFrameworkCore;

namespace VueAdmin.EntityFrameworkCore.Repositories.Logging
{
    public class LogRepository : EfCoreRepository<VueAdminDbContext, LogEntity, Guid>, ILogRepository
    {
        public LogRepository(IDbContextProvider<VueAdminDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}
