using UnityEngine;
using System.Collections;

/// <summary>
/// The base Quality level interface
/// </summary>
public interface IISQuality {

    /// <summary>
    /// The Quality level's name
    /// </summary>
	string Name { get; set; }

    /// <summary>
    /// The Quality level's in game icon
    /// </summary>
    Sprite Icon { get; set; }
}
