using UnityEngine;
using System.Collections;
using UnityEditor;

namespace ItemSystem.Editor
{
    public partial class ISObjectEditor
    {
        Vector2 _scrollPos = Vector2.zero;
        int _listViewWidth = 200;
        int _listViewButtonWidth = 190;
        int _listViewButtongHeight = 25;

        int _selectedIndex = -1;

        void ISObjectListView()
        {
            _scrollPos = GUILayout.BeginScrollView(_scrollPos, "Box", GUILayout.ExpandHeight(true), GUILayout.Width(_listViewWidth));

            for (int cnt = 0; cnt < _weaponDatabase.Count; cnt++)
            {
                if (GUILayout.Button(_weaponDatabase.Get(cnt).Name, "box", GUILayout.Width(_listViewButtonWidth), GUILayout.Height(_listViewButtongHeight)))
                {
                    _selectedIndex = cnt;
                    _tempWeapon = new ISWeapon(_weaponDatabase.Get(cnt));
                    _showNewWeaponDetails = true;
                    _state = DisplayState.WEAPON_DETAILS;
                }
            }

            GUILayout.EndScrollView();
        }
    }
}
