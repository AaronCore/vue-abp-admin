using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VueAdmin.Common.Base;
using VueAdmin.Log.Repositories;

namespace VueAdmin.Log
{
    public class LogService : VueAdminApplicationService, ILogService
    {
        private readonly ILogRepository _logRepository;

        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }
        public async Task<ServiceResult> AddAsync(LogDto dto)
        {
            var result = new ServiceResult();

            var entity = new LogEntity()
            {
                CreateTime = DateTime.Now
            };
            await _logRepository.AddAsync(entity);

            return result;
        }
    }
}
