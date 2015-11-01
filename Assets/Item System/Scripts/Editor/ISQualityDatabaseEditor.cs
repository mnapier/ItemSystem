using UnityEditor;
using UnityEngine;
using System.Collections;

namespace ItemSystem.Editor
{
    /// <summary>
    /// Item System Quality Database Editor Window
    /// </summary>
    public class ISQualityDatabaseEditor : EditorWindow
    {
        const string DATABASE_FILE_NAME = @"ItemSystemQualityDatabase.asset";
        const string DATABASE_FOLDER_NAME = @"Database";
        const string DATABASE_FULL_PATH = @"Assets/" + DATABASE_FOLDER_NAME + "/" + DATABASE_FILE_NAME;

        const int SPRITE_BUTTON_SIZE = 92;

        ISQualityDatabase _qualityDatabase;
        ISQuality _selectedItem;
        Texture2D _selectedTexture;

        /// <summary>
        /// Adds a menu named "Quality Editor" to unity
        /// </summary>
        [MenuItem("ItemSystem/Database/Quality Editor %#i")]
        static void Init()
        {
            ISQualityDatabaseEditor window = EditorWindow.GetWindow<ISQualityDatabaseEditor>();
            window.minSize = new Vector2(400, 300);
            window.titleContent = new GUIContent("Quality Database");
            window.Show();
        }

        /// <summary>
        /// When the editor window is opened
        /// 1) Try to load the database
        /// 2) If it doesn't exist, create and save it
        /// </summary>
        void OnEnable()
        {
            _qualityDatabase = AssetDatabase.LoadAssetAtPath(DATABASE_FULL_PATH, typeof(ISQualityDatabase)) as ISQualityDatabase;

            if (_qualityDatabase == null)
            {
                if (!AssetDatabase.IsValidFolder("Assets/" + DATABASE_FOLDER_NAME))
                {
                    AssetDatabase.CreateFolder("Assets", DATABASE_FOLDER_NAME);
                }

                _qualityDatabase = ScriptableObject.CreateInstance<ISQualityDatabase>();
                AssetDatabase.CreateAsset(_qualityDatabase, DATABASE_FULL_PATH);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }

            _selectedItem = new ISQuality();
        }

        void OnGUI()
        {
            AddQualityToDatabase();
        }

        void AddQualityToDatabase()
        {
            // Name
            _selectedItem.Name = EditorGUILayout.TextField("Name:", _selectedItem.Name);
            
            // Sprite
            if (_selectedItem.Icon)
            {
                _selectedTexture = _selectedItem.Icon.texture;
            }
            else
            {
                _selectedTexture = null;
            }

            if (GUILayout.Button(_selectedTexture, GUILayout.Width(SPRITE_BUTTON_SIZE), GUILayout.Height(SPRITE_BUTTON_SIZE)))
            {
                int controllerID = EditorGUIUtility.GetControlID(FocusType.Passive);
                EditorGUIUtility.ShowObjectPicker<Sprite>(null, true, null, controllerID);
            }

            string commandName = Event.current.commandName;
            if (commandName == "ObjectSelectorUpdated")
            {
                _selectedItem.Icon = (Sprite) EditorGUIUtility.GetObjectPickerObject();
                Repaint();
            }

            if (GUILayout.Button("Save"))
            {
                if (_selectedItem == null)
                {
                    return;
                }

                _qualityDatabase.Add(_selectedItem);

                _selectedItem = new ISQuality();
            }
        }

    }
}
