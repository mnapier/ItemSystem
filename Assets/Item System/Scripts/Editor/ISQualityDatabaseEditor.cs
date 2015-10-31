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

        ISQualityDatabase _db;

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
            _db = AssetDatabase.LoadAssetAtPath(DATABASE_FULL_PATH, typeof(ISQualityDatabase)) as ISQualityDatabase;

            if (_db == null)
            {
                if (!AssetDatabase.IsValidFolder("Assets/" + DATABASE_FOLDER_NAME))
                {
                    AssetDatabase.CreateFolder("Assets", DATABASE_FOLDER_NAME);
                }

                _db = ScriptableObject.CreateInstance<ISQualityDatabase>();
                AssetDatabase.CreateAsset(_db, DATABASE_FULL_PATH);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
        }

    }
}
