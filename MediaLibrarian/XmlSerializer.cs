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

/*    [Serializable]
    public class LibraryHeaders
    {
        public XmlSerializer formatter = new XmlSerializer(typeof(LibraryHeaders));
        public string LibName { get; set; }
        public List<Category> LibCategory { get; set; }
                        
        public LibraryHeaders(){}
        public LibraryHeaders(string LibName, List<Category> LibCategory)
        {
            this.LibName = LibName;
            this.LibCategory = LibCategory;
        }
        public void Serialize(string Name) 
        {
            using (FileStream file = new FileStream(Environment.CurrentDirectory+"\\Libraries\\" + Name + ".xml", FileMode.OpenOrCreate))
            { 
                formatter.Serialize(file, this);
            }
        }
        public List<Category> CurrentLibraryColumns { get; set; }
    }
        
    [Serializable]
    public class LibraryContent
    {
        public LibraryContent() { }
    
    }

    [Serializable]
    public class Settings
    {        
    }*/

}
