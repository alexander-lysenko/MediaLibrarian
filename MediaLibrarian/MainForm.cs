using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MediaLibrarian
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            //SplashForm splash = new SplashForm();
            //splash.ShowDialog();
            InitializeComponent();
            _libManagerForm = new LibManagerForm(this);
            _editForm = new EditForm(this);
            _settingsForm = new SettingsForm(this);
            _searchForm = new SearchForm(this);
        }

        LibManagerForm _libManagerForm;
        EditForm _editForm;
        SettingsForm _settingsForm;
        SearchForm _searchForm;
        public Settings Preferences;
        public List<Category> ColumnsInfo = new List<Category>();
        int offset; //LocationOffset

        void LoadItemInfo(ListViewItem item)
        {
            InfoPanel.Controls.Clear();
            offset = 5;
            foreach (var col in ColumnsInfo)
            {
                if (ColumnsInfo.IndexOf(col) == 0) continue;
                var headerLabel = new Label()
                {
                    Location = new Point(3, offset),
                    Size = new Size(200, 15),
                    Font = new Font("Tahoma", 9.75f),
                    AutoEllipsis = true,
                    Text = col.Name + ":",
                };
                InfoPanel.Controls.Add(headerLabel);
                switch (col.Type)
                {
                    case "VARCHAR(128)":
                    case "VARCHAR(20)":
                    case "CHAR(20)":
                    case "VARCHAR(10)":
                    default:
                    {
                        var strLabel = new Label()
                        {
                            Location = new Point(210, offset),
                            Size = new Size(200, 15),
                            Font = new Font("Tahoma", 9.75f),
                            AutoEllipsis = true,
                            Text = item.SubItems[ColumnsInfo.IndexOf(col)].Text,
                            TextAlign = ContentAlignment.MiddleRight,
                        };
                        InfoPanel.Controls.Add(strLabel);
                        offset += 20;
                    }
                        ;
                        break; //Строка, дата, дата+время, приоритет
                    case "TEXT":
                    {
                        offset += 20;
                        var txtLabel = new Label()
                        {
                            Location = new Point(3, offset),
                            MaximumSize = new Size(405, 0),
                            Font = new Font("Tahoma", 9.75f),
                            ForeColor = Color.Blue,
                            AutoSize = true,
                            Text = item.SubItems[ColumnsInfo.IndexOf(col)].Text,
                        };
                        InfoPanel.Controls.Add(txtLabel);
                        offset += txtLabel.Size.Height + 10;
                    }
                        ;
                        break; //Текст

                    case "CHAR(5)":
                    {
                        var m5Label = new Label()
                        {
                            Location = new Point(210, offset - 5),
                            Size = new Size(200, 20),
                            Font = new Font("Lucida Console", 18f),
                            Text = item.SubItems[ColumnsInfo.IndexOf(col)].Text,
                            TextAlign = ContentAlignment.MiddleRight,
                        };
                        switch (HowMatch(m5Label.Text))
                        {
                            case 1:
                            case 2:
                                m5Label.ForeColor = Color.Red;
                                break;
                            case 3:
                            case 4:
                                m5Label.ForeColor = Color.Orange;
                                break;
                            case 5:
                                m5Label.ForeColor = Color.LimeGreen;
                                break;
                            default:
                                break;
                        }
                        InfoPanel.Controls.Add(m5Label);
                        offset += 20;
                    }
                        ;
                        break; //Поле оценка (5)
                    case "CHAR(10)":
                    {
                        var m10Label = new Label()
                        {
                            Location = new Point(210, offset - 5),
                            Size = new Size(200, 20),
                            Font = new Font("Lucida Console", 18f),
                            Text = item.SubItems[ColumnsInfo.IndexOf(col)].Text,
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
                                m10Label.ForeColor = Color.LimeGreen;
                                break;
                            default:
                                break;
                        }
                        InfoPanel.Controls.Add(m10Label);
                        offset += 20;
                    }
                        ;
                        break; //Поле оценка (10)
                }
            }
            InfoPanel.Controls.Add(new Label() {Location = new Point(1, offset), Size = new Size(1, 20)});
        }
        int HowMatch(string sourceString)
        {
            var star = new Regex("★");
            return star.Matches(sourceString, 0).Count;
        }
        #region Buttons

        private void SelectCollectionButton_Click(object sender, EventArgs e)
        {
            _libManagerForm.ShowDialog();
        }

        private void AddElementButton_Click(object sender, EventArgs e)
        {
            _editForm.ShowDialog();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (Collection.SelectedItems.Count > 0)
            {
                _editForm.EditMode = true;
                _editForm.ShowDialog();
            }
            else
            {
                StatusLabel.Text = "Не выбран элемент для редактирования";
            }
        }

        private void DeleteElementButton_Click(object sender, EventArgs e)
        {
            if (Collection.SelectedItems.Count > 0)
            {
                _editForm.DeleteItem(Collection.Columns[0].Text, Collection.SelectedItems[0].Text);
            }
            else
            {
                StatusLabel.Text = "Не выбран элемент для удаления";
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            _searchForm.Show();
        }

        #endregion
        #region FileTSM

        private void OpenLibTSMI_Click(object sender, EventArgs e)
        {
            SelectCollectionButton.PerformClick();
        }

        private void CreateLibTSMI_Click(object sender, EventArgs e)
        {
            _libManagerForm.Edited = true;
            _libManagerForm.ShowDialog();
        }

        private void ClearLibTSMI_Click(object sender, EventArgs e)
        {

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
            if (MessageBox.Show("Удалить элемент \"" + Collection.FocusedItem.Text + "\"?",
                    "Подтверждение удаления элемента",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

        }

        private void FullScreenTSMI_Click(object sender, EventArgs e)
        {
            if (FullScreenTSMI.Checked) WindowState = FormWindowState.Maximized;
            else WindowState = FormWindowState.Normal;
        }

        private void PreferencesTSMI_Click(object sender, EventArgs e)
        {
            _settingsForm.ShowDialog();
        }

        #endregion
        #region HelpTSM

        private void HelpTSMI_Click(object sender, EventArgs e)
        {

        }

        private void AboutTSMI_Click(object sender, EventArgs e)
        {

        }

        #endregion
        private void PosterBox_MouseClick(object sender, MouseEventArgs e)
        {
            var pv = new PictureViewer {ImageBox = {Image = PosterBox.Image}};
            pv.Show();
        }
        private void Collection_ItemActivate(object sender, EventArgs e)
        {
            EditElementButton.PerformClick();
        }
        private void Collection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Collection.SelectedItems.Count > 0)
            {
                LoadItemInfo(Collection.SelectedItems[0]);
                TitleLabel.Text = Collection.SelectedItems[0].Text;
            }
            try
            {
                using (var fs = File.OpenRead(String.Format(@"{0}\{1}\{2}.jpg", Environment.CurrentDirectory,
                    ReplaceSymblos(SelectedLibLabel.Text),
                    ReplaceSymblos(Collection.FocusedItem.Text))))
                {
                    PosterBox.Image = Image.FromStream(fs);
                    PosterBox.BackgroundImage = null;
                }
            }
            catch (Exception)
            {
                PosterBox.Image = null;
                PosterBox.BackgroundImage = Properties.Resources.noposter;
            }
        }
        public string ReplaceSymblos(string str)
        {
            str = str.Replace(":", "꞉").Replace("*", "˟").Replace("?", "‽").Replace("\"", "ʺ");
            return str;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                _settingsForm.Preferences = XmlManager.Deserialize();
                Text = _settingsForm.Preferences.FormCaptionText;
                TitleLabel.ForeColor = Color.FromArgb(_settingsForm.Preferences.MainColor);
                TitleLabel.Font = new Font(_settingsForm.Preferences.MainFont.FontFamilyName,
                    _settingsForm.Preferences.MainFont.FontSize, _settingsForm.Preferences.MainFont.FontStyle);
                _libManagerForm.ReadTableFromDatabase("Фильмы");
            }
            catch (Exception)
            {
                ;
            }
            screenResolutionLabel.Text = String.Format("Разрешение экрана: {0}х{1}", 
                SystemInformation.PrimaryMonitorSize.Width, SystemInformation.PrimaryMonitorSize.Height);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_settingsForm.rememberLastLibraryChk.Checked)
            {
                _settingsForm.Preferences.LastLibraryName = SelectedLibLabel.Text;
                XmlManager.Serialize(_settingsForm.Preferences);
            }
        }
    }
}
