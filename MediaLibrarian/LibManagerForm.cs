﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.Common;
using System.Data;

namespace MediaLibrarian
{
    public partial class LibManagerForm : Form
    {
        public LibManagerForm(MainForm formMain)
        {
            InitializeComponent();
            _mainForm = formMain;
        }
        MainForm _mainForm;

        public bool Edited;
        public const int MaxFc = 20;
        public int FNo = -1;
        public string LibTableHeaders = "";
        List<TextBox> _fieldName = new List<TextBox>();
        List<ComboBox> _fieldType = new List<ComboBox>();
        List<Button> _removeButton = new List<Button>();
        TextBox _libNameTb = new TextBox() { Size = new Size(265, 20), Location = new Point(130, 0), MaxLength = 50 };
        Point _fieldPosition = new Point(5, 25);
        public readonly SQLiteConnection _connection = Connetcion.Connection;

        private int GetColumnLength(string type)
        {
            switch (type)
            {
                case "VARCHAR(128)": return 200;    //Строка
                case "TEXT": return 300;            //Текст
                case "VARCHAR(20)": return 120;     //Поле дата
                case "CHAR(20)": return 120;        //Поле дата+время
                case "CHAR(5)": return 90;          //Поле оценка (5)
                case "CHAR(10)": return 90;         //Поле оценка (10)
                case "VARCHAR(10)": return 90;      //Поле приоритет
            }
            return 120;
        }
        private string GetTypeString(int index)
        {
            switch (index)
            {
                case 0: return "VARCHAR(128)";      //Строка
                case 1: return "TEXT";              //Текст
                case 2: return "VARCHAR(20)";       //Поле дата
                case 3: return "CHAR(20)";          //Поле дата+время
                case 4: return "CHAR(5)";           //Поле оценка (5)
                case 5: return "CHAR(10)";          //Поле оценка (10)
                case 6: return "VARCHAR(10)";       //Поле приоритет
                default: return "VARCHAR(128)";
            }
        }
        #region Database API
        private void ReadDatabase_ForLibsList()
        {
            LibsList.Items.Clear();
            var getTables = new SQLiteCommand("select name from sqlite_master where type='table' order by name;", _connection);
            _connection.Open();
            var readTables = getTables.ExecuteReader();
            foreach (DbDataRecord table in readTables)
            {
                var colsList = new List<string>();
                var lib = new ListViewItem(table["name"].ToString());
                var getColumns = new SQLiteCommand(string.Format("pragma table_info(`{0}`);", table["name"]), _connection);
                var readCols = getColumns.ExecuteReader();
                foreach (DbDataRecord col in readCols)
                {
                    colsList.Add(col["name"].ToString());
                }
                lib.SubItems.Add(string.Join(", ", colsList));
                LibsList.Items.Add(lib);
            }
            _connection.Close();
        }
        public void ReadHeadersForTable(string tableName)
        {
            _mainForm.ColumnsInfo.Clear();
            var getColumns = new SQLiteCommand(string.Format("pragma table_info('{0}');", tableName), _connection);
            _connection.Open();
            var readCols = getColumns.ExecuteReader();
            foreach (DbDataRecord col in readCols)
            {
                _mainForm.Collection.Columns.Add(col["name"].ToString(), GetColumnLength(col["type"].ToString()));
                _mainForm.ColumnsInfo.Add(new Category
                {
                    Name = col["name"].ToString(),
                    Type = col["type"].ToString()
                });
            }
            _connection.Close();
        }
        public void ReadTableFromDatabase(string tableName)
        {
            var selectQuery = String.Format("select * from `{0}` ", tableName);
            if (_mainForm.Preferences.AutoSortByName) selectQuery += "order by " + _mainForm.ColumnsInfo[0].Name;
            var selectCountQuery = String.Format("select count(*) from `{0}`", tableName);
            _mainForm.Collection.Items.Clear();
            var readTable = new SQLiteCommand(selectQuery, _connection);
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
                _mainForm.ElementCount.Text = rowsCount.ToString();
                _mainForm.InfoPanel.Controls.Clear();
                _mainForm.PosterBox.BackgroundImage = null;
                _mainForm.PosterBox.Image = null;
                _mainForm.TitleHeaderLabel.Text = _mainForm.Collection.Columns[0].Text + ":";
                _mainForm.TitleLabel.Text = "";
                _mainForm.SelectedLibLabel.Text = tableName;
                _mainForm.ElementActionsGB.Enabled = true;
                if (_mainForm.Preferences.FocusFirstItem && _mainForm.Collection.Items.Count > 0)
                    _mainForm.Collection.Items[0].Selected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка подключения к базе данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ClearLibrary(string tableName)
        {
            var clearQuery = String.Format("delete from `{0}`", tableName);
            var Clear = new SQLiteCommand(clearQuery, _connection);
            _connection.Open();
            Clear.ExecuteNonQuery();
            _connection.Close();
        }
        #endregion
        #region Buttons
        private void CreateNewLibraryButton_Click(object sender, EventArgs e)
        {
            AddFieldsPanel.Controls.Clear();
            CollectionEditGB.Visible = true;
            AddFieldsPanel.Controls.Add(new Label()
            {
                Size = new Size(120, 20),
                Text = "Название библиотеки"
            });
            _libNameTb.TextChanged += new EventHandler(this.TB_TextChanged);
            AddFieldsPanel.Controls.Add(_libNameTb);
            AddMoreFieldsButton.PerformClick();
            _fieldType[0].Enabled = false;
            _removeButton[0].Enabled = false;
            CreateNewLibraryButton.Enabled = false;
        }
        private void RemoveCollectionButton_Click(object sender, EventArgs e)
        {
            if (LibsList.SelectedItems.Count != 0)
                if (MessageBox.Show("Нажимая \"Удалить библиотеку\", \nВы осознанно принимаете решение удалить выбранную библиотеку\n(" + LibsList.FocusedItem.Text
                    + ")\nцеликом, включая все накопленные в ней элементы.\nПродолжить?", "Очень важное предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (_mainForm.SelectedLibLabel.Text == LibsList.SelectedItems[0].Text)
                    {
                        _mainForm.Collection.Clear();
                        _mainForm.SelectedLibLabel.Text = "";
                        _mainForm.ElementActionsGB.Enabled = false;
                    }
                    var dropTable = new SQLiteCommand(String.Format("drop table `{0}`;", LibsList.SelectedItems[0].Text), _connection);
                    _connection.Open();
                    dropTable.ExecuteNonQuery();
                    _connection.Close();
                    _mainForm.StatusLabel.Text = " Была удалена библиотека \"" + LibsList.SelectedItems[0].Text + "\"";
                    try { 
                    System.IO.Directory.Delete(Environment.CurrentDirectory + "\\Posters\\" +
                        _mainForm.ReplaceSymblos(LibsList.SelectedItems[0].Text), true);
                    }
                    catch(Exception)
                    {}
                    if (_mainForm.SelectedLibLabel.Text == LibsList.SelectedItems[0].Text) _mainForm.FormReset();
                    ReadDatabase_ForLibsList(); 
                }
        }
        private void SaveLibraryButton_Click(object sender, EventArgs e)
        {
            if (_libNameTb.Text == "")
            {
                MessageBox.Show("Не заполнено название новой библиотеки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (var i = 0; i < _fieldName.Count; i++)
            {
                if (_fieldName[i].Text == "" || _fieldType[_fieldName.IndexOf(_fieldName[i])].SelectedIndex == -1)
                { MessageBox.Show("Пожалуйста, заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                for (var j = i + 1; j < _fieldName.Count; j++)
                {
                    if (_fieldName[i].Text == _fieldName[j].Text)
                    { MessageBox.Show("Пожалуйста, воздержитесь от одинаковых имен для полей", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                }
            }
            var query = String.Format("create table `{0}` (", _libNameTb.Text);
            foreach (var item in _fieldName)
            {
                query += "`" + item.Text + "` " + GetTypeString(_fieldType[_fieldName.IndexOf(item)].SelectedIndex);
                if (_fieldName.IndexOf(item) == 0)
                {
                    query += " NOT NULL UNIQUE";
                }
                if (_fieldName.IndexOf(item) != _fieldName.Count - 1)
                {
                    query += ", ";
                }
            }
            query += ");";

            var createTable = new SQLiteCommand(query, _connection);
            _connection.Open();
            var verifyName = new SQLiteCommand("select name from sqlite_master where type='table' order by name;", _connection);
            var readTables = verifyName.ExecuteReader();
            foreach (DbDataRecord table in readTables)
            {
                if (table["name"].ToString().ToLower().Equals(_libNameTb.Text.ToLower()))
                {
                    MessageBox.Show("Библиотека с таким именем уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _connection.Close(); return;
                }
            }
            createTable.ExecuteNonQuery();
            readTables.Close();
            _connection.Close();
            System.IO.Directory.CreateDirectory(Environment.CurrentDirectory+"\\" + _mainForm.ReplaceSymblos(_libNameTb.Text));
            ReadDatabase_ForLibsList();
            CollectionEditGB.Visible = Edited = false;
            CreateNewLibraryButton.Enabled = RemoveLibraryButton.Enabled = true;
            _mainForm.StatusLabel.Text = " Была создана библиотека \"" + _libNameTb.Text + "\"";
            FormReset();
            
        }
        private void AddMoreFieldsButton_Click(object sender, EventArgs e)
        {
            if (_fieldName.Count > 20)
            {
                MessageBox.Show("Простите, но больше полей добавть нельзя!");
                return;
            }
            FNo = _fieldName.Count;
            _fieldName.Add(new TextBox()
            {
                Size = new Size(210, 20),
            });
            AddFieldsPanel.Controls.Add(_fieldName[FNo]);
            _fieldName[FNo].TextChanged += new EventHandler(this.TB_TextChanged);

            _fieldType.Add(new ComboBox()
            {
                Size = new Size(150, 21),
                DropDownStyle = ComboBoxStyle.DropDownList,
            });
            _fieldType[FNo].Items.AddRange(new object[] {"Строка", "Текст", "Поле \"Дата\"",
            "Поле \"Дата + Время\"", "Поле \"Оценка (5)\"", "Поле \"Оценка (10)\"", "Поле \"Приоритет\""});
            AddFieldsPanel.Controls.Add(_fieldType[FNo]);
            _fieldType[FNo].SelectedIndex = 0;

            _removeButton.Add(new Button()
            {
                Size = new Size(20, 21),
                Text = "-",
                Tag = FNo.ToString(),
                TabStop = true
            });
            _removeButton[FNo].Click += new System.EventHandler(this.RemoveButton_Click);
            AddFieldsPanel.Controls.Add(_removeButton[FNo]);
            Edited = true;
        }
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (_fieldName.Count <= 1)
            {
                MessageBox.Show("Это поле удалять нельзя!");
                return;
            }
            var In = _removeButton.IndexOf(sender as Button);//int.Parse((sender as Button).Tag.ToString());
            AddFieldsPanel.Controls.Remove(_fieldName[In]);
            _fieldName.Remove(_fieldName[In]);
            AddFieldsPanel.Controls.Remove(_fieldType[In]);
            _fieldType.Remove(_fieldType[In]);
            AddFieldsPanel.Controls.Remove(_removeButton[In]);
            _removeButton.Remove(_removeButton[In]);
        }
        #endregion
        private void LibsList_ItemActivate(object sender, EventArgs e)
        {
            _mainForm.Collection.Clear();
            _mainForm.ColumnsInfo.Clear();
            ReadHeadersForTable(LibsList.FocusedItem.Text);
            ReadTableFromDatabase(LibsList.FocusedItem.Text);
            _mainForm.ClearLibTSMI.Enabled = true;
            this.Close();
        }
        private void TB_TextChanged(object sender, EventArgs e)
        {
            (sender as TextBox).Text = (sender as TextBox).Text.
                Replace("<", "").Replace(">", "").Replace("|", "").Replace("/", "").Replace("\\", "");
        }
        private void LibManagerForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete: RemoveLibraryButton.PerformClick(); break;
                case Keys.Escape: FormReset(); break;
            }
        }
        private void LibManagerForm_Load(object sender, EventArgs e)
        {
            this.Size = new Size(480, 220);
            ReadDatabase_ForLibsList();
            LibsList.Focus();
            if (LibsList.Items.Count>0) LibsList.Items[0].Selected = LibsList.Items[0].Focused = true;
        }
        private void LibManagerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Edited)
            {
                if (MessageBox.Show("Выйти без сохранения?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    FormReset();
                }
                else e.Cancel = true;
            }
            else FormReset();
        }
        private void FormReset()
        {
            AddFieldsPanel.Controls.Clear();
            CollectionEditGB.Visible = false;
            _libNameTb.Text = "";
            _fieldName.Clear();
            _fieldType.Clear();
            _removeButton.Clear();
            _fieldPosition = new Point(5, 25);
            CreateNewLibraryButton.Enabled = true;
            RemoveLibraryButton.Enabled = true;
            Edited = false;
        }
    }
}
