using UnityEngine;
using System.Collections;

namespace ItemSystem.Editor
{
    /// <summary>
    /// The partial class file that holds the code to populate and display the ListView for the given database
    /// </summary>
    public partial class ISObjectDatabaseType<D, T> where D : ScriptableObjectDatabase<T> where T : ISObject, new()
    {
        // Default to nothing selected
        int _selectedIndex = -1;
        Vector2 _scrollPos = Vector2.zero;
        T _tempItem;
        bool _showDetails = false;

        /// <summary>
        /// Lists each item in the database
        /// </summary>
        /// <param name="buttonSize">Button size</param>
        /// <param name="_listViewWidth">list view width</param>
        public void ListView(Vector2 buttonSize, int _listViewWidth)
        {
            if (_showDetails != false)
            {
                return;
            }

            _scrollPos = GUILayout.BeginScrollView(_scrollPos, "Box", GUILayout.ExpandHeight(true), GUILayout.Width(_listViewWidth));

            for (int cnt = 0; cnt < _database.Count; cnt++)
            {
                if (GUILayout.Button(_database.Get(cnt).Name, "box", GUILayout.Width(buttonSize.x), GUILayout.Height(buttonSize.y)))
                {
                    _selectedIndex = cnt;
                    _tempItem = new T();
                    _tempItem.Clone(_database.Get(cnt));
                    _showDetails = true;
                }
            }

            GUILayout.EndScrollView();
        }
    }
}
