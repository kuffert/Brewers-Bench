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
    public class Base
    {
        public string name;
        public int volatility;
        public float dosageMod;
        public List<Effect> baseEffects;

        /// <summary>
        /// Default Base Constructor
        /// </summary>
        public Base()
        {
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
        public Base(string name, int volatility, float dosageMod, List<Effect> baseEffects)
        {
            this.name = (name == "") ? "Unnamed Base" : name;
            this.volatility = (volatility < 0) ? 0 : volatility;
            this.dosageMod = (dosageMod <= 0) ? 1 : dosageMod;
            this.baseEffects = (baseEffects == null) ? new List<Effect>() : baseEffects;
        }
    }
}
