using UnityEngine;
using UnityEditor;
using System.Collections;

namespace ItemSystem.Editor
{
    public partial class ISObjectDatabaseType<D, T> where D : ScriptableObjectDatabase<T> where T : ISObject, new()
    {
        /// <summary>
        /// Adds an item to the database
        /// </summary>
        /// <param name="item">Item</param>
        public void Add(T item)
        {
            _database.Items.Add(item);
            EditorUtility.SetDirty(_database);
        }

        /// <summary>
        /// Inserts an item into the database at the passed in index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, T item)
        {
            _database.Items.Insert(index, item);
            EditorUtility.SetDirty(_database);
        }

        /// <summary>
        /// Removes an item from the database
        /// </summary>
        /// <param name="item"></param>
        public void Remove(T item)
        {
            _database.Items.Remove(item);
            EditorUtility.SetDirty(_database);
        }

        /// <summary>
        /// Removes an item from the database at the passed in index
        /// </summary>
        /// <param name="index"></param>
        public void Remove(int index)
        {
            _database.Items.RemoveAt(index);
            EditorUtility.SetDirty(_database);
        }

        public void Replace(int index, T item)
        {
            _database.Items[index] = item;
            EditorUtility.SetDirty(_database);
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
