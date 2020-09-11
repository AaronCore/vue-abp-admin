using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using VueAdmin.Domain.Role;
using VueAdmin.Domain.Role.Repositories;
using VueAdmin.EntityFrameworkCore.EntityFrameworkCore;

namespace VueAdmin.EntityFrameworkCore.Repositories.Role
{
    public class RoleRepository : EfCoreRepository<VueAdminDbContext, RoleEntity, Guid>, IRoleRepository
    {
        public RoleRepository(IDbContextProvider<VueAdminDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}
