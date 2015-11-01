using UnityEngine;
using System.Collections;

namespace ItemSystem
{
    /// <summary>
    /// The base Item interface
    /// </summary>
    public interface IISObject
    {

        /// <summary>
        /// The Item's name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The Item's value in gold
        /// </summary>
        int Value { get; set; }

        /// <summary>
        /// The Item's in game icon
        /// </summary>
        Sprite Icon { get; set; }

        /// <summary>
        /// The Item's weight
        /// </summary>
        int Burden { get; set; }

        /// <summary>
        /// The Item's quality level
        /// </summary>
        ISQuality Quality { get; set; }


        // Move to other interfaces later
        // questItem flag
    }
}
