using System;
using System.Collections.Generic;
using System.Text;

namespace TGWAppp
{
    class Worker
    {

        public int destinationCount;
        public bool isRandom;
        public int consecutiveLoads;
        public int failurePercentage;
        public int loadCount;
        public String result;


        private int loadModulus;
        private Random random = new Random();


        private List<Destination> destinationList = new List<Destination>();

        public void Work()
        {
            CreateDestinations();

            loadModulus = loadCount % consecutiveLoads;
            loadCount -= loadModulus;

            if (isRandom)
            {
                DoRandomSelection();
            } else
            {
                DoRobinSelection();
            }

            BuildResultString();
        }

        private void CreateDestinations()
        {
            for (int i = 0; i <= destinationCount; i++)
            {
                destinationList.Add(new Destination(i));
            }
        } 
        
        private void BuildResultString()
        {
            StringBuilder sb = new StringBuilder();
   
            destinationList.ForEach(d => sb.AppendFormat("Destination No. {0}, Successfull loads: {1}, Successfull load percentage: {2:N2}% \n", d.id, d.successfullLoads, d.loadPercentage));

            result = sb.ToString();
        }


        private void DoRobinSelection()
        {

            int destinationId = 1;

            for (int i = 1; i < loadCount; i += consecutiveLoads)
            {
                Destination destination = destinationList[destinationId];

                LoadToDestination(destination, consecutiveLoads);

                destinationId = ( destinationId == destinationList.Count-1 ) ? 1 : ++destinationId;
            }

            if (loadModulus > 0) LoadToDestination(destinationList[destinationId], loadModulus);
        }

        private void DoRandomSelection()
        {

            for (int i = 1; i < loadCount; i += consecutiveLoads)
            {
                Destination destination = destinationList[random.Next(1,destinationList.Count)];

                LoadToDestination(destination, consecutiveLoads);

            }

            if (loadModulus > 0) LoadToDestination(destinationList[random.Next(1, destinationList.Count)], loadModulus);

        }


        private void LoadToDestination(Destination destination, int loadCount)
        {
            Destination failedLoadDestination = destinationList[0];

            destination.loads += loadCount;

            for (int o = 0; o < loadCount; o++)
            {

                if (random.NextDouble() >= (double)failurePercentage / 100)
                {
                    ++destination.successfullLoads;
                }
                else
                {
                    ++failedLoadDestination.successfullLoads;
                }

            }
        }
    }
}
