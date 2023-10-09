using System;
using System.Drawing;
using System.Windows.Forms;

namespace MediaLibrarian_
{
    public partial class SettingsForm : Form
    {
        public SettingsForm(MainForm formMain)
        {
            InitializeComponent();
            _mainForm = formMain;
        }

        private readonly MainForm _mainForm;

        private void SaveSettings()
        {
            _mainForm.Preferences = new Settings
            {
                PageSize = (int)pageSizeNumeric.Value,
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
                MainFont = new SFont(mainFontLabel.Font.FontFamily.Name, mainFontLabel.Font.Size,
                    mainFontLabel.Font.Style)
            };
            if (formCaptionTB.Text == "") _mainForm.Preferences.FormCaptionText = "�����-������������";
            XmlManager.Serialize(_mainForm.Preferences);
            hintLabel.Text = "��������� ��������� �������.";
            _mainForm.TitleLabel.ForeColor = _mainForm.SelectedLibLabel.ForeColor =
                _mainForm.ElementCount.ForeColor = Color.FromName(_mainForm.Preferences.MainColor);
            _mainForm.Refresh();
            _mainForm.InitFont();
        }

        private void RestoreSettings(Settings preferences)
        {
            pageSizeNumeric.Value = preferences.PageSize;
            rememberLastLibraryChk.Checked = preferences.RememberLastLibrary;
            focusFirstItemChk.Checked = preferences.FocusFirstItem;
            cropMaxViewSizeChk.Checked = preferences.CropMaxViewSize;
            try
            {
                picMaxWidthNUD.Value = preferences.PicMaxWidth;
                picMaxHeightNUD.Value = preferences.PicMaxHeight;
            }
            catch (Exception)
            {
                picMaxWidthNUD.Value = 720;
                picMaxHeightNUD.Value = 720;
            }

            fullScreenStartChk.Checked = preferences.StartFullScreen;
            autoSortByNameChk.Checked = preferences.AutoSortByName;
            formCaptionTB.Text = preferences.FormCaptionText;
            themeColor1CB.Text = preferences.ThemeColor1;
            themeColor2CB.Text = preferences.ThemeColor2;
            mainColorCB.Text = preferences.MainColor;
            fontColorCB.Text = preferences.FontColor;
            mainFontLabel.Font = new Font(preferences.MainFont.FontFamilyName,
                preferences.MainFont.FontSize, preferences.MainFont.FontStyle);
            mainFontLabel.Text = preferences.MainFont.FontFamilyName + "\n(�������� ���������)";
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
            if (headerFontDialog.ShowDialog() != DialogResult.OK) return;

            mainFontLabel.Text = headerFontDialog.Font.Name + "\n(�������� ���������)";
            mainFontLabel.Font = headerFontDialog.Font;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            var colors = Enum.GetNames(enumType: typeof(KnownColor));
            foreach (var color in colors)
            {
                if (Color.FromName(name: color).IsSystemColor ||
                    Color.FromName(name: color).Name == Color.Transparent.Name)
                    continue;
                themeColor1CB.Items.Add(item: color);
                themeColor2CB.Items.Add(item: color);
                mainColorCB.Items.Add(item: color);
                fontColorCB.Items.Add(item: color);
            }

            toolTip.SetToolTip(
                control: rememberLastLibraryChk,
                caption: "��� ������ � ��������� ����� ������������� \n����������� ��������� �������� ����� ����������"
            );
            toolTip.SetToolTip(
                control: focusFirstItemChk,
                caption: "����� � ��������� ��������� ����������, � � ��� ���� ��������, \n" +
                         "����� ������������� ������� ������ �������, � ����� ���������� ���������� � ���"
            );
            toolTip.SetToolTip(
                control: cropMaxViewSizeChk,
                caption: "�� ��������� ����������� �������� ���������� ���������� \n������ ������, � ����� " +
                         "��������� ������ ��� ����.\n�� ������ ���������� ������ ����������� ��������"
            );
            toolTip.SetToolTip(
                control: fullScreenStartChk,
                caption: "�����������, ���� ������, ����� ��� ������� \n��������� ��������������� �� ���� �����"
            );
            toolTip.SetToolTip(
                control: autoSortByNameChk,
                caption: "��� �����-���� ���������� � ������� ���������, \n" +
                         "��� ������ ����� ������������� ������������� �� ������� �������"
            );
            toolTip.SetToolTip(
                control: fromCaptionLabel,
                caption: "�� ������ ���������� ����������� ��������� ���������.\n���� ����� ������� " +
                         "����������� ��������� - \"�����-������������\"\n���� �� ������ ��� ��������, �������� ������"
            );
            toolTip.SetToolTip(
                control: backgroundGB,
                caption:
                "����� �������� ����� ����������� �������� ���� ���������.\n������������ ����� ����������� ��������� " +
                "���� ����������� ������,\n������� ����� ������� �� ������ �����"
            );
            toolTip.SetToolTip(
                control: mainColorLabel,
                caption:
                "���������� �� ��������� ���� ����������, ����� ������� \n���� ����������� ��������� ������ �������� � �������� �����.\n" +
                "������ � ����, ��� ��������� ���� ���� ����� �� �������������\n� ���������� ������� ����"
            );
            toolTip.SetToolTip(
                control: fontColorLabel,
                caption:
                "���� �� ������� ������ ����� ��� ����, � ��������� ��������\n��������� �� �����, ����� ������ �� ���� ���������"
            );
            toolTip.SetToolTip(
                control: fontSelectLabel,
                caption:
                "����� ������� ����� ����������� ����� �������� � �������� ����� \n(��� �������� - ��� ������ ������� �������, �" +
                " �������� ����� \n������������ �������� ������� ����� � ��������).\n�������� ��������: �� ��� ������ ������������ ���������!"
            );
            toolTip.SetToolTip(
                control: pageSizeLabel,
                caption:
                "���� ������� �������� 1-500, ����� ������������ ���������� ���������.\n��������� �������� ���������� ���������� " +
                "���������, ������������ �� ��������.\n�������� '0' ��������� ���������, �� �������� ��������� ��� �������� ����������"
            );

            screenResolutionLabel.Text = string.Format(
                "���������� ������: {0}�{1}",
                SystemInformation.PrimaryMonitorSize.Width,
                SystemInformation.PrimaryMonitorSize.Height
            );
            picMaxWidthNUD.Maximum = SystemInformation.PrimaryMonitorSize.Width;
            picMaxHeightNUD.Maximum = SystemInformation.PrimaryMonitorSize.Height;
            try
            {
                RestoreSettings(preferences: _mainForm.Preferences);
            }
            catch (InvalidOperationException)
            {
                hintLabel.Text = "��������� ���� �������� �� ���������";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    text: ex.Message,
                    caption: "������ �������� ����� ��������",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Error
                );
            }
        }
    }
}