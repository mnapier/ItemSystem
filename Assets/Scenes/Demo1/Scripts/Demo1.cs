﻿using UnityEngine;
using System.Collections;
using ItemSystem;

// Connect to the database
// Spawn items from the database
[DisallowMultipleComponent]
public class Demo1 : MonoBehaviour {

    public ISWeaponDatabase database;

    void OnGUI()
    {
        for (int cnt = 0; cnt < database.Count; cnt++)
        {
            if (GUILayout.Button("Spawn " + database.Get(cnt).Name))
            {
                Spawn(cnt);
            }
        }
    }

    void Spawn(int index)
    {
        ISWeapon isw = database.Get(index);

        GameObject weapon = Instantiate(isw.Prefab);

        weapon.name = isw.Name;
    }

}
