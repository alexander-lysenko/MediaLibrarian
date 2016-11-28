using System;
using System.Drawing;

namespace MediaLibrarian
{
    [Serializable]
    public class Settings
    {
        public bool RememberLastLibrary { get; set; }
        public string LastLibraryName { get; set; }
        public bool FocusFirstItem { get; set; }
        public bool CropMaxViewSize { get; set; }
        public decimal PicMaxWidth { get; set; }
        public decimal PicMaxHeight { get; set; }
        public bool StartFullScreen { get; set; }
        public bool AutoSortByName { get; set; }
        public string SelectedTheme { get; set; }
        public string FormCaptionText { get; set; }
        public int MainColor { get; set; }
        public SFont MainFont { get; set; }
    }
    [Serializable]
    public class SFont 
    {
        public string FontFamily_Name { get; set; }
        public float Font_Size { get; set; }
        public FontStyle Font_Style { get; set; }

        public SFont() { }

        public SFont(string name, float size, FontStyle style)
        {
            FontFamily_Name = name;
            Font_Size = size;
            Font_Style = style;
        }
    }
}