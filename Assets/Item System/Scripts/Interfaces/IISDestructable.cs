using UnityEngine;
using System.Collections;

namespace ItemSystem
{
    public interface IISDestructable
    {
        /// <summary>
        /// The Item's durability
        /// </summary>
        int Durability { get; }

        /// <summary>
        /// The Item's maximum durability
        /// </summary>
        int MaxDurability { get; }

        /// <summary>
        /// Damage the item by the passed in amount
        /// </summary>
        /// <param name="amount"></param>
        void TakeDamage(int amount);

        /// <summary>
        /// Break the item once it's durability has reached 0
        /// </summary>
        void Break();

        /// <summary>
        /// Attempts to repair the item back to it's maximum durability.
        /// Has a chance of lowering the item's maximum durability on failure.
        /// </summary>
        void Repair();
    }
}
