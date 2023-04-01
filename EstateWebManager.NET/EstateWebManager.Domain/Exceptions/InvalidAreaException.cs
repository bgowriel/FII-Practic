namespace EstateWebManager.Domain.Exceptions
{
    public class InvalidAreaException : Exception
    {
        public InvalidAreaException() : base("Area is not valid") {}

        public InvalidAreaException(string message) : base(message) {}
    }
}
