using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;

namespace MediaLibrarian
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static event EventHandler LanguageChanged;

        // ReSharper disable once CollectionNeverQueried.Local
        private static List<CultureInfo> Languages { get; } = new List<CultureInfo>();

        public App()
        {
            Languages.Clear();
            Languages.Add(new CultureInfo("en-US")); // Neutral Culture
            Languages.Add(new CultureInfo("ru-RU"));
            LanguageChanged += OnLanguageChanged;
        }

        // https://habr.com/ru/articles/256193/
        private static CultureInfo Language
        {
            get => System.Threading.Thread.CurrentThread.CurrentUICulture;
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                if (Equals(value, System.Threading.Thread.CurrentThread.CurrentUICulture)) return;

                // Changing application's locale
                System.Threading.Thread.CurrentThread.CurrentUICulture = value;

                // Creating ResourceDictionary for a new culture
                var dictionary = new ResourceDictionary();
                switch (value.Name)
                {
                    case "ru-RU":
                        dictionary.Source = new Uri($"Lang/{value.Name}.xaml", UriKind.Relative);
                        break;
                    default:
                        dictionary.Source = new Uri("Lang/en_US.xaml", UriKind.Relative);
                        break;
                }

                // Finding an old ResourceDictionary and replacing it with a new one
                var oldDictionary = (
                    from d in Current.Resources.MergedDictionaries
                    where d.Source != null && d.Source.OriginalString.StartsWith("Lang/")
                    select d
                ).First();

                if (oldDictionary == null)
                {
                    Current.Resources.MergedDictionaries.Add(dictionary);
                }
                else
                {
                    var index = Current.Resources.MergedDictionaries.IndexOf(oldDictionary);
                    Current.Resources.MergedDictionaries.Remove(oldDictionary);
                    Current.Resources.MergedDictionaries.Insert(index, dictionary);
                }

                // Firing the event to notify all windows
                LanguageChanged?.Invoke(Current, EventArgs.Empty);
            }
        }
        
        private void OnLoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            Language = MediaLibrarian.Properties.Settings.Default.DefaultLanguage;
        }

        private static void OnLanguageChanged(object sender, EventArgs e)
        {
            MediaLibrarian.Properties.Settings.Default.DefaultLanguage = Language;
            MediaLibrarian.Properties.Settings.Default.Save();
        }
    }
}