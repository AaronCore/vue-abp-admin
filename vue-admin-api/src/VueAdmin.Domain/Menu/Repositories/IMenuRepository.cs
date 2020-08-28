using System;
using Volo.Abp.Domain.Repositories;

namespace VueAdmin.Menu.Repositories
{
    /// <summary>
    /// IMenuRepository
    /// </summary>
    public interface IMenuRepository : IRepository<MenuEntity, Guid>
    {
    }
}
