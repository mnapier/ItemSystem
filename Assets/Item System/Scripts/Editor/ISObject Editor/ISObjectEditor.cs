using UnityEngine;
using UnityEditor;
using System.Collections;

namespace ItemSystem.Editor
{
    public partial class ISObjectEditor : EditorWindow
    {

        /// <summary>
        /// Adds a menu named "Item System Editor" to unity
        /// Opens with CTRL + SHIFT + I
        /// </summary>
        [MenuItem("ItemSystem/Database/Item System Editor %#i")]
        static void Init()
        {
            ISObjectEditor window = EditorWindow.GetWindow<ISObjectEditor>();
            window.minSize = new Vector2(800, 600);
            window.titleContent = new GUIContent("Item System");
            window.Show();
        }

        void OnEnable()
        {

        }

        void OnGUI()
        {
            ISObjectTopTabBar();

            GUILayout.BeginHorizontal();
            ISObjectListView();
            ISObjectDetails();
            GUILayout.EndHorizontal();

            ISObjectBottomStatusBar();
        }
    }
}
