using System;
using Volo.Abp.Domain.Repositories;

namespace VueAdmin.Role.Repositories
{
    /// <summary>
    /// IRoleRepository
    /// </summary>
    public interface IRoleRepository : IRepository<RoleEntity, Guid>
    {
    }
}
