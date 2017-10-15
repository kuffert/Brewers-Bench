using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewersBench
{
    /// <summary>
    /// Singleton class that contains all of the benches currently stocked materials.
    /// </summary>
    class BenchStock : IDescriptor
    {
        private static BenchStock instance;

        private List<Vessel> stockedVessels;
        private List<Base> stockedBases;
        private List<Ingredient> stockedIngredients;
        private List<Potion> stockedPotions;

        /// <summary>
        /// Private BenchStock constructor that initializes all stocked lists of materials.
        /// </summary>
        private BenchStock()
        {
            stockedVessels = new List<Vessel>();
            stockedBases = new List<Base>();
            stockedIngredients = new List<Ingredient>();
            stockedPotions = new List<Potion>();
        }

        /// <summary>
        /// Retrieves the single instance of the BenchStock, creating a new one if one
        /// does not already exist.
        /// </summary>
        /// <returns></returns>
        public static BenchStock GetBenchStockInstance()
        {
            if (instance == null)
            {
                instance = new BenchStock();
            }
            return instance;
        }

        /// <summary>
        /// Constructs a descriptor detailing the current amount of stocked materials.
        /// </summary>
        /// <returns></returns>
        public string defaultDescriptor()
        {
            string builder = "";
            builder += "Current bench stock:\n";
            builder += "Stocked Vessels: " + stockedVessels.Count + "\n";
            builder += "Stocked Ingredients: " + stockedIngredients + "\n";
            builder += "Stocked Potions: " + stockedPotions + "\n";
            return builder;
        }

        /// <summary>
        /// Constructs a descriptor for all stocked Vessels.
        /// </summary>
        /// <returns></returns>
        public string stockedVesselsDescriptor()
        {
            string builder = "";
            foreach (Vessel v in stockedVessels)
            {
                builder += v.defaultDescriptor();
            }
            return builder;
        }

        /// <summary>
        /// Constructs a descriptor for all stocked Bases.
        /// </summary>
        /// <returns></returns>
        public string stockedBasesDescriptor()
        {
            string builder = "";
            foreach (Base b in stockedBases)
            {
                builder += b.defaultDescriptor();
            }
            return builder;
        }

        /// <summary>
        /// Constructs a descriptor for all stocked Ingredients.
        /// </summary>
        /// <returns></returns>
        public string stockedIngredientsDescriptor()
        {
            string builder = "";
            foreach (Ingredient i in stockedIngredients)
            {
                builder += i.defaultDescriptor();
            }
            return builder;
        }

        /// <summary>
        /// Constructs a descriptor for all stocked Potions.
        /// </summary>
        /// <returns></returns>
        public string stockedPotionsDescriptor()
        {
            string builder = "";
            foreach (Potion p in stockedPotions)
            {
                builder += p.defaultDescriptor();
            }
            return builder;
        }

        /// <summary>
        /// Gets the list of stocked Vessels.
        /// </summary>
        /// <returns></returns>
        public List<Vessel> getStockedVessels()
        {
            return stockedVessels;
        }

        /// <summary>
        /// Gets the list of stocked Bases.
        /// </summary>
        /// <returns></returns>
        public List<Base> getStockedBases()
        {
            return stockedBases;
        }

        /// <summary>
        /// Gets the list of stocked Ingredients.
        /// </summary>
        /// <returns></returns>
        public List<Ingredient> getStockedIngredients()
        {
            return stockedIngredients;
        }

        /// <summary>
        /// Gets the list of stocked Potions.
        /// </summary>
        /// <returns></returns>
        public List<Potion> getStockedPotions()
        {
            return stockedPotions;
        }

        /// <summary>
        /// Stocks a new Vessel.
        /// </summary>
        /// <param name="v"></param>
        public void stockVessel(Vessel v)
        {
            stockedVessels.Add(v);
        }

        /// <summary>
        /// Stocks a new Base.
        /// </summary>
        /// <param name="b"></param>
        public void stockBase(Base b)
        {
            stockedBases.Add(b);
        }

        /// <summary>
        /// Stocks a new Ingredient.
        /// </summary>
        /// <param name="i"></param>
        public void stockIngredient(Ingredient i)
        {
            stockedIngredients.Add(i);
        }

        /// <summary>
        /// Stocks a new Potion.
        /// </summary>
        /// <param name="p"></param>
        public void stockPotion(Potion p)
        {
            stockedPotions.Add(p);
        }
    }


}
