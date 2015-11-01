using UnityEngine;
using System.Collections;

namespace ItemSystem
{
    public interface IISStackable
    {
        /// <summary>
        /// The amount of Items stacked
        /// Defaults to 0
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        int Stack(int amount);

        /// <summary>
        /// The maximum stack size for an Item
        /// </summary>
        int MaxStack { get; }        
    }
}
