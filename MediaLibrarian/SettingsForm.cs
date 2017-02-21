using System;
using System.Drawing;
using System.Windows.Forms;

namespace MediaLibrarian
{
    public partial class SettingsForm : Form
    {
        public SettingsForm(MainForm formMain)
        {
            InitializeComponent();
            _mainForm = formMain;
        }
        MainForm _mainForm;
        public void SaveSettings() 
        {
            _mainForm.Preferences = new Settings
            {
                RememberLastLibrary = rememberLastLibraryChk.Checked,
                LastLibraryName = _mainForm.SelectedLibLabel.Text,
                FocusFirstItem = focusFirstItemChk.Checked,
                CropMaxViewSize = cropMaxViewSizeChk.Checked,
                PicMaxWidth = picMaxWidthNUD.Value,
                PicMaxHeight = picMaxHeightNUD.Value,
                StartFullScreen = fullScreenStartChk.Checked,
                AutoSortByName = autoSortByNameChk.Checked,
                FormCaptionText = formCaptionTB.Text,
                ThemeColor1 = themeColor1CB.Text,
                ThemeColor2 = themeColor2CB.Text,
                MainColor = mainColorCB.Text,
                FontColor = fontColorCB.Text,
                MainFont = new SFont(mainFontLabel.Font.FontFamily.Name, mainFontLabel.Font.Size, mainFontLabel.Font.Style)
            };
            if (formCaptionTB.Text == "") _mainForm.Preferences.FormCaptionText = "Медиа-библиотекарь";
            XmlManager.Serialize(_mainForm.Preferences);
            hintLabel.Text = "Настройки сохранены успешно.";
            _mainForm.TitleLabel.ForeColor = _mainForm.SelectedLibLabel.ForeColor =
                _mainForm.ElementCount.ForeColor = Color.FromName(_mainForm.Preferences.MainColor);            
            _mainForm.Refresh();
            _mainForm.InitFont();
        }
        public void RestoreSettings(Settings Preferences)
        {
            rememberLastLibraryChk.Checked = Preferences.RememberLastLibrary;
            _mainForm.SelectedLibLabel.Text = Preferences.LastLibraryName;
            focusFirstItemChk.Checked = Preferences.FocusFirstItem;
            cropMaxViewSizeChk.Checked = Preferences.CropMaxViewSize;
            try
            {
                picMaxWidthNUD.Value = Preferences.PicMaxWidth;
                picMaxHeightNUD.Value = Preferences.PicMaxHeight;
            }
            catch (Exception)
            {
                picMaxWidthNUD.Value = 720;
                picMaxHeightNUD.Value = 720;
            }
            fullScreenStartChk.Checked = Preferences.StartFullScreen;
            autoSortByNameChk.Checked = Preferences.AutoSortByName;
            formCaptionTB.Text = Preferences.FormCaptionText;
            themeColor1CB.Text = Preferences.ThemeColor1;
            themeColor2CB.Text = Preferences.ThemeColor2;
            mainColorCB.Text = Preferences.MainColor;
            fontColorCB.Text = Preferences.FontColor;
            mainFontLabel.Font = new Font(Preferences.MainFont.FontFamilyName,
                Preferences.MainFont.FontSize, Preferences.MainFont.FontStyle);
            mainFontLabel.Text = Preferences.MainFont.FontFamilyName + "\n(Проверка кириллицы)";
        }
        #region Buttons
        private void OK_Button_Click(object sender, EventArgs e)
        {
            SaveSettings();
            cancelButton.PerformClick();
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Hide();
        }
        private void ApplyButton_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }
        #endregion
        #region ColorsCB
        private void themeColor1CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            themeColor1PB.BackColor = Color.FromName(themeColor1CB.Text);
        }
        private void themeColor2CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            themeColor2PB.BackColor = Color.FromName(themeColor2CB.Text);
        }
        
        private void mainColorCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            mainColorPB.BackColor = Color.FromName(mainColorCB.Text);
        }
        private void fontColorCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            fontColorPB.BackColor = Color.FromName(fontColorCB.Text);
        }
        #endregion
        private void mainFontLabel_Click(object sender, EventArgs e)
        {
            headerFontDialog.Font = mainFontLabel.Font;
            if(headerFontDialog.ShowDialog()==DialogResult.OK)
            {
                mainFontLabel.Text = headerFontDialog.Font.Name+"\n(Проверка кириллицы)";
                mainFontLabel.Font = headerFontDialog.Font;
            }
        }
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            string[] colors = Enum.GetNames(typeof(KnownColor));            
            foreach (string color in colors)
            {
                if (((Color.FromName(color)).IsSystemColor == false) && ((Color.FromName(color)).Name != Color.Transparent.Name))
                {
                    themeColor1CB.Items.Add(color);
                    themeColor2CB.Items.Add(color);
                    mainColorCB.Items.Add(color);
                    fontColorCB.Items.Add(color);
                }
            }
            toolTip.SetToolTip(rememberLastLibraryChk, "При зауске в программу будет автоматически \nзагружаться последняя открытая ранее библиотека");
            toolTip.SetToolTip(focusFirstItemChk, "Когда в программу загружена библиотека, и в ней есть элементы, \nбудет автоматически выделен первый элемент, и будет отображена информация о нем");
            toolTip.SetToolTip(cropMaxViewSizeChk, "По умолчанию просмотрщик постеров определяет разрешение \nВашего экрана, и будет подгонять постер под него. \nВы можете ограничить размер отображения постеров");
            toolTip.SetToolTip(fullScreenStartChk, "Активируйте, если хотите, чтобы при запуске \nпрограмма разворачивалась на весь экран");
            toolTip.SetToolTip(autoSortByNameChk, "При каких-либо изменениях в таблице элементов, \nони всегда будут сортироваться автоматически по первому столбцу");
            toolTip.SetToolTip(fromCaptionLabel, "Вы можете установить собственный заголовок программы.\nЭтот текст заменит стандартный заголовок - \"Медиа-библиотекарь\"\nЕсли не хотите менять, оставьте пустым");
            toolTip.SetToolTip(backgroundGB, "Выбор цветовой схемы отображения главного окна программы.\nПредставляет собой градиентное наложение двух контрастных цветов,\nкоторые можно выбрать по своему вкусу");
            toolTip.SetToolTip(mainColorLabel, "Независимо от выбранной темы оформления, можно выбрать \nцвет отображения подробных данных элемента в основной форме.\nИмейте в виду, что выбранный Вами цвет может не гармонировать\nс выбранными цветами темы");
            toolTip.SetToolTip(fontColorLabel, "Если Вы выбрали темные цвета для темы, и остальных надписей\nпрограммы не видно, можно задать им цвет посветлее");
            toolTip.SetToolTip(fontSelectLabel, "Можно выбрать шрифт отображения ИМЕНИ ЭЛЕМЕНТА в основной форме \n(Имя элемента - это первый столбец таблицы, в основной форме \nотображается большими буквами рядом с постером).\n Обратите внимание: не все шрифты поддерживают кириллицу!");

            screenResolutionLabel.Text = String.Format("Разрешение экрана: {0}х{1}",
                SystemInformation.PrimaryMonitorSize.Width, SystemInformation.PrimaryMonitorSize.Height);
            picMaxWidthNUD.Maximum = SystemInformation.PrimaryMonitorSize.Width;
            picMaxHeightNUD.Maximum = SystemInformation.PrimaryMonitorSize.Height;
            try
            {
                RestoreSettings(_mainForm.Preferences);
            }
            catch (InvalidOperationException)
            {
                hintLabel.Text = "Настройки были сброшены по умолчанию";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка открытия файла настроек", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}