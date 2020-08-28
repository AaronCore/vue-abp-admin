using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using VueAdmin.Account;
using VueAdmin.Account.Repositories;
using VueAdmin.EntityFrameworkCore;

namespace VueAdmin.Repositories.Account
{
    public class AccountRepository : EfCoreRepository<VueAdminDbContext, AccountEntity, Guid>, IAccountRepository
    {
        public AccountRepository(IDbContextProvider<VueAdminDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}
