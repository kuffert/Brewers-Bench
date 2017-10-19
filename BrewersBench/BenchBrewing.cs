using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewersBench
{
    /// <summary>
    /// Handles the brewing of new potions using stocked ingredients.
    /// </summary>
    class BenchBrewing
    {
        private static BenchBrewing instance;
        private PotionBuilder pb;

        /// <summary>
        /// Default Bench Brewing Constructor. Initializes a new clean Potion Builder.
        /// </summary>
        private BenchBrewing()
        {
            pb = PotionBuilder.GetCleanPotionBuilderInstance();
        }

        /// <summary>
        /// Retrieves the Bench Brewing instance, constructing a new one if the instance
        /// does not yet exist.
        /// </summary>
        /// <returns></returns>
        public static BenchBrewing GetBenchBrewingInstance()
        {
            if (instance == null)
            {
                instance = new BenchBrewing();
            }
            return instance;
        }


        /// <summary>
        /// Adds a Vessel to the Potion builder.
        /// </summary>
        /// <param name="v"></param>
        public void addVessel(Vessel v)
        {
            pb.addVessel(v);
        }

        /// <summary>
        /// Adds a Base to the Potion builder.
        /// </summary>
        /// <param name="b"></param>
        public void addBase(Base b)
        {
            pb.addBase(b);
        }

        /// <summary>
        /// Adds an Ingredient to the Potion builder.
        /// </summary>
        /// <param name="i"></param>
        public void addIngredient(Ingredient i)
        {
            pb.addIngredient(i);
        }

        /// <summary>
        /// Brews together the components of the PotionBuilder into a Potion.
        /// </summary>
        /// <returns></returns>
        public Potion brewPotion()
        {
            return pb.BrewPotion();
        }

        /// <summary>
        /// Cleans and resets the Potion Builder instance. 
        /// </summary>
        public void cleanPotion()
        {
            pb = PotionBuilder.GetCleanPotionBuilderInstance();
        }

    }
}
