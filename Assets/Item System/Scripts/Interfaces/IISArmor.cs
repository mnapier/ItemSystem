using UnityEngine;
using System.Collections;

namespace ItemSystem
{
    public interface IISArmor
    {
        /// <summary>
        /// Holds the minimum and maximum Armor values
        /// </summary>
        Vector2 Armor { get; set; }
    }
}
