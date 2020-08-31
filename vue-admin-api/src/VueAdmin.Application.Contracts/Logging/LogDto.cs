using System;

namespace VueAdmin.Log
{
    public class LogDto
    {
        public string Message { get; set; }
        public string Exception { get; set; }
        public string StackTrace { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
