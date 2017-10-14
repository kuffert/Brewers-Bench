using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewersBench
{
    class DialogueHandler
    {

        public static DialogueHandler instance;

        /// <summary>
        /// Protected DialogueHandler singleton Constructor.
        /// </summary>
        protected DialogueHandler()
        {

        }

        /// <summary>
        /// Retrieves the single instance of the DialogueHandler singleton, and creates a new one if one does not yet exist.
        /// </summary>
        /// <returns></returns>
        public static DialogueHandler GetDialogueHandlerInstance()
        {
            if (instance == null)
            {
                instance = new DialogueHandler();
            }
            return instance;
        }

        /// <summary>
        /// When a new potion is a brewed, this function will output the potions details.
        /// </summary>
        /// <param name="pb"></param>
        public void outputNewPotionDetails(PotionBuilder pb)
        {
            Console.WriteLine("----------NEW POTION BREWED!!!------------");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine(pb.getPotion().getPotionName());
            Console.WriteLine("------------------------------------------");
        }
    }
}
