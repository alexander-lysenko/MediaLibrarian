using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaLibrarian_
{
    public partial class EditForm : Form
    {
        public EditForm(MainForm formMain)
        {
            InitializeComponent();
            _mainForm = formMain;
        }

        private readonly MainForm _mainForm;
        private readonly List<Control> _columnData = new List<Control>();
        private const string CustomDateTimeFormat = "d.MM.yyyy, HH:mm:ss";
        private string _errorString;
        public bool EditMode;
        public EventArgs E { get; set; }

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

        #region DatabaseAPI&LoadData

        private void GetControlByType(string type, int i)
        {
            switch (type)
            {
                case "VARCHAR(128)":
                    MakeATextBox(i);
                    break; //Строка
                case "TEXT":
                    MakeATextArea(i);
                    break; //Текст
                case "VARCHAR(20)":
                    MakeADateField(i);
                    break; //Поле дата
                case "CHAR(20)":
                    MakeADateTimeField(i);
                    break; //Поле дата+время
                case "CHAR(5)":
                    Make5Stars(i);
                    break; //Поле оценка(5)
                case "CHAR(10)":
                    Make10Stars(i);
                    break; //Поле оценка(10)
                case "VARCHAR(10)":
                    Make10Cubes(i);
                    break; //Поле приоритет
                default:
                    MessageBox.Show(
                        text: "Типы данных повреждены. Чтение невозможно",
                        caption: "Ошибка базы данных",
                        buttons: MessageBoxButtons.OK,
                        icon: MessageBoxIcon.Error
                    );
                    break;
            }
        }

        private static List<string> GetDataFromDatabase(string tableName, string elementHeaderName, string elementName)
        {
            var items = new List<string>();
            try
            {
                var getDataQuery = string.Format(
                    "select * from `{0}` where `{1}`='{2}'",
                    tableName,
                    elementHeaderName,
                    elementName.Replace("'", "''")
                );
                var editString = Database.GetTable(getDataQuery);
                items.AddRange(editString.Rows[0].ItemArray.Select(item => item.ToString()));
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }

            return items;
        }

        private void PushDataIntoCreatedControls(IReadOnlyList<string> items)
        {
            for (var i = 0; i < _columnData.Count; i++)
            {
                switch (_columnData[i].GetType().ToString())
                {
                    case "System.Windows.Forms.TextBox":
                    case "System.Windows.Forms.RichTextBox":
                        _columnData[i].Text = items[i];
                        break;
                    case "System.Windows.Forms.Panel":
                        //if (!new List<string>(){null, "", "0"}.Contains(Items[i])) 
                        switch (_columnData[i].Tag.ToString())
                        {
                            case "Star5":
                                if (GetNumValue(items[i]) != 0)
                                    Star5_Click(_columnData[i].Controls[GetNumValue(items[i]) - 1], E);
                                else _columnData[i].Text = "☆☆☆☆☆";
                                break;
                            case "Star10":
                                if (GetNumValue(items[i]) != 0)
                                    Star10_Click(_columnData[i].Controls[GetNumValue(items[i]) - 1], E);
                                else _columnData[i].Text = "☆☆☆☆☆☆☆☆☆☆";
                                break;
                            case "Cube10":
                                if (GetNumValue(items[i]) != 0)
                                    Cube10_Click(_columnData[i].Controls[GetNumValue(items[i]) - 1], E);
                                else _columnData[i].Text = "▒▒▒▒▒▒▒▒▒▒";
                                break;
                        }

                        break;
                    case "System.Windows.Forms.DateTimePicker":
                        try
                        {
                            (_columnData[i] as DateTimePicker).Value = DateTime.Parse(items[i]);
                        }
                        catch (Exception ex)
                        {
                            ErrorMessage(ex);
                        }

                        break;
                }
            }
        }

        #endregion

        #region Items

        private void EditItem()
        {
            var names = new List<string>();
            var values = new List<string>();
            var updateQuery = string.Format("update `{0}` set ", _mainForm.SelectedLibLabel.Text);

            names.AddRange(from val in _mainForm.ColumnsInfo select val.Name);
            values.AddRange(from data in _columnData select data.Text);
            for (var i = 0; i < names.Count; i++)
            {
                updateQuery += string.Format(
                    "`{0}` = '{1}'",
                    names[i],
                    values[i].Trim().Replace("'", "''")
                );
                if (names.Count - i > 1) updateQuery += ", ";
            }

            updateQuery += string.Format(
                " where `{0}` = '{1}'",
                names[0],
                _columnData[0].Tag.ToString().Trim().Replace("'", "''")
            );

            if (!VerifyItem()) return;
            try
            {
                Database.Execute(updateQuery);
                SavePicture();
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }

            _mainForm.StatusLabel.Text = string.Format("Элемент \"{0}\" изменен", _columnData[0].Text);
            Close();
        }

        private void AddNewItem()
        {
            var names = string.Join("` , `", from val in _mainForm.ColumnsInfo select val.Name.Trim());
            var values = string.Join("\" , \"", from data in _columnData select data.Text.Trim().Replace("\"", "\"\""));
            var addNewItemQuery = string.Format(
                "insert into `{0}` (`{1}`) values (\"{2}\")",
                _mainForm.SelectedLibLabel.Text,
                names,
                values
            );

            if (!VerifyItem()) return;
            try
            {
                Database.Execute(addNewItemQuery);
                SavePicture();
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }

            _mainForm.StatusLabel.Text = string.Format("Добавлена запись \"{0}\"", _columnData[0].Text);
            Close();
        }

        private bool VerifyItem()
        {
            try
            {
                var verifyQuery = string.Format(
                    "select `{0}` from `{1}` where TOUPPER(`{0}`) = '{2}'",
                    _mainForm.ColumnsInfo[0].Name,
                    _mainForm.SelectedLibLabel.Text,
                    _columnData[0].Text.Trim().Replace("'", "''").ToUpper()
                );
                var value = Database.GetScalar(verifyQuery);
                if (
                    value != null
                    && string.Equals(
                        value.ToString(),
                        _columnData[0].Text.Trim(),
                        StringComparison.CurrentCultureIgnoreCase
                    )
                    && _columnData[0].Tag.ToString() != _columnData[0].Text
                )
                {
                    MessageBox.Show(
                        text: "Запись с таким именем уже существует в библиотеке",
                        caption: "Обнаружен дубликат данных",
                        buttons: MessageBoxButtons.OK,
                        icon: MessageBoxIcon.Exclamation
                    );
                    DialogResult = DialogResult.Abort;
                    return false;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
                return false;
            }

            return true;
        }

        public void DeleteItem(string itemType, string itemName)
        {
            try
            {
                var deleteItemQuery = string.Format(
                    "delete from `{0}` where `{1}` = '{2}'",
                    _mainForm.SelectedLibLabel.Text,
                    itemType,
                    itemName
                );
                Database.Execute(deleteItemQuery);
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
                return;
            }

            var pathToPoster = string.Format(
                @"{0}\Posters\{1}\{2}.jpg",
                Environment.CurrentDirectory,
                _mainForm.ReplaceSymbols(_mainForm.SelectedLibLabel.Text),
                _mainForm.ReplaceSymbols(itemName)
            );
            if (File.Exists(pathToPoster))
            {
                _mainForm.PosterBox.Image.Dispose();
                File.Delete(pathToPoster);
            }

            _mainForm.StatusLabel.Text = string.Format("Запись \"{0}\" успешно удалена", itemName);
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
            var externalRegex = new Regex(@"(http|https|ftp):\/\/(([a-z0-9\-\.]+)?[a-z0-9\-]+(!?\.[a-z]{2,4}))");
            var localRegex = new Regex(@"^(.+):(\\.*)*\.(.*)$");
            if (externalRegex.IsMatch(PosterImageTB.Text))
            {
                try
                {
                    DownloadPicture(PosterImageTB.Text);
                }
                catch (ArgumentException)
                {
                    LoadingLabel.Text = "Адрес недоступен";
                }
            }
            else
            {
                if (localRegex.IsMatch(PosterImageTB.Text) && File.Exists(PosterImageTB.Text))
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

        private void DownloadPicture(string address)
        {
            Bitmap bmp = null;
            if (loadedPicture.Image != null) loadedPicture.Image = null;
            LoadingLabel.Text = "Загрузка...";
            Action taskPayload = () =>
            {
                Thread.Sleep(500);
                try
                {
                    var request = System.Net.WebRequest.Create(address);
                    var response = request.GetResponse();
                    using (var responseStream = response.GetResponseStream())
                    {
                        bmp = new Bitmap(responseStream);
                    }
                }
                catch (Exception ex)
                {
                    _errorString = ex.Message;
                    bmp = null;
                }

                Invoke((Action)(() =>
                {
                    loadedPicture.Image = bmp;
                    SaveButton.Enabled = true;
                    LoadingLabel.Text = loadedPicture.Image != null ? "Изображение загружено" : _errorString;
                }));
            };
            Task.Factory.StartNew(taskPayload);
        }

        private void SelectLocalPicture(string filename)
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

        private void SavePicture()
        {
            if (_mainForm.PosterBox.Image != null) _mainForm.PosterBox.Image.Dispose();
            var newStr = string.Format(@"{0}\Posters\{1}\{2}.jpg", Environment.CurrentDirectory,
                _mainForm.ReplaceSymbols(_mainForm.SelectedLibLabel.Text),
                _mainForm.ReplaceSymbols(_columnData[0].Text));
            var oldStr = string.Format(@"{0}\Posters\{1}\{2}.jpg", Environment.CurrentDirectory,
                _mainForm.ReplaceSymbols(_mainForm.SelectedLibLabel.Text),
                _mainForm.ReplaceSymbols(_columnData[0].Tag.ToString()));
            try
            {
                if (PosterImageTB.Text == "") //Если картинка пуста, независимо от изменения имени, убираем ее
                {
                    if (loadedPicture.Image != null) loadedPicture.Image.Dispose();
                    if (File.Exists(oldStr)) File.Delete(oldStr);
                }
                else //Если картинка не пуста...
                {
                    if (_columnData[0].Text != _columnData[0].Tag.ToString()) //Если изменено имя...
                    {
                        if (oldStr != PosterImageTB.Text) //Если изменены имя и картинка, сохраняем новую
                        {
                            loadedPicture.Image.Save(newStr, ImageFormat.Jpeg);
                            loadedPicture.Image.Dispose();
                            if (File.Exists(oldStr)) File.Delete(oldStr); //Избавляемся от старой картинки
                        }
                        else if (File.Exists(oldStr)) //Если имя изменено, а картинка нет, ее нужно переместить
                        {
                            if (loadedPicture.Image != null) loadedPicture.Image.Dispose();
                            File.Move(oldStr, newStr);
                        }
                    }
                    else //Если имя не изменено, но изменена картинка перезаписываем существующую картинку
                    {
                        if (oldStr != PosterImageTB.Text) loadedPicture.Image.Save(newStr, ImageFormat.Jpeg);
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

        private void CreateHeaderLabel(int i)
        {
            EditPanel.Controls.Add(new Label
            {
                Size = new Size(220, 15),
                AutoEllipsis = true,
                Font = new Font("Tahoma", 9),
                FlatStyle = FlatStyle.System,
                Text = _mainForm.ColumnsInfo[i].Name
            });
        }

        private void MakeATextBox(int i)
        {
            var tb = new TextBox
            {
                Size = new Size(420, 25),
                MaxLength = 128
            };
            tb.TextChanged += tb_TextChanged;
            _columnData.Add(tb);
        }

        private void MakeATextArea(int i)
        {
            _columnData.Add(new RichTextBox
            {
                Size = new Size(420, 100),
                ScrollBars = RichTextBoxScrollBars.ForcedVertical,
                WordWrap = true,
            });
        }

        private void MakeADateField(int i)
        {
            _columnData.Add(new DateTimePicker
            {
                Size = new Size(150, 20),
                Margin = new Padding { Left = 47, Bottom = 5 },
                Font = new Font("Tahoma", 9),
                Format = DateTimePickerFormat.Long,
                Value = DateTime.Now,
            });
        }

        private void MakeADateTimeField(int i)
        {
            _columnData.Add(new DateTimePicker
            {
                Size = new Size(160, 20),
                Margin = new Padding { Left = 37, Bottom = 5 },
                Font = new Font("Tahoma", 9),
                Format = DateTimePickerFormat.Custom,
                CustomFormat = CustomDateTimeFormat,
                Value = DateTime.Now,
            });
        }

        #endregion

        #region CreateStarsAndCubes

        private void Make5Stars(int i) //i - порядок панели на форме
        {
            var starsList = new List<Label>();
            var stars5Panel = new Panel
            {
                Size = new Size(190, 30),
                Tag = "Star5",
            };
            for (var ii = 0; ii < 5; ii++)
            {
                var star5 = new Label
                {
                    Size = new Size(25, 30),
                    Location = new Point(ii * 25 + 65, 0),
                    Font = new Font("Lucida Console", 18f, FontStyle.Bold),
                    ForeColor = Color.Gray,
                    TextAlign = ContentAlignment.TopLeft,
                    Text = "☆",
                    Tag = new[] { i, starsList.Count }
                };
                star5.Click += Star5_Click;
                starsList.Add(star5);
            }

            stars5Panel.Controls.AddRange(starsList.ToArray());
            _columnData.Add(stars5Panel);
            _columnData[_columnData.IndexOf(stars5Panel)].Text = "☆☆☆☆☆";
        }

        private void Make10Stars(int i) //i - порядок панели на форме
        {
            var starsList = new List<Label>();
            var stars10Panel = new Panel
            {
                Size = new Size(195, 30),
                Tag = "Star10",
            };
            for (var ii = 0; ii < 10; ii++)
            {
                var star10 = new Label
                {
                    Size = new Size(20, 30),
                    Location = new Point(ii * 19 + 2, 0),
                    FlatStyle = FlatStyle.System,
                    Font = new Font("Lucida Console", 18f, FontStyle.Bold),
                    ForeColor = Color.Gray,
                    TextAlign = ContentAlignment.TopLeft,
                    Text = "☆",
                    Tag = new[] { i, starsList.Count }
                };
                star10.Click += Star10_Click;
                starsList.Add(star10);
            }

            stars10Panel.Controls.AddRange(starsList.ToArray());
            _columnData.Add(stars10Panel);
            _columnData[_columnData.IndexOf(stars10Panel)].Text = "☆☆☆☆☆☆☆☆☆☆";
        }

        private void Make10Cubes(int i) //i - порядок панели на форме
        {
            var cubeList = new List<Label>();
            var cubes10Panel = new Panel
            {
                Size = new Size(150, 30),
                Margin = new Padding { Left = 42 },
                Tag = "Cube10"
            };
            for (var ii = 0; ii < 10; ii++)
            {
                var cube = new Label
                {
                    Size = new Size(15, 30),
                    Location = new Point(ii * 15, 0),
                    Font = new Font("Tahoma", 16, FontStyle.Bold),
                    FlatStyle = FlatStyle.System,
                    ForeColor = Color.Gray,
                    Text = "▒",
                    Tag = new[] { i, cubeList.Count }
                };
                cube.Click += Cube10_Click;
                cubeList.Add(cube);
            }

            cubes10Panel.Controls.AddRange(cubeList.ToArray());
            _columnData.Add(cubes10Panel);
            _columnData[_columnData.IndexOf(cubes10Panel)].Text = "▒▒▒▒▒▒▒▒▒▒";
        }

        #endregion

        #region ClickToBlocks

        private void Star5_Click(object sender, EventArgs e)
        {
            var colCrd = ((int[])(sender as Label).Tag)[0];
            var listCrd = ((int[])(sender as Label).Tag)[1];
            if (sender as Label == _columnData[colCrd].Controls[0] && _columnData[colCrd].Controls[0].Text == "★" &&
                _columnData[colCrd].Controls[1].Text == "☆")
            {
                _columnData[colCrd].Controls[0].Text = "☆";
                _columnData[colCrd].Controls[0].ForeColor = Color.Gray;
                _columnData[colCrd].Text = "☆☆☆☆☆";
            }
            else
            {
                _columnData[colCrd].Text = "";
                for (var i = 0; i < listCrd + 1; i++)
                {
                    if (listCrd < 2) _columnData[colCrd].Controls[i].ForeColor = Color.Red;
                    if (listCrd == 2) _columnData[colCrd].Controls[i].ForeColor = Color.Orange;
                    if (listCrd > 2) _columnData[colCrd].Controls[i].ForeColor = Color.LimeGreen;
                    _columnData[colCrd].Controls[i].Text = "★";
                    _columnData[colCrd].Text += "★";
                }

                for (var j = _columnData[colCrd].Controls.Count - 1; j > listCrd; j--)
                {
                    _columnData[colCrd].Controls[j].ForeColor = Color.Gray;
                    _columnData[colCrd].Controls[j].Text = "☆";
                    _columnData[colCrd].Text += "☆";
                }
            }
        }

        private void Star10_Click(object sender, EventArgs e)
        {
            var colCrd = ((int[])(sender as Label).Tag)[0];
            var listCrd = ((int[])(sender as Label).Tag)[1];
            if (sender as Label == _columnData[colCrd].Controls[0] && _columnData[colCrd].Controls[0].Text == "★" &&
                _columnData[colCrd].Controls[1].Text == "☆")
            {
                _columnData[colCrd].Controls[0].Text = "☆";
                _columnData[colCrd].Controls[0].ForeColor = Color.Gray;
                _columnData[colCrd].Text = "☆☆☆☆☆☆☆☆☆☆";
            }
            else
            {
                _columnData[colCrd].Text = "";
                for (var i = 0; i < listCrd + 1; i++)
                {
                    if (listCrd < 4) _columnData[colCrd].Controls[i].ForeColor = Color.Red;
                    if (listCrd > 3 && listCrd < 8) _columnData[colCrd].Controls[i].ForeColor = Color.Orange;
                    if (listCrd > 7) _columnData[colCrd].Controls[i].ForeColor = Color.LimeGreen;
                    _columnData[colCrd].Controls[i].Text = "★";
                    _columnData[colCrd].Text += "★";
                }

                for (var j = _columnData[colCrd].Controls.Count - 1; j > listCrd; j--)
                {
                    _columnData[colCrd].Controls[j].ForeColor = Color.Gray;
                    _columnData[colCrd].Controls[j].Text = "☆";
                    _columnData[colCrd].Text += "☆";
                }
            }
        }

        private void Cube10_Click(object sender, EventArgs e)
        {
            var colCrd = ((int[])(sender as Label).Tag)[0];
            var listCrd = ((int[])(sender as Label).Tag)[1];
            if (sender as Label == _columnData[colCrd].Controls[0] && _columnData[colCrd].Controls[0].Text == "█" &&
                _columnData[colCrd].Controls[1].Text == "▒")
            {
                _columnData[colCrd].Controls[0].Text = "▒";
                _columnData[colCrd].Controls[0].ForeColor = Color.Gray;
                _columnData[colCrd].Text = "▒▒▒▒▒▒▒▒▒▒";
            }
            else
            {
                _columnData[colCrd].Text = "";
                for (var i = 0; i < listCrd + 1; i++)
                {
                    _columnData[colCrd].Controls[i].ForeColor = Color.SeaGreen;
                    _columnData[colCrd].Controls[i].Text = "█";
                    _columnData[colCrd].Text += "█";
                }

                for (var j = _columnData[colCrd].Controls.Count - 1; j > listCrd; j--)
                {
                    _columnData[colCrd].Controls[j].ForeColor = Color.Gray;
                    _columnData[colCrd].Controls[j].Text = "▒";
                    _columnData[colCrd].Text += "▒";
                }
            }
        }

        #endregion

        #region ButtonClicks

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (_columnData[0].Text == "")
            {
                MessageBox.Show(
                    text: "Графа \"" + _mainForm.ColumnsInfo[0].Name + "\" должна быть обязательно заполнена",
                    caption: "Ошибка входных данных",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Error
                );
                DialogResult = DialogResult.Abort;
                return;
            }

            if (EditMode) EditItem();
            else AddNewItem();
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
            var currentPage = Convert.ToInt32(_mainForm.pagerCurrentTb.Text);
            var offset = _mainForm.Preferences.PageSize * (currentPage - 1);
            _mainForm.LibManagerForm.ReadTableFromDatabase(
                tableName: _mainForm.SelectedLibLabel.Text,
                limit: _mainForm.Preferences.PageSize,
                offset: offset
            );
        }

        private static int GetNumValue(string stars)
        {
            int digit;
            switch (stars)
            {
                case "☆☆☆☆☆":
                    digit = 0;
                    break;
                case "☆☆☆☆☆☆☆☆☆☆":
                    digit = 0;
                    break;
                case "▒▒▒▒▒▒▒▒▒▒":
                    digit = 0;
                    break;
                case "★☆☆☆☆":
                    digit = 1;
                    break;
                case "★☆☆☆☆☆☆☆☆☆":
                    digit = 1;
                    break;
                case "█▒▒▒▒▒▒▒▒▒":
                    digit = 1;
                    break;
                case "★★☆☆☆":
                    digit = 2;
                    break;
                case "★★☆☆☆☆☆☆☆":
                    digit = 2;
                    break;
                case "██▒▒▒▒▒▒▒▒":
                    digit = 2;
                    break;
                case "★★★☆☆":
                    digit = 3;
                    break;
                case "★★★☆☆☆☆☆☆☆":
                    digit = 3;
                    break;
                case "███▒▒▒▒▒▒▒":
                    digit = 3;
                    break;
                case "★★★★☆":
                    digit = 4;
                    break;
                case "★★★★☆☆☆☆☆☆":
                    digit = 4;
                    break;
                case "████▒▒▒▒▒▒":
                    digit = 4;
                    break;
                case "★★★★★":
                    digit = 5;
                    break;
                case "★★★★★☆☆☆☆☆":
                    digit = 5;
                    break;
                case "█████▒▒▒▒▒":
                    digit = 5;
                    break;
                case "★★★★★★☆☆☆☆":
                    digit = 6;
                    break;
                case "██████▒▒▒▒":
                    digit = 6;
                    break;
                case "★★★★★★★☆☆☆":
                    digit = 7;
                    break;
                case "███████▒▒▒":
                    digit = 7;
                    break;
                case "★★★★★★★★☆☆":
                    digit = 8;
                    break;
                case "████████▒▒":
                    digit = 8;
                    break;
                case "★★★★★★★★★☆":
                    digit = 9;
                    break;
                case "█████████▒":
                    digit = 9;
                    break;
                case "★★★★★★★★★★":
                    digit = 10;
                    break;
                case "██████████":
                    digit = 10;
                    break;
                default:
                    digit = 0;
                    break;
            }

            return digit;
        }

        private void EditForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4 && e.Alt)
            {
                var dialogResult = MessageBox.Show(
                    text: "Редактирование еще не завершено.\nВы действительно желаете закрыть это окно?",
                    caption: "Стоп-стоп-стоп...",
                    buttons: MessageBoxButtons.YesNo,
                    icon: MessageBoxIcon.Question
                );
                e.Handled = dialogResult == DialogResult.No;
            }
            else if (e.KeyCode == Keys.Enter && e.Control)
            {
                SaveButton.PerformClick();
            }
        }

        private static void tb_TextChanged(object sender, EventArgs e)
        {
            (sender as TextBox).Text = (sender as TextBox).Text
                .Replace("<", "").Replace(">", "").Replace("|", "")
                .Replace("/", "").Replace("\\", "").Replace(";", "");
        }

        #endregion

        #region OpenClose

        private void EditForm_Load(object sender, EventArgs e)
        {
            _columnData.Clear();
            for (var i = 0; i < _mainForm.ColumnsInfo.Count; i++)
            {
                CreateHeaderLabel(i);
                GetControlByType(_mainForm.ColumnsInfo[i].Type, i);
                EditPanel.Controls.Add(_columnData[i]);
            }

            if (EditMode && _mainForm.Collection.SelectedItems.Count > 0)
            {
                PushDataIntoCreatedControls(
                    GetDataFromDatabase(
                        tableName: _mainForm.SelectedLibLabel.Text,
                        elementHeaderName: _mainForm.ColumnsInfo[0].Name,
                        elementName: _mainForm.Collection.SelectedItems[0].Text
                    )
                );
                var pathToFile = string.Format(
                    @"{0}\Posters\{1}\{2}.jpg",
                    Environment.CurrentDirectory,
                    _mainForm.ReplaceSymbols(_mainForm.SelectedLibLabel.Text),
                    _mainForm.ReplaceSymbols(_columnData[0].Text)
                );
                if (File.Exists(pathToFile))
                {
                    PosterImageTB.Text = pathToFile;
                    PosterImageTB_TextChanged(PosterImageTB, null);
                }
            }

            _columnData[0].Tag = _columnData[0].Text;
        }

        private void EditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Abort) e.Cancel = true;
            else FormReset();
        }

        private void FormReset()
        {
            EditMode = false;
            _columnData.Clear();
            EditPanel.Controls.Clear();
            PosterImageTB.Text = "";
            LoadingLabel.Text = "";
            loadedPicture.Image = null;
        }

        #endregion
    }
}