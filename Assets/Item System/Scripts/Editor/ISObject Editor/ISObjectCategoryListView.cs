using UnityEngine;
using System.Collections;

namespace ItemSystem.Editor
{
    public partial class ISObjectCategory
    {
        // Default to nothing selected
        int _selectedIndex = -1;
        Vector2 _scrollPos = Vector2.zero;
        ISArmor _tempArmor;
        bool _createNewArmor = false;
        bool _showDetails = false;

        public void ListView(Vector2 buttonSize, int _listViewWidth)
        {
            if (_showDetails != false)
            {
                return;
            }

            _scrollPos = GUILayout.BeginScrollView(_scrollPos, "Box", GUILayout.ExpandHeight(true), GUILayout.Width(_listViewWidth));

            for (int cnt = 0; cnt < Database.Count; cnt++)
            {
                if (GUILayout.Button(Database.Get(cnt).Name, "box", GUILayout.Width(buttonSize.x), GUILayout.Height(buttonSize.y)))
                {
                    _selectedIndex = cnt;
                    _tempArmor = new ISArmor(Database.Get(cnt));
                    _createNewArmor = true;
                    _showDetails = true;
                }
            }

            GUILayout.EndScrollView();
        }
    }
}
