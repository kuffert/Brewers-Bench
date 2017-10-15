using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewersBench
{
    /// <summary>
    /// Client that allows Stocker User to input new Vessels, Bases, Ingredients, and Potions.
    /// </summary>
    class StockerClient
    {
        private const string BACK = "back";
        private const string VESSEL = "vessel";
        private const string BASE = "base";
        private const string INGREDIENT = "ingredient";
        private const string POTION = "potion";

        private Stocker stocker;
        private OutputHandler oh;

        /// <summary>
        /// Standard Constructor for the Stocker Client.
        /// </summary>
        /// <param name="stocker"></param>
        public StockerClient(Stocker stocker)
        {
            this.stocker = stocker;
            oh = OutputHandler.GetDialogueHandlerInstance();
        }

        /// <summary>
        /// Main StockerClient application loop. 
        /// </summary>
        public int StockerClientMain()
        {
            string input = "";
            while  (true)
            {
                oh.outputStandardStockerMessage();
                input = Console.ReadLine().ToLower();
                int outcome = handleStockerInput(input);
                if (outcome < 0)
                {
                    oh.outputStockerError(outcome);
                    return outcome;
                }
                if (outcome == 0)
                {
                    return 1;
                }
            }
        }

        /// <summary>
        /// Handles what functionality to execute depending on Stocker input.
        /// </summary>
        /// <param name="input"></param>
        private int handleStockerInput(string input)
        {
            switch (input)
            {
                case BACK:
                    return handleBack();
                case VESSEL:
                    return handleVessel();
                case BASE:
                    return handleBase();
                case INGREDIENT:
                    return handleIngredient();
                case POTION:
                    return handleIngredient();
                default:
                    oh.outputStandardStockerInvalidInputMessage();
                    return 0;
            }
        }

        /// <summary>
        /// Handles "back" Stocker input.
        /// </summary>
        private int handleBack()
        {
            return 0;
        }

        /// <summary>
        /// Handles "back" Stocker input.
        /// </summary>
        private int handleVessel()
        {
            Vessel v = new Vessel();
            int step = 0;
            while (step < 4)
            {
                oh.outputVesselRequiredStepInput(step);
                string input = Console.ReadLine();
                switch (step)
                {
                    case 0:
                        v.name = input;
                        step++;
                        break;
                    case 1:
                        int doses = 0;
                        if (Int32.TryParse(input, out doses))
                        {
                            v.doses = doses;
                            step++;
                            break;
                        }
                        oh.outputVesselInputError(step);
                        break;
                    case 2: 
                        switch (input)
                        {
                            case "single":
                                v.usage = Usage.singleTarget;
                                step++;
                                break;
                            case "multi":
                                v.usage = Usage.multiTarget;
                                step++;
                                break;
                            default:
                                oh.outputVesselInputError(step);
                                break;
                        }
                        break;
                    case 3:
                        int radius = 0;
                        if (Int32.TryParse(input, out radius))
                        {
                            v.radius = radius;
                            step++;
                            break;
                        }
                        oh.outputVesselInputError(step);
                        break;
                }
            }
            stocker.executeStockVessel(v);
            oh.outputVesselSuccess();
            return 1;
        }

        /// <summary>
        /// Handles "base" user input.
        /// </summary>
        private int handleBase()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Handles "ingredient" user input.
        /// </summary>
        private int handleIngredient()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Handles "potion" user input.
        /// </summary>
        private int handlePotion()
        {
            throw new NotImplementedException();
        }
    }
}
