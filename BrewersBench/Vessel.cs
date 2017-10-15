using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewersBench
{
    /// <summary>
    /// Usage can either be single target or multi target. 
    /// </summary>
    public enum Usage
    {
        singleTarget,
        multiTarget
    };

    /// <summary>
    /// Container of the brewed potion. Determines the dosage and usage of the final potion.
    /// </summary>
    public class Vessel : IDescriptor
    {

        public string name;
        public float doses;
        public Usage usage;
        public int radius;

        /// <summary>
        /// Default Vessel Constructor
        /// </summary>
        public Vessel()
        {
            name = "Default Vessel";
            doses = 3;
            usage = Usage.singleTarget;
            radius = 0;
        }

        /// <summary>
        /// Standard Vessel Constructor
        /// </summary>
        /// <param name="name">Name of Vessel</param>
        /// <param name="doses">Number of doses this Vessel holds</param>
        /// <param name="usage">Number of targets this Vessel effects</param>
        /// <param name="radius">Radius of potion if usage is multitarget</param>
        public Vessel(string name, float doses, Usage usage, int radius)
        {
            this.name = (name == "") ? "Unnamed Vessel" : name;
            this.doses = (doses <= 0) ? 0 : doses;
            this.usage = usage;
            this.radius = (radius < 0) ? 0 : radius;
        }

        /// <summary>
        /// Constructs a descriptor based on the Vessel's name, dosage, usage, and radius.
        /// </summary>
        /// <returns></returns>
        public string defaultDescriptor()
        {
            string builder = "";
            builder += name + "\n";
            builder += "~ " + doses + " doses\n";
            switch (usage)
            {
                case (Usage.singleTarget):
                    builder += "~ Single Target\n";
                    break;

                case (Usage.multiTarget):
                    builder += "~ Multi Target\n";
                    break;
            }
            builder += "~ " + radius + " ft. radius";
            return builder;
        }
    }
}
