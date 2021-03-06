﻿using UnityEngine;
using UnityEditor;
using System.Collections;

namespace ItemSystem.Editor
{
    public partial class ISQualityDatabaseEditor
    {
        /// <summary>
        /// List all of the stored qualities in the database
        /// </summary>
        void ListView()
        {
            _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos, GUILayout.ExpandHeight(true));

            DisplayQualities();

            EditorGUILayout.EndScrollView();
        }

        void DisplayQualities()
        {
            for (int cnt = 0; cnt < _qualityDatabase.Count; cnt++)
            {
                GUILayout.BeginHorizontal("Box");

                // Sprite
                if (_qualityDatabase.Get(cnt).Icon)
                {
                    _selectedTexture = _qualityDatabase.Get(cnt).Icon.texture;
                }
                else
                {
                    _selectedTexture = null;
                }

                if (GUILayout.Button(_selectedTexture, GUILayout.Width(SPRITE_BUTTON_SIZE), GUILayout.Height(SPRITE_BUTTON_SIZE)))
                {
                    int controllerID = EditorGUIUtility.GetControlID(FocusType.Passive);
                    EditorGUIUtility.ShowObjectPicker<Sprite>(null, true, null, controllerID);
                    _selectedIndex = cnt;
                }

                string commandName = Event.current.commandName;
                if (commandName == "ObjectSelectorUpdated")
                {
                    if (_selectedIndex != -1)
                    {
                        _qualityDatabase.Get(_selectedIndex).Icon = (Sprite)EditorGUIUtility.GetObjectPickerObject();
                        //_selectedIndex = -1;
                    }

                    Repaint();
                }

                GUILayout.BeginVertical();

                // Name
                _qualityDatabase.Get(cnt).Name = GUILayout.TextField(_qualityDatabase.Get(cnt).Name);

                // Delete button
                if (GUILayout.Button("X", GUILayout.Width(30), GUILayout.Height(25)))
                {
                    if (EditorUtility.DisplayDialog("Delete Quality",
                        "Are you sure that you want to delete " + _qualityDatabase.Get(cnt).Name + " from the database?",
                        "Delete",
                        "Cancel"))
                    {
                        _qualityDatabase.Remove(cnt);
                    }
                }

                GUILayout.EndVertical();
                GUILayout.EndHorizontal();
            }
        }
    }
}
