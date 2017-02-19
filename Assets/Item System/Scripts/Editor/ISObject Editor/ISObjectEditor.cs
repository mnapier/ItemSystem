using UnityEngine;
using UnityEditor;
using System.Collections;

namespace ItemSystem.Editor
{
    public partial class ISObjectEditor : EditorWindow
    {
        // The databases that we will be using
        ISObjectDatabaseType<ISWeaponDatabase, ISWeapon> weaponDb = new ISObjectDatabaseType<ISWeaponDatabase, ISWeapon>("weaponTest.asset");
        ISObjectDatabaseType<ISArmorDatabase, ISArmor> armorDb = new ISObjectDatabaseType<ISArmorDatabase, ISArmor>("armorTest.asset");
        ISObjectDatabaseType<ISQualityDatabase, ISQuality> qualityDb = new ISObjectDatabaseType<ISQualityDatabase, ISQuality>("ItemSystemQualityDatabase.asset");

        int _listViewWidth = 200;
        Vector2 buttonSize = new Vector2(190, 25);

        /// <summary>
        /// Adds a menu named "Item System Editor" to unity
        /// Opens with CTRL + SHIFT + I
        /// </summary>
        [MenuItem("ItemSystem/Database/Item System Editor %#i")]
        static void Init()
        {
            ISObjectEditor window = EditorWindow.GetWindow<ISObjectEditor>();
            window.minSize = new Vector2(800, 600);
            window.titleContent = new GUIContent("Item System");
            window.Show();
        }

        /// <summary>
        /// Make sure that things are setup as soon as this editor starts up
        /// </summary>
        void OnEnable()
        {
            weaponDb.OnEnable("Weapon");
            armorDb.OnEnable("Armor");

            tabState = TabState.QUALITY;
        }

        void OnGUI()
        {
            ISObjectTopTabBar();

            GUILayout.BeginHorizontal();

            switch(tabState)
            {
                case TabState.WEAPON:
                    weaponDb.OnGUI(buttonSize, _listViewWidth);
                    break;
                case TabState.ARMOR:
                    armorDb.OnGUI(buttonSize, _listViewWidth);
                    break;
                case TabState.POTION:
                    GUILayout.Label("Potion");
                    break;
                default:
                    GUILayout.Label("Default State - Quality" );
                    break;
            }

            
            GUILayout.EndHorizontal();

            ISObjectBottomStatusBar();
        }
    }
}
