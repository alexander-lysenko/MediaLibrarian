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
        public string FormCaptionText { get; set; }
        public string ThemeColor { get; set; }
        public string MainColor { get; set; }
        public string FontColor { get; set; }
        public SFont MainFont { get; set; }
    }
    [Serializable]
    public class SFont 
    {
        public string FontFamilyName { get; set; }
        public float FontSize { get; set; }
        public FontStyle FontStyle { get; set; }

        public SFont() { }

        public SFont(string name, float size, FontStyle style)
        {
            FontFamilyName = name;
            FontSize = size;
            FontStyle = style;
        }
    }
}