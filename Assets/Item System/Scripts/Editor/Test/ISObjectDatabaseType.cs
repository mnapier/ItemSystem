using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace ItemSystem.Editor
{
    public partial class ISObjectDatabaseType<D, T> where D : ScriptableObjectDatabase<T> where T :ISObject
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

        public void OnGUI()
        {

        }

        
    }
}
