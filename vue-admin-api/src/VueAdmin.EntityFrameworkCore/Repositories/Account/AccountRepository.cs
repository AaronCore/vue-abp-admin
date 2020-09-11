using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using VueAdmin.Domain.Account;
using VueAdmin.Domain.Account.Repositories;
using VueAdmin.EntityFrameworkCore.EntityFrameworkCore;

namespace VueAdmin.EntityFrameworkCore.Repositories.Account
{
    public class AccountRepository : EfCoreRepository<VueAdminDbContext, AccountEntity, Guid>, IAccountRepository
    {
        public AccountRepository(IDbContextProvider<VueAdminDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}
