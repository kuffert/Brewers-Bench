using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewersBench
{
    /// <summary>
    /// BrewersBenchSystem is a Singleton Facade system that handles Client interactions with the application's subsystems. 
    /// </summary>
    class BrewersBenchSystem
    {
        private static BrewersBenchSystem instance;

        BenchStock benchStock;
        BenchBrewing benchBrewing;

        /// <summary>
        /// Standard Constructor for the Facade BrewersBenchSystem.
        /// </summary>
        private BrewersBenchSystem()
        {
            benchStock = BenchStock.GetBenchStockInstance();
            // need to init benchBrewing as Singleton
        }

        /// <summary>
        /// Retuns the singleton instance of the BrewersBenchSystem, and creates a new one if the instance
        /// does not yet exist. 
        /// </summary>
        /// <returns></returns>
        public static BrewersBenchSystem GetBrewersBenchInstance()
        {
            if (instance == null)
            {
                instance = new BrewersBenchSystem();
            }
            return instance;
        }

        /// <summary>
        /// Stocks the new Vessel into the BenchStock.
        /// </summary>
        /// <param name="v"></param>
        public void stockNewVessel(Vessel v)
        {
            benchStock.stockVessel(v);
        }

        /// <summary>
        /// Stocks the new Base into the BenchStock.
        /// </summary>
        /// <param name="b"></param>
        public void stockNewBase(Base b)
        {
            benchStock.stockBase(b);
        }

        /// <summary>
        /// Stocks the new Ingredient into the BenchStock.
        /// </summary>
        /// <param name="i"></param>
        public void stockNewIngredient(Ingredient i)
        {
            benchStock.stockIngredient(i);
        }

        /// <summary>
        /// Stocks the new Potion into the BenchStock.
        /// </summary>
        /// <param name="p"></param>
        public void stockNewPotion(Potion p)
        {
            benchStock.stockPotion(p);
        }

        /// <summary>
        /// Gets the number of stocked Vessels from the Bench Stock.
        /// </summary>
        /// <returns></returns>
        public int getVesselStockCount()
        {
            return benchStock.getStockedVessels().Count;
        }

        /// <summary>
        /// Gets the number of stocked Bases from the Bench Stock.
        /// </summary>
        /// <returns></returns>
        public int getBaseStockCount()
        {
            return benchStock.getStockedBases().Count;
        }

        /// <summary>
        /// Gets the number of stocked Ingredients from the Bench Stock.
        /// </summary>
        /// <returns></returns>
        public int getIngredientStockCount()
        {
            return benchStock.getStockedIngredients().Count;
        }

        /// <summary>
        /// Gets the number of stocked Potions from the Bench Stock.
        /// </summary>
        /// <returns></returns>
        public int getPotionStockCount()
        {
            return benchStock.getStockedPotions().Count;
        }

        /// <summary>
        /// Gets the list of stocked Vessels from the Bench Stock.
        /// </summary>
        /// <returns></returns>
        public List<Vessel> getStockedVessels()
        {
            return benchStock.getStockedVessels();
        }

        /// <summary>
        /// Gets the list of stocked Bases from the Bench Stock.
        /// </summary>
        /// <returns></returns>
        public List<Base> getStockedBases()
        {
            return benchStock.getStockedBases();
        }

        /// <summary>
        /// Gets the list of stocked Ingredients from the Bench Stock.
        /// </summary>
        /// <returns></returns>
        public List<Ingredient> getStockedIngredients()
        {
            return benchStock.getStockedIngredients();
        }

        /// <summary>
        /// Gets the list of stocked Potions from the Bench Stock.
        /// </summary>
        /// <returns></returns>
        public List<Potion> getStockedPotions()
        {
            return benchStock.getStockedPotions();
        }
    }



}
