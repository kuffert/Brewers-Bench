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
            PotionBuilder pb = PotionBuilder.GetCleanPotionBuilderInstance();
            DialogueHandler dh = DialogueHandler.GetDialogueHandlerInstance();
            Effect e1 = new StatEffect("Stat Effect 1", ImbiberStat.Attack, 60);
            Vessel v = new Vessel("Vial", 3, Usage.singleTarget, 0);
            Base b = new Base("Water", 0, 1, null);
            Ingredient i = new Ingredient("Vitalae", 0, new List<Effect> { e1 });
            pb.addVessel(v);
            pb.addBase(b);
            pb.addIngredient(i);
            pb.BrewPotion();

            dh.outputNewPotionDetails(pb);
            Console.ReadLine();


        }
    }
}
