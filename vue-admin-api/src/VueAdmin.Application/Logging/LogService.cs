using System;
using System.Linq;
using System.Threading.Tasks;
using VueAdmin.Application.Contracts.Logging;
using VueAdmin.Common.Base;
using VueAdmin.Common.Extensions;
using VueAdmin.Domain.Logging;
using VueAdmin.Domain.Logging.Repositories;

namespace VueAdmin.Application.Logging
{
    public class LogService : VueAdminApplicationService, ILogService
    {
        private readonly ILogRepository _logRepository;

        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ServiceResult> AddAsync(LogInput input)
        {
            var result = new ServiceResult();

            var entity = ObjectMapper.Map<LogInput, LogEntity>(input);
            entity.CreateTime = DateTime.Now;

            await _logRepository.InsertAsync(entity, true);

            result.IsSuccess();
            return result;
        }

        /// <summary>
        /// 获取Log信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ServiceResult<LogOut>> GetLog(string id)
        {
            var result = new ServiceResult<LogOut>();

            var log = await _logRepository.GetAsync(p => p.Id.ToString() == id);
            var logOut = ObjectMapper.Map<LogEntity, LogOut>(log);

            result.IsSuccess(logOut);
            return result;
        }

        public ServiceResult<PagedList<LogOut>> QueryList(int pageIndex, int pageSize)
        {
            var result = new ServiceResult<PagedList<LogOut>>();

            var list = _logRepository.OrderByDescending(p => p.CreateTime).PageByIndex(pageIndex, pageSize).Select(p => new LogOut
            {
                Id = p.Id.ToString(),

            }).ToList();


            result.IsSuccess(new PagedList<LogOut>(1, null));
            return result;
        }
    }
}
