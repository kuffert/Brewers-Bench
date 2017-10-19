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

        /// <summary>
        /// Fetches all stocked Vessels from the Bench Stock.
        /// </summary>
        public List<Vessel> fetchStockedVessels()
        {
            return system.getStockedVessels();
        }

        /// <summary>
        /// Fetches all stocked Bases from the Bench Stock.
        /// </summary>
        /// <returns></returns>
        public List<Base> fetchStockedBases()
        {
            return system.getStockedBases();
        }

        /// <summary>
        /// Fetches all stocked Ingredients from the Bench Stock.
        /// </summary>
        /// <returns></returns>
        public List<Ingredient> fetchStockedIngredients()
        {
            return system.getStockedIngredients();
        }

        /// <summary>
        /// Fetches all stocked Potions from the Bench Stock.
        /// </summary>
        /// <returns></returns>
        public List<Potion> fetchStockedPotions()
        {
            return system.getStockedPotions();
        }

        /// <summary>
        /// Returns an array of names pulled from a List of Descriptables.
        /// </summary>
        /// <param name="descriptables"></param>
        /// <returns></returns>
        public string[] getNames(List<IDescriptor> descriptables)
        {
            string[] names = new string[descriptables.Count];
            for(int i = 0; i < descriptables.Count; i++)
            {
                names[i] = descriptables[i].getName();
            }
            return names;
        }
    }

    /// <summary>
    /// A User who can invoke commands to view Bench Stock. Cannot Brew or Stock.
    /// </summary>
    class Observer : BenchUser
    {
        public Observer()
        {

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

        /// <summary>
        /// Invokes a command to add a Vessel to the brew.
        /// </summary>
        /// <param name="v"></param>
        public void addBrewVessel(Vessel v)
        {
            BrewerCommand command = new AddBrewVesselCommand(system, v);
            command.execute();
            brewCommands.Add(command);
            currentCommand++;
        }

        /// <summary>
        /// Invokes a command to add a Base to the brew.
        /// </summary>
        /// <param name="b"></param>
        public void addBrewBase(Base b)
        {
            BrewerCommand command = new AddBrewBaseCommand(system, b);
            command.execute();
            brewCommands.Add(command);
            currentCommand++;
        }

        /// <summary>
        /// Invokes a command to add an Ingredient to the brew.
        /// </summary>
        /// <param name="i"></param>
        public void addBrewIngredient(Ingredient i)
        {
            BrewerCommand command = new AddBrewIngredientCommand(system, i);
            command.execute();
            brewCommands.Add(command);
            currentCommand++;
        }

        /// <summary>
        /// Invokes a command to brew the Potion, then return it.
        /// </summary>
        /// <returns></returns>
        public Potion brewPotion()
        {
            BrewAndStockPotionCommand command = new BrewAndStockPotionCommand(system);
            command.execute();
            brewCommands.Add(command);
            currentCommand++;
            return command.getPotion();
        }

        /// <summary>
        /// Requests the Brewer Bench System to clean and reset the currently brewed potion.
        /// </summary>
        public void cleanPotion()
        {
            system.cleanPotion();
        }
    }
}
