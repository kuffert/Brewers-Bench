using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewersBench
{
    class BrewerClient
    {
        private const string BEGIN = "begin";
        private const string BREW = "brew";
        private const string CANCEL = "cancel";
        private const string BACK = "back";

        private Brewer brewer;
        private OutputHandler oh;
        
        /// <summary>
        /// Standard Constructor for the BrewerClient.
        /// </summary>
        /// <param name="brewer"></param>
        public BrewerClient(Brewer brewer)
        {
            this.brewer = brewer;
            oh = OutputHandler.GetOutputHandlerInstance();
        }
        
        /// <summary>
        /// Main Brewer Client application loop.
        /// </summary>
        /// <returns></returns>
        public int BrewerClientMain()
        {

            while (true)
            {
                oh.outputStandardBrewerMessage();
                string input = Console.ReadLine();
                int outcome = handleBrewerInput(input);
                if (outcome == 0)
                {
                    return 1;
                }
                if (outcome < 0)
                {
                    oh.outputBrewerError(outcome);
                    return outcome;
                }
            }
        } 

        /// <summary>
        /// Handles brewer input.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public int handleBrewerInput(string input)
        {
            switch(input)
            {
                case BEGIN:
                    return handleBrewPotion();
                case BACK:
                    return handleBack();
                default:
                    oh.outputStandardObserverInvalidInputMessage();
                    return 1;
            }
        }

        /// <summary>
        /// Handles the "back" input.
        /// </summary>
        /// <returns></returns>
        public int handleBack()
        {
            return 0;
        }

        /// <summary>
        /// Processes user input and builds the potion's components.
        /// </summary>
        /// <returns></returns>
        public int handleBrewPotion()
        {
            int step = 0;
            brewer.cleanPotion();

            while (step < 3)
            {
                oh.outputBrewNextTypeSelect(step);
                switch(step)
                {
                    case 0:
                        List<Vessel> vessels = brewer.fetchStockedVessels();
                        int vesselIndex = handleAddVessel(vessels); 
                        if (vesselIndex < 0)
                        {
                            oh.outputBrewerInputError(step);
                            break;
                        }
                        Vessel v = vessels[vesselIndex];
                        brewer.addBrewVessel(v);
                        step++;
                        break;
                    case 1:
                        List<Base> bases = brewer.fetchStockedBases();
                        int baseIndex = handleAddBase(bases);
                        if (baseIndex < 0)
                        {
                            oh.outputBrewerInputError(step);
                            break;
                        }
                        Base b = bases[baseIndex];
                        brewer.addBrewBase(b);
                        step++;
                        break;
                    case 2:
                        List<Ingredient> ingredients = brewer.fetchStockedIngredients();
                        int ingredientIndex = handleAddIngredient(ingredients);
                        if (ingredientIndex < 0)
                        {
                            oh.outputBrewerInputError(step);
                            break;
                        }
                        Ingredient i = ingredients[ingredientIndex];
                        brewer.addBrewIngredient(i);
                        step++;
                        break;
                }
            }
            while (true)
            {
                int brewOutcome  = handleBrewInput();
                if (brewOutcome > 0)
                {
                    return 1;
                }
                oh.outputBrewPotionPromptError();
            }
        }

        /// <summary>
        /// Handles the selection of a Vessel to add.
        /// </summary>
        /// <param name="vessels"></param>
        /// <returns></returns>
        public int handleAddVessel(List<Vessel> vessels)
        {
            string[] vesselNames = brewer.getNames(vessels.ToList<IDescriptor>());
            oh.outputVessels(vessels);
            string vesselInput = Console.ReadLine();
            return Array.IndexOf(vesselNames, vesselInput);
        }

        /// <summary>
        /// Handles the selection of a Base to add.
        /// </summary>
        /// <param name="bases"></param>
        /// <returns></returns>
        public int handleAddBase(List<Base> bases)
        {
            string[] baseNames = brewer.getNames(bases.ToList<IDescriptor>());
            oh.outputBases(bases);
            string baseInput = Console.ReadLine();
            return Array.IndexOf(baseNames, baseInput);
        }

        /// <summary>
        /// Handles the selection of an ingredient to add.
        /// </summary>
        /// <param name="ingredients"></param>
        /// <returns></returns>
        public int handleAddIngredient(List<Ingredient> ingredients)
        {
            string[] ingredientNames = brewer.getNames(ingredients.ToList<IDescriptor>());
            oh.outputIngredients(ingredients);
            string ingredientInput = Console.ReadLine();
            return Array.IndexOf(ingredientNames, ingredientInput);
        }

        /// <summary>
        /// Handles the brew decision.
        /// </summary>
        /// <returns></returns>
        public int handleBrewInput()
        {
            oh.outputBrewPotionPrompt();
            string brewInput = Console.ReadLine();
            if (brewInput == CANCEL)
            {
                brewer.cleanPotion();
                return 1;
            }
            if (brewInput == BREW)
            {
                Potion p = brewer.brewPotion();
                oh.outputNewPotionDetails(p);
                return 1;
            }
            return 0;
        }
    }
}
