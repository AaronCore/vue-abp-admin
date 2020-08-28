using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using VueAdmin.Log;

namespace VueAdmin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : AbpController
    {
        private readonly ILogService _logService;

        public LogController(ILogService logService)
        {
            _logService = logService;
        }

        [HttpPost]
        [Route("addLog")]
        public async Task<string> AddLogAsync([FromBody] LogDto dto)
        {
            await _logService.AddAsync(dto);
            return "ok";
        }
    }
}