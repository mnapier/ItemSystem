using UnityEngine;
using System.Collections;

namespace ItemSystem
{
    public interface IISWeapon
    {
        /// <summary>
        /// The minimum amount of damage the weapon can do
        /// </summary>
        int MinDamage { get; set; }

        /// <summary>
        /// Returns the amount of damage the weapon does on attack
        /// </summary>
        /// <returns></returns>
        int Attack();
    }
}
