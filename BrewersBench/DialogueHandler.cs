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

        public static OutputHandler instance;

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
    }
}
