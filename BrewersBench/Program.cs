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
            OutputHandler oh = OutputHandler.GetOutputHandlerInstance();

            while (true)
            {
                oh.outputBrewersBenchGreeting();
                string selection = Console.ReadLine();
                if (selection == "view")
                {
                    Observer observer = new Observer();
                    ObserverClient oc = new ObserverClient(observer);
                    int oco = oc.ObserverClientMain();
                    if (oco < 0)
                    {
                        return;
                    }
                }
                if (selection == "stock")
                {
                    Stocker stocker = new Stocker();
                    StockerClient sc = new StockerClient(stocker);
                    int outcome = sc.StockerClientMain();
                    if (outcome < 0)
                    {
                        return;
                    }
                }
                if (selection == "brew")
                {
                    Brewer brewer = new Brewer();
                    BrewerClient bc = new BrewerClient(brewer);
                    int outcome = bc.BrewerClientMain();
                    if (outcome < 0)
                    {
                        return;
                    }
                }
            }
        }
    }
}
