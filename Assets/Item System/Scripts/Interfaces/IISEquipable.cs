using UnityEngine;
using System.Collections;

namespace ItemSystem
{
    public interface IISEquipable
    {
        /// <summary>
        /// The Item's equipment slot
        /// </summary>
        ISEquipmentSlot EquipmentSlot { get; }

        /// <summary>
        /// Equips or unequips the item
        /// </summary>
        /// <returns></returns>
        bool Equip();
    }
}
