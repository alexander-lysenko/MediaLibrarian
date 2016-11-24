using System;
using System.Windows.Forms;

namespace MediaLibrarian
{
    public partial class SettingsForm : Form
    {
        public SettingsForm(MainForm FormMain)
        {
            InitializeComponent();
            MainForm = FormMain;
        }
        MainForm MainForm;
        Settings Preferences;

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            Preferences = new Settings{
                RememberLastLibrary = rememberLastLibraryChk.Checked,
                FocusFirstItem = focusFirstItemChk.Checked,
                CropMaxViewSize = cropMaxViewSizeChk.Checked,
                PicMaxWidth = picMaxWidthNUD.Value,
                PicMaxHeight = picMaxHeightNUD.Value,
                StartFullScreen = fullScreenStartChk.Checked,
                AutoSortByName =  autoSortByNameChk.Checked,
                SelectedTheme = selectThemeCB.Text, 
                FormCaptionText = formCaptionTB.Text,
                MainColor = mainColorLabel.ForeColor,
                MainFont = mainFontLabel.Font};
            XmlManager.Serialize(Preferences);
            hintLabel.Text = "Настройки сохранены успешно.";
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
            if(headerFontDialog.ShowDialog()==DialogResult.OK)
            {
                mainFontLabel.Text = headerFontDialog.Font.Name+"\n(Проверка кириллицы)";
                mainFontLabel.Font = headerFontDialog.Font;
            }
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
        }
    }
}