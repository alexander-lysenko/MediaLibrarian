using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Linq;

namespace MediaLibrarian_
{
    public partial class SearchForm : Form
    {
        public SearchForm(MainForm formMain)
        {
            InitializeComponent();
            _mainForm = formMain;
        }

        private readonly MainForm _mainForm;
        private readonly List<CheckBox> _boxList = new List<CheckBox>();
        private readonly List<Control> _dataList = new List<Control>();

        private static string CreateStars(string type, decimal value)
        {
            var str = "";
            int symbolIndex, max;
            char[] symbols = { '☆', '★', '▒', '█' };
            switch (type)
            {
                case "VARCHAR(10)":
                    symbolIndex = 3;
                    max = 10; //Приоритет
                    break;
                case "CHAR(10)":
                    symbolIndex = 1;
                    max = 10; //Оценка 10
                    break;
                default:
                    symbolIndex = 1;
                    max = 5; //Оценка 5
                    break;
            }

            for (var i = 0; i < (int)value; i++)
            {
                str += symbols[symbolIndex];
            }

            for (var j = (int)value; j < max; j++)
            {
                str += symbols[symbolIndex - 1];
            }

            return str;
        }

        private void LoadMeta(List<Category> columns)
        {
            foreach (var item in columns)
            {
                CreateChkBox(item.Name);
                CreateControl(item.Type);
            }
        }

        private void CreateChkBox(string name)
        {
            var chkBox = new CheckBox
            {
                Size = new Size(150, 20),
                Text = name,
                Checked = false,
            };
            chkBox.CheckedChanged += chkBox_CheckedChanged;
            _boxList.Add(chkBox);
            dataPanel.Controls.Add(chkBox);
        }

        private void CreateControl(string type)
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
                    _dataList.Add(num10);
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
                    _dataList.Add(num5);
                    dataPanel.Controls.Add(num5);
                    break;
                default:
                    var line = new TextBox
                    {
                        Enabled = false,
                        Size = new Size(265, 20),
                    };
                    _dataList.Add(line);
                    dataPanel.Controls.Add(line);
                    break;
            }
        }

        private void Search()
        {
            var tableName = _mainForm.SelectedLibLabel.Text;
            var selectQuery = string.Format("select * from `{0}` where ", tableName);
            foreach (var item in _mainForm.ColumnsInfo)
            {
                var i = _mainForm.ColumnsInfo.IndexOf(item);
                if (!_dataList[i].Enabled) continue;

                selectQuery += _dataList[i] is NumericUpDown
                    ? string.Format(
                        "`{0}` = '{1}' and ",
                        item.Name,
                        CreateStars(item.Type, (_dataList[i] as NumericUpDown).Value)
                    )
                    : string.Format(
                        "TOUPPER(`{0}`) like '%{1}%' and ",
                        item.Name,
                        _dataList[i].Text.ToUpper()
                    );
            }

            selectQuery += " 1 ";
            if (_mainForm.Preferences.AutoSortByName)
                selectQuery += string.Format("order by `{0}`", _mainForm.ColumnsInfo[0].Name);
            _mainForm.Collection.Items.Clear();
            try
            {
                var data = Database.GetTable(selectQuery);
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
                MessageBox.Show(
                    text: ex.Message,
                    caption: "Ошибка подключения к базе данных",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Error
                );
            }
        }

        #region FormEvents

        private void searchButton_Click(object sender, EventArgs e)
        {
            Search();
            DialogResult = DialogResult.Abort;
        }

        private void chkBox_CheckedChanged(object sender, EventArgs e)
        {
            int index = _boxList.IndexOf(sender as CheckBox), chkCount = 0;
            _dataList[index].Enabled = _boxList[index].Checked;
            chkCount += _boxList.Count(chk => chk.Checked);
            if (chkCount > 0) searchBtn.Enabled = true;
        }

        private void clearFormBtn_Click(object sender, EventArgs e)
        {
            dataPanel.Controls.Clear();
            LoadMeta(_mainForm.ColumnsInfo);
        }

        private void restoreTableBtn_Click(object sender, EventArgs e)
        {
            _mainForm.LibManagerForm.ReadTableFromDatabase(
                _mainForm.SelectedLibLabel.Text,
                _mainForm.Preferences.PageSize
            );
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            LoadMeta(_mainForm.ColumnsInfo);
            _boxList[0].Checked = true;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void SearchForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        #endregion
    }
}