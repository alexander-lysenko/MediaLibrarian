using System;
using System.Collections.Generic;
using System.Drawing;
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
        
        private void Collection_ItemActivate(object sender, EventArgs e)
        {
            EditElementButton.PerformClick();
        }
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

        }

        #region FileTSM
        private void OpenLibTSMI_Click(object sender, EventArgs e)
        {
            SelectCollectionButton.PerformClick();
        }

        private void CreateLibTSMI_Click(object sender, EventArgs e)
        {
            libManagerForm.ShowDialog();
            libManagerForm.CreateNewLibraryButton.PerformClick();
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
            if (AutoSortingTSMI.Checked) AutoSortingTSMI.Checked = false;
            else AutoSortingTSMI.Checked = true;
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
    }
}
