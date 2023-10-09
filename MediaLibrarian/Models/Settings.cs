namespace MediaLibrarian.Models
{
    public static class Settings
    {
        public static bool RememberLastLibrary { get; set; }
        public static bool StartFullScreen { get; set; }
        public static bool AutoSortByName { get; set; }

        static Settings()
        {
            RememberLastLibrary = true;
            StartFullScreen = false;
            AutoSortByName = false;
        }
    }
}