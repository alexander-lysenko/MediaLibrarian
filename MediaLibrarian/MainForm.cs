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
        }
        LibManagerForm LibManagerForm;
        EditForm EditForm;

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

    }
}
