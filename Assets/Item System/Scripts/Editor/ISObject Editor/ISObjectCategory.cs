using UnityEngine;
using System.Collections;

namespace ItemSystem.Editor
{
    /// <summary>
    /// The partial class file that holds all of the generic variables and methods for the rest of the class
    /// </summary>
    public partial class ISObjectCategory
    {
        const string DATABASE_PATH = @"Database";

        protected ISArmorDatabase Database { get; set; }

        protected string DatabaseName { get; set; }     // = @"ItemSystemArmorDatabase.asset";

        /// <summary>
        /// Initializes a new instance of the <see cref="ISObjectCategory"/> class
        /// </summary>
        public ISObjectCategory()
        {
            DatabaseName = @"ItemSystemArmorDatabase.asset";
        }

        /// <summary>
        /// Gets the full path to the database
        /// </summary>
        /// <value>The database full path</value>
        public string DatabaseFullPath
        {
            get
            {
                return @"Assets/" + DATABASE_PATH + "/" + DatabaseName;
            }
        }

        /// <summary>
        /// Raises the enable event.
        /// Call this from a Unity OnEnable() method so this class is ready to go.
        /// </summary>
        public void OnEnable()
        {
            // Load the databases
            if (Database == null)
            {
                Database = ISArmorDatabase.GetDatabase<ISArmorDatabase>(DATABASE_PATH, DatabaseName);
            }
        }

        public void OnGUI(Vector2 buttonSize, int _listViewWidt)
        {
            ListView(buttonSize, _listViewWidt);
            DetailView();
        }
    }
}
