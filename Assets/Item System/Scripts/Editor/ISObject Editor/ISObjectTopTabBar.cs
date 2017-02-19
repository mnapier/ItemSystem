using UnityEngine;
using System.Collections;

namespace ItemSystem.Editor
{
    public partial class ISObjectEditor
    {
        /// <summary>
        /// List of different tabs for our editor window
        /// </summary>
        enum TabState
        {
            WEAPON,
            ARMOR,
            POTION,
            QUALITY
        }

        /// <summary>
        /// Track what tab we have selected
        /// </summary>
        TabState tabState;

        /// <summary>
        /// The display format for the tab bar
        /// </summary>
        void ISObjectTopTabBar()
        {
            GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));

            WeaponTab();
            ArmorTab();
            PotionTab();
            QualityTab();

            GUILayout.EndHorizontal();
        }

        /// <summary>
        /// Weapons tab
        /// </summary>
        void WeaponTab()
        {
            if (GUILayout.Button("Weapons"))
            {
                tabState = TabState.WEAPON;
            }
        }

        /// <summary>
        /// Armor tab
        /// </summary>
        void ArmorTab()
        {
            if (GUILayout.Button("Armor"))
            {
                tabState = TabState.ARMOR;
            }
        }

        /// <summary>
        /// Potions tab
        /// </summary>
        void PotionTab()
        {
            if (GUILayout.Button("Potions"))
            {
                tabState = TabState.POTION;
            }
        }

        /// <summary>
        /// Quality tab
        /// </summary>
        void QualityTab()
        {
            if (GUILayout.Button("Quality"))
            {
                tabState = TabState.QUALITY;
            }
        }
    }
}
