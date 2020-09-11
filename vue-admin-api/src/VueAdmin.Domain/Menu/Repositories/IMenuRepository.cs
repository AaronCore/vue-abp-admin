﻿using System;
using Volo.Abp.Domain.Repositories;

namespace VueAdmin.Domain.Menu.Repositories
{
    /// <summary>
    /// IMenuRepository
    /// </summary>
    public interface IMenuRepository : IRepository<MenuEntity, Guid>
    {

    }
}
