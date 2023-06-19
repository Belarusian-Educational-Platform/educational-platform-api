namespace educational_platform_api.Exceptions
{
    public enum ExceptionSource
    {
        USER,
        GROUP,
        SUBGROUP,
        ORGANIZATION,
        GLOBAL
    }

    public class BaseException : Exception
    {
        public ExceptionSource source { get; set; }

        public BaseException() { }

        public BaseException(string message)
            : base(message) { }

        public BaseException(string message, Exception inner)
            : base(message, inner) { }

        public BaseException(string message, ExceptionSource source) 
            : base(message) 
        {
            this.source = source;
        }
    }
}
