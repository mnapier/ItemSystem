using UnityEngine;
using System.Collections;
using UnityEditor;

namespace ItemSystem.Editor
{
    /// <summary>
    /// The partial class file that holds the code for displaying the Details of the current item that is active
    /// </summary>
    public partial class ISObjectCategory
    {
        string itemType = "Armor";

        public void DetailView()
        {
            GUILayout.BeginVertical("Box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            GUILayout.BeginVertical(GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));

            GUILayout.EndVertical();
            GUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));

            DisplayButtons();

            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
        }

        void DisplayButtons()
        {
            if (_showDetails)
            {
                SaveButton();
                CancelButton();
            }
            else
            {
                CreateItemButton();
            }
        }

        void CreateItemButton()
        {
            if (GUILayout.Button("Create " + itemType))
            {
                _tempArmor = new ISArmor();
                _showDetails = true;
                _createNewArmor = true;
            }
        }

        void SaveButton()
        {
            GUI.SetNextControlName("SaveButton");

            if (GUILayout.Button("Save"))
            {
                // TODO save item
                //if (_selectedIndex == -1)
                //{
                //    Database.Add(_tempArmor);
                //}
                //else
                //{
                //    Database.Replace(_selectedIndex, _tempArmor);
                //}

                _showDetails = false;
                _createNewArmor = false;
                _selectedIndex = -1;
                _tempArmor = null;

                GUI.FocusControl("SaveButton");
            }
        }

        void CancelButton()
        {
            if (GUILayout.Button("Cancel"))
            {
                _showDetails = false;
                _createNewArmor = false;
                _tempArmor = null;
                _selectedIndex = -1;

                GUI.FocusControl("SaveButton");
            }
        }

        void DeleteButton()
        {
            if (_selectedIndex != -1)
            {
                if (GUILayout.Button("Delete"))
                {
                    if (EditorUtility.DisplayDialog("Delete Weapon",
                        "Are you sure that you want to delete " + Database.Get(_selectedIndex).Name + " from the database?",
                        "Delete",
                        "Cancel"))
                    {
                        Database.Remove(_selectedIndex);

                        _showDetails = false;
                        _createNewArmor = false;
                        _tempArmor = null;
                        _selectedIndex = -1;

                        GUI.FocusControl("SaveButton");
                    }
                }
            }
        }
    }
}
