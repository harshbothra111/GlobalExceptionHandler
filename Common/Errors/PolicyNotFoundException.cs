namespace Errors
{
    public class PolicyNotFoundException : Exception
    {
        public PolicyNotFoundException() : base () { }
        public PolicyNotFoundException(string message) : base(message) { }
    }
}