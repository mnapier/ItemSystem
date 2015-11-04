using UnityEngine;
using System.Collections;

namespace ItemSystem.Editor
{
    public partial class ISObjectCategory
    {
        protected ISArmorDatabase database { get; set; }

        protected string databaseName { get; set; }     // = @"ItemSystemArmorDatabase.asset";
        protected string databasePath { get; set; }     //= @"Database";

        public string DatabaseFullPath
        {
            get
            {
                return @"Assets/" + databasePath + "/" + databaseName;
            }
        }

        public void OnEnable()
        {
            // Load the databases
            if (database == null)
            {
                database = ISArmorDatabase.GetDatabase<ISArmorDatabase>(databasePath, databaseName);
            }
        }
    }
}
