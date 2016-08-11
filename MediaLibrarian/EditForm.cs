using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace MediaLibrarian
{
    public partial class EditForm : Form
    {
        public EditForm(MainForm FormMain)
        {
            InitializeComponent();
            MainForm = FormMain;            
        }
        MainForm MainForm;

        List<Control> ColumnData = new List<Control>();
        List<Category> ColumnValue = new List<Category>();
        string CustomDateFormat = "d MMMM yyyy";
        string CustomDateTimeFormat = "d.MM.yyyy, HH:mm:ss";
        static string Database = "baza.db";
        SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", Database));
        public bool EditMode = false;
        private void GetControlByType(string type, int i)
        {
            switch (type)
            {
                case "VARCHAR(128)": MakeATextBox(i); break;        //Строка
                case "TEXT": MakeATextArea(i); break;               //Текст
                case "VARCHAR(20)": MakeADateField(i); break;       //Поле дата
                case "DATETIME": MakeADateTimeField(i); break;      //Поле дата+время
                case "CHAR(5)": Make5Stars(i); break;               //Поле оценка(5)
                case "CHAR(10)": Make10Stars(i); break;             //Поле оценка(10)
                case "VARCHAR(10)": Make10Cubes(i); break;          //Поле приоритет
            }
        }
        private void GetColumnInfo()
        {
            ColumnData.Clear();
            SQLiteCommand GetColumns = new SQLiteCommand(string.Format("pragma table_info('{0}');", MainForm.SelectedLibLabel.Text), connection);
            connection.Open();
            SQLiteDataReader ReadCols = GetColumns.ExecuteReader();
            foreach (DbDataRecord col in ReadCols)
            {
                ColumnValue.Add(new Category
                {
                    Name = col["name"].ToString(),
                    Type = col["type"].ToString()
                });
            }
            connection.Close();
        }
        private void GetDataFromDatabase(string ElementName, string TableName)
        {
            SQLiteCommand GetData = new SQLiteCommand(String.Format("select * from {0} where name={1}", TableName, ElementName), connection);
        }
        private void PushDataIntoCreatedControls()
        {
            for (int i = 0; i < ColumnData.Count; i++)
            {
                switch (ColumnData[i].GetType().ToString())
                {
                    case "System.Windows.Forms.TextBox": case "System.Windows.Forms.RichTextBox":
                        ColumnData[i].Text = MainForm.Collection.FocusedItem.SubItems[i].Text; break;
                    case "System.Windows.Forms.Panel":
                        if (MainForm.Collection.FocusedItem.SubItems[i].Text!="0") switch (ColumnData[i].Tag.ToString())
                        {                            
                            case "Star5": Star5_Click(ColumnData[i].Controls[int.Parse(MainForm.Collection.FocusedItem.SubItems[i].Text)-1], e); break;
                            case "Star10": Star10_Click(ColumnData[i].Controls[int.Parse(MainForm.Collection.FocusedItem.SubItems[i].Text)-1], e); break;
                            case "Cube10": Cube10_Click(ColumnData[i].Controls[int.Parse(MainForm.Collection.FocusedItem.SubItems[i].Text)-1], e); break;
                        }
                        break;
                }
            }
        }
        private void SaveData()
        {
            ListViewItem Item = new ListViewItem(ColumnData[0].Text);
            foreach (var control in ColumnData)
            {
                if (control == ColumnData[0]) continue;
                Item.SubItems.Add(control.Text);
            }
            MainForm.Collection.Items.Add(Item);
        }
        private void FormReset()
        {
            ColumnData.Clear();
            ColumnValue.Clear();
            EditPanel.Controls.Clear();
        }

        #region CreateControls
        void CreateHeaderLabel(int i)
        {
            EditPanel.Controls.Add(new Label() 
            {
                Size = new Size(220, 15),
                AutoEllipsis = true,
                Font = new Font("Tahoma", 9),
                FlatStyle = FlatStyle.System,
                Text = ColumnValue[i].Name
            });
        }
        void MakeATextBox(int i)
        {
            ColumnData.Add(new TextBox() 
            {
                Size = new Size(420, 25),
            });
        }
        void MakeATextArea(int i)
        {
            ColumnData.Add(new RichTextBox()
            {
                Size = new Size(420, 100),
                ScrollBars = RichTextBoxScrollBars.ForcedVertical,
                WordWrap = true,
            });
        }
        void MakeADateField(int i)
        {
            ColumnData.Add(new DateTimePicker()
            {
                Size = new Size(150, 20),
                Margin = new Padding() {Left = 47, Bottom = 5 },
                Font = new Font("Tahoma", 9),
                Format = DateTimePickerFormat.Custom,
                CustomFormat = CustomDateFormat,
                Value = DateTime.Now,
            });
        }
        void MakeADateTimeField(int i)
        {
            ColumnData.Add(new DateTimePicker()
            {
                Size = new Size(160, 20),
                Margin = new Padding() {Left = 37, Bottom = 5 },
                Font = new Font("Tahoma", 9),
                Format = DateTimePickerFormat.Custom,
                CustomFormat = CustomDateTimeFormat,
                Value = DateTime.Now,
            });
        }
        #endregion
        #region CreateStarsAndCubes
        void Make5Stars(int i) //i - порядок панели на форме
        {
            var StarsList = new List<Label>();
            Panel Stars5Panel = new Panel()
            {
                Size = new Size(190, 30),
                Text = "0",
                Tag = "Star5"
            };
            for (int ii = 0; ii < 5; ii++)
            {
                Label Star5 = new Label()
                {
                    Size = new Size(25, 30),
                    Location = new Point(ii * 25 + 65, 0),
                    Font = new Font("Tahoma", 16, FontStyle.Bold),
                    ForeColor = Color.Gray,
                    Text = "☆",
                    Tag = new int[] {i , StarsList.Count}
                };
                Star5.Click += new EventHandler(Star5_Click);
                StarsList.Add(Star5);
            }
            Stars5Panel.Controls.AddRange(StarsList.ToArray());
            ColumnData.Add(Stars5Panel);
        }
        void Make10Stars(int i) //i - порядок панели на форме
        {
            var StarsList = new List<Label>();
            Panel Stars10Panel = new Panel()
            {
                Size = new Size(195, 30),
                Text = "0",
                Tag = "Star10"
            };
            for (int ii = 0; ii < 10; ii++)
            {
                Label Star10 = new Label()
                {
                    Size = new Size(20, 30),
                    Location = new Point(ii * 19 + 2, 0),
                    FlatStyle = FlatStyle.System,
                    Font = new Font("Tahoma", 14, FontStyle.Bold),
                    ForeColor = Color.Gray,
                    Text = "★",
                    Tag = new int[] {i, StarsList.Count}
                };
                Star10.Click += new EventHandler(Star10_Click);
                StarsList.Add(Star10);
            }
            Stars10Panel.Controls.AddRange(StarsList.ToArray());
            ColumnData.Add(Stars10Panel);
        }
        void Make10Cubes(int i) //i - порядок панели на форме
        {
            var CubeList = new List<Label>();
            Panel Cubes10Panel = new Panel()
            {
                Size = new Size(150, 30),
                Margin = new Padding() { Left = 42 },
                Text = "0",
                Tag = "Cube10"
            };
            for (int ii = 0; ii < 10; ii++)
            {
                Label Cube = new Label()
                {
                    Size = new Size(15, 30),
                    Location = new Point(ii * 15, 0),
                    Font = new Font("Tahoma", 16, FontStyle.Bold),
                    FlatStyle = FlatStyle.System,
                    ForeColor = Color.Gray,
                    Text = "▒",
                    Tag = new int[] {i, CubeList.Count}
                };
                Cube.Click += new EventHandler(Cube10_Click);
                CubeList.Add(Cube);
            }
            Cubes10Panel.Controls.AddRange(CubeList.ToArray());
            ColumnData.Add(Cubes10Panel);
        }
        #endregion
        #region ClickToBlocks
        private void Star5_Click(object sender, EventArgs e)
        {
            int ColCrd = ((int[])(sender as Label).Tag)[0];
            int ListCrd = ((int[])(sender as Label).Tag)[1];
            if ((sender as Label) == ColumnData[ColCrd].Controls[0] && ColumnData[ColCrd].Controls[0].Text == "★" && ColumnData[ColCrd].Controls[1].Text == "☆")
            {
                ColumnData[ColCrd].Controls[0].Text = "☆";
                ColumnData[ColCrd].Controls[0].ForeColor = Color.Gray;
                ColumnData[ColCrd].Text = "0";
            }
            else
            {
                ColumnData[ColCrd].Text = "";
                for (int i = 0; i < ListCrd + 1; i++)
                {
                    if (ListCrd < 2) ColumnData[ColCrd].Controls[i].ForeColor = Color.Red;
                    if (ListCrd == 2) ColumnData[ColCrd].Controls[i].ForeColor = Color.Orange;
                    if (ListCrd > 2) ColumnData[ColCrd].Controls[i].ForeColor = Color.LimeGreen;
                    ColumnData[ColCrd].Controls[i].Text = "★";
                }
                ColumnData[ColCrd].Text = (ListCrd + 1).ToString();
                for (int j = ColumnData[ColCrd].Controls.Count - 1; j > ListCrd; j--)
                {
                    ColumnData[ColCrd].Controls[j].ForeColor = Color.Gray;
                    ColumnData[ColCrd].Controls[j].Text = "☆";
                }
            }
        }
        private void Star10_Click(object sender, EventArgs e)
        {
            int ColCrd = ((int[])(sender as Label).Tag)[0];
            int ListCrd = ((int[])(sender as Label).Tag)[1];
            if ((sender as Label) == ColumnData[ColCrd].Controls[0] && ColumnData[ColCrd].Controls[0].Text == "★" && ColumnData[ColCrd].Controls[1].Text == "☆")
            {
                ColumnData[ColCrd].Controls[0].Text = "☆";
                ColumnData[ColCrd].Controls[0].ForeColor = Color.Gray;
                ColumnData[ColCrd].Text = "0";
            }
            else
            {
                for (int i = 0; i < ListCrd + 1; i++)
                {
                    if (ListCrd < 4) ColumnData[ColCrd].Controls[i].ForeColor = Color.Red;
                    if (ListCrd > 3 && ListCrd < 8) ColumnData[ColCrd].Controls[i].ForeColor = Color.Orange;
                    if (ListCrd > 7) ColumnData[ColCrd].Controls[i].ForeColor = Color.LimeGreen;
                    ColumnData[ColCrd].Controls[i].Text = "★";
                }
                ColumnData[ColCrd].Text = (ListCrd + 1).ToString();
                for (int j = ColumnData[ColCrd].Controls.Count - 1; j > ListCrd; j--)
                {
                    ColumnData[ColCrd].Controls[j].ForeColor = Color.Gray;
                    ColumnData[ColCrd].Controls[j].Text = "☆";
                }
            }
        }
        private void Cube10_Click(object sender, EventArgs e)
        {
            int ColCrd = ((int[])(sender as Label).Tag)[0];
            int ListCrd = ((int[])(sender as Label).Tag)[1];
            if ((sender as Label) == ColumnData[ColCrd].Controls[0] && ColumnData[ColCrd].Controls[0].Text == "█" && ColumnData[ColCrd].Controls[1].Text == "▒")
            {
                ColumnData[ColCrd].Controls[0].Text = "▒";
                ColumnData[ColCrd].Controls[0].ForeColor = Color.Gray;
                ColumnData[ColCrd].Text = "0";
            }
            else
            {
                for (int i = 0; i < ListCrd + 1; i++)
                {
                    ColumnData[ColCrd].Controls[i].ForeColor = Color.SeaGreen;
                    ColumnData[ColCrd].Controls[i].Text = "█";
                }
                ColumnData[ColCrd].Text = (ListCrd + 1).ToString();
                for (int j = ColumnData[ColCrd].Controls.Count - 1; j > ListCrd; j--)
                {
                    ColumnData[ColCrd].Controls[j].ForeColor = Color.Gray;
                    ColumnData[ColCrd].Controls[j].Text = "▒";
                }
            }
        }
        #endregion
        private void EditForm_Load(object sender, EventArgs e)
        {
            GetColumnInfo();
            for (int i = 0; i < ColumnValue.Count; i++)
            {
                CreateHeaderLabel(i);
                GetControlByType(ColumnValue[i].Type, i);
                EditPanel.Controls.Add(ColumnData[i]);
            }
            if (EditMode)
            {
                GetDataFromDatabase(MainForm.Collection.FocusedItem.Text, MainForm.SelectedLibLabel.Text);
                PushDataIntoCreatedControls();
            }
        }
        private void EditForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F4: if (e.Alt) MessageBox.Show("Я не закрываюсь! Шутка))"); break;
                case Keys.Escape: Cancel_Button.PerformClick(); break;
            }
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveData();
            this.Close();
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void EditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormReset();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Star10_Click(ColumnData[5].Controls[6], e);
        }

        public EventArgs e { get; set; }
    }
}