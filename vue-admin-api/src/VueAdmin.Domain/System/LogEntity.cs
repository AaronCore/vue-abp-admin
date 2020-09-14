using System;
using Volo.Abp.Domain.Entities;

namespace VueAdmin.Domain.System
{
    public class LogEntity : Entity<Guid>
    {
        public string Message { get; set; }
        public string Exception { get; set; }
        public string StackTrace { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
