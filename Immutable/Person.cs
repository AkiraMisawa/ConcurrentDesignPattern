namespace Immutable
{
    /// <summary>
    /// This class is immutable because all properties are set only in ctor.
    /// </summary>
    public class Person
    {
        public string Name { get; }
        public string Address { get;}

        public Person(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public override string ToString()
        {
            return $"[ Person: name = {Name}, address = {Address} ]";
        }
    }
}