using System;
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

    [Serializable]
    public class Settings
    {
        static XmlSerializer formatter = new XmlSerializer(typeof(Settings));
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

        public Settings() { }

        public Settings(
            bool RememberLastLibrary, 
            bool FocusFirstItem, 
            bool CropMaxViewSize, 
            decimal PicMaxWidth,
            decimal PicMaxHeight, 
            bool StartFullScreen, 
            bool AutoSortByName, 
            string SelectedTheme, 
            string FormCaptionText,
            Color MainColor, 
            Font MainFont)
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

        public void Serialize()
        {
            using (FileStream file = new FileStream(Environment.CurrentDirectory + "Settings.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(file, this);
            }
        }

        public void Deserialize()
        {
            using (FileStream file = new FileStream(Environment.CurrentDirectory + "Settings.xml", FileMode.OpenOrCreate))
            {
                Settings Preferences = (Settings)formatter.Deserialize(file);
                RememberLastLibrary = Preferences.RememberLastLibrary;
                FocusFirstItem = Preferences.FocusFirstItem;
                CropMaxViewSize = Preferences.CropMaxViewSize;
                PicMaxWidth = Preferences.PicMaxWidth;
                PicMaxHeight = Preferences.PicMaxHeight;
                StartFullScreen = Preferences.StartFullScreen;
                AutoSortByName = Preferences.AutoSortByName;
                SelectedTheme = Preferences.SelectedTheme;
                FormCaptionText = Preferences.FormCaptionText;
                MainColor = Preferences.MainColor;
                MainFont = Preferences.MainFont;
            }
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
