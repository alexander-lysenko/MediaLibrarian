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

        public List<Category> CurrentLibraryColumns = new List<Category>();

        
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
            EditForm.ShowDialog();
        }

        private void PreferencesTSMI_Click(object sender, EventArgs e)
        {
            SettingsForm.ShowDialog();
        }

    }
}
