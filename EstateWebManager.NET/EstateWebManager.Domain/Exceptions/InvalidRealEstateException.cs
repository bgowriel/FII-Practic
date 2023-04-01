namespace EstateWebManager.Domain.Exceptions
{
    public class InvalidRealEstateException : Exception
    {
        public string message = "Real estate data is not valid";

        public InvalidRealEstateException() : base("Real estate data is not valid") {}

        public InvalidRealEstateException(string message) : base(message) {}
    }
}
