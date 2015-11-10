using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace ItemSystem.Editor
{
    public class ISObjectDatabaseType<D, T> where D : ScriptableObjectDatabase<T> where T :ISObject
    {
        [SerializeField]
        D _database;

        [SerializeField]
        string _databaseName;

        [SerializeField]
        string _databasePath = @"Database";

        public ISObjectDatabaseType(string name)
        {
            _databaseName = name;
        }

        public void OnEnable()
        {
            if (_database == null)
            {
                LoadDatabase();
            }
        }

        void LoadDatabase()
        {
            string dbFullPath = @"Assets/" + _databasePath + "/" + _databaseName;

            _database = AssetDatabase.LoadAssetAtPath(dbFullPath, typeof(D)) as D;

            if (_database == null)
            {
                CreateDatabase(dbFullPath);
            }
        }

        void CreateDatabase(string dbFullPath)
        {
            // Check to see if the folder exists
            if (!AssetDatabase.IsValidFolder(@"Assets/" + _databasePath))
            {
                AssetDatabase.CreateFolder(@"Assets", _databasePath);
            }

            // Create the database and refresh the AssetDatabase
            _database = ScriptableObject.CreateInstance<D>();
            AssetDatabase.CreateAsset(_database, dbFullPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}
