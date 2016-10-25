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
            LibManagerForm = new LibManagerForm(this);
            EditForm = new EditForm(this);
            SettingsForm = new SettingsForm(this);
        }
        LibManagerForm LibManagerForm;
        EditForm EditForm;
        SettingsForm SettingsForm;
        
        private void SelectCollectionButton_Click(object sender, EventArgs e)
        {
            LibManagerForm.ShowDialog();
        }

        private void AddElementButton_Click(object sender, EventArgs e)
        {
            EditForm.ShowDialog();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (Collection.SelectedItems.Count > 0)
            {
                EditForm.EditMode = true;
                EditForm.ShowDialog();
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
                EditForm.DeleteItem(Collection.SelectedItems[0].Text);
            }
            else
            {
                StatusLabel.Text = "Не выбран элемент для удаления";
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {

        }

        private void PreferencesTSMI_Click(object sender, EventArgs e)
        {
            SettingsForm.ShowDialog();
        }
        private void EditElementTSMI_Click(object sender, EventArgs e)
        {
            EditElementButton.PerformClick();
        }
        private void Collection_ItemActivate(object sender, EventArgs e)
        {
            EditElementButton.PerformClick();
        }



    }
}
