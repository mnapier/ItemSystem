using UnityEditor;
using UnityEngine;
using System.Collections;

namespace ItemSystem.Editor
{
    /// <summary>
    /// Item System Quality Database Editor Window
    /// </summary>
    public partial class ISQualityDatabaseEditor : EditorWindow
    {
        const string DATABASE_NAME = @"ItemSystemQualityDatabase.asset";
        const string DATABASE_PATH = @"Database";
        //const string DATABASE_FULL_PATH = @"Assets/" + DATABASE_PATH + "/" + DATABASE_NAME;

        const int SPRITE_BUTTON_SIZE = 46;

        ISQualityDatabase _qualityDatabase;
        Texture2D _selectedTexture;
        /// <summary>
        /// Scroll position for the ListView
        /// </summary>
        Vector2 _scrollPos;
        /// <summary>
        /// The selected item in the ListView
        /// </summary>
        int _selectedIndex = -1;

        /// <summary>
        /// Adds a menu named "Quality Editor" to unity
        /// </summary>
        [MenuItem("ItemSystem/Database/Quality Editor %#w")]
        static void Init()
        {
            ISQualityDatabaseEditor window = EditorWindow.GetWindow<ISQualityDatabaseEditor>();
            window.minSize = new Vector2(400, 300);
            window.titleContent = new GUIContent("Quality Database");
            window.Show();
        }

        void OnEnable()
        {
            // Load the database
            if (_qualityDatabase == null)
            {
                _qualityDatabase = ISQualityDatabase.GetDatabase<ISQualityDatabase>(DATABASE_PATH, DATABASE_NAME);
            }
        }

        void OnGUI()
        {
            if (_qualityDatabase == null)
            {
                Debug.LogWarning("QualityDatabase not loaded");
                return;
            }

            ListView();

            GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));
            BottomBar();
            GUILayout.EndHorizontal();
        }

        void BottomBar()
        {
            // Count
            GUILayout.Label("Qualities: " + _qualityDatabase.Count);

            // Add button
            if (GUILayout.Button("Add"))
            {
                _qualityDatabase.Add(new ISQuality());
            }
        }

    }
}
