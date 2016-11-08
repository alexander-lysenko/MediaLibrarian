using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Drawing;

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
    public class Settings
    {
        public bool RememberLastLibrary { get; set; }
        public bool FocusFirstItem { get; set; }
        public bool CropMaxViewSize { get; set; }
        public decimal PicMaxWidth { get; set; }
        public decimal PicMaxHeight { get; set; }
        public bool StartFullScreen { get; set; }
        public bool AutoSortByName { get; set; }
        public string SelectedTheme { get; set; }
        public string FormCaptionText { get; set; }
        public Color MainColor { get; set; }
        public Font MainFont { get; set; }

        public Settings()
        {
            this.RememberLastLibrary = RememberLastLibrary;
            this.FocusFirstItem = FocusFirstItem;
            this.CropMaxViewSize = CropMaxViewSize;
            this.PicMaxWidth = PicMaxWidth;
            this.PicMaxHeight = PicMaxHeight;
            this.StartFullScreen = StartFullScreen;
            this.AutoSortByName = AutoSortByName;
            this.SelectedTheme = SelectedTheme;
            this.FormCaptionText = FormCaptionText;
            this.MainColor = MainColor;
            this.MainFont = MainFont;
        }
    }

    public class ThemeSettings
    {
 
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
