using UnityEngine;
using System.Collections;

namespace ItemSystem.Editor
{
    public partial class ISObjectCategory
    {
        public void DetailView()
        {
            GUILayout.BeginVertical("Box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            GUILayout.BeginVertical(GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));

            GUILayout.EndVertical();
            GUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));

            //DisplayButtons();

            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
        }
    }
}
