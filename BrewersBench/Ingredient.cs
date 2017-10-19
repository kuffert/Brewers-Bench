using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewersBench
{
    /// <summary>
    /// Primary ingredient in the final Potion. Determines the volatility and effects of final Potion on the Imbiber.
    /// </summary>
    class Ingredient : IDescriptor
    {
        private int id;
        public string name;
        public int volatility;
        public List<Effect> ingredientEffects;

        /// <summary>
        /// Default Ingredient Constructor
        /// </summary>
        public Ingredient()
        {
            id = -1;
            name = "Unnamed Ingredient";
            volatility = 0;
            ingredientEffects = new List<Effect>();
        }

        /// <summary>
        /// Standard Ingredient Constructor
        /// </summary>
        /// <param name="volatility">How dangerous this Ingredient is to the Imbiber</param>
        /// <param name="ingredientEffects">All potential Effects this ingredient will have on the Imbiber</param>
        public Ingredient(int id, string name, int volatility, List<Effect> ingredientEffects)
        {
            this.id = id;
            this.name = (name == "") ? "Unnamed Ingredient" : name;
            this.volatility = (volatility <= 0) ? 0 : volatility;
            this.ingredientEffects = (ingredientEffects == null) ? new List<Effect>() : ingredientEffects;
        }

        /// <summary>
        /// Standard Ingredient Constructor with no ID provided
        /// </summary>
        /// <param name="volatility">How dangerous this Ingredient is to the Imbiber</param>
        /// <param name="ingredientEffects">All potential Effects this ingredient will have on the Imbiber</param>
        public Ingredient(string name, int volatility, List<Effect> ingredientEffects)
        {
            id = -1;
            this.name = (name == "") ? "Unnamed Ingredient" : name;
            this.volatility = (volatility <= 0) ? 0 : volatility;
            this.ingredientEffects = (ingredientEffects == null) ? new List<Effect>() : ingredientEffects;
        }

        /// <summary>
        /// Constructs a descriptor based on the Ingredient's name, volatility, and Effects.
        /// </summary>
        /// <returns></returns>
        public string defaultDescriptor()
        {
            string builder = name + "\n";
            builder += "~ " + volatility + " volatility\n";
            foreach (Effect e in ingredientEffects)
            {
                builder += e.defaultDescriptor() + "\n";
            }
            return builder.Substring(0, builder.Length-1);
        }

        /// <summary>
        /// Returns this Ingredient's name.
        /// </summary>
        /// <returns></returns>
        public string getName()
        {
            return name;
        }

        /// <summary>
        /// Gets the Ingredient's Id.
        /// </summary>
        /// <returns></returns>
        public int getId()
        {
            return id;
        }
    }
}
