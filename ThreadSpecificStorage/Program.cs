namespace ThreadSpecificStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            new ClientThread("Alice").Start();
            new ClientThread("Bobby").Start();
            new ClientThread("Chris").Start();
        }
    }
}
