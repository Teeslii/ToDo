namespace WebApi.Services
{
    public class ConsolLogger : ILoggerService
    {
        public void Write(string message)
        {
           Console.WriteLine("[ConsoleLogger] - "+ message);
        }
    }
}
