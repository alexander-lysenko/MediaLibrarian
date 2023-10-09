using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MediaLibrarian_
{
    public partial class LibManagerForm : Form
    {
        public LibManagerForm(MainForm formMain)
        {
            InitializeComponent();
            _mainForm = formMain;
        }

        private readonly MainForm _mainForm;

        private bool _edited;
        public const int MaxFc = 20;
        private int _fNo = -1;
        public string LibTableHeaders = "";
        private readonly List<TextBox> _fieldName = new List<TextBox>();
        private readonly List<ComboBox> _fieldType = new List<ComboBox>();
        private readonly List<Button> _removeButton = new List<Button>();

        private readonly TextBox _libNameTb = new TextBox
        {
            Size = new Size(265, 20),
            Location = new Point(130, 0),
            MaxLength = 50
        };

        private Point _fieldPosition = new Point(5, 25);

        private static void ErrorMessage(Exception ex)
        {
            MessageBox.Show(
                text: string.Format(
                    "Имя ошибки: {0}\nМесто: {1}\nЗначение: {2}",
                    ex.ToString().Remove(ex.ToString().IndexOf(':')),
                    ex.Source,
                    ex.Message
                ),
                caption: "Произошла ошибка",
                buttons: MessageBoxButtons.OK,
                icon: MessageBoxIcon.Error
            );
        }

        private static int GetColumnLength(string type)
        {
            switch (type)
            {
                case "VARCHAR(128)": return 200; //Строка
                case "TEXT": return 300; //Текст
                case "VARCHAR(20)": return 120; //Поле дата
                case "CHAR(20)": return 120; //Поле дата+время
                case "CHAR(5)": return 90; //Поле оценка (5)
                case "CHAR(10)": return 90; //Поле оценка (10)
                case "VARCHAR(10)": return 90; //Поле приоритет
            }

            return 120;
        }

        private static string GetTypeString(int index)
        {
            switch (index)
            {
                case 0: return "VARCHAR(128)"; //Строка
                case 1: return "TEXT"; //Текст
                case 2: return "VARCHAR(20)"; //Поле дата
                case 3: return "CHAR(20)"; //Поле дата+время
                case 4: return "CHAR(5)"; //Поле оценка (5)
                case 5: return "CHAR(10)"; //Поле оценка (10)
                case 6: return "VARCHAR(10)"; //Поле приоритет
                default: return "VARCHAR(128)";
            }
        }

        private bool VerifyFields()
        {
            if (_libNameTb.Text == "")
            {
                MessageBox.Show(
                    text: "Не заполнено название новой библиотеки",
                    caption: "Ошибка",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Error
                );
                return false;
            }

            for (var i = 0; i < _fieldName.Count; i++)
            {
                if (_fieldName[i].Text == "" || _fieldType[_fieldName.IndexOf(_fieldName[i])].SelectedIndex == -1)
                {
                    MessageBox.Show(
                        text: "Пожалуйста, заполните все поля",
                        caption: "Ошибка",
                        buttons: MessageBoxButtons.OK,
                        icon: MessageBoxIcon.Error
                    );
                    return false;
                }

                for (var j = i + 1; j < _fieldName.Count; j++)
                {
                    if (_fieldName[i].Text.Trim() != _fieldName[j].Text.Trim()) continue;
                    MessageBox.Show(
                        text: "Пожалуйста, воздержитесь от одинаковых имен для полей",
                        caption: "Ошибка",
                        buttons: MessageBoxButtons.OK,
                        icon: MessageBoxIcon.Error
                    );
                    return false;
                }
            }

            return true;
        }

        private string MakeCreateQuery()
        {
            var createQuery = string.Format("create table `{0}` (", _libNameTb.Text.Trim());
            foreach (var item in _fieldName)
            {
                createQuery += string.Format(
                    "`{0}` {1}",
                    item.Text.Trim(),
                    GetTypeString(_fieldType[_fieldName.IndexOf(item)].SelectedIndex)
                );
                if (_fieldName.IndexOf(item) == 0) createQuery += " NOT NULL UNIQUE";
                if (_fieldName.IndexOf(item) != _fieldName.Count - 1) createQuery += ", ";
            }

            createQuery += ");";
            return createQuery;
        }

        #region Database API

        private void ReadDatabase_ForLibsList()
        {
            LibsList.Items.Clear();
            try
            {
                var getTablesQuery = "select name from sqlite_master where type='table' order by name;";
                var readTables = Database.GetTable(getTablesQuery);
                foreach (DataRow table in readTables.Rows)
                {
                    var colsList = new List<string>();
                    var lib = new ListViewItem(table[0].ToString());
                    var getColumnsQuery = string.Format("pragma table_info(`{0}`);",
                        table[table.Table.Columns["name"].Ordinal]);
                    var readCols = Database.GetTable(getColumnsQuery);
                    foreach (DataRow col in readCols.Rows)
                    {
                        Console.Write(col.ItemArray);
                        colsList.Add(col[col.Table.Columns["name"].Ordinal].ToString());
                    }

                    lib.SubItems.Add(string.Join(", ", colsList));
                    LibsList.Items.Add(lib);
                }

                /*var readTables = Database.GetReader(getTablesQuery);
                foreach (DbDataRecord table in readTables)
                {
                    var colsList = new List<string>();
                    var lib = new ListViewItem(table["name"].ToString());
                    var getColumnsQuery = String.Format("pragma table_info(`{0}`);", table["name"]);
                    var readCols = Database.GetReader(getColumnsQuery);
                    foreach (DbDataRecord col in readCols)
                    {
                        colsList.Add(col["name"].ToString());
                    }
                    lib.SubItems.Add(string.Join(", ", colsList));
                    LibsList.Items.Add(lib);
                }*/
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }
        }

        public void ReadHeadersForTable(string tableName)
        {
            _mainForm.ColumnsInfo.Clear();
            var getColumnsQuery = string.Format("pragma table_info('{0}');", tableName);
            try
            {
                var readCols = Database.GetTable(getColumnsQuery);
                foreach (DataRow col in readCols.Rows)
                {
                    var name = col.Table.Columns["name"].Ordinal;
                    var type = col.Table.Columns["type"].Ordinal;
                    _mainForm.Collection.Columns.Add(col[name].ToString(), GetColumnLength(col[type].ToString()));
                    _mainForm.ColumnsInfo.Add(new Category
                    {
                        Name = col[name].ToString(),
                        Type = col[type].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }
        }

        public void ReadTableFromDatabase(string tableName, int limit = 0, int offset = 0)
        {
            var selectCountQuery = string.Format("select count(*) from `{0}`", tableName);
            var selectQuery = string.Format("select * from `{0}` ", tableName);
            if (_mainForm.Preferences.AutoSortByName) selectQuery += "order by " + _mainForm.ColumnsInfo[0].Name;
            if (limit > 0) selectQuery += string.Format(" limit {0} offset {1}", limit, offset);
            _mainForm.Collection.Items.Clear();
            try
            {
                var data = Database.GetTable(selectQuery);
                var rowsCount = Database.GetScalar(selectCountQuery);
                foreach (DataRow row in data.Rows)
                {
                    var item = new ListViewItem(row[0].ToString());
                    for (var i = 1; i < data.Columns.Count; i++)
                    {
                        item.SubItems.Add(row[i].ToString());
                    }

                    _mainForm.Collection.Items.Add(item);
                }

                if (limit > 0)
                {
                    var rows = Convert.ToInt32(rowsCount);
                    var pagesCount = Math.Ceiling(d: rows / limit) + 1;
                    _mainForm.pagerCountLabel.Tag = pagesCount;
                    _mainForm.pagerCountLabel.Text = string.Format("из {0}", pagesCount);
                    _mainForm.paginationToolStrip.Enabled = rows > _mainForm.Preferences.PageSize;
                }

                _mainForm.ElementCount.Text = rowsCount.ToString();
                _mainForm.InfoPanel.Controls.Clear();
                _mainForm.PosterBox.BackgroundImage = null;
                _mainForm.PosterBox.Image = null;
                _mainForm.TitleHeaderLabel.Text = "Нет элементов для отображения";
                _mainForm.TitleLabel.Text = "";
                _mainForm.SelectedLibLabel.Text = tableName;
                _mainForm.ElementActionsGB.Enabled = true;
                if (_mainForm.Preferences.FocusFirstItem && _mainForm.Collection.Items.Count > 0)
                    _mainForm.Collection.Items[0].Selected = true;
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }
        }

        public void ClearLibrary(string tableName)
        {
            var clearQuery = string.Format("delete from `{0}`", tableName);
            Database.Execute(clearQuery);
        }

        #endregion

        #region Buttons

        private void CreateNewLibraryButton_Click(object sender, EventArgs e)
        {
            AddFieldsPanel.Controls.Clear();
            CollectionEditGB.Visible = true;
            AddFieldsPanel.Controls.Add(new Label
            {
                Size = new Size(120, 20),
                Text = "Название библиотеки"
            });
            _libNameTb.TextChanged += TB_TextChanged;
            AddFieldsPanel.Controls.Add(_libNameTb);
            AddMoreFieldsButton.PerformClick();
            _fieldType[0].Enabled = false;
            _removeButton[0].Enabled = false;
            CreateNewLibraryButton.Enabled = false;
        }

        private void RemoveCollectionButton_Click(object sender, EventArgs e)
        {
            if (LibsList.SelectedItems.Count <= 0) return;
            var dialogResult = MessageBox.Show(
                text: string.Format(
                    "Нажимая \"Удалить библиотеку\", \nВы осознанно принимаете решение удалить выбранную библиотеку\n" +
                    "({0})\nцеликом, включая все накопленные в ней записи.\nПродолжить?",
                    LibsList.FocusedItem.Text
                ),
                caption: "Очень важное предупреждение",
                buttons: MessageBoxButtons.YesNo,
                icon: MessageBoxIcon.Warning
            );
            if (dialogResult == DialogResult.No) return;

            if (_mainForm.SelectedLibLabel.Text == LibsList.SelectedItems[0].Text)
            {
                _mainForm.Collection.Clear();
                _mainForm.SelectedLibLabel.Text = _mainForm.TitleHeaderLabel.Text = "";
                _mainForm.ElementActionsGB.Enabled = false;
            }

            try
            {
                var dropTableQuery = string.Format("drop table `{0}`;", LibsList.SelectedItems[0].Text);
                Database.Execute(dropTableQuery);
                _mainForm.StatusLabel.Text =
                    string.Format("Была удалена библиотека \"{0}\"", LibsList.SelectedItems[0].Text);

                Directory.Delete(
                    path: string.Format(
                        @"{0}\Posters\{1}",
                        Environment.CurrentDirectory,
                        _mainForm.ReplaceSymbols(LibsList.SelectedItems[0].Text)
                    ),
                    recursive: true
                );
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }

            if (_mainForm.SelectedLibLabel.Text == LibsList.SelectedItems[0].Text) _mainForm.FormReset();
            ReadDatabase_ForLibsList();
        }

        private void SaveLibraryButton_Click(object sender, EventArgs e)
        {
            if (!VerifyFields()) return;
            try
            {
                const string verifyNameQuery = "select name from sqlite_master where type='table' order by name;";
                var readTables = Database.GetTable(verifyNameQuery);
                foreach (DataRow table in readTables.Rows)
                {
                    var name = table.Table.Columns["name"].Ordinal;
                    if (!table[name].ToString().ToLower().Equals(_libNameTb.Text.ToLower())) continue;
                    MessageBox.Show(
                        text: "Библиотека с таким именем уже существует",
                        caption: "Ошибка",
                        buttons: MessageBoxButtons.OK,
                        icon: MessageBoxIcon.Error
                    );
                    return;
                }

                Database.Execute(MakeCreateQuery());
                Directory.CreateDirectory(
                    string.Format(
                        @"{0}\Posters\{1}",
                        Environment.CurrentDirectory,
                        _mainForm.ReplaceSymbols(_libNameTb.Text)
                    )
                );
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
                return;
            }

            ReadDatabase_ForLibsList();
            CollectionEditGB.Visible = _edited = false;
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

            _fNo = _fieldName.Count;
            _fieldName.Add(new TextBox
            {
                Size = new Size(210, 20),
            });
            AddFieldsPanel.Controls.Add(_fieldName[_fNo]);
            _fieldName[_fNo].TextChanged += TB_TextChanged;

            _fieldType.Add(new ComboBox
            {
                Size = new Size(150, 21),
                DropDownStyle = ComboBoxStyle.DropDownList,
            });
            _fieldType[_fNo].Items.AddRange(new object[]
            {
                "Строка",
                "Текст",
                @"Поле ""Дата""",
                @"Поле ""Дата + Время""",
                @"Поле ""Оценка (5)""",
                @"Поле ""Оценка (10)""",
                @"Поле ""Приоритет"""
            });
            AddFieldsPanel.Controls.Add(_fieldType[_fNo]);
            _fieldType[_fNo].SelectedIndex = 0;

            _removeButton.Add(new Button
            {
                Size = new Size(20, 21),
                Text = "-",
                Tag = _fNo.ToString(),
                TabStop = true
            });
            _removeButton[_fNo].Click += RemoveButton_Click;
            AddFieldsPanel.Controls.Add(_removeButton[_fNo]);
            _edited = true;
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (_fieldName.Count <= 1)
            {
                MessageBox.Show("Это поле удалять нельзя!");
                return;
            }

            var @in = _removeButton.IndexOf(sender as Button);
            AddFieldsPanel.Controls.Remove(_fieldName[@in]);
            _fieldName.Remove(_fieldName[@in]);
            AddFieldsPanel.Controls.Remove(_fieldType[@in]);
            _fieldType.Remove(_fieldType[@in]);
            AddFieldsPanel.Controls.Remove(_removeButton[@in]);
            _removeButton.Remove(_removeButton[@in]);
        }

        #endregion

        private void LibsList_ItemActivate(object sender, EventArgs e)
        {
            try
            {
                _mainForm.Collection.Clear();
                _mainForm.ColumnsInfo.Clear();
                ReadHeadersForTable(LibsList.FocusedItem.Text);
                ReadTableFromDatabase(LibsList.FocusedItem.Text, _mainForm.Preferences.PageSize);
                _mainForm.SearchForm.dataPanel.Controls.Clear();
                _mainForm.pagerCurrentTb.Text = "1";
                _mainForm.ClearLibTSMI.Enabled = true;
                _mainForm.StatusLabel.Text = string.Format("Загружена библиотека \"{0}\"", LibsList.FocusedItem.Text);
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }

            Close();
        }

        private static void TB_TextChanged(object sender, EventArgs e)
        {
            (sender as TextBox).Text = (sender as TextBox).Text
                .Replace("<", "").Replace(">", "").Replace("|", "")
                .Replace("/", "").Replace("\\", "").Replace(";", "");
        }

        #region FormEvents

        private void LibManagerForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) RemoveLibraryButton.PerformClick();
            else if (e.KeyCode == Keys.Escape) FormReset();
        }

        private void LibManagerForm_Load(object sender, EventArgs e)
        {
            Size = new Size(480, 220);
            ReadDatabase_ForLibsList();
            LibsList.Focus();
            if (LibsList.Items.Count > 0) LibsList.Items[0].Selected = LibsList.Items[0].Focused = true;
        }

        private void LibManagerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_edited)
            {
                var dialogResult = MessageBox.Show(
                    text: "Выйти без сохранения?",
                    caption: "Предупреждение",
                    buttons: MessageBoxButtons.YesNo,
                    icon: MessageBoxIcon.Warning
                );
                if (dialogResult == DialogResult.Yes)
                    FormReset();
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
            _edited = false;
        }

        #endregion
    }
}