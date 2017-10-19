using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewersBench
{
    /// <summary>
    /// Base liquid the potion will be constructed with. Determines volatility, dosage, and effects.
    /// </summary>
    public class Base : IDescriptor
    {
        private int id;
        public string name;
        public int volatility;
        public float dosageMod;
        public List<Effect> baseEffects;

        /// <summary>
        /// Default Base Constructor
        /// </summary>
        public Base()
        {
            id = -1;
            name = "Unnamed Base";
            volatility = 0;
            dosageMod = 1;
            baseEffects = new List<Effect>();
        }

        /// <summary>
        /// Standard Base Constructor
        /// </summary>
        /// <param name="volatility">How dangerous the Base is to the Imbiber</param>
        /// <param name="dosageMod">Effect of Base on vessel dosage</param>
        /// <param name="baseEffects">All potential Effects this Base will have on the Imbiber</param>
        public Base(int id, string name, int volatility, float dosageMod, List<Effect> baseEffects)
        {
            this.id = id;
            this.name = (name == "") ? "Unnamed Base" : name;
            this.volatility = (volatility < 0) ? 0 : volatility;
            this.dosageMod = (dosageMod <= 0) ? 1 : dosageMod;
            this.baseEffects = (baseEffects == null) ? new List<Effect>() : baseEffects;
        }

        /// <summary>
        /// Standard Base Constructor with no ID provided
        /// </summary>
        /// <param name="volatility">How dangerous the Base is to the Imbiber</param>
        /// <param name="dosageMod">Effect of Base on vessel dosage</param>
        /// <param name="baseEffects">All potential Effects this Base will have on the Imbiber</param>
        public Base(string name, int volatility, float dosageMod, List<Effect> baseEffects)
        {
            id = -1;
            this.name = (name == "") ? "Unnamed Base" : name;
            this.volatility = (volatility < 0) ? 0 : volatility;
            this.dosageMod = (dosageMod <= 0) ? 1 : dosageMod;
            this.baseEffects = (baseEffects == null) ? new List<Effect>() : baseEffects;
        }

        /// <summary>
        /// Constructs a descriptor from the Base's volatility, dosage, and Effects.
        /// </summary>
        /// <returns></returns>
        public string defaultDescriptor()
        {
            string builder = "";
            builder += name + "\n";
            builder += "~ " + volatility + " Volatility\n";
            builder += "~ " + dosageMod + " Dosage Modfier\n";
            foreach(Effect e in baseEffects)
            {
                builder += e.defaultDescriptor() + "\n";
            }
            return builder.Substring(0, builder.Length - 1);
        }

        /// <summary>
        /// Returns the base's name.
        /// </summary>
        /// <returns></returns>
        public string getName()
        {
            return name;
        }

        /// <summary>
        /// Gets the Base's Id.
        /// </summary>
        public int getId()
        {
            return id;
        }
    }
}
