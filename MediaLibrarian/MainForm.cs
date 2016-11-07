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
            InitializeComponent();
            libManagerForm = new LibManagerForm(this);
            editForm = new EditForm(this);
            settingsForm = new SettingsForm(this);
        }
        LibManagerForm libManagerForm;
        EditForm editForm;
        SettingsForm settingsForm;
        public List<Category> columnsInfo = new List<Category>();
        int LO;     //LocationOffset

        void LoadItemInfo(ListViewItem item)
        {
            InfoPanel.Controls.Clear();
            int s = 0;
            LO = 5;
            foreach (var col in columnsInfo)
            {
                if (s == 0) { s++; continue; }
                Label HeaderLabel = new Label() 
                {
                Location = new Point(3, LO),
                Size = new Size(200, 15),
                Font = new Font("Tahoma", 9.75f),
                AutoEllipsis = true,
                Text = col.Name + ":",
                };
                InfoPanel.Controls.Add(HeaderLabel);
                switch (col.Type)
                {
                    case "VARCHAR(128)": case "VARCHAR(20)": case "CHAR(20)": case "VARCHAR(10)": default:
                        {
                            Label strLabel = new Label()
                            {
                                Location = new Point(210, LO),
                                Size = new Size(200, 15),
                                Font = new Font("Tahoma", 9.75f),
                                AutoEllipsis = true,
                                Text = item.SubItems[s].Text,
                            };
                            InfoPanel.Controls.Add(strLabel);
                            LO += 20;
                        }; break;       //Строка, дата, дата+время, приоритет
                    case "TEXT":
                        {
                            LO += 20;
                            Label txtLabel = new Label()
                            {
                                Location = new Point(3, LO),
                                MaximumSize = new Size(405, 0),
                                Font = new Font("Tahoma", 9.75f),
                                AutoSize = true,
                                Text = item.SubItems[s].Text,
                            };
                            InfoPanel.Controls.Add(txtLabel);
                            LO += txtLabel.Size.Height+10;
                        }; break;       //Текст
                    
                    case "CHAR(5)":
                        {
                            Label m5Label = new Label()
                            {
                                Location = new Point(210, LO-5),
                                Size = new Size(200, 20),
                                Font = new Font("Lucida Console", 18f),
                                Text = item.SubItems[s].Text,
                            };
                            switch (HowMatch(m5Label.Text))
                            {
                                case 1:
                                case 2: m5Label.ForeColor = Color.Red; break;
                                case 3:
                                case 4: m5Label.ForeColor = Color.Orange; break;
                                case 5: m5Label.ForeColor = Color.LimeGreen; break;
                                default: break;
                            }
                            InfoPanel.Controls.Add(m5Label);
                            LO += 20;
                        }; break;       //Поле оценка (5)
                    case "CHAR(10)":
                        {
                            Label m10Label = new Label()
                            {
                                Location = new Point(210, LO-5),
                                Size = new Size(200, 20),
                                Font = new Font("Lucida Console", 18f),
                                Text = item.SubItems[s].Text,
                            }; 
                            switch (HowMatch(m10Label.Text))
                            {
                                case 1:
                                case 2:
                                case 3:
                                case 4: m10Label.ForeColor = Color.Red; break;
                                case 5:
                                case 6:
                                case 7:
                                case 8: m10Label.ForeColor = Color.Orange; break;
                                case 9:
                                case 10: m10Label.ForeColor = Color.LimeGreen; break; 
                                default: break;
                            }
                            InfoPanel.Controls.Add(m10Label);
                            LO += 20;
                        }; break;       //Поле оценка (10)
                }
                s++;
            }
        }
        int HowMatch(string sourceString)
        {
            var Star = new Regex("★");
            return Star.Matches(sourceString, 0).Count;
        }




        #region Buttons
        private void SelectCollectionButton_Click(object sender, EventArgs e)
        {
            libManagerForm.ShowDialog();
        }
        private void AddElementButton_Click(object sender, EventArgs e)
        {
            editForm.ShowDialog();
        }
        private void Edit_Click(object sender, EventArgs e)
        {
            if (Collection.SelectedItems.Count > 0)
            {
                editForm.EditMode = true;
                editForm.ShowDialog();
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
                editForm.DeleteItem(Collection.Columns[0].Text, Collection.SelectedItems[0].Text);
            }
            else
            {
                StatusLabel.Text = "Не выбран элемент для удаления";
            }
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            SearchButton.PerformClick();
        }
        #endregion
        #region FileTSM
        private void OpenLibTSMI_Click(object sender, EventArgs e)
        {
            SelectCollectionButton.PerformClick();
        }

        private void CreateLibTSMI_Click(object sender, EventArgs e)
        {
            libManagerForm.Edited = true;
            libManagerForm.ShowDialog();
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
            if (MessageBox.Show("Удалить элемент \"" + Collection.FocusedItem.Text + "\"?", "Подтверждение удаления элемента",
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
            settingsForm.ShowDialog();
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
            PictureViewer PV = new PictureViewer();
            PV.ImageBox.Image = PosterBox.Image;
            PV.Show();
        }

        private void Collection_ItemActivate(object sender, EventArgs e)
        {
            EditElementButton.PerformClick();
        }
        private void Collection_SelectedIndexChanged(object sender, EventArgs e)
        {
            TitleLabel.Text = Collection.FocusedItem.Text;
            TitleHeaderLabel.Text = Collection.Columns[0].Text;
            try
            {
                using (FileStream fs = File.OpenRead(String.Format(@"{0}\{1}\{2}.jpg", Environment.CurrentDirectory,
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
                PosterBox.BackgroundImage = MediaLibrarian.Properties.Resources.noposter;
            }
            LoadItemInfo(Collection.FocusedItem);
        }
        public string ReplaceSymblos(string str)
        {
            str = str.Replace(":", "꞉").Replace("*", "˟").Replace("?", "‽").Replace("\"", "ʺ");
            return str;
        }
    }
}
