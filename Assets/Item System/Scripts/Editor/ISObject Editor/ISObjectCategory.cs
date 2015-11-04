using UnityEngine;
using System.Collections;

namespace ItemSystem.Editor
{
    public partial class ISObjectCategory
    {
        const string DATABASE_PATH = @"Database";

        protected ISArmorDatabase Database { get; set; }

        protected string DatabaseName { get; set; }     // = @"ItemSystemArmorDatabase.asset";

        public ISObjectCategory()
        {
            DatabaseName = @"ItemSystemArmorDatabase.asset";
        }

        public string DatabaseFullPath
        {
            get
            {
                return @"Assets/" + DATABASE_PATH + "/" + DatabaseName;
            }
        }

        public void OnEnable()
        {
            // Load the databases
            if (Database == null)
            {
                Database = ISArmorDatabase.GetDatabase<ISArmorDatabase>(DATABASE_PATH, DatabaseName);
            }
        }
    }
}
