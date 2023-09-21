using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using MediaLibrarian.Properties;

namespace MediaLibrarian
{
    internal sealed partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            Text = string.Format("О программе \"{0}\"", AssemblyTitle);
            CurrentVersionLabel.Text = AssemblyVersion;
            companyNameLabel.Text = AssemblyCompany;
        }

        #region Методы доступа к атрибутам сборки

        private static string AssemblyTitle
        {
            get
            {
                var attributes = Assembly
                    .GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length <= 0)
                    return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
                var titleAttribute = (AssemblyTitleAttribute)attributes[0];
                return titleAttribute.Title != ""
                    ? titleAttribute.Title
                    : Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        private static string AssemblyVersion
        {
            get { return Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
        }

        public string AssemblyDescription
        {
            get
            {
                var attributes = Assembly
                    .GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                return attributes.Length == 0 ? "" : ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                var attributes = Assembly
                    .GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                return attributes.Length == 0 ? "" : ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                var attributes = Assembly
                    .GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                return attributes.Length == 0 ? "" : ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        private static string AssemblyCompany
        {
            get
            {
                var attributes = Assembly
                    .GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                return attributes.Length == 0 ? "" : ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        #endregion

        private void AboutForm_Load(object sender, EventArgs e)
        {
            CurVersionDateLabel.Text = new DateTime(2019, 08, 03).ToShortDateString();
            FirstVersionDateLabel.Text = new DateTime(2017, 03, 10).ToShortDateString();
            ChangelogRTB.Text = Resources.changelog;
        }
    }
}