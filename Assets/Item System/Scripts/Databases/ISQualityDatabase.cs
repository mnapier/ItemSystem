namespace ItemSystem
{
    public class ISQualityDatabase : ScriptableObjectDatabase<ISQuality>
    {
        public int GetIndex(string name)
        {
            return _items.FindIndex(a => a.Name == name);
        }
    }
}
