using UnityEngine;
using UnityEditor;
using System.Collections;

namespace ItemSystem.Editor
{
    public partial class ISObjectEditor : EditorWindow
    {
        const string DATABASE_NAME = @"ItemSystemWeaponDatabase.asset";
        const string DATABASE_PATH = @"Database";
        const string DATABASE_FULL_PATH = @"Assets/" + DATABASE_PATH + "/" + DATABASE_NAME;

        ISObjectDatabaseType<ISWeaponDatabase, ISWeapon> weaponDb = new ISObjectDatabaseType<ISWeaponDatabase, ISWeapon>("weaponTest.asset");
        ISWeaponDatabase _weaponDatabase;
        ISObjectCategory _armorDatabase = new ISObjectCategory();

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

        void OnEnable()
        {
            // Load the databases
            if (_weaponDatabase == null)
            {
                _weaponDatabase = ISWeaponDatabase.GetDatabase<ISWeaponDatabase>(DATABASE_PATH, DATABASE_NAME);
            }

            _armorDatabase.OnEnable();

            weaponDb.OnEnable();

            tabState = TabState.ABOUT;
        }

        void OnGUI()
        {
            ISObjectTopTabBar();

            GUILayout.BeginHorizontal();

            switch(tabState)
            {
                case TabState.WEAPON:
                    ISObjectListView();
                    ISObjectDetails();
                    break;
                case TabState.ARMOR:
                    _armorDatabase.OnGUI(buttonSize, _listViewWidth);
                    break;
                case TabState.POTION:
                    GUILayout.Label("Potion");
                    break;
                default:
                    GUILayout.Label("Default State - About" );
                    break;
            }

            
            GUILayout.EndHorizontal();

            ISObjectBottomStatusBar();
        }
    }
}
