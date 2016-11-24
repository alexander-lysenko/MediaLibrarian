using System;
using System.Drawing;

namespace MediaLibrarian
{
    [Serializable]
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
    }
}