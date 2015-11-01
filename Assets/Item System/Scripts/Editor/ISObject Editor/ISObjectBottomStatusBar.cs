using UnityEngine;
using System.Collections;

namespace ItemSystem.Editor
{
    public partial class ISObjectEditor
    {
        void ISObjectBottomStatusBar()
        {
            GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));

            GUILayout.Label("Status Bar View");

            GUILayout.EndHorizontal();
        }
    }
}
