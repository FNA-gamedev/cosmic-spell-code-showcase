using System;

namespace _Scripts.GrowthFund._Shared.Utility
{
    [AttributeUsage(AttributeTargets.Field)]
    public class JsonPathAttribute : Attribute
    {

        public JsonPathAttribute(string path)
        {
            if (!path.StartsWith("/"))
            {
                throw new ArgumentException("Path needs to start with a /");
            }
            Path = path;
        }

        public JsonPathAttribute(string path, string name) : this(path)
        {
            Name = name;
        }

        
        public string Path { get; set; }

        public string Name { get; set; }

        public bool DateTimeKindLocalSerializedTimestamp { get; set; }
    }
}