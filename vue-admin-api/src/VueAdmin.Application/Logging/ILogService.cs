using System.Threading.Tasks;
using VueAdmin.Common.Base;

namespace VueAdmin.Log
{
    public interface ILogService
    {
        Task<ServiceResult> AddAsync(LogDto dto);
    }
}
