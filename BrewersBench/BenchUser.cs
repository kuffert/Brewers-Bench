using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewersBench
{
    /// <summary>
    /// The abstract superclass for a BrewersBench User.
    /// </summary>
    abstract class BenchUser
    {
        protected BrewersBenchSystem system;
        protected int currentCommand;
        protected static int totalUsers = 0;

        /// <summary>
        /// Standard Brewer Constructor.
        /// </summary>
        public BenchUser()
        {
            system = BrewersBenchSystem.GetBrewersBenchInstance();
            currentCommand = 0;
            totalUsers++;
        }

        /// <summary>
        /// Standard Destructor for a Bench User.
        /// </summary>
        ~BenchUser()
        {
            totalUsers--;
        }

        /// <summary>
        /// Fetches the number of stocked Potions from the Bench Stock.
        /// </summary>
        /// <returns></returns>
        public int fetchStockedVesselCount()
        {
            return system.getVesselStockCount();
        }

        /// <summary>
        /// Fetches the number of stocked Bases from the Bench Stock.
        /// </summary>
        /// <returns></returns>
        public int fetchStockedBaseCount()
        {
            return system.getBaseStockCount();
        }

        /// <summary>
        /// Fetches the number of stocked Bases from the Bench Stock.
        /// </summary>
        /// <returns></returns>
        public int fetchStockedIngredientsCount()
        {
            return system.getIngredientStockCount();
        }

        /// <summary>
        /// Fetches the number of stocked Potions from the Bench Stock. 
        /// </summary>
        /// <returns></returns>
        public int fetchStockedPotionCount()
        {
            return system.getPotionStockCount();
        }
    }

    /// <summary>
    /// A User who can invoke commands to manipulate the Bench Stock. Cannot Brew.
    /// </summary>
    class Stocker : BenchUser
    {
        private List<StockerCommand> stockCommands;

        /// <summary>
        /// Standard Constructor for a Stocker, a User who can manipulate Bench stock. Cannot Brew.
        /// </summary>
        public Stocker()
        {
            stockCommands = new List<StockerCommand>();
        }

        /// <summary>
        /// Executes the command to stock a Vessel.
        /// </summary>
        /// <param name="v"></param>
        public void executeStockVessel(Vessel v)
        {
            StockerCommand command = new StockVesselCommand(system, v);
            command.execute();
            stockCommands.Add(command);
            currentCommand++;
        }

        /// <summary>
        /// Executes the command to stock a Base.
        /// </summary>
        /// <param name="v"></param>
        public void executeStockBase(Base b)
        {
            StockerCommand command = new StockBaseCommand(system, b);
            command.execute();
            stockCommands.Add(command);
            currentCommand++;
        }

        /// <summary>
        /// Executes the command to stock an Ingredient.
        /// </summary>
        /// <param name="v"></param>
        public void executeStockingredient(Ingredient i)
        {
            StockerCommand command = new StockIngredientCommand(system, i);
            command.execute();
            stockCommands.Add(command);
            currentCommand++;
        }

        /// <summary>
        /// Executes the command to stock a potion.
        /// </summary>
        /// <param name="p"></param>
        public void executeStockPotion(Potion p)
        {
            StockerCommand command = new StockPotionCommand(system, p);
            command.execute();
            stockCommands.Add(command);
            currentCommand++;
        }
    }

    /// <summary>
    /// A User who can invoke Commands to brew Potions. Cannot Stock.
    /// </summary>
    class Brewer : BenchUser
    {
        private List<BrewerCommand> brewCommands;

        /// <summary>
        /// Standard Constructor for Brewer, a User who can brew Potions. Cannot Stock. 
        /// </summary>
        public Brewer()
        {
            brewCommands = new List<BrewerCommand>();
        }
    }
}
