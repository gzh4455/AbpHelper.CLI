namespace EasyAbp.AbpHelper.Core.Models
{
    public class PropertyInfo
    {
        public string Type { get; }

        public string Name { get; }

        public int SortId { get; } = 0;

        public PropertyInfo(string type, string name)
        {
            Type = type;
            Name = name;
        }
        
        public PropertyInfo(string type, string name,int sortId)
        {
            Type = type;
            Name = name;
            SortId = sortId;
        }
    }
}