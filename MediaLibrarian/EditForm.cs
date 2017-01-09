using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MediaLibrarian
{
    public partial class EditForm : Form
    {
        public EditForm(MainForm formMain)
        {
            InitializeComponent();
            _mainForm = formMain;            
        }
        MainForm _mainForm;
        LibManagerForm _libManagerForm;
        List<Control> columnData = new List<Control>();
        string customDateTimeFormat = "d.MM.yyyy, HH:mm:ss";
        readonly SQLiteConnection _connection = Connetcion.Connection;
        public bool EditMode;
        public EventArgs E { get; set; }

        #region DatabaseAPI
        private void GetControlByType(string type, int i)
        {
            switch (type)
            {
                case "VARCHAR(128)": MakeATextBox(i); break;        //Строка
                case "TEXT": MakeATextArea(i); break;               //Текст
                case "VARCHAR(20)": MakeADateField(i); break;       //Поле дата
                case "CHAR(20)": MakeADateTimeField(i); break;      //Поле дата+время
                case "CHAR(5)": Make5Stars(i); break;               //Поле оценка(5)
                case "CHAR(10)": Make10Stars(i); break;             //Поле оценка(10)
                case "VARCHAR(10)": Make10Cubes(i); break;          //Поле приоритет
            }
        }
        private List<string> GetDataFromDatabase(string tableName, string elementHeaderName, string elementName)
        {
            var getData = new SQLiteCommand(String.Format("select * from `{0}` where `{1}`='{2}'", tableName, 
                elementHeaderName, elementName.Replace("'","''")), _connection);
            var editString = new DataTable();
            _connection.Open();
            editString.Load(getData.ExecuteReader());
            _connection.Close();
            var items = new List<string>();
            foreach (var item in editString.Rows[0].ItemArray)
            {
                items.Add(item.ToString());
            }
            return items;
        }
        private void PushDataIntoCreatedControls(List<string> items)
        {
            for (var i = 0; i < columnData.Count; i++)
            {
                switch (columnData[i].GetType().ToString())
                {
                    case "System.Windows.Forms.TextBox": case "System.Windows.Forms.RichTextBox":
                        columnData[i].Text = items[i]; break;
                    case "System.Windows.Forms.Panel":
                        //if (!new List<string>(){null, "", "0"}.Contains(Items[i])) 
                            switch (columnData[i].Tag.ToString())
                        {
                            case "Star5": if (GetNumValue(items[i]) != 0)
                                Star5_Click(columnData[i].Controls[GetNumValue(items[i]) - 1], E);
                                else columnData[i].Text = "☆☆☆☆☆"; break;
                            case "Star10": if (GetNumValue(items[i]) != 0)
                                Star10_Click(columnData[i].Controls[GetNumValue(items[i]) - 1], E);
                                else columnData[i].Text = "☆☆☆☆☆☆☆☆☆☆"; break;
                            case "Cube10": if (GetNumValue(items[i]) != 0)
                                Cube10_Click(columnData[i].Controls[GetNumValue(items[i]) - 1], E);
                                else columnData[i].Text = "▒▒▒▒▒▒▒▒▒▒"; break;
                        }
                        break;
                    case "System.Windows.Forms.DateTimePicker": 
                        try
                            {
                                (columnData[i] as DateTimePicker).Value = DateTime.Parse(items[i]);
                            }
                        catch (Exception ex) {MessageBox.Show(ex.Message);}
                        break;
                }
            }
        }
        #endregion
        #region Items
        private void EditItem()
        {
            var names = new List<string>();
            names.AddRange(from val in _mainForm.ColumnsInfo select val.Name);
            var values = new List<string>();
            values.AddRange(from data in columnData select data.Text);
            var updateQuery = String.Format("update `{0}` set ", _mainForm.SelectedLibLabel.Text);
            for (var i = 0; i < names.Count; i++)
            {
                updateQuery += "`" + names[i] + "` = '" + values[i].Replace("'", "''") + "'";
                if (names.Count - i > 1) updateQuery += ", ";
            }
            updateQuery += " where `" + names[0] + "` = '" + columnData[0].Tag.ToString().Replace("'", "''") + "'";            
            if (VerifyItem())
            {
                var editItem = new SQLiteCommand(updateQuery, _connection);
                try { editItem.ExecuteNonQuery(); }
                catch (SQLiteException) { 
                    MessageBox.Show("Доступ к базе временно заблокирован. Попробуйте еще раз",
                        "ОТшибка ",MessageBoxButtons.OK, MessageBoxIcon.Error); 
                    _connection.Close();
                    this.DialogResult = DialogResult.Abort;
                    return; }
                _connection.Close();
                SavePicture();
                _mainForm.StatusLabel.Text = "Элемент \"" + columnData[0].Text + "\" изменен";
                Close();
            }

        }
        private void AddNewItem()
        {
            var names = String.Join("` , `", from val in _mainForm.ColumnsInfo select val.Name);
            var values = String.Join("\" , \"", from data in columnData select data.Text);
            var addNewItem = new SQLiteCommand(String.Format("insert into `{0}` (`{1}`) values (\"{2}\")",
                _mainForm.SelectedLibLabel.Text, names, values), _connection);
            if (VerifyItem())
            {
                addNewItem.ExecuteNonQuery();
                _connection.Close();
                SavePicture();
                _mainForm.StatusLabel.Text = "Добавлен элемент \"" + columnData[0].Text + "\"";
                Close();
            }
        }
        private bool VerifyItem()
        {
            var verify = new SQLiteCommand(string.Format("select `{0}` from `{1}` where `{0}` = '{2}'",
                _mainForm.ColumnsInfo[0].Name, _mainForm.SelectedLibLabel.Text, columnData[0].Text.Replace("'", "''")), _connection);
            _connection.Open();
            var reader = verify.ExecuteReader();
            if (reader.HasRows && (columnData[0].Tag.ToString() != columnData[0].Text))
            {
                MessageBox.Show("Элемент с таким именем уже существует в библиотеке", "Обнаружен дубликат данных", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _connection.Close();
                this.DialogResult = DialogResult.Abort;
                return false;
            }
            reader.Close();
            reader.Dispose();
            return true;
        }
        public void DeleteItem(string itemType, string itemName)
        {
            var deleteItem = new SQLiteCommand(String.Format("delete from `{0}` where `{1}` = '{2}'", _mainForm.SelectedLibLabel.Text,
                itemType, itemName), _connection);
            _connection.Open();
            deleteItem.ExecuteNonQuery();
            _connection.Close();
            var pathToPoster = String.Format(@"{0}\Posters\{1}\{2}.jpg", Environment.CurrentDirectory,
                        _mainForm.ReplaceSymblos(_mainForm.SelectedLibLabel.Text),
                        _mainForm.ReplaceSymblos(itemName));
            if (File.Exists(pathToPoster))
            {
                _mainForm.PosterBox.Image.Dispose();
                File.Delete(pathToPoster);
            }
            _mainForm.StatusLabel.Text = "Элемент \"" + itemName + "\" успешно удален";
            UpdateCollection();
        }
        #endregion

        #region SetPoster
        private void PosterImageTB_TextChanged(object sender, EventArgs e)
        {
            if (PosterImageTB.Text == "")
            {
                SaveButton.Enabled = true;
                LoadingLabel.Text = "Постер отсутствует";
                return;
            }
            SaveButton.Enabled = false;
            if (new Regex("http://|https://|ftp://").IsMatch(PosterImageTB.Text))
                DownloadPicture(PosterImageTB.Text);
            else
            {
                if (new Regex(@"^(.+):(\\.*)*\.(.*)$").IsMatch(PosterImageTB.Text) && File.Exists(PosterImageTB.Text))
                {
                    SelectLocalPicture(PosterImageTB.Text);
                }
                else
                {
                    LoadingLabel.Text = "Файл не найден";
                    loadedPicture.Image = null;
                }
            }
        }
        void DownloadPicture(string address)
        {
            LoadingLabel.Text = "Загрузка...";
            try
            {   
                if(loadedPicture.Image!=null) loadedPicture.Image.Dispose();
                var request = System.Net.WebRequest.Create(address);
                var response = request.GetResponse();
                using (var responseStream = response.GetResponseStream())
                {
                    loadedPicture.Image = new Bitmap(responseStream);
                    LoadingLabel.Text = "Изображение загружено";
                    SaveButton.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                LoadingLabel.Text = ex.Message;
                loadedPicture.Image = null;
            }
        }
        void SelectLocalPicture(string filename)
        {
            try
            {
                if (loadedPicture.Image != null) loadedPicture.Image.Dispose();
                loadedPicture.Image = new Bitmap(filename);
                LoadingLabel.Text = "Выбран локальный файл";
                SaveButton.Enabled = true;
            }
            catch (Exception ex)
            {
                LoadingLabel.Text = ex.Message;
                loadedPicture.Image = null;
            }
        }
        void SavePicture()
        {
            _mainForm.PosterBox.Image.Dispose();
            var newStr = String.Format(@"{0}\Posters\{1}\{2}.jpg", Environment.CurrentDirectory,
                        _mainForm.ReplaceSymblos(_mainForm.SelectedLibLabel.Text),
                        _mainForm.ReplaceSymblos(columnData[0].Text));
            var oldStr = String.Format(@"{0}\Posters\{1}\{2}.jpg", Environment.CurrentDirectory,
                        _mainForm.ReplaceSymblos(_mainForm.SelectedLibLabel.Text),
                        _mainForm.ReplaceSymblos(columnData[0].Tag.ToString()));
            try
            {
                if (PosterImageTB.Text == "") //Если картинка пуста, независимо от изменения имени, убираем ее
                {
                    loadedPicture.Image.Dispose();
                    if (File.Exists(oldStr)) File.Delete(oldStr);
                }
                else //Если картинка не пуста...
                {
                    if (columnData[0].Text != columnData[0].Tag.ToString()) //Если изменено имя...
                    {
                        if (oldStr != PosterImageTB.Text) //Если изменены имя и картинка, сохраняем новую
                        {
                            loadedPicture.Image.Save(newStr, ImageFormat.Jpeg);
                            loadedPicture.Image.Dispose();
                            if (File.Exists(oldStr)) File.Delete(oldStr); //Избавляемся от старой картинки
                        }
                        else if (File.Exists(oldStr)) //Если имя изменено, а картинка нет, ее нужно переместить
                            {
                                loadedPicture.Image.Dispose();
                                File.Move(oldStr, newStr);
                            }
                    }
                    else //Если имя не изменено, но изменена картинка перезаписываем существующую картинку
                    {
                        if(oldStr != PosterImageTB.Text)loadedPicture.Image.Save(newStr, ImageFormat.Jpeg);
                        //В случае, если ничего не изменено, ничего не делать
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Abort;
            }
            

        }
        #endregion
        #region CreateControls
        void CreateHeaderLabel(int i)
        {
            EditPanel.Controls.Add(new Label() 
            {
                Size = new Size(220, 15),
                AutoEllipsis = true,
                Font = new Font("Tahoma", 9),
                FlatStyle = FlatStyle.System,
                Text = _mainForm.ColumnsInfo[i].Name
            });
        }
        void MakeATextBox(int i)
        {
            var tb = new TextBox()
            {
                Size = new Size(420, 25),
                MaxLength = 128
            };
            tb.TextChanged += tb_TextChanged;
            columnData.Add(tb);
        }
        void MakeATextArea(int i)
        {
            columnData.Add(new RichTextBox()
            {
                Size = new Size(420, 100),
                ScrollBars = RichTextBoxScrollBars.ForcedVertical,
                WordWrap = true,
            });
        }
        void MakeADateField(int i)
        {
            columnData.Add(new DateTimePicker()
            {
                Size = new Size(150, 20),
                Margin = new Padding() {Left = 47, Bottom = 5 },
                Font = new Font("Tahoma", 9),
                Format = DateTimePickerFormat.Long,
                Value = DateTime.Now,
            });
        }
        void MakeADateTimeField(int i)
        {
            columnData.Add(new DateTimePicker()
            {
                Size = new Size(160, 20),
                Margin = new Padding() {Left = 37, Bottom = 5 },
                Font = new Font("Tahoma", 9),
                Format = DateTimePickerFormat.Custom,
                CustomFormat = customDateTimeFormat,
                Value = DateTime.Now,
            });
        }
        #endregion
        #region CreateStarsAndCubes
        void Make5Stars(int i) //i - порядок панели на форме
        {
            var starsList = new List<Label>();
            var stars5Panel = new Panel()
            {
                Size = new Size(190, 30),
                Tag = "Star5",
               
            };
            for (var ii = 0; ii < 5; ii++)
            {
                var star5 = new Label()
                {
                    Size = new Size(25, 30),
                    Location = new Point(ii * 25 + 65, 0),
                    Font = new Font("Lucida Console", 18f, FontStyle.Bold),
                    ForeColor = Color.Gray,
                    TextAlign = ContentAlignment.TopLeft,
                    Text = "☆",
                    Tag = new int[] {i , starsList.Count}
                };
                star5.Click += new EventHandler(Star5_Click);
                starsList.Add(star5);
            }
            stars5Panel.Controls.AddRange(starsList.ToArray());
            columnData.Add(stars5Panel);
        }
        void Make10Stars(int i) //i - порядок панели на форме
        {
            var starsList = new List<Label>();
            var stars10Panel = new Panel()
            {
                Size = new Size(195, 30),
                Tag = "Star10",
            };
            for (var ii = 0; ii < 10; ii++)
            {
                var star10 = new Label()
                {
                    Size = new Size(20, 30),
                    Location = new Point(ii * 19 + 2, 0),
                    FlatStyle = FlatStyle.System,
                    Font = new Font("Lucida Console", 18f, FontStyle.Bold),
                    ForeColor = Color.Gray,
                    TextAlign = ContentAlignment.TopLeft,
                    Text = "☆",
                    Tag = new int[] {i, starsList.Count}
                };
                star10.Click += new EventHandler(Star10_Click);
                starsList.Add(star10);
            }
            stars10Panel.Controls.AddRange(starsList.ToArray());
            columnData.Add(stars10Panel);
        }
        void Make10Cubes(int i) //i - порядок панели на форме
        {
            var cubeList = new List<Label>();
            var cubes10Panel = new Panel()
            {
                Size = new Size(150, 30),
                Margin = new Padding() { Left = 42 },
                Tag = "Cube10"
            };
            for (var ii = 0; ii < 10; ii++)
            {
                var cube = new Label()
                {
                    Size = new Size(15, 30),
                    Location = new Point(ii * 15, 0),
                    Font = new Font("Tahoma", 16, FontStyle.Bold),
                    FlatStyle = FlatStyle.System,
                    ForeColor = Color.Gray,
                    Text = "▒",
                    Tag = new int[] {i, cubeList.Count}
                };
                cube.Click += new EventHandler(Cube10_Click);
                cubeList.Add(cube);
            }
            cubes10Panel.Controls.AddRange(cubeList.ToArray());
            columnData.Add(cubes10Panel);
        }
        #endregion
        #region ClickToBlocks
        private void Star5_Click(object sender, EventArgs e)
        {
            var colCrd = ((int[])(sender as Label).Tag)[0];
            var listCrd = ((int[])(sender as Label).Tag)[1];
            if ((sender as Label) == columnData[colCrd].Controls[0] && columnData[colCrd].Controls[0].Text == "★" && columnData[colCrd].Controls[1].Text == "☆")
            {
                columnData[colCrd].Controls[0].Text = "☆";
                columnData[colCrd].Controls[0].ForeColor = Color.Gray;
                columnData[colCrd].Text = "☆☆☆☆☆";
            }
            else
            {
                columnData[colCrd].Text = "";
                for (var i = 0; i < listCrd + 1; i++)
                {
                    if (listCrd < 2) columnData[colCrd].Controls[i].ForeColor = Color.Red;
                    if (listCrd == 2) columnData[colCrd].Controls[i].ForeColor = Color.Orange;
                    if (listCrd > 2) columnData[colCrd].Controls[i].ForeColor = Color.LimeGreen;
                    columnData[colCrd].Controls[i].Text = "★";
                    columnData[colCrd].Text += "★";
                }
                for (var j = columnData[colCrd].Controls.Count - 1; j > listCrd; j--)
                {
                    columnData[colCrd].Controls[j].ForeColor = Color.Gray;
                    columnData[colCrd].Controls[j].Text = "☆";
                    columnData[colCrd].Text += "☆";
                }
            }
        }
        private void Star10_Click(object sender, EventArgs e)
        {
            var colCrd = ((int[])(sender as Label).Tag)[0];
            var listCrd = ((int[])(sender as Label).Tag)[1];
            if ((sender as Label) == columnData[colCrd].Controls[0] && columnData[colCrd].Controls[0].Text == "★" && columnData[colCrd].Controls[1].Text == "☆")
            {
                columnData[colCrd].Controls[0].Text = "☆";
                columnData[colCrd].Controls[0].ForeColor = Color.Gray;
                columnData[colCrd].Text = "☆☆☆☆☆☆☆☆☆☆";
            }
            else
            {
                columnData[colCrd].Text = "";
                for (var i = 0; i < listCrd + 1; i++)
                {
                    if (listCrd < 4) columnData[colCrd].Controls[i].ForeColor = Color.Red;
                    if (listCrd > 3 && listCrd < 8) columnData[colCrd].Controls[i].ForeColor = Color.Orange;
                    if (listCrd > 7) columnData[colCrd].Controls[i].ForeColor = Color.LimeGreen;
                    columnData[colCrd].Controls[i].Text = "★";
                    columnData[colCrd].Text += "★";
                }
                for (var j = columnData[colCrd].Controls.Count - 1; j > listCrd; j--)
                {
                    columnData[colCrd].Controls[j].ForeColor = Color.Gray;
                    columnData[colCrd].Controls[j].Text = "☆";
                    columnData[colCrd].Text += "☆";
                }
            }
        }
        private void Cube10_Click(object sender, EventArgs e)
        {
            var colCrd = ((int[])(sender as Label).Tag)[0];
            var listCrd = ((int[])(sender as Label).Tag)[1];
            if ((sender as Label) == columnData[colCrd].Controls[0] && columnData[colCrd].Controls[0].Text == "█" && columnData[colCrd].Controls[1].Text == "▒")
            {
                columnData[colCrd].Controls[0].Text = "▒";
                columnData[colCrd].Controls[0].ForeColor = Color.Gray;
                columnData[colCrd].Text = "▒▒▒▒▒▒▒▒▒▒";
            }
            else
            {
                columnData[colCrd].Text = "";
                for (var i = 0; i < listCrd + 1; i++)
                {
                    columnData[colCrd].Controls[i].ForeColor = Color.SeaGreen;
                    columnData[colCrd].Controls[i].Text = "█";
                    columnData[colCrd].Text += "█";
                }
                for (var j = columnData[colCrd].Controls.Count - 1; j > listCrd; j--)
                {
                    columnData[colCrd].Controls[j].ForeColor = Color.Gray;
                    columnData[colCrd].Controls[j].Text = "▒";
                    columnData[colCrd].Text += "▒";
                }
            }
        }
        #endregion
        #region ButtonClicks
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (columnData[0].Text == "")
            {
                MessageBox.Show("Графа \"" + _mainForm.ColumnsInfo[0].Name + "\" должна быть обязательно заполнена",
                    "Ошибка входных данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Abort;
                return;
            }
            if (EditMode) EditItem(); else AddNewItem();
            UpdateCollection();
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void SelectImageButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                PosterImageTB.Text = OpenFile.FileName;
            }

        }
        #endregion
        #region Miscellaneous
        private void UpdateCollection()
        {
            _libManagerForm = new LibManagerForm(_mainForm);
            _libManagerForm.ReadTableFromDatabase(_mainForm.SelectedLibLabel.Text);
            _libManagerForm.Dispose();
        }
        int GetNumValue(string stars)
        {
            var digit = 0;
            switch (stars)
            {
                case "☆☆☆☆☆": digit = 0; break;
                case "☆☆☆☆☆☆☆☆☆☆": digit = 0; break;
                case "▒▒▒▒▒▒▒▒▒▒": digit = 0; break;
                case "★☆☆☆☆": digit = 1; break;
                case "★☆☆☆☆☆☆☆☆☆": digit = 1; break;
                case "█▒▒▒▒▒▒▒▒▒": digit = 1; break;
                case "★★☆☆☆": digit = 2; break;
                case "★★☆☆☆☆☆☆☆": digit = 2; break;
                case "██▒▒▒▒▒▒▒▒": digit = 2; break;
                case "★★★☆☆": digit = 3; break;
                case "★★★☆☆☆☆☆☆☆": digit = 3; break;
                case "███▒▒▒▒▒▒▒": digit = 3; break;
                case "★★★★☆": digit = 4; break;
                case "★★★★☆☆☆☆☆☆": digit = 4; break;
                case "████▒▒▒▒▒▒": digit = 4; break;
                case "★★★★★": digit = 5; break;
                case "★★★★★☆☆☆☆☆": digit = 5; break;
                case "█████▒▒▒▒▒": digit = 5; break;
                case "★★★★★★☆☆☆☆": digit = 6; break;
                case "██████▒▒▒▒": digit = 6; break;
                case "★★★★★★★☆☆☆": digit = 7; break;
                case "███████▒▒▒": digit = 7; break;
                case "★★★★★★★★☆☆": digit = 8; break;
                case "████████▒▒": digit = 8; break;
                case "★★★★★★★★★☆": digit = 9; break;
                case "█████████▒": digit = 9; break;
                case "★★★★★★★★★★": digit = 10; break;
                case "██████████": digit = 10; break;
                default: digit = 0; break;
            }
            return digit;
        }
        private void EditForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F4: if (e.Alt) if(MessageBox.Show("Редактирование еще не завершено.\nВы действительно желаете закрыть это окно?",
                    "Стоп-стоп-стоп...", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.No) e.Handled = true;
                    break;
            }
        }
        private void tb_TextChanged(object sender, EventArgs e)
        {
            (sender as TextBox).Text = (sender as TextBox).Text.
                Replace("<", "").Replace(">", "").Replace("|", "").Replace("/", "").Replace("\\", "");
        }
        #endregion
        #region OpenClose
        private void EditForm_Load(object sender, EventArgs e)
        {
            columnData.Clear();
            for (var i = 0; i < _mainForm.ColumnsInfo.Count; i++)
            {
                CreateHeaderLabel(i);
                GetControlByType(_mainForm.ColumnsInfo[i].Type, i);
                EditPanel.Controls.Add(columnData[i]);
            }
            if (EditMode && _mainForm.Collection.SelectedItems.Count > 0)
            {
                PushDataIntoCreatedControls(GetDataFromDatabase(_mainForm.SelectedLibLabel.Text, _mainForm.ColumnsInfo[0].Name, 
                    _mainForm.Collection.FocusedItem.Text));
                var pathToFile = String.Format(@"{0}\Posters\{1}\{2}.jpg", Environment.CurrentDirectory,
                        _mainForm.ReplaceSymblos(_mainForm.SelectedLibLabel.Text),
                        _mainForm.ReplaceSymblos(columnData[0].Text));
                if (File.Exists(pathToFile))
                {
                    PosterImageTB.Text = pathToFile;
                    PosterImageTB_TextChanged(PosterImageTB, null);
                }
            }
            columnData[0].Tag = columnData[0].Text;
        }
        private void EditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Abort) e.Cancel = true;
            else FormReset();
        }
        private void FormReset()
        {
            EditMode = false;
            columnData.Clear();
            EditPanel.Controls.Clear();
            PosterImageTB.Text = "";
            LoadingLabel.Text = "";
        }
        #endregion
    }
}