using UnityEngine;
using System.Collections;

namespace ItemSystem.Editor
{
    public partial class ISObjectEditor
    {
        ISWeapon _tempWeapon = new ISWeapon();
        bool _showNewWeaponDetails = false;

        void ISObjectDetails()
        {
            GUILayout.BeginVertical("Box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            GUILayout.BeginHorizontal(GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));

            if (_showNewWeaponDetails)
            {
                DisplayNewWeapon();
            }

            GUILayout.EndHorizontal();
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
                }
            }
            else
            {
                if (GUILayout.Button("Save"))
                {
                    _showNewWeaponDetails = false;
                    _tempWeapon = null;
                }

                if (GUILayout.Button("Cancel"))
                {
                    _showNewWeaponDetails = false;
                    _tempWeapon = null;
                }
            }
        }
    }
}
