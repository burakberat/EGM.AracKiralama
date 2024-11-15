namespace Infrastructure.Exceptions
{
    public class TimeException : Exception
    {
        public TimeException(string message) : base(message)
        {
            ErrorCode = 320;
        }
        public int ErrorCode { get; }
    }
}
