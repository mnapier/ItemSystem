using UnityEngine;
using System.Collections;
using UnityEditor;

namespace ItemSystem.Editor
{
    /// <summary>
    /// The partial class file that holds the code for displaying the Details of the current item that is active
    /// </summary>
    public partial class ISObjectDatabaseType<D, T> where D : ScriptableObjectDatabase<T> where T : ISObject, new()
    {
        /// <summary>
        /// Display the details of the selected Item
        /// </summary>
        public void DetailView()
        {
            GUILayout.BeginVertical("Box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            GUILayout.BeginVertical(GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));

            if (_tempItem != null && _showDetails)
            {
                _tempItem.OnGUI();
            }

            GUILayout.EndVertical();
            GUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));

            DisplayButtons();

            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
        }

        /// <summary>
        /// Display the buttons at the bottom of the panel
        /// </summary>
        void DisplayButtons()
        {
            if (_showDetails)
            {
                SaveButton();
                DeleteButton();
                CancelButton();
            }
            else
            {
                CreateItemButton();
            }
        }

        /// <summary>
        /// Button for creating an item
        /// </summary>
        void CreateItemButton()
        {
            if (GUILayout.Button("Create " + itemType))
            {
                _tempItem = new T();
                _showDetails = true;
            }
        }

        /// <summary>
        /// Button for saving an item to the database
        /// </summary>
        void SaveButton()
        {
            GUI.SetNextControlName("SaveButton");

            if (GUILayout.Button("Save"))
            {
                if (_selectedIndex == -1)
                {
                    Add(_tempItem);
                }
                else
                {
                    Replace(_selectedIndex, _tempItem);
                }

                _showDetails = false;
                _selectedIndex = -1;
                _tempItem = null;

                GUI.FocusControl("SaveButton");
            }
        }

        /// <summary>
        /// Button for canceling the edits to the selected item. This will return with out saving.
        /// </summary>
        void CancelButton()
        {
            if (GUILayout.Button("Cancel"))
            {
                _showDetails = false;
                _tempItem = null;
                _selectedIndex = -1;

                GUI.FocusControl("SaveButton");
            }
        }

        /// <summary>
        /// Button to delete an item from the database
        /// </summary>
        void DeleteButton()
        {
            if (_selectedIndex != -1)
            {
                if (GUILayout.Button("Delete"))
                {
                    if (EditorUtility.DisplayDialog("Delete " + _tempItem.Name + "?",
                        "Are you sure that you want to delete " + _tempItem.Name + " from the database?",
                        "Delete",
                        "Cancel"))
                    {
                        Remove(_selectedIndex);

                        _showDetails = false;
                        _tempItem = null;
                        _selectedIndex = -1;

                        GUI.FocusControl("SaveButton");
                    }
                }
            }
        }
    }
}
