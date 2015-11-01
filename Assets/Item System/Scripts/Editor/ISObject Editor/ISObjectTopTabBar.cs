using UnityEngine;
using System.Collections;

namespace ItemSystem.Editor
{
    public partial class ISObjectEditor
    {
        void ISObjectTopTabBar()
        {
            GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));

            WeaponTab();
            ArmorTab();

            GUILayout.Button("Potions");

            AboutTab();

            GUILayout.EndHorizontal();
        }

        void WeaponTab()
        {
            GUILayout.Button("Weapons");
        }

        void ArmorTab()
        {
            GUILayout.Button("Armor");
        }

        void AboutTab()
        {
            GUILayout.Button("About");
        }
    }
}
