using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using VueAdmin.EntityFrameworkCore;
using VueAdmin.Role;
using VueAdmin.Role.Repositories;

namespace VueAdmin.Repositories.Role
{
    public class RoleMenuRepository : EfCoreRepository<VueAdminDbContext, RoleMenuEntity, Guid>, IRoleMenuRepository
    {
        public RoleMenuRepository(IDbContextProvider<VueAdminDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}
