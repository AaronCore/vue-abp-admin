﻿using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using VueAdmin.Domain.Menu;
using VueAdmin.Domain.Menu.Repositories;
using VueAdmin.EntityFrameworkCore.EntityFrameworkCore;

namespace VueAdmin.EntityFrameworkCore.Repositories.Menu
{
    public class MenuRepository : EfCoreRepository<VueAdminDbContext, MenuEntity, Guid>, IMenuRepository
    {
        public MenuRepository(IDbContextProvider<VueAdminDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}
