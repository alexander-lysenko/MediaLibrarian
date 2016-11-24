using System;
using System.IO;
using System.Xml.Serialization;

namespace MediaLibrarian
{
    public static class XmlManager
    {
        private static readonly string _path;

        static XmlManager()
        {
            _path = Environment.CurrentDirectory + "/Settings.xml";
        }

        public static void Serialize(Settings settings)
        {
            if(settings == null)
                throw new ArgumentNullException("Произошла ошибка при сохранении настроек");
            XmlSerializer formatter = new XmlSerializer(settings.GetType());
            using (FileStream file = new FileStream(_path, FileMode.Create))
            {
                formatter.Serialize(file, settings);
            }
        }

        public static Settings Deserialize()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Settings));
            Settings preferences;
            using (FileStream file = new FileStream(_path, FileMode.OpenOrCreate))
            {
                preferences = (Settings)formatter.Deserialize(file);
            }
            return preferences;
        }

    }
}