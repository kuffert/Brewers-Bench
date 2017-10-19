using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewersBench
{
    /// <summary>
    /// Abstract superclass for available commands.
    /// Command Design Pattern.
    /// 
    /// 
    /// NEED TO ADD ABILITY TO UNDO (unexecute())
    /// 
    /// 
    ///
    /// </summary>
    abstract class BenchCommand
    {
        protected BrewersBenchSystem BBSystem;

        /// <summary>
        /// Public command constructor.
        /// </summary>
        /// <param name="system"></param>
        public BenchCommand(BrewersBenchSystem system)
        {
            BBSystem = system;
        }

        /// <summary>
        /// Handles the execution of this command.
        /// </summary>
        public abstract void execute();
    }

    /// <summary>
    /// Abstract superclass for Commands that are available to a Brewer.
    /// </summary>
    abstract class BrewerCommand : BenchCommand
    {
        /// <summary>
        /// Standard Constructor for a Brewer Command.
        /// </summary>
        /// <param name="system"></param>
        public BrewerCommand(BrewersBenchSystem system) : base(system)
        {

        }
    }

    /// <summary>
    /// Brewer Command to add a new Vessel to the Brew.
    /// </summary>
    class AddBrewVesselCommand : BrewerCommand
    {
        Vessel vessel;

        /// <summary>
        /// Standard Constructor for an AddBrewVesselCommand
        /// </summary>
        /// <param name="system"></param>
        /// <param name="v"></param>
        public AddBrewVesselCommand(BrewersBenchSystem system, Vessel v) : base(system)
        {
            vessel = v;
        }

        /// <summary>
        /// Executes the Add Brew Vessel Command in the Brewers Bench System Facade.
        /// </summary>
        public override void execute()
        {
            BBSystem.addBrewVessel(vessel);
        }
    }

    /// <summary>
    /// Brewer Command to add a new Base to the Brew.
    /// </summary>
    class AddBrewBaseCommand : BrewerCommand
    {
        Base bbase;

        /// <summary>
        /// Standard Constructor for an AddBrewBaseCommand.
        /// </summary>
        /// <param name="system"></param>
        /// <param name="b"></param>
        public AddBrewBaseCommand(BrewersBenchSystem system, Base b) : base(system)
        {
            bbase = b;
        }

        /// <summary>
        /// Executes the Add Brew Base Command in the Brewers Bench System Facade.
        /// </summary>
        public override void execute()
        {
            BBSystem.addBrewBase(bbase);
        }
    }

    /// <summary>
    /// Brewer Command to add an Ingredient to the Brew.
    /// </summary>
    class AddBrewIngredientCommand : BrewerCommand
    {
        Ingredient ingredient;

        /// <summary>
        /// Standard Constructor for an AddBrewIngredientCommand.
        /// </summary>
        /// <param name="system"></param>
        /// <param name="i"></param>
        public AddBrewIngredientCommand(BrewersBenchSystem system, Ingredient i) : base(system)
        {
            ingredient = i;
        }

        /// <summary>
        /// Executes the AddBrewIngredient Command in the Brewers Bench System Facade.
        /// </summary>
        public override void execute()
        {
            BBSystem.addBrewIngredient(ingredient);
        }
    }

    /// <summary>
    /// Brewer Command to Brew the Potion.
    /// </summary>
    class BrewAndStockPotionCommand : BrewerCommand
    {
        Potion potion;
        /// <summary>
        /// Standard Constructor for a BrewAndStockPotionCommand.
        /// </summary>
        /// <param name="system"></param>
        public BrewAndStockPotionCommand(BrewersBenchSystem system) : base(system)
        {

        }

        /// <summary>
        /// Executes the Brew And Stock Potion Command in the Brewers Bench System Facade.
        /// </summary>
        public override void execute()
        {
            potion = BBSystem.brewAndStockPotion();
        }

        /// <summary>
        /// Returns the brewed potion. Call after command has been invoked.
        /// </summary>
        /// <returns></returns>
        public Potion getPotion()
        {
            return potion;
        }
    }




    /// <summary>
    /// Abstract superclass for Commands that are available to a Stocker. 
    /// </summary>
    abstract class StockerCommand : BenchCommand
    {
        /// <summary>
        /// Standard Constructor for a Stocker Command.
        /// </summary>
        /// <param name="system"></param>
        public StockerCommand(BrewersBenchSystem system) : base(system)
        {

        }
    }

    /// <summary>
    /// Bench Command to stock a new Vessel in the BenchStock.
    /// </summary>
    class StockVesselCommand : StockerCommand
    {
        private Vessel vessel;

        /// <summary>
        /// Standard Constructor for the Stock Vessel Command.
        /// </summary>
        /// <param name="system"></param>
        /// <param name="v"></param>
        public StockVesselCommand(BrewersBenchSystem system, Vessel v) : base(system)
        {
            vessel = v;
        }

        /// <summary>
        /// Executes the Stock Vessel Command in the BrewsBenchSystem Facade.
        /// </summary>
        public override void execute()
        {
            BBSystem.stockNewVessel(vessel);
        }
    }

    /// <summary>
    /// Bench Command to stock a new Base in the BenchStock.
    /// </summary>
    class StockBaseCommand : StockerCommand
    {
        private Base bbase;

        /// <summary>
        /// Standard Constructor for the Stock Base Command.
        /// </summary>
        /// <param name="system"></param>
        /// <param name="b"></param>
        public StockBaseCommand(BrewersBenchSystem system, Base b) : base (system)
        {
            bbase = b;
        }

        /// <summary>
        /// Exectutes the Stock Base Command in the BrewersBenchSystem Facade.
        /// </summary>
        public override void execute()
        {
            BBSystem.stockNewBase(bbase);
        }
    }

    /// <summary>
    /// Bench Command to stock a new Ingredient in the BenchStock.
    /// </summary>
    class StockIngredientCommand : StockerCommand
    {
        private Ingredient ingredient;

        /// <summary>
        /// Standard Constructor for the Stock Ingredient Command.
        /// </summary>
        /// <param name="system"></param>
        /// <param name="i"></param>
        public StockIngredientCommand(BrewersBenchSystem system, Ingredient i) : base (system)
        {
            ingredient = i;
        }

        /// <summary>
        /// Executes the Stock Ingredient Command in the BrewersBenchSystem Facade.
        /// </summary>
        public override void execute()
        {
            BBSystem.stockNewIngredient(ingredient);
        }
    }
    /// <summary>
    /// Bench Command to stock a new Potion in the BenchStock.
    /// </summary>
    class StockPotionCommand : StockerCommand
    {
        private Potion potion;

        /// <summary>
        /// Standard Constructor for the Stock Potion Command.
        /// </summary>
        /// <param name="system"></param>
        /// <param name="p"></param>
        public StockPotionCommand(BrewersBenchSystem system, Potion p) : base(system)
        {
            potion = p;
        }

        /// <summary>
        /// Excecutes the Stock Potion Command in the BrewersBenchSystem Facade.
        /// </summary>
        public override void execute()
        {
            BBSystem.stockNewPotion(potion);
        }
    }
}
