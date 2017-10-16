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
            Base b = new Base();
            int step = 0;
            while (step < 4)
            {
                oh.outputBaseRequiredNextInput(step);
                string input = Console.ReadLine();
                switch(step)
                {
                    case 0:
                        b.name = input;
                        step++;
                        break;
                    case 1:
                        int volatility = 0;
                        if (Int32.TryParse(input, out volatility))
                        {
                            b.volatility = volatility;
                            step++;
                            break;
                        }
                        oh.outputBaseInputError(step);
                        break;
                    case 2:
                        float dosageMod = 0;
                        if (float.TryParse(input, out dosageMod))
                        {
                            b.dosageMod = dosageMod;
                            step++;
                            break;
                        }
                        oh.outputBaseInputError(step);
                        break;
                    case 3:
                        int effectsOutcome = handleEffect();
                        if (effectsOutcome == 0)
                        {
                            return 0;
                        }
                        if (effectsOutcome < 0)
                        {
                            oh.outputBaseInputError(step);
                            break;
                        }
                        step++;
                        break;
                }
            }
            stocker.executeStockBase(b);
            oh.outputBaseSuccess();
            return 1;
        }

        /// <summary>
        /// Handles "ingredient" user input.
        /// </summary>
        private int handleIngredient()
        {
            Ingredient i = new Ingredient();
            int step = 0;
            while (step < 3)
            {
                oh.outputIngredientRequiredNextInput(step);
                string input = Console.ReadLine();
                switch(step)
                {
                    case 0:
                        i.name = input;
                        step++;
                        break;
                    case 1:
                        int volatility = 0;
                        if (Int32.TryParse(input, out volatility))
                        {
                            i.volatility = volatility;
                            step++;
                            break;
                        }
                        oh.outputIngredientInputError(step);
                        break;
                    case 2:
                        int effectsOutcome = handleEffect();
                        if (effectsOutcome == 0)
                        {
                            return 0;
                        }
                        if (effectsOutcome < 0)
                        {
                            oh.outputIngredientInputError(step);
                            break;
                        }
                        step++;
                        break;
                }
            }
            stocker.executeStockingredient(i);
            oh.outputIngredientSuccess();
            return 1;
        }

        /// <summary>
        /// Handles "potion" user input.
        /// </summary>
        private int handlePotion()
        {
            oh.outputPotionSuccess();
            return 1;
        }

        /// <summary>
        /// Handles "effect" user input. 
        /// </summary>
        /// <returns></returns>
        private  int handleEffect()
        {
            return 1;
        }
    }
}
