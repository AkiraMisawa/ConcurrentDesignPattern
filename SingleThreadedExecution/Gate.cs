using System;
using System.Threading;
using System.Linq;


namespace SingleThreadedExecution
{
    /// <summary>
    /// Shared resource.
    /// </summary>
    class Gate
    {
        /// <summary>
        /// The number of people who passed this gate.
        /// </summary>
        private int Counter { get; set; } = 0;

        /// <summary>
        /// The name of the last person who passed this gate.
        /// </summary>
        private string Name { get; set; } = "Nobody";

        /// <summary>
        /// The address of the last person who passed this gate.
        /// </summary>
        private string Address { get; set; } = "NoWhere";

        private static object lockObject = new object();

        /// <summary>
        /// To record: 
        ///     - the number of person
        ///     - the name of the last person
        ///     - the address of the last person
        /// who passed this gate.
        /// </summary>
        /// <param name="name">The name of the person who passes this gate.</param>
        /// <param name="address">The address of the person who passes this gate.</param>
        public void Pass(string name, string address)
        {
            lock (lockObject) 
            {
                Counter++;
                Name = name;
                Address = address;
                Check();
            }
        }

        public override string ToString()
        {
            lock (lockObject)
            {
                return $"No. {Counter.ToString()}: {Name}, {Address}";
            }
        }

        private void Check()
        {
            if (Name.First() != Address.First())
            {
                Console.WriteLine("***** BROKEN *****" + ToString());
            }
        }
    }
}