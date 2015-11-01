using UnityEngine;
using System.Collections;

namespace ItemSystem
{
    public interface IISEquipmentSlot
    {
        /// <summary>
        /// The equipment slot's name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The quipment slow's icon
        /// </summary>
        Sprite Icon { get; set; }
    }
}
