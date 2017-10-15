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
        public static OutputHandler GetDialogueHandlerInstance()
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
            Console.WriteLine("If you wish to brew potions, please enter 'brew'");
            Console.WriteLine("If you wish to stock the bench with materials, please enter 'stock'");
        }

        /// <summary>
        /// When a new potion is a brewed, this function will output the Potion's details.
        /// </summary>
        /// <param name="pb"></param>
        public void outputNewPotionDetails(PotionBuilder pb)
        {
            Console.WriteLine("----------NEW POTION BREWED!!!------------");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine(pb.getPotion().defaultDescriptor());
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
        /// Outputs the standard message to a Stocker User when an invalid input is recieved.
        /// </summary>
        public void outputStandardStockerInvalidInputMessage()
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
    }
}
