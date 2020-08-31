using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using VueAdmin.Common.Base;
using VueAdmin.Log;

namespace VueAdmin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = VueAdminConsts.Grouping.GroupName_v1)]
    public class LogController : AbpController
    {
        private readonly ILogService _logService;

        public LogController(ILogService logService)
        {
            _logService = logService;
        }

        [HttpPost]
        [Route("addLog")]
        public async Task<ServiceResult> AddLogAsync([FromBody] LogDto dto)
        {
            var result = await _logService.AddAsync(dto);
            return result;
        }
    }
}