using System;
using NUnitLite;
using Swaglab.NunitTest;

namespace Swaglab
{
    public class Swaglab
    {
        public static void Main(string[] args)
        {
            new AutoRun(typeof(Swaglabtests).Assembly).Execute(args);

            Console.ReadKey();
        }
    }
}
