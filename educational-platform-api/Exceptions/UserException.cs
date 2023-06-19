namespace educational_platform_api.Exceptions
{
    public class UserException : BaseException
    {
        public UserException() { }

        public UserException(string message)
            : base(message) { }

        public UserException(string message, Exception inner)
            : base(message, inner) { }

        public UserException(string message, ExceptionSource source)
            : base(message, source) { }
    }
}
