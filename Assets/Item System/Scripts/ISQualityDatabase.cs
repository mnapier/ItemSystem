using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace ItemSystem
{
    public class ISQualityDatabase : ScriptableObjectDatabase<ISQuality>
    {
        public int GetIndex(string name)
        {
            return database.FindIndex(a => a.Name == name);
        }
    }
}
