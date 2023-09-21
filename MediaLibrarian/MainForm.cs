using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MediaLibrarian
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SplashForm.ShowForm();
            LibManagerForm = new LibManagerForm(this);
            _editForm = new EditForm(this);
            _settingsForm = new SettingsForm(this);
            SearchForm = new SearchForm(this);
        }

        public readonly LibManagerForm LibManagerForm;
        private readonly EditForm _editForm;
        private readonly SettingsForm _settingsForm;
        public readonly SearchForm SearchForm;
        public Settings Preferences;
        public readonly List<Category> ColumnsInfo = new List<Category>();
        private int _offset; //LocationOffset
        private int _sortColumn = -1;

        public static void ShowForm()
        {
            var mainForm = new MainForm();
            mainForm.Show();
        }

        public void InitFont()
        {
            var foreColor = Color.FromName(Preferences.FontColor);
            var systemColor = SystemColors.ControlText;

            MainMenu.ForeColor = foreColor;
            ElementInfoGB.ForeColor = foreColor;
            ElementActionsGB.ForeColor = foreColor;
            LibInfoGB.ForeColor = foreColor;
            StatusLabel.ForeColor = foreColor;
            informationLabel.ForeColor = foreColor;
            pagerCountLabel.ForeColor = foreColor;
            Text = Preferences.FormCaptionText;
            AddElementButton.ForeColor = systemColor;
            EditElementButton.ForeColor = systemColor;
            DeleteElementButton.ForeColor = systemColor;
            SearchButton.ForeColor = systemColor;
            SelectCollectionButton.ForeColor = systemColor;
            TitleLabel.Font = new Font(
                familyName: Preferences.MainFont.FontFamilyName,
                emSize: Preferences.MainFont.FontSize,
                style: Preferences.MainFont.FontStyle
            );
        }

        #region Buttons

        private void SelectCollectionButton_Click(object sender, EventArgs e)
        {
            LibManagerForm.ShowDialog();
        }

        private void AddElementButton_Click(object sender, EventArgs e)
        {
            _editForm.ShowDialog();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (Collection.SelectedItems.Count <= 0)
            {
                StatusLabel.Text = "Не выбран элемент для редактирования";
                return;
            }

            _editForm.EditMode = true;
            _editForm.ShowDialog();
        }

        private void DeleteElementButton_Click(object sender, EventArgs e)
        {
            if (Collection.SelectedItems.Count <= 0)
            {
                StatusLabel.Text = "Не выбран элемент для удаления";
                return;
            }

            var dialogResult = MessageBox.Show(
                text: string.Format("Удалить элемент \"{0}\"?", Collection.SelectedItems[0].Text),
                caption: "Подтверждение удаления элемента",
                buttons: MessageBoxButtons.YesNo,
                icon: MessageBoxIcon.Question
            );
            if (dialogResult != DialogResult.Yes) return;

            _editForm.DeleteItem(Collection.Columns[0].Text, Collection.SelectedItems[0].Text);
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (int.Parse(ElementCount.Text) <= 5)
            {
                StatusLabel.Text = "Библиотека не заполнена. Поиск не доступен.";
                return;
            }

            SearchForm.Show();
        }

        #endregion

        #region ContextMenu

        private void copyNameTSMI_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Collection.FocusedItem.Text);
        }

        private void EditItemTSMI_Click(object sender, EventArgs e)
        {
            EditElementButton.PerformClick();
        }

        private void DeleteItemTSMI_Click(object sender, EventArgs e)
        {
            DeleteElementButton.PerformClick();
        }

        #endregion

        #region FileTSM

        private void OpenLibTSMI_Click(object sender, EventArgs e)
        {
            SelectCollectionButton.PerformClick();
        }

        private void ClearLibTSMI_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(
                text: "Внимание! Данная операция безвозратно уничтожит ВСЕ записи в этой библиотеке.\n" +
                      "В результате библиотека останется, но будет пуста." +
                      "Вы действительно желаете продолжить?",
                caption: "Подтверждение очистки библиотеки",
                buttons: MessageBoxButtons.YesNo,
                icon: MessageBoxIcon.Question
            );
            if (dialogResult != DialogResult.Yes) return;

            LibManagerForm.ClearLibrary(SelectedLibLabel.Text);
            LibManagerForm.ReadTableFromDatabase(SelectedLibLabel.Text, Preferences.PageSize);
        }

        private void CloseAppTSMI_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region EditTSM

        private void AddElementTSMI_Click(object sender, EventArgs e)
        {
            AddElementButton.PerformClick();
        }

        private void EditElementTSMI_Click(object sender, EventArgs e)
        {
            EditElementButton.PerformClick();
        }

        private void DeleteElementTSMI_Click(object sender, EventArgs e)
        {
            DeleteElementButton.PerformClick();
        }

        private void FindElementTSMI_Click(object sender, EventArgs e)
        {
            SearchButton.PerformClick();
        }

        #endregion

        #region ViewTSM

        private void AutoSortingTSMI_Click(object sender, EventArgs e)
        {
            Preferences.AutoSortByName = AutoSortingTSMI.Checked;
            StatusLabel.Text = AutoSortingTSMI.Checked
                ? "Включена автоматическая сортировка таблицы по имени"
                : "Отключена автоматическая сортировка таблицы по имени";

            if (SelectedLibLabel.Text == "") return;
            try
            {
                var currentPage = Convert.ToInt32(pagerCurrentTb.Text);
                var pagerOffset = Preferences.PageSize * (currentPage - 1);
                LibManagerForm.ReadTableFromDatabase(SelectedLibLabel.Text, Preferences.PageSize, pagerOffset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    text: ex.Message,
                    caption: "Ошибка подключения к базе данных",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Error
                );
            }
        }

        private void FullScreenTSMI_Click(object sender, EventArgs e)
        {
            WindowState = FullScreenTSMI.Checked ? FormWindowState.Maximized : FormWindowState.Normal;
        }

        private void PreferencesTSMI_Click(object sender, EventArgs e)
        {
            _settingsForm.ShowDialog();
        }

        #endregion

        #region HelpTSM

        private void HelpTSMI_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("help.chm");
            }
            catch (Exception)
            {
                MessageBox.Show("Файл со справкой не найден");
            }
        }

        private void AboutTSMI_Click(object sender, EventArgs e)
        {
            var aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        #endregion

        #region Items

        private void PosterBox_MouseClick(object sender, MouseEventArgs e)
        {
            var pv = new PictureViewer { ImageBox = { Image = PosterBox.Image } };
            var pvSize = Preferences.CropMaxViewSize
                ? new Size((int)Preferences.PicMaxWidth, (int)Preferences.PicMaxHeight)
                : new Size(SystemInformation.PrimaryMonitorSize.Width, SystemInformation.PrimaryMonitorSize.Height);
            var pictureSizeMode = PosterBox.Image.Width > pv.Size.Width || PosterBox.Image.Height > pv.Size.Height
                ? PictureBoxSizeMode.Zoom
                : PictureBoxSizeMode.CenterImage;

            pv.ImageBox.SizeMode = Preferences.CropMaxViewSize ? pictureSizeMode : PictureBoxSizeMode.CenterImage;
            pv.Size = pvSize;
            pv.Show();
        }

        private void Collection_ItemActivate(object sender, EventArgs e)
        {
            EditElementButton.PerformClick();
        }

        private void Collection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Collection.SelectedItems.Count <= 0)
            {
                InfoPanel.Controls.Clear();
                TitleLabel.Text = "";
                TitleHeaderLabel.Text = "Нет элементов для отображения";
                PosterBox.Image = null;
                return;
            }

            TitleHeaderLabel.Text = ColumnsInfo[0].Name;
            LoadItemInfo(Collection.SelectedItems[0]);
            TitleLabel.Text = Collection.SelectedItems[0].Text;
            try
            {
                PosterBox.Image = Image.FromFile(
                    string.Format(
                        @"{0}\Posters\{1}\{2}.jpg",
                        Environment.CurrentDirectory,
                        ReplaceSymbols(SelectedLibLabel.Text),
                        ReplaceSymbols(Collection.SelectedItems[0].Text)
                    )
                );
                PosterBox.BackgroundImage = null;
            }
            catch (Exception)
            {
                PosterBox.Image = null;
                PosterBox.BackgroundImage = Properties.Resources.noposter;
            }
        }

        public string ReplaceSymbols(string str)
        {
            return str.Replace(":", "꞉")
                .Replace("*", "˟")
                .Replace("?", "‽")
                .Replace("\"", "ʺ");
        }

        private static int HowMatch(string sourceString)
        {
            return new Regex("★").Matches(sourceString, 0).Count;
        }

        #endregion

        #region LoadItemsInfo

        private void LoadStringData(string text)
        {
            var strLabel = new Label
            {
                Location = new Point(210, _offset),
                Size = new Size(200, 15),
                Font = new Font("Tahoma", 9.75f),
                ForeColor = Color.FromName(Preferences.MainColor),
                AutoEllipsis = true,
                Text = text,
                TextAlign = ContentAlignment.MiddleRight,
            };
            InfoPanel.Controls.Add(strLabel);
            _offset += 20;
        }

        private void LoadTextData(string text)
        {
            _offset += 20;
            var txtLabel = new Label
            {
                Location = new Point(3, _offset),
                MaximumSize = new Size(405, 0),
                Font = new Font("Tahoma", 9.75f),
                ForeColor = Color.FromName(Preferences.MainColor),
                AutoSize = true,
                Text = text,
            };
            InfoPanel.Controls.Add(txtLabel);
            _offset += txtLabel.Size.Height + 10;
        }

        private void Load5StarData(string mark)
        {
            var m5Label = new Label
            {
                Location = new Point(210, _offset - 5),
                Size = new Size(200, 20),
                Font = new Font("Lucida Console", 18f),
                Text = mark,
                TextAlign = ContentAlignment.MiddleRight,
            };
            switch (HowMatch(m5Label.Text))
            {
                case 1:
                case 2:
                    m5Label.ForeColor = Color.Red;
                    break;
                case 3:
                    m5Label.ForeColor = Color.Orange;
                    break;
                case 4:
                case 5:
                    m5Label.ForeColor = Color.Green;
                    break;
            }

            InfoPanel.Controls.Add(m5Label);
            _offset += 20;
        }

        private void Load10StarData(string mark)
        {
            var m10Label = new Label
            {
                Location = new Point(210, _offset - 5),
                Size = new Size(200, 20),
                Font = new Font("Lucida Console", 18f),
                Text = mark,
                TextAlign = ContentAlignment.MiddleRight,
            };
            switch (HowMatch(m10Label.Text))
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    m10Label.ForeColor = Color.Red;
                    break;
                case 5:
                case 6:
                case 7:
                case 8:
                    m10Label.ForeColor = Color.Orange;
                    break;
                case 9:
                case 10:
                    m10Label.ForeColor = Color.Green;
                    break;
            }

            InfoPanel.Controls.Add(m10Label);
            _offset += 20;
        }

        private void LoadItemInfo(ListViewItem item)
        {
            InfoPanel.Controls.Clear();
            _offset = 5;
            foreach (var col in ColumnsInfo)
            {
                if (ColumnsInfo.IndexOf(col) == 0) continue;
                var headerLabel = new Label
                {
                    Location = new Point(3, _offset),
                    Size = new Size(200, 15),
                    Font = new Font("Tahoma", 9.75f),
                    AutoEllipsis = true,
                    ForeColor = Color.FromName(Preferences.FontColor),
                    Text = col.Name + ":",
                };
                InfoPanel.Controls.Add(headerLabel);
                switch (col.Type)
                {
                    default:
                        LoadStringData(item.SubItems[ColumnsInfo.IndexOf(col)].Text);
                        break; //Строка, дата, дата+время, приоритет
                    case "TEXT":
                        LoadTextData(item.SubItems[ColumnsInfo.IndexOf(col)].Text);
                        break; //Текст
                    case "CHAR(5)":
                        Load5StarData(item.SubItems[ColumnsInfo.IndexOf(col)].Text);
                        break; //Поле оценка (5)
                    case "CHAR(10)":
                        Load10StarData(item.SubItems[ColumnsInfo.IndexOf(col)].Text);
                        break; //Поле оценка (10)
                }
            }

            InfoPanel.Controls.Add(new Label { Location = new Point(1, _offset), Size = new Size(1, 20) });
        }

        #endregion

        #region FormEvents

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            var brush = new LinearGradientBrush(
                rect: ClientRectangle,
                color1: Color.FromName(Preferences.ThemeColor1),
                color2: Color.FromName(Preferences.ThemeColor2),
                angle: 80F
            );
            using (brush)
            {
                e.Graphics.FillRectangle(brush, ClientRectangle);
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void InfoPanel_Scroll(object sender, ScrollEventArgs e)
        {
            InfoPanel.Invalidate();
        }

        public void FormReset()
        {
            Collection.Items.Clear();
            InfoPanel.Controls.Clear();
            SelectedLibLabel.Text = "";
            ColumnsInfo.Clear();
            ElementActionsGB.Enabled = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists("Settings.xml"))
                    Preferences = XmlManager.Deserialize();
                else
                    Preferences = new Settings
                    {
                        PageSize = 50,
                        AutoSortByName = true,
                        CropMaxViewSize = true,
                        FocusFirstItem = true,
                        FormCaptionText = "Медиа-библиотекарь",
                        LastLibraryName = "",
                        MainFont = new SFont { FontFamilyName = "Tahoma", FontSize = 16, FontStyle = FontStyle.Bold },
                        PicMaxHeight = 720,
                        PicMaxWidth = 720,
                        RememberLastLibrary = false,
                        StartFullScreen = false,
                        ThemeColor1 = "WhiteSmoke",
                        ThemeColor2 = "SteelBlue",
                        MainColor = "Blue",
                        FontColor = "Black"
                    };
                InitFont();
                if (Preferences.RememberLastLibrary && Preferences.LastLibraryName != "")
                {
                    LibManagerForm.ReadHeadersForTable(Preferences.LastLibraryName);
                    LibManagerForm.ReadTableFromDatabase(Preferences.LastLibraryName, Preferences.PageSize);
                    paginationToolStrip.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка открытия файла настроек", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            if (Preferences.StartFullScreen)
            {
                WindowState = FormWindowState.Maximized;
                FullScreenTSMI.Checked = true;
            }

            if (Preferences.AutoSortByName)
            {
                AutoSortingTSMI.Checked = true;
            }

            Text = Preferences.FormCaptionText;
            BackColor = Color.FromName(Preferences.ThemeColor1);
            TitleLabel.ForeColor = SelectedLibLabel.ForeColor = ElementCount.ForeColor =
                Color.FromName(Preferences.MainColor);

            TitleLabel.Font = new Font(Preferences.MainFont.FontFamilyName,
                Preferences.MainFont.FontSize, Preferences.MainFont.FontStyle);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Preferences.RememberLastLibrary) return;

            Preferences.LastLibraryName = SelectedLibLabel.Text;
            XmlManager.Serialize(Preferences);
        }

        private void Collection_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Определение того, совпадает ли столбец с последним выбранным столбцом.
            if (e.Column != _sortColumn)
            {
                // Установка сортировки нового столбца.
                _sortColumn = e.Column;
                // Установка порядка сортировки "по возрастанию" как порядка по умолчанию.
                Collection.Sorting = SortOrder.Ascending;
            }
            else
                Collection.Sorting = Collection.Sorting == SortOrder.Ascending
                    ? SortOrder.Descending
                    : SortOrder.Ascending;

            Collection.Sort();
            Collection.ListViewItemSorter = new ListViewItemComparer(e.Column, Collection.Sorting);
        }

        private void ContextMenuBlockOpening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Collection.SelectedItems.Count == 0) e.Cancel = true;
        }

        #endregion

        #region Pagination

        private void PagerUpdate()
        {
            var currentPage = Convert.ToInt32(pagerCurrentTb.Text);
            var allPages = Convert.ToInt32(pagerCountLabel.Tag);
            if (currentPage == 1)
            {
                pagerBeginBtn.Enabled = pagerDownBtn.Enabled = false;
                pagerEndBtn.Enabled = pagerUpBtn.Enabled = true;
            }

            if (currentPage == allPages)
            {
                pagerBeginBtn.Enabled = pagerDownBtn.Enabled = true;
                pagerEndBtn.Enabled = pagerUpBtn.Enabled = false;
            }

            if (currentPage > 1 && currentPage < allPages)
            {
                pagerBeginBtn.Enabled = pagerDownBtn.Enabled = pagerEndBtn.Enabled = pagerUpBtn.Enabled = true;
            }

            if (currentPage > allPages)
            {
                pagerBeginBtn.Enabled = pagerDownBtn.Enabled = pagerEndBtn.Enabled = pagerUpBtn.Enabled = false;
            }

            var tableLimit = Preferences.PageSize;
            var tableOffset = (currentPage - 1) * tableLimit;
            LibManagerForm.ReadTableFromDatabase(SelectedLibLabel.Text, tableLimit, tableOffset);
        }

        private void pagerCurrentTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsDigit(e.KeyChar) && e.KeyChar != '0';
        }

        private void pagerCurrentTb_TextChanged(object sender, EventArgs e)
        {
            PagerUpdate();
        }

        private void pagerBeginBtn_Click(object sender, EventArgs e)
        {
            pagerCurrentTb.Text = "1";
            PagerUpdate();
        }

        private void pagerDownBtn_Click(object sender, EventArgs e)
        {
            var currentPage = Convert.ToInt32(pagerCurrentTb.Text);
            pagerCurrentTb.Text = (currentPage - 1).ToString();
            PagerUpdate();
        }

        private void pagerUpBtn_Click(object sender, EventArgs e)
        {
            var currentPage = Convert.ToInt32(pagerCurrentTb.Text);
            pagerCurrentTb.Text = (currentPage + 1).ToString();
            PagerUpdate();
        }

        private void pagerEndBtn_Click(object sender, EventArgs e)
        {
            pagerCurrentTb.Text = pagerCountLabel.Tag.ToString();
            PagerUpdate();
        }

        #endregion
    }
}