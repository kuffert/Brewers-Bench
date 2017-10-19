using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewersBench
{

    /// <summary>
    /// Handles the processing and outputting of dialogue to the user.
    /// </summary>
    class OutputHandler
    {

        private static OutputHandler instance;

        /// <summary>
        /// Protected DialogueHandler singleton Constructor.
        /// </summary>
        protected OutputHandler()
        {

        }

        /// <summary>
        /// Retrieves the single instance of the DialogueHandler singleton, and creates a new one if one does not yet exist.
        /// </summary>
        /// <returns></returns>
        public static OutputHandler GetOutputHandlerInstance()
        {
            if (instance == null)
            {
                instance = new OutputHandler();
            }
            return instance;
        }

        /// <summary>
        /// Outputs the standard greeting upon application load.
        /// </summary>
        public void outputBrewersBenchGreeting()
        {
            Console.WriteLine("Welcome to the Brewers Bench!");
            Console.WriteLine("If you wish to view stock, please enter 'view'");
            Console.WriteLine("If you wish to brew potions, please enter 'brew'");
            Console.WriteLine("If you wish to stock the bench with materials, please enter 'stock'");
        }

        /// <summary>
        /// When a new potion is a brewed, this function will output the Potion's details.
        /// </summary>
        /// <param name="potion">Potion details to output</param>
        public void outputNewPotionDetails(Potion potion)
        {
            Console.WriteLine("----------NEW POTION BREWED!!!------------");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine(potion.defaultDescriptor());
            Console.WriteLine("------------------------------------------");
        }

        /// <summary>
        /// Outputs the standard message to a Stocker User.
        /// </summary>
        public void outputStandardStockerMessage()
        {
            Console.WriteLine("To stock a new item, please enter one of the following keywords");
            Console.WriteLine("vessel");
            Console.WriteLine("base");
            Console.WriteLine("ingredient");
            Console.WriteLine("potion");
            Console.WriteLine("back");
        }

        /// <summary>
        /// Outputs the standard message to an Observer user.
        /// </summary>
        public void outputStandardObserverMessage()
        {
            Console.WriteLine("To view stock contents, please enter the material you'd like to browse:");
            Console.WriteLine("vessels");
            Console.WriteLine("bases");
            Console.WriteLine("ingredients");
            Console.WriteLine("potions");
            Console.WriteLine("back");
        }

        /// <summary>
        /// Outputs the standard message to a Brewer user.
        /// </summary>
        public void outputStandardBrewerMessage()
        {
            Console.WriteLine("To begin brewing a potion, please enter 'begin'");
        }

        /// <summary>
        /// Outputs the standard message to a Stocker User when an invalid input is recieved.
        /// </summary>
        public void outputStandardStockerInvalidInputMessage()
        {
            Console.WriteLine("Input not recognized. Try again.");
        }

        /// <summary>
        /// Outputs the standard message to an Observer User when an invalid input is recieved.
        /// </summary>
        public void outputStandardObserverInvalidInputMessage()
        {
            Console.WriteLine("Input not recognized. Try again.");
        }

        /// <summary>
        /// Outputs a Stocker error message depending on the given code. 
        /// </summary>
        /// <param name="errorCode"></param>
        public void outputStockerError(int errorCode)
        {
            Console.WriteLine("Something went wrong. Aborting.");
        }

        /// <summary>
        /// Outputs an Observer error message depending on the given code.
        /// </summary>
        /// <param name="errorCode"></param>
        public void outputObserverError(int errorCode)
        {
            Console.WriteLine("Sometthing went wrong. Aborting.");
        }

        /// <summary>
        /// Outputs a Brewer error message depending on the given code.
        /// </summary>
        /// <param name="errorCode"></param>
        public void outputBrewerError(int errorCode)
        {
            Console.WriteLine("Something went wrong. Aborting.");
        }

        /// <summary>
        /// Outputs what the next required input is when inputting a Vessel.
        /// </summary>
        /// <param name="step"></param>
        public void outputVesselRequiredStepInput(int step)
        {
            switch (step)
            {
                case 0:
                    Console.WriteLine("Enter the name of the Vessel");
                    break;
                case 1:
                    Console.WriteLine("Enter the vessel dosage. (1-10)");
                    break;
                case 2:
                    Console.WriteLine("Enter the vessale usage. (single or muli)");
                    break;
                case 3:
                    Console.WriteLine("Enter the radius. (0-100)");
                    break;
            }
        }

        /// <summary>
        /// Outputs an error message if the Stocker's input is invalid while making a Vessel.
        /// </summary>
        /// <param name="step"></param>
        public void outputVesselInputError(int step)
        {
            switch (step)
            {
                case 0:
                    Console.WriteLine("Error accepting name. Try again.");
                    break;
                case 1:
                    Console.WriteLine("Error accepting dosage. Try again.");
                    break;
                case 2:
                    Console.WriteLine("Error accepting usage. Try again.");
                    break;
                case 3:
                    Console.WriteLine("Error accepting radius. Try again.");
                    break;
            }
        }

        /// <summary>
        /// Outputs a message stating the successful creation of a new Vessel.
        /// </summary>
        public void outputVesselSuccess()
        {
            Console.WriteLine("Vessel successfully created.");
        }

        /// <summary>
        /// Outputs what the next required input is when inputting a base
        /// </summary>
        /// <param name="step"></param>
        public void outputBaseRequiredNextInput(int step)
        {
            switch (step)
            {
                case 0:
                    Console.WriteLine("Enter the name of the Base");
                    break;
                case 1:
                    Console.WriteLine("Enter the base volatility (0-100)");
                    break;
                case 2:
                    Console.WriteLine("Enter the base dosage modifer (.1 - 1)");
                    break;
                case 3:
                    Console.WriteLine("Enter the base's effects. Press 'ENTER' to begin.");
                    break;
            }
        }

        /// <summary>
        /// Outputs an error message if a Stocker's input is invalid while adding a Base.
        /// </summary>
        /// <param name="step"></param>
        public void outputBaseInputError(int step)
        {
            switch (step)
            {
                case 0:
                    Console.WriteLine("Error accepting name. Try again.");
                    break;
                case 1:
                    Console.WriteLine("Error accepting volatility. Try again.");
                    break;
                case 2:
                    Console.WriteLine("Error accepting dosage modifer. Try again.");
                    break;
                case 3:
                    Console.WriteLine("Error accepting effects. Try again.");
                    break;
            }
        }

        /// <summary>
        /// Outputs a message stating the successful creation of a new Base.
        /// </summary>
        public void outputBaseSuccess()
        {
            Console.WriteLine("Base successfully created.");
        }

        /// <summary>
        /// Outputs what the next required input is when inputting an ingredient.
        /// </summary>
        /// <param name="step"></param>
        public void outputIngredientRequiredNextInput(int step)
        {
            switch(step)
            {
                case 0:
                    Console.WriteLine("Enter the name of the Ingredient");
                    break;
                case 1:
                    Console.WriteLine("Enter the Indredient volatility (0-100)");
                    break;
                case 2:
                    Console.WriteLine("Enter the Ingredient's effects. Press 'ENTER' to begin.");
                    break;
            }
        }

        /// <summary>
        /// Outputs an error message if a Stocker's input is invalid while adding an Ingredient.
        /// </summary>
        /// <param name="step"></param>
        public void outputIngredientInputError(int step)
        {
            switch (step)
            {
                case 0:
                    Console.WriteLine("Error accepting name. Try again.");
                    break;
                case 1:
                    Console.WriteLine("Error accepting volatility. Try again.");
                    break;
                case 2:
                    Console.WriteLine("Error accepting effects. Try again.");
                    break;
            }
        }

        /// <summary>
        /// Outputs an input error depending on the current brewing step.
        /// </summary>
        /// <param name="step"></param>
        public void outputBrewerInputError(int step)
        {
            string itemType = "";
            switch (step)
            {
                case 0:
                    itemType = "Vessel";
                    break;
                case 1:
                    itemType = "Base";
                    break;
                case 2:
                    itemType = "Ingredient";
                    break;
            }
            Console.WriteLine("Invalid " + itemType + " name selected. Try again.");
        }

        /// <summary>
        /// Outputs a message stating the successful creation of a new Ingredient.
        /// </summary>
        public void outputIngredientSuccess()
        {
            Console.WriteLine("Ingredient successfully created.");
        }

        /// <summary>
        /// Outputs a messagge stating the successful creation of a new potion.
        /// </summary>
        public void outputPotionSuccess()
        {
            Console.WriteLine("Potion not yet implemented.");
        }

        /// <summary>
        /// Outputs a formatted list of all Vessels.
        /// </summary>
        /// <param name="vessels"></param>
        public void outputVessels(List<Vessel> vessels)
        {
            Console.WriteLine("----- VESSELS -----");
            Console.WriteLine("-------------------");
            foreach(Vessel v in vessels)
            {
                Console.WriteLine(v.defaultDescriptor());
                Console.WriteLine("------------------");
            }
        }

        /// <summary>
        /// Outputs a formatted list of all Bases.
        /// </summary>
        /// <param name="bases"></param>
        public void outputBases(List<Base> bases)
        {
            Console.WriteLine("----- BASES -----");
            Console.WriteLine("-----------------");
            foreach(Base b in bases)
            {
                Console.WriteLine(b.defaultDescriptor());
                Console.WriteLine("-----------------");
            }
        }

        /// <summary>
        /// Outputs a formatted list of all Ingredients.
        /// </summary>
        /// <param name="ingredients"></param>
        public void outputIngredients(List<Ingredient> ingredients)
        {
            Console.WriteLine("-- INGREDIENTS --");
            Console.WriteLine("-----------------");
            foreach (Ingredient i in ingredients)
            {
                Console.WriteLine(i.defaultDescriptor());
                Console.WriteLine("-----------------");
            }
        }

        /// <summary>
        /// Outputs a formatted list of all potions.
        /// </summary>
        /// <param name="potions"></param>
        public void outputPotions(List<Potion> potions)
        {
            Console.WriteLine("---- POTIONS ----");
            Console.WriteLine("-----------------");
            foreach(Potion p in potions)
            {
                Console.WriteLine(p.defaultDescriptor());
                Console.WriteLine("-----------------");
            }
        }

        /// <summary>
        /// Outputs a message letting the user know what type of item they need to select next,
        /// depending on their current brew step.
        /// </summary>
        /// <param name="itemType"></param>
        public void outputBrewNextTypeSelect(int step)
        {
            string itemType = "";
            switch(step)
            {
                case 0:
                    itemType = "Vessel";
                    break;
                case 1:
                    itemType = "Base";
                    break;
                case 2:
                    itemType = "Ingredient";
                    break;
            }
            Console.WriteLine("Please select one of the following " + itemType);
        }

        /// <summary>
        /// Outputs a message prompting brewing input.
        /// </summary>
        public void outputBrewPotionPrompt()
        {
            Console.WriteLine("Enter 'brew' to brew this potion, or 'cancel' to start over.");
        }

        /// <summary>
        /// Outputs a message alerting user of invalid brew input.
        /// </summary>
        public void outputBrewPotionPromptError()
        {
            Console.WriteLine("Invalid brew input, try again.");
        }

        /// <summary>
        /// Outputs a message prompting the user for the next input when making
        /// a new effect
        /// </summary>
        /// <param name="step"></param>
        public void outputEffectRequiredNextInput(int step, EffectType type)
        {
            switch (step)
            {
                case 0:
                    Console.WriteLine("Enter a name for this effect, or 'done' to cancel.");
                    break;
                case 1:
                    Console.WriteLine("Select an effect type : Stat, Buff, or Debuff");
                    break;
                case 2:
                    switch (type)
                    {
                        case EffectType.STAT:
                            Console.WriteLine("Select stat: Health, Stamina, Attack, Defense");
                            break;
                        case EffectType.BUFF:
                            Console.WriteLine("Select a buff: Shielding, Barrier, Speed, Aim");
                            break;
                        case EffectType.DEBUFF:
                            Console.WriteLine("Select a debuff: Weakness, Dullness, Slowness, Blindness");
                            break;
                    }
                    break;
                case 3:
                    Console.WriteLine("Enter the Intensity of the effect");
                    break;
            }
        }

        /// <summary>
        /// Outputs an error message if the input while creating a new effect
        /// is invalid.
        /// </summary>
        /// <param name="step"></param>
        public void outputEffectInputError(int step)
        {
            switch(step)
            {
                case 1:
                    Console.WriteLine("Incorrect type, try again.");
                    break;
                case 2:
                    Console.WriteLine("Incorrect type, try again.");
                    break;
                case 3:
                    Console.WriteLine("Invalid amount, try again.");
                    break;
            }
        }

        /// <summary>
        /// Outputs a message stating the effect creation was a success.
        /// </summary>
        public void outputEffectSuccess()
        {
            Console.WriteLine("Effect successfully created.");
        }
    }
}
