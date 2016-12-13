using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MediaLibrarian
{
    public partial class SearchForm : Form
    {
        public SearchForm(MainForm formMain)
        {
            InitializeComponent();
            _mainForm = formMain;
        }
        MainForm _mainForm;

        private void SearchForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {

        }
        public void LoadMeta(List<Category> columns)
        {

        }
    }
}
