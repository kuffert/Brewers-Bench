using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewersBench
{
    /// <summary>
    /// Result of combining a Vessel, Base, and Ingredient. Potions can have a multitude of Effects on the Imbiber.
    /// </summary>
    class Potion : IDescriptor
    {
        private int id;
        string name;
        float doses;
        int volatility;
        Usage usage;
        List<Effect> potionEffects;

        /// <summary>
        /// Default Potion Constructor
        /// </summary>
        public Potion()
        {
            id = -1;
            name = "Default Potion";
            doses = 1;
            volatility = 0;
            usage = Usage.singleTarget;
            potionEffects = new List<Effect>();
        }

        /// <summary>
        /// Standard Potion Constructor
        /// </summary>
        /// <param name="name">Name of the brewed Potion</param>
        /// <param name="doses">Number of potential doses of this Potion</param>
        /// <param name="volatility">How dangerous this potion is to the Imbiber</param>
        /// <param name="usage">Number of targets this Potion effects</param>
        /// <param name="potionEffects">All Effects this Potion will have on the Imbiber</param>
        public Potion (int id, string name, float doses, int volatility, Usage usage, List<Effect> potionEffects)
        {
            this.id = id;
            this.name = name;
            this.doses = doses;
            this.volatility = volatility;
            this.usage = usage;
            this.potionEffects = potionEffects;
        }

        /// <summary>
        /// Standard Potion Constructor with no provided ID
        /// </summary>
        /// <param name="name">Name of the brewed Potion</param>
        /// <param name="doses">Number of potential doses of this Potion</param>
        /// <param name="volatility">How dangerous this potion is to the Imbiber</param>
        /// <param name="usage">Number of targets this Potion effects</param>
        /// <param name="potionEffects">All Effects this Potion will have on the Imbiber</param>
        public Potion(string name, float doses, int volatility, Usage usage, List<Effect> potionEffects)
        {
            id = -1;
            this.name = name;
            this.doses = doses;
            this.volatility = volatility;
            this.usage = usage;
            this.potionEffects = potionEffects;
        }

        /// <summary>
        /// Constructs a descriptor for this potion based on its name, volatility, dosage, usage, and effects.
        /// </summary>
        /// <returns></returns>
        public string defaultDescriptor()
        {
            string builder = name + "\n";
            builder += "~ " + doses + " doses\n";
            builder += "~ " + volatility + " volatility\n";
            switch (usage)
            {
                case (Usage.singleTarget):
                    builder += "~ Single Target\n";
                    break;

                case (Usage.multiTarget):
                    builder += "~ Multi Target\n";
                    break;
            }

            foreach(Effect e in potionEffects)
            {
                builder += e.defaultDescriptor() + "\n";
            }

            return builder.Substring(0, builder.Length - 1);
        }

        /// <summary>
        /// Gets the potion's name.
        /// </summary>
        /// <returns></returns>
        public string getPotionName()
        {
            return name;
        }

        /// <summary>
        /// Gets the potion's effects.
        /// </summary>
        /// <returns></returns>
        public List<Effect> getEffects()
        {
            return potionEffects;
        }

        /// <summary>
        /// Returns this Potion's name.
        /// </summary>
        /// <returns></returns>
        public string getName()
        {
            return name;
        }

        /// <summary>
        /// Gets the Potion's Id
        /// </summary>
        /// <returns></returns>
        public int getId()
        {
            return id;
        }

        /// <summary>
        /// Gets the Potion's doses
        /// </summary>
        /// <returns></returns>
        public float getDoses()
        {
            return doses;
        }

        /// <summary>
        /// Gets the Potion's Usage
        /// </summary>
        /// <returns></returns>
        public Usage getUsage()
        {
            return usage;
        }

        /// <summary>
        /// Gets the Potion's volatility
        /// </summary>
        /// <returns></returns>
        public int getVolatility()
        {
            return volatility;
        }
    }

}
