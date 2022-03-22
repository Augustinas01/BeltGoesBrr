using System;
using System.Collections.Generic;
using System.Text;

namespace TGWAppp
{
    class App
    {


        public void Start()
        {
            while (true)
            {
                Worker worker = new Worker();

                ReadInput(worker);

                worker.Work();

                Console.WriteLine(worker.result);
            }
        }


        private void ReadInput(Worker worker)
        {
            Console.WriteLine("Please input number of destinations");
            worker.destinationCount = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Set destination selection strategy.");
            Console.WriteLine("1. Round robin.");
            Console.WriteLine("2. Random.");
            worker.isRandom = Console.ReadLine() == "2";

            Console.WriteLine("Enter number for consecutive loads");
            worker.consecutiveLoads = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter percentage of failure for destination(0-100)");
            worker.failurePercentage = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter number of loads");
            worker.loadCount = Int32.Parse(Console.ReadLine());
        }



    }
}
