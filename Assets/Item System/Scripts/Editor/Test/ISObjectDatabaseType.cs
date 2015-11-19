using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace ItemSystem.Editor
{
    public partial class ISObjectDatabaseType<D, T> where D : ScriptableObjectDatabase<T> where T : ISObject, new()
    {
        [SerializeField]
        D _database;

        [SerializeField]
        string _databaseName;

        [SerializeField]
        string _databasePath = @"Database";

        public string itemType = "Item";

        public ISObjectDatabaseType(string name)
        {
            _databaseName = name;
        }

        public void OnEnable(string itemType)
        {
            this.itemType = itemType;
            if (_database == null)
            {
                LoadDatabase();
            }
        }

        /// <summary>
        /// Display the requested information for this database
        /// </summary>
        /// <param name="buttonSize">Button size</param>
        /// <param name="_listViewWidt">List view width</param>
        public void OnGUI(Vector2 buttonSize, int _listViewWidt)
        {
            ListView(buttonSize, _listViewWidt);
            DetailView();
        }


    }
}
