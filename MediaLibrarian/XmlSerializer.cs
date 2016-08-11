using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace MediaLibrarian
{
    [Serializable]
    public class Category
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Category() 
        {
            this.Name = Name;
            this.Type = Type;
        }
    }
}
