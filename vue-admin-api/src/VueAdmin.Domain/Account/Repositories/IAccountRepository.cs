using System;
using Volo.Abp.Domain.Repositories;

namespace VueAdmin.Account.Repositories
{
    /// <summary>
    /// IAccountRepository
    /// </summary>
    public interface IAccountRepository : IRepository<AccountEntity, Guid>
    {

    }
}