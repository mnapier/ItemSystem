using UnityEngine;
using System.Collections;

namespace ItemSystem
{
    public interface IISGameObject
    {
        /// <summary>
        /// Prefab for the Item in game
        /// </summary>
        GameObject Prefab { get; }
    }
}
