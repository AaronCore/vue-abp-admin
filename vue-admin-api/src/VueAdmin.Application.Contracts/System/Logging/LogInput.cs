namespace VueAdmin.Application.Contracts.System.Logging
{
    public class LogInput
    {
        public string Message { get; set; }
        public string Exception { get; set; }
        public string StackTrace { get; set; }
    }
}
