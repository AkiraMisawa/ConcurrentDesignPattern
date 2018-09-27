namespace GuardedSuspension
{
    public class Request
    {
        private string Name { get; }

        public Request(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"[ Request {Name} ]";
        }
    }
}