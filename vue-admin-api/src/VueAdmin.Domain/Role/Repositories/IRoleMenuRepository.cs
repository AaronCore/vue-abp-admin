using System;
using Volo.Abp.Domain.Repositories;

namespace VueAdmin.Domain.Role.Repositories
{
    /// <summary>
    /// IRoleMenuRepository
    /// </summary>
    public interface IRoleMenuRepository : IRepository<RoleMenuEntity, Guid>
    {
    }
}
