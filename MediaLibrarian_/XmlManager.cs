using System;
using System.IO;
using System.Xml.Serialization;

namespace MediaLibrarian_
{
    public static class XmlManager
    {
        private static readonly string Path;

        static XmlManager()
        {
            Path = Environment.CurrentDirectory + "/Settings.xml";
        }

        public static void Serialize(Settings settings)
        {
            if (settings == null)
                throw new ArgumentNullException("Произошла ошибка при сохранении настроек");
            var formatter = new XmlSerializer(settings.GetType());
            using (var file = new FileStream(Path, FileMode.Create))
            {
                formatter.Serialize(file, settings);
            }
        }

        public static Settings Deserialize()
        {
            var formatter = new XmlSerializer(typeof(Settings));
            Settings preferences;
            using (var file = new FileStream(Path, FileMode.OpenOrCreate))
            {
                preferences = (Settings)formatter.Deserialize(file);
            }

            return preferences;
        }
    }
}