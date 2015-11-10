#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

/// <summary>
/// Generic database that will store items to a ScriptableObject. ScriptableObjects can be read from at runtime,
/// but not written or added to. They are immutable.
/// </summary>
/// <typeparam name="T"></typeparam>
public class ScriptableObjectDatabase<T> : ScriptableObject where T : class
{
    [SerializeField]
    protected List<T> database = new List<T>();

#if UNITY_EDITOR
    /// <summary>
    /// Adds an item to the database
    /// </summary>
    /// <param name="item">Item</param>
    public void Add(T item)
    {
        database.Add(item);
        EditorUtility.SetDirty(this);
    }

    /// <summary>
    /// Inserts an item into the database at the passed in index
    /// </summary>
    /// <param name="index"></param>
    /// <param name="item"></param>
    public void Insert(int index, T item)
    {
        database.Insert(index, item);
        EditorUtility.SetDirty(this);
    }

    /// <summary>
    /// Removes an item from the database
    /// </summary>
    /// <param name="item"></param>
    public void Remove(T item)
    {
        database.Remove(item);
        EditorUtility.SetDirty(this);
    }

    /// <summary>
    /// Removes an item from the database at the passed in index
    /// </summary>
    /// <param name="index"></param>
    public void Remove(int index)
    {
        database.RemoveAt(index);
        EditorUtility.SetDirty(this);
    }
#endif

    public int Count
    {
        get
        {
            return database.Count;
        }
    }

    public T Get(int index)
    {
        return database.ElementAt(index);
    }
#if UNITY_EDITOR
    public void Replace(int index, T item)
    {
        database[index] = item;
        EditorUtility.SetDirty(this);
    }

    /// <summary>
    /// Return a reference to the database
    /// </summary>
    /// <typeparam name="U"></typeparam>
    /// <param name="dbPath">database path</param>
    /// <param name="dbName">database name</param>
    /// <returns>the database</returns>
    public static U GetDatabase<U>(string dbPath, string dbName) where U : ScriptableObject
    {
        string dbFullPath = @"Assets/" + dbPath + "/" + dbName;


        U db = AssetDatabase.LoadAssetAtPath(dbFullPath, typeof(U)) as U;

        if (db == null)
        {
            // Check to see if the folder exists
            if (!AssetDatabase.IsValidFolder(@"Assets/" + dbPath))
            {
                AssetDatabase.CreateFolder(@"Assets", dbPath);
            }

            // Create the database and refresh the AssetDatabase
            db = ScriptableObject.CreateInstance<U>();
            AssetDatabase.CreateAsset(db, dbFullPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        return db;
    }
#endif
}
