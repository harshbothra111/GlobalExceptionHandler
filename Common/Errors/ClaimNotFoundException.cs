namespace Errors
{
    public class ClaimNotFoundException : Exception
    {
        public ClaimNotFoundException() : base () { }
        public ClaimNotFoundException(string message) : base(message) { }
    }
}