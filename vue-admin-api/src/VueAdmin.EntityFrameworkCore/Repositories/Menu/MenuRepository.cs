using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using VueAdmin.EntityFrameworkCore;
using VueAdmin.Menu;
using VueAdmin.Menu.Repositories;

namespace VueAdmin.Repositories.Menu
{
    public class MenuRepository : EfCoreRepository<VueAdminDbContext, MenuEntity, Guid>, IMenuRepository
    {
        public MenuRepository(IDbContextProvider<VueAdminDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}
