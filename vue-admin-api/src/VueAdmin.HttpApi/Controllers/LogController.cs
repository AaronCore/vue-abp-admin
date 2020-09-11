using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using VueAdmin.Application.Contracts.Logging;
using VueAdmin.Application.Logging;
using VueAdmin.Common.Base;
using VueAdmin.Domain.Shared;

namespace VueAdmin.HttpApi.Controllers
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

        /// <summary>
        /// 添加Log
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("addLog")]
        public async Task<ServiceResult> AddLogAsync([FromBody] LogInput input)
        {
            var result = await _logService.AddAsync(input);
            return result;
        }

        /// <summary>
        /// 获取Log
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("getLog")]
        public async Task<ServiceResult> GetLogAsync(string id)
        {
            var result = await _logService.GetLog(id);
            return result;
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="pageIndex">分页下标</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns></returns>
        [HttpGet]
        [Route("query")]
        public ServiceResult QueryList(int pageIndex, int pageSize)
        {
            var result = _logService.QueryList(pageIndex, pageSize);
            return result;
        }
    }
}