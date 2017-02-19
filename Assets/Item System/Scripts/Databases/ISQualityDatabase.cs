namespace ItemSystem
{
    public class ISQualityDatabase : ScriptableObjectDatabase<ISQuality>
    {
        /**
         * TODO have a method that checks to see if we have a database created.
         * If we do not, then create it and add at least one entry.
         */

        public int GetIndex(string name)
        {
            return _items.FindIndex(a => a.Name == name);
        }
    }
}
