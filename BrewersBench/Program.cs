using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewersBench
{
    class BrewersBenchMain
    {
        static void Main(string[] args)
        {
            OutputHandler oh = OutputHandler.GetDialogueHandlerInstance();

            while (true)
            {
                oh.outputBrewersBenchGreeting();
                string selection = Console.ReadLine();
                if (selection == "count")
                {
                    Stocker counter = new Stocker();
                    Console.WriteLine(counter.fetchStockedVesselCount());
                    continue;
                }

                // If Stock is seleted: 
                Stocker stocker = new Stocker();
                StockerClient sc = new StockerClient(stocker);
                int outcome = sc.StockerClientMain();
                if (outcome < 0)
                {
                    return;
                }
            }
        }
    }
}
