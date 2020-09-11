using System;
using Volo.Abp.Domain.Repositories;

namespace VueAdmin.Domain.Account.Repositories
{
    /// <summary>
    /// IAccountRepository
    /// </summary>
    public interface IAccountRepository : IRepository<AccountEntity, Guid>
    {

    }
}