using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewersBench
{
    /// <summary>
    /// A Base, Ingredient, or Catalyst behavior applied to the final Potion. 
    /// </summary>
    public abstract class Effect
    {
        public string name;

        /// <summary>
        /// Determines if the Effect is negated by the given effect.
        /// </summary>
        /// <param name="effect">The Effect to check for negation</param>
        /// <returns>True if negated, false otherwise.</returns>
        public abstract bool isNegatedBy(Effect effect);

        /// <summary>
        /// Returns whether this class is a stat class.
        /// </summary>
        /// <returns></returns>
        public abstract bool isStat();

        /// <summary>
        /// Returns whether this class is a buff class.
        /// </summary>
        /// <returns></returns>
        public abstract bool isBuff();

        /// <summary>
        /// Returns whether this class is a debuff class.
        /// </summary>
        /// <returns></returns>
        public abstract bool isDebuff();

        /// <summary>
        /// Returns whether this Effect can combine with the given effect.
        /// </summary>
        /// <param name="effect"></param>
        /// <returns></returns>
        public abstract bool canCombine(Effect effect);


        /// <summary>
        /// Returns this Effect combined with the given effect.
        /// </summary>
        /// <param name="effect"></param>
        /// <returns></returns>
        public abstract void combine(Effect effect);

        /// <summary>
        /// Returns a string qualifier of the strength of the Effect.
        /// </summary>
        /// <returns></returns>
        public abstract string getStrengthQualifier();

        /// <summary>
        /// Determines whether the given buff and debuff are opposites.
        /// </summary>
        /// <param name="buff">The buff to compare</param>
        /// <param name="debuff">The debuff to compare</param>
        /// <returns></returns>
        protected bool areBuffAndDebuffOpposite(ImbiberBuff buff, ImbiberDebuff debuff)
        {
            return ((buff == ImbiberBuff.Shielding && debuff == ImbiberDebuff.Weakness) ||
                   (buff == ImbiberBuff.Barrier && debuff == ImbiberDebuff.Dullness) ||
                   (buff == ImbiberBuff.Speed && debuff == ImbiberDebuff.Slowness) ||
                   (buff == ImbiberBuff.Aim && debuff == ImbiberDebuff.Blindness));
        }
    }

    /// <summary>
    /// A type of Effect that does nothing.
    /// </summary>
    public class NoEffect : Effect
    {
        /// <summary>
        /// Default No Effect Constructor
        /// </summary>
        public NoEffect()
        {
            name = "No Effect";
        }

        /// <summary>
        /// NoEffect cannot be negated.
        /// </summary>
        /// <param name="effect"></param>
        /// <returns></returns>
        public override bool isNegatedBy(Effect effect)
        {
            return false;
        }

        /// <summary>
        /// NoEffect is not a stat mod. 
        /// </summary>
        /// <returns></returns>
        public override bool isStat()
        {
            return false;
        }

        /// <summary>
        /// NoEffect is not a buff.
        /// </summary>
        /// <returns></returns>
        public override bool isBuff()
        {
            return false;
        }

        /// <summary>
        /// NoEffect is not a debuff.
        /// </summary>
        /// <returns></returns>
        public override bool isDebuff()
        {
            return false;
        }

        /// <summary>
        /// NoEffect cannot be combined.
        /// </summary>
        /// <param name="effect"></param>
        /// <returns></returns>
        public override bool canCombine(Effect effect)
        {
            return false;
        }

        /// <summary>
        /// Combining with a NoEffect produces the same NoEffect.
        /// </summary>
        /// <param name="effect"></param>
        /// <returns></returns>
        public override void combine(Effect effect)
        {

        }

        /// <summary>
        /// NoEffect has no Strength.
        /// </summary>
        /// <returns></returns>
        public override string getStrengthQualifier()
        {
            return "";
        }

    }

    /// <summary>
    /// The stats a StatEffect can modify.
    /// </summary>
    public enum ImbiberStat
    {
        Health,
        Stamina,
        Attack,
        Defense
    };

    /// <summary>
    /// A type of Effect that effects the Imbiber's stats.
    /// </summary>
    public class StatEffect : Effect
    {
        ImbiberStat affectedStat;
        int statModifier;

        /// <summary>
        /// Standard StatEffect Constructor
        /// </summary>
        /// <param name="name">Name of Stat Effect</param>
        /// <param name="affectedStat">The Imbiber Stat that this Effect will modify</param>
        /// <param name="statModifier">How much to modify the stat by</param>
        /// <param name="negatedEffect">The Effect that this Effect negates/is negated by</param>
        public StatEffect(string name, ImbiberStat affectedStat, int statModifier)
        {
            this.name = (name == "") ? "Unnamed Stat Effect" : name;
            this.affectedStat = affectedStat;
            this.statModifier = statModifier;
        }

        /// <summary>
        /// Retrieves this Effect's affected stat
        /// </summary>
        /// <returns></returns>
        public ImbiberStat getAffectedStat()
        {
            return affectedStat;
        }

        /// <summary>
        /// StatEffect is a stat mod. 
        /// </summary>
        /// <returns></returns>
        public override bool isStat()
        {
            return true;
        }

        /// <summary>
        /// StatEffects cannot be negated, only combined. 
        /// </summary>
        /// <param name="effect"></param>
        /// <returns></returns>
        public override bool isNegatedBy(Effect effect)
        {
            return false;
        }

        /// <summary>
        /// StatEffects are not buffs.
        /// </summary>
        /// <returns></returns>
        public override bool isBuff()
        {
            return false;
        }

        /// <summary>
        /// StatsEffects are not debuffs.
        /// </summary>
        /// <returns></returns>
        public override bool isDebuff()
        {
            return false;
        }

        /// <summary>
        /// If the given Effect is a StatEffect and affects the same stat, it can be combined.
        /// </summary>
        /// <param name="effect"></param>
        /// <returns></returns>
        public override bool canCombine(Effect effect)
        {
            return (effect.isStat() && (((StatEffect)effect).getAffectedStat() == affectedStat));
        }

        /// <summary>
        /// Combining with a StatEffect increases this Effects statModifier by the given StatEffect's statModifier.
        /// </summary>
        /// <param name="effect"></param>
        /// <returns></returns>
        public override void combine(Effect effect)
        {
            statModifier += ((StatEffect)effect).statModifier;
        }

        /// <summary>
        /// Constructs a string qualifier based on the statModifier and affect Stat.
        /// </summary>
        /// <returns></returns>
        public override string getStrengthQualifier()
        {
            string rs = "";
            rs += (statModifier >= 100) ? "Immense " : "";
            rs += (statModifier >= 50 && statModifier < 100) ? "Major " : "";
            rs += (statModifier >= 1 && statModifier < 50) ? "Minor " : "";
            rs += affectedStat.ToString();
            
            return rs;
        }
    }

    /// <summary>
    /// The buffs that can be applied to the imbiber.
    /// </summary>
    public enum ImbiberBuff
    {
        Shielding,
        Barrier,
        Speed,
        Aim
    };

    /// <summary>
    /// A type of Effect that grants the imbiber a buff.
    /// </summary>
    public class BuffEffect : Effect
    {
        protected ImbiberBuff buff;
        int intensity;

        /// <summary>
        /// Standard ImbiberBuff Constructor
        /// </summary>
        /// <param name="name">Nqame of Buff Effect</param>
        /// <param name="buff">The ImbiberBuff that this Effect will apply</param>
        /// <param name="intensity">The strength of the buff</param>
        /// <param name="negatedEffect">The Effect that this Effect negates/is negated by</param>
        protected BuffEffect(string name, ImbiberBuff buff, int intensity)
        {
            this.name = (name == "") ? "Unnamed Buff Effect" : name;
            this.buff = buff;
            this.intensity = (intensity < 1) ? 1 : intensity;
        }

        /// <summary>
        /// Retrieves this Effect's buff.
        /// </summary>
        /// <returns></returns>
        public ImbiberBuff getBuff()
        {
            return buff;
        }

        /// <summary>
        /// BuffEffect is not a stat mod. 
        /// </summary>
        /// <returns></returns>
        public override bool isStat()
        {
            return false;
        }

        /// <summary>
        /// Buff Effects can be negated by a Debuff Effect of opposing type.
        /// </summary>
        /// <param name="effect"></param>
        /// <returns></returns>
        public override bool isNegatedBy(Effect effect)
        {
            return (effect.isDebuff() && areBuffAndDebuffOpposite(buff, ((DebuffEffect)effect).getDebuff()));
        }

        /// <summary>
        /// BuffEffects are buffs.
        /// </summary>
        /// <returns></returns>
        public override bool isBuff()
        {
            return true;
        }

        /// <summary>
        /// BuffEffects are not debuffs.
        /// </summary>
        /// <returns></returns>
        public override bool isDebuff()
        {
            return false;
        }

        /// <summary>
        /// If the given Effect is a BuffEffect and affects the same buff, they can be combined.
        /// </summary>
        /// <param name="effect"></param>
        /// <returns></returns>
        public override bool canCombine(Effect effect)
        {
            return (effect.isBuff() && (((BuffEffect)effect).getBuff() == buff));
        }

        /// <summary>
        /// Combining with a BuffEffect increases this Effects intensity by the given BuffEffect's intensity.
        /// </summary>
        /// <param name="effect"></param>
        public override void combine(Effect effect)
        {
            intensity += ((BuffEffect)effect).intensity;
        }

        /// <summary>
        /// Constructs a string qualifier based on the intensity and buff.
        /// </summary>
        /// <returns></returns>
        public override string getStrengthQualifier()
        {
            string rs = "";
            rs += (intensity == 3) ? "Immense " : "";
            rs += (intensity == 2) ? "Major " : "";
            rs += (intensity == 1) ? "Minor " : "";
            rs += buff.ToString();

            return rs;
        }

    }

    /// <summary>
    /// The Debuffs that can be applled to the imbiber.
    /// </summary>
    public enum ImbiberDebuff
    {
        Weakness,
        Dullness,
        Slowness,
        Blindness
    };

    /// <summary>
    /// A type of Effect that applies a debuff on the imbiber.
    /// </summary>
    public class DebuffEffect : Effect
    {
        protected ImbiberDebuff debuff;
        int intensity;

        /// <summary>
        /// Standard DebuffEffect Constructor
        /// </summary>
        public DebuffEffect(string name, ImbiberDebuff debuff, int intensity)
        {
            this.name = (name == "") ? "Unnamed Debuff Effect" : name;
            this.debuff = debuff;
            this.intensity = (intensity < 1) ? 1 : intensity;
        }

        /// <summary>
        /// Retrieves this Effect's debuff.
        /// </summary>
        /// <returns></returns>
        public ImbiberDebuff getDebuff()
        {
            return debuff;
        }

        /// <summary>
        /// DebuffEffect is not a stat mod. 
        /// </summary>
        /// <returns></returns>
        public override bool isStat()
        {
            return false;
        }

        /// <summary>
        /// Buff Effects can be negated by a Debuff Effect of opposing type.
        /// </summary>
        /// <param name="effect"></param>
        /// <returns></returns>
        public override bool isNegatedBy(Effect effect)
        {
            return (effect.isBuff() && areBuffAndDebuffOpposite(((BuffEffect)effect).getBuff(), debuff));
        }

        /// <summary>
        /// DebuffEffects are not buffs.
        /// </summary>
        /// <returns></returns>
        public override bool isBuff()
        {
            return false;
        }

        /// <summary>
        /// DebuffEffects are debuffs.
        /// </summary>
        /// <returns></returns>
        public override bool isDebuff()
        {
            return true;
        }

        /// <summary>
        /// If the given Effect is a DebuffEffect and affects the same debuff, they can be combined.
        /// </summary>
        /// <param name="effect"></param>
        /// <returns></returns>
        public override bool canCombine(Effect effect)
        {
            return (effect.isDebuff() && (((DebuffEffect)effect).getDebuff() == debuff));
        }

        /// <summary>
        /// Combining with a DebuffEffect increases this Effects intensity by the given DebuffEffect's intensity.
        /// </summary>
        /// <param name="effect"></param>
        public override void combine(Effect effect)
        {
            intensity += ((DebuffEffect)effect).intensity;
        }

        /// <summary>
        /// Constructs a string qualifier based on the intensity and debuff.
        /// </summary>
        /// <returns></returns>
        public override string getStrengthQualifier()
        {
            string rs = "";
            rs += (intensity == 3) ? "Destructive " : "";
            rs += (intensity == 2) ? "Debilitating " : "";
            rs += (intensity == 1) ? "Slight " : "";
            rs += debuff.ToString();

            return rs;
        }
    }
}
