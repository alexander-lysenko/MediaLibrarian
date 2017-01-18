using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Drawing;
using System.Data;

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
        List<CheckBox> boxList = new List<CheckBox>();
        List<Control> dataList = new List<Control>();

        static string CreateStars(string type, decimal value)
        {
            string str = ""; int symbolIndex, max;
            char[] symbols = { '☆', '★', '▒', '█' };
            switch (type)
            {
                case "VARCHAR(10)": symbolIndex = 3; max = 10; //Приоритет
                    break;
                case "CHAR(10)": symbolIndex = 1; max = 10; //Оценка 10
                    break;
                default: symbolIndex = 1; max = 5; //Оценка 5
                    break;
            }
            for (int i = 0; i < (int)value; i++)
            {
                str += symbols[symbolIndex];
            }
            for (int j = (int)value; j < max; j++)
            {
                str += symbols[symbolIndex - 1];
            }
            return str;
        }

        private void SearchForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
        private void SearchForm_Load(object sender, EventArgs e)
        {
            LoadMeta(_mainForm.ColumnsInfo);
            boxList[0].Checked = true;
        }
        public void LoadMeta(List<Category> columns)
        {
            foreach (var item in columns)
            {
                CreateChkBox(item.Name);
                CreateControl(item.Type);
            }
        }

        void CreateChkBox(string name)
        {
            var chkBox = new CheckBox
            {
                Size = new Size(150, 20),
                Text = name,
                Checked = false,
            };
            chkBox.CheckedChanged += new EventHandler(chkBox_CheckedChanged);
            boxList.Add(chkBox);
            dataPanel.Controls.Add(chkBox);
        }
        void CreateControl(string type)
        {
            switch (type)
            {
                case "CHAR(10)":
                case "VARCHAR(10)":
                    var num10 = new NumericUpDown
                    {
                        Minimum = 0,
                        Maximum = 10,
                        Enabled = false,
                        Size = new Size(265, 20),
                    };
                    dataList.Add(num10);
                    dataPanel.Controls.Add(num10);
                    break;
                case "CHAR(5)":
                    var num5 = new NumericUpDown
                    {
                        Minimum = 0,
                        Maximum = 5,
                        Enabled = false,
                        Size = new Size(265, 20),
                    };
                    dataList.Add(num5);
                    dataPanel.Controls.Add(num5);
                    break;
                default:
                    var line = new TextBox
                    {
                        Enabled = false,
                        Size = new Size(265, 20),
                    };
                    dataList.Add(line);
                    dataPanel.Controls.Add(line);
                    break;
            }
        }

        void Search()
        {
            string tableName = _mainForm.SelectedLibLabel.Text;
            var selectQuery = String.Format("select * from `{0}` where ", tableName);
            foreach (var item in _mainForm.ColumnsInfo)
            {
                int i = _mainForm.ColumnsInfo.IndexOf(item);
                if (dataList[i].Enabled)
                {
                    if(dataList[i] is NumericUpDown)
                    {
                        selectQuery += String.Format("`{0}` = '{1}' and", item.Name, CreateStars(item.Type, (dataList[i] as NumericUpDown).Value));
                    }
                    else
                    selectQuery += String.Format("`{0}` like '%{1}%' and", item.Name, dataList[i].Text);
                }
            }
            selectQuery += " 1 ";
            if (_mainForm.Preferences.AutoSortByName) selectQuery += String.Format("order by `{0}`", _mainForm.ColumnsInfo[0].Name);
            _mainForm.Collection.Items.Clear();
            var connection = Connetcion.Connection;
            var readTable = new SQLiteCommand(selectQuery, connection);
            var data = new DataTable();
            try
            {
                connection.Open();
                var reader = readTable.ExecuteReader();
                data.Load(reader);
                reader.Close();
                connection.Close();
                foreach (DataRow row in data.Rows)
                {
                    var item = new ListViewItem(row[0].ToString());
                    for (var i = 1; i < data.Columns.Count; i++)
                    {
                        item.SubItems.Add(row[i].ToString());
                    }
                    _mainForm.Collection.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка подключения к базе данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            Search();
            DialogResult = DialogResult.Abort;
        }
        private void chkBox_CheckedChanged(object sender, EventArgs e)
        {
            int index = boxList.IndexOf(sender as CheckBox), chkCount = 0;
            if (boxList[index].Checked) dataList[index].Enabled = true; else dataList[index].Enabled = false;
            foreach (var chk in boxList)
            {
                if (chk.Checked) chkCount++;
            }
            if (chkCount > 0) searchBtn.Enabled = true;
        }

        private void clearFormBtn_Click(object sender, EventArgs e)
        {
            dataPanel.Controls.Clear();
            LoadMeta(_mainForm.ColumnsInfo);
        }

        private void restoreTableBtn_Click(object sender, EventArgs e)
        {
            _mainForm._libManagerForm.ReadTableFromDatabase(_mainForm.SelectedLibLabel.Text);
        }
    }
}
