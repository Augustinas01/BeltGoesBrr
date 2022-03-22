using System;
using System.Collections.Generic;
using System.Text;

namespace TGWAppp
{
    class Destination
    {

        public int id;
        public int loads;
        public int successfullLoads;

        public double loadPercentage { 
            get
            {
                return id == 0 ? 100 : (double)successfullLoads / loads * 100;
            }
        }

        public Destination(int id)
        {
            this.id = id;
        }


    }
}
