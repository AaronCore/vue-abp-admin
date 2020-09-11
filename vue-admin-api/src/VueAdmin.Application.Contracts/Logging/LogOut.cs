using System;

namespace VueAdmin.Application.Contracts.Logging
{
    public class LogOut
    {
        public string Id { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public string StackTrace { get; set; }
        public string CreateTime { get; set; }
    }
}
