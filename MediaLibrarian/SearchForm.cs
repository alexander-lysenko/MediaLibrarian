using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SQLite;

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
            titleLabel.Text = _mainForm.ColumnsInfo[0].Name;
            LoadMeta(_mainForm.ColumnsInfo);
        }
        public void LoadMeta(List<Category> columns)
        {

        }

        /*void Search()
        {
            var selectQuery = String.Format("select * from `{0}` ", tableName);
            if (_mainForm.Preferences.AutoSortByName) selectQuery += "order by " + _mainForm.ColumnsInfo[0].Name;
            var selectCountQuery = String.Format("select count(*) from `{0}`", tableName);
            _mainForm.Collection.Items.Clear();
            var readTable = new SQLiteCommand(selectQuery, _mainForm.C);
            var count = new SQLiteCommand(selectCountQuery, _connection);
            var data = new DataTable();
            object rowsCount;
            try
            {
                _connection.Open();
                var reader = readTable.ExecuteReader();
                rowsCount = count.ExecuteScalar();
                data.Load(reader);
                reader.Close();
                _connection.Close();
                foreach (DataRow row in data.Rows)
                {
                    var item = new ListViewItem(row[0].ToString());
                    for (var i = 1; i < data.Columns.Count; i++)
                    {
                        item.SubItems.Add(row[i].ToString());
                    }
                    _mainForm.Collection.Items.Add(item);
                }
        }*/

        private void searchButton_Click(object sender, EventArgs e)
        {
        }
    }
}
