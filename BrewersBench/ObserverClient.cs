using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewersBench
{
    /// <summary>
    /// Client that allows an observer to browse the Bench's current Stock. 
    /// </summary>
    class ObserverClient
    {
        private const string VESSELS = "vessels";
        private const string BASES = "bases";
        private const string INGREDIENTS = "ingredients";
        private const string POTIONS = "potions";
        private const string BACK = "back";

        private BenchUser observer;
        private OutputHandler oh;

        /// <summary>
        /// Standard Constructor for an Observer Client.
        /// </summary>
        /// <param name="observer"></param>
        public ObserverClient(BenchUser observer)
        {
            this.observer = observer;
            oh = OutputHandler.GetOutputHandlerInstance();
        }

        /// <summary>
        /// Main ObserverClient application loop.
        /// </summary>
        public int ObserverClientMain()
        {
            string input = "";
            while(true)
            {
                oh.outputStandardObserverMessage();
                input = Console.ReadLine().ToLower();
                int outcome = handleObserverInput(input);  
                if (outcome == 0)
                {
                    return 1;
                }
                if (outcome < 0)
                {
                    oh.outputObserverError(outcome);
                    return outcome;
                }
            }
        }

        /// <summary>
        /// Determines how to handle the Observer's input.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public int handleObserverInput(string input)
        {
            switch (input)
            {
                case VESSELS:
                    return handleFetchVessels();
                case BASES:
                    return handleFetchBases();
                case INGREDIENTS:
                    return handleFetchIngredients();
                case POTIONS:
                    return handleFetchPotions();
                case BACK:
                    return handleBack();
                default:
                    oh.outputStandardObserverInvalidInputMessage();
                    return 1;
            }
        }

        /// <summary>
        /// Handles the "vessels" user input.
        /// </summary>
        /// <returns></returns>
        public int handleFetchVessels()
        {
            oh.outputVessels(observer.fetchStockedVessels());
            return 1;
        }

        /// <summary>
        /// Handles the "bases" Observer input.
        /// </summary>
        /// <returns></returns>
        public int handleFetchBases()
        {
            oh.outputBases(observer.fetchStockedBases());
            return 1;
        }

        /// <summary>
        /// Handles the "ingredients" Observer input.
        /// </summary>
        /// <returns></returns>
        public int handleFetchIngredients()
        {
            oh.outputIngredients(observer.fetchStockedIngredients());
            return 1;
        }

        /// <summary>
        /// Handles the "potions" Observer input.
        /// </summary>
        /// <returns></returns>
        public int handleFetchPotions()
        {
            oh.outputPotions(observer.fetchStockedPotions());
            return 1;
        }

        /// <summary>
        /// Handles the "back" Observer input.
        /// </summary>
        /// <returns></returns>
        public int handleBack()
        {
            return 0;
        }
    }
}
