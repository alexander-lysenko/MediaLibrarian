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

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
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
                SelectedTheme = selectThemeCB.Text,
                FormCaptionText = formCaptionTB.Text,
                MainColor = mainColorLabel.ForeColor.ToArgb(),
                MainFont = new SFont(mainFontLabel.Font.FontFamily.Name, mainFontLabel.Font.Size, mainFontLabel.Font.Style)
            };
            XmlManager.Serialize(_mainForm.Preferences);
            hintLabel.Text = "Настройки сохранены успешно.";
            _mainForm.TitleLabel.ForeColor = _mainForm.SelectedLibLabel.ForeColor =
                _mainForm.ElementCount.ForeColor = Color.FromArgb(_mainForm.Preferences.MainColor);
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            applyButton.PerformClick();
            cancelButton.PerformClick();
        }

        private void mainColorLabel_Click(object sender, EventArgs e)
        {
            if (headerColorDialog.ShowDialog() == DialogResult.OK) 
            {
                mainColorLabel.Text = headerColorDialog.Color.Name;
                mainColorLabel.ForeColor = headerColorDialog.Color;
            }
        }

        private void mainFontLabel_Click(object sender, EventArgs e)
        {
            headerFontDialog.Font = mainFontLabel.Font;
            if(headerFontDialog.ShowDialog()==DialogResult.OK)
            {
                mainFontLabel.Text = headerFontDialog.Font.Name+"\n(Проверка кириллицы)";
                mainFontLabel.Font = headerFontDialog.Font;
            }
        }

        public void RestoreSettings(Settings Preferences)
        {
            rememberLastLibraryChk.Checked = Preferences.RememberLastLibrary;
            _mainForm.SelectedLibLabel.Text = Preferences.LastLibraryName;
            focusFirstItemChk.Checked = Preferences.FocusFirstItem;
            cropMaxViewSizeChk.Checked = Preferences.CropMaxViewSize;
            picMaxWidthNUD.Value = Preferences.PicMaxWidth;
            picMaxHeightNUD.Value = Preferences.PicMaxHeight;
            fullScreenStartChk.Checked = Preferences.StartFullScreen;
            autoSortByNameChk.Checked = Preferences.AutoSortByName;
            selectThemeCB.Text = Preferences.SelectedTheme;
            formCaptionTB.Text = Preferences.FormCaptionText;
            mainColorLabel.ForeColor = Color.FromArgb(Preferences.MainColor);
            mainColorLabel.Text = mainColorLabel.ForeColor.Name;
            mainFontLabel.Font = new Font(Preferences.MainFont.FontFamilyName,
                Preferences.MainFont.FontSize, Preferences.MainFont.FontStyle);
            mainFontLabel.Text = Preferences.MainFont.FontFamilyName + "\n(Проверка кириллицы)";
        }
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            toolTip.SetToolTip(rememberLastLibraryChk, "При зауске в программу будет автоматически \nзагружаться последняя открытая ранее библиотека");
            toolTip.SetToolTip(focusFirstItemChk, "Когда в программу загружена библиотека, и в ней есть элементы, \nбудет автоамтически выделен первый элемент, и будет отображена информация о нем");
            toolTip.SetToolTip(cropMaxViewSizeChk, "По умолчанию просмотрщик постеров определяет разрешение \nВашего экрана, и будет подгонять постер под него. \nВы можете ограничить размер отображения постеров.");
            toolTip.SetToolTip(fullScreenStartChk, "Активируйте, если хотите, чтобы при запуске \nпрограмма разворачивалась на весь экран");
            toolTip.SetToolTip(autoSortByNameChk, "При каких-либо изменениях в таблице элементов, \nони всегда будут сортироваться автоматически по первому столбцу.");
            toolTip.SetToolTip(selectThemeLabel, "Выбор цветовой схемы отображения основных разделов программы \n(Основная форма, выбор библиотеки, редактирование элемента).\nВы можете выбрать цветовую схему из предложенных вариантов.");
            toolTip.SetToolTip(fromCaptionLabel, "Вы можете установить собственный заголовок программы.\nЭтот текст заменит стандартный заголовок - \"Медиа-библиотекарь\"");
            toolTip.SetToolTip(colorSelectLabel, "Независимо от выбранной темы оформления, можно выбрать \nцвет отображения подробных данных элемента в основной форме.\nЧтобы выбрать цвет, нажмите на элемент справа от этой надписи.\nДля удобства восприятия, его фон будет подкрашен в цвет \nвыбранной Вами темы.");
            toolTip.SetToolTip(fontSelectLabel, "Можно выбрать шрифт отображения ИМЕНИ ЭЛЕМЕНТА в основной форме \n(Имя элемента - это первый столбец таблицы, в основной форме \nотображается большими буквами рядом с постером).\n Обратите внимание: не все шрифты поддерживают кириллицу!");
            //toolTip.SetToolTip()
            //toolTip.SetToolTip();
            //toolTip.SetToolTip();

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
                MessageBox.Show(ex.Message);
            }

        }
    }
}