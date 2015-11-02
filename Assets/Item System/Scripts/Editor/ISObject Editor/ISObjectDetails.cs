﻿using UnityEngine;
using UnityEditor;
using System.Collections;

namespace ItemSystem.Editor
{
    public partial class ISObjectEditor
    {
        enum DisplayState
        {
            NONE,
            WEAPON_DETAILS
        }

        ISWeapon _tempWeapon = new ISWeapon();
        bool _showNewWeaponDetails = false;
        DisplayState _state = DisplayState.NONE;

        void ISObjectDetails()
        {
            GUILayout.BeginVertical("Box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            GUILayout.BeginVertical(GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));

            EditorGUILayout.LabelField("State: " + _state);

            switch(_state)
            {
                case DisplayState.WEAPON_DETAILS:
                    if (_showNewWeaponDetails)
                    {
                        DisplayNewWeapon();
                    }

                    break;
                default:
                    break;
            }

            

            GUILayout.EndVertical();
            GUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));

            DisplayButtons();

            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
        }

        void DisplayNewWeapon()
        {
            _tempWeapon.OnGUI();
        }

        void DisplayButtons()
        {
            if (!_showNewWeaponDetails)
            {
                if (GUILayout.Button("Create Weapon"))
                {
                    _tempWeapon = new ISWeapon();
                    _showNewWeaponDetails = true;
                    _state = DisplayState.WEAPON_DETAILS;
                }
            }
            else
            {
                if (GUILayout.Button("Save"))
                {
                    if (_selectedIndex == -1)
                    {
                        _weaponDatabase.Add(_tempWeapon);
                    }
                    else
                    {
                        _weaponDatabase.Replace(_selectedIndex, _tempWeapon);
                    }

                    _showNewWeaponDetails = false;
                    _state = DisplayState.NONE;
                    _tempWeapon = null;
                    _selectedIndex = -1;
                }

                if (GUILayout.Button("Cancel"))
                {
                    _showNewWeaponDetails = false;
                    _state = DisplayState.NONE;
                    _tempWeapon = null;
                    _selectedIndex = -1;
                }
            }
        }
    }
}
