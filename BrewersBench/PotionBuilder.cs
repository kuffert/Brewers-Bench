using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewersBench
{
    /// <summary>
    /// System that builds potions one step at a time, combining the Vessel, Base, and Ingredient into a Potion.
    /// PotionBuilder is designed as a Singleton: only one instance of this class should ever exist. Calling new
    /// will overwrite its components with null values.
    /// </summary>
    class PotionBuilder
    {
        private static PotionBuilder instance;

        private Vessel potionVessel;
        private Base potionBase;
        private Ingredient potionIngredient;
        private Potion potion;

        /// <summary>
        /// Protected PotionBuilder Constructor, generates a fresh instance of the Singleton PotionBuilder
        /// </summary>
        protected PotionBuilder()
        {
            potionVessel = null;
            potionBase = null;
            potionIngredient = null;
            potion = null;
        }

        /// <summary>
        /// Retrieves the single instance of the PotionBuilder singleton, and generates a new one if the instance does not yet exist.
        /// </summary>
        /// <returns></returns>
        public static PotionBuilder GetPotionBuilderInstance()
        {
            if (instance == null)
            {
                instance = new PotionBuilder();
            }
            return instance;
        }

        /// <summary>
        /// Retrieves the single instance of the PotionBuilder singleton, after it has been cleaned and reset.
        /// </summary>
        /// <returns></returns>
        public static PotionBuilder GetCleanPotionBuilderInstance()
        {
            instance = new PotionBuilder();
            return instance;
        }

        /// <summary>
        /// Adds a vessel to the PotionBuilder.
        /// </summary>
        /// <param name="vessel"></param>
        public void addVessel(Vessel vessel)
        {
            potionVessel = vessel;
        }

        /// <summary>
        /// Adds a base to the PotionBuilder.
        /// </summary>
        /// <param name="pBase"></param>
        public void addBase(Base pBase)
        {
            potionBase = pBase;
        }

        /// <summary>
        /// Adds an ingedient to the PotionBuilder.
        /// </summary>
        /// <param name="ingredient"></param>
        public void addIngredient(Ingredient ingredient)
        {
            potionIngredient = ingredient;
        }

        /// <summary>
        /// Gets the currently brewed potion.
        /// </summary>
        /// <returns></returns>
        public Potion getPotion()
        {
            return potion;
        }

        /// <summary>
        /// Combines the Vessel, Base, and Ingedient into a Potion, then returns it.
        /// </summary>
        public Potion BrewPotion()
        {
            int totalDoses = (int)Math.Ceiling(potionVessel.doses * potionBase.dosageMod);
            int totalVolatility = potionBase.volatility + potionIngredient.volatility;
            Usage usage = potionVessel.usage;
            List<Effect> allEffects = new List<Effect>();
            allEffects.AddRange(potionBase.baseEffects);
            allEffects.AddRange(potionIngredient.ingredientEffects);
            allEffects = processEffects(allEffects);
            string potionName = generatePotionName(totalDoses, totalVolatility, allEffects[0]);
            potion = new Potion(potionName, totalDoses, totalVolatility, usage, allEffects);

            return potion;
        }

        /// <summary>
        /// Purges Effects that negate each other and combines effects of the same type.
        /// TODO: This function could use a rework to increase efficiency. Currently it runs in O(n^2)
        /// </summary>
        /// <param name="effects"></param>
        private List<Effect> processEffects(List<Effect> effects)
        {
            if (effects.Count == 1)
            {
                return effects;
            }
            List<Effect> processedList = new List<Effect>();
            for(int i = 0; i < effects.Count - 1; i++)
            {
                bool addCurrentEffect = true;
                Effect iEffect = effects.ElementAt(i);
                for(int k = i+1; k < effects.Count; k++)
                {
                    Effect kEffect = effects.ElementAt(k);
                    if (iEffect.isNegatedBy(kEffect))
                    {
                        effects[i] = new NoEffect();
                        effects[k] = new NoEffect();
                        addCurrentEffect = false;
                        break;
                    }
                    if (iEffect.canCombine(kEffect))
                    {
                        iEffect.combine(kEffect);
                        effects[i] = new NoEffect();
                        effects[k] = new NoEffect();
                        addCurrentEffect = true;
                        break;
                    }
                }
                if (addCurrentEffect)
                {
                    processedList.Add(iEffect);
                }
            }
            if (processedList.Count == 0)
            {
                processedList.Add(new NoEffect());
            }
            return processedList;
        }

        /// <summary>
        /// Generates a name for the potion currently being built by the PotionBuilder
        /// </summary>
        /// <param name="primaryEffect"></param>
        /// <returns></returns>
        private string generatePotionName(int doses, int volatility, Effect primaryEffect)
        {
            string name = "";

            if (!(primaryEffect.isBuff() || primaryEffect.isDebuff() || primaryEffect.isStat()))
            {
                return "Useless Potion";
            }

            name += (doses >= 5) ? "Large " : "";
            name += (doses <= 3 && doses > 1) ? "Medium " : "";
            name += (doses >= 1 && doses < 3) ? "Small " : "";

            name += (volatility >= 100) ? "Deadly" : "";
            name += (volatility >= 50 && volatility < 100) ? "Dangerous " : "";

            name += potionVessel.name + " of ";

            name += primaryEffect.getStrengthQualifier();

            return name;
        }
    }
}
