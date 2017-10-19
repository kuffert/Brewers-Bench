using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewersBench
{
    /// <summary>
    /// Interface for constructing descriptor strings for a variety of BrewerBench Classes.
    /// </summary>
    interface IDescriptor
    {
        /// <summary>
        /// Standard descriptor builder.
        /// </summary>
        /// <returns></returns>
        string defaultDescriptor();

        /// <summary>
        /// Gets the name of the Descriptable.
        /// </summary>
        /// <returns></returns>
        string getName();


    }
}