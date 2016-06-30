using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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

        List<object> ColumnData = new List<object>();
        List<Category> ColumnValue = new List<Category>();
        List<List<Label>> StarsList = new List<List<Label>>();
        string CustomDateFormat = "d MMMM yyyy";
        string CustomDateTimeFormat = "d.MM.yyyy, HH:mm:ss";
        static string Database = "baza.db";
        SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", Database));
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
        private void GetDataFromControls(int i)
        {
            switch (ColumnData[i].GetType().ToString()) 
            {
                case "System.Windows.Forms.TextBox": break;
                case "System.Windows.Forms.RichTextBox": break;
                case "System.Windows.Forms.DateTimePicker": break;
                case "System.Windows.Forms.Label": break;
            }
        }
        private void EditForm_Load(object sender, EventArgs e)
        {
            GetColumnInfo();
            for (int i = 0; i < ColumnValue.Count; i++)
            {
                CreateHeaderLabel(i);
                GetControlByType(ColumnValue[i].Type, i);
            }
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
            EditPanel.Controls.Add(ColumnData[i] as TextBox);
        }
        void MakeATextArea(int i)
        {
            ColumnData.Add(new RichTextBox()
            {
                Size = new Size(420, 100),
                ScrollBars = RichTextBoxScrollBars.ForcedVertical,
                WordWrap = true,
            });
            EditPanel.Controls.Add(ColumnData[i] as RichTextBox);
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
            EditPanel.Controls.Add(ColumnData[i] as DateTimePicker);
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
            EditPanel.Controls.Add(ColumnData[i] as DateTimePicker);
        }
        #endregion
        #region CreateStarsAndCubes
        void Make5Stars(int i)
        {
            StarsList.Add(new List<Label>());
            ColumnData.Add(new Label()
            {
                Text = "★★☆☆☆",
            });
            Panel Stars5Panel = new Panel()
            {
                Size = new Size(190, 30)
            };
            for (int ii = 0; ii < 5; ii++)
            {
                Label Star5 = new Label()
                {
                    Size = new Size(25, 30),
                    Location = new Point(ii * 25 + 65, 0),
                    Font = new Font("Tahoma", 16, FontStyle.Bold),
                    Text = "☆",
                    Tag = new int[] { ii, i, StarsList.Count - 1 }
                };
                Star5.Click += new EventHandler(Star5_Click);
                StarsList[StarsList.Count - 1].Add(Star5);
                Stars5Panel.Controls.Add(Star5);
            }
            EditPanel.Controls.Add(Stars5Panel);
        }
        void Make10Stars(int i)
        {
            StarsList.Add(new List<Label>());
            ColumnData.Add(new Label()
            {
                Text = "★★★★★☆☆☆☆☆",
            });
            Panel Stars10Panel = new Panel()
            {
                Size = new Size(195, 30)
            };
            for (int ii = 0; ii < 10; ii++)
            {
                Label Star10 = new Label()
                {
                    Size = new Size(20, 30),
                    Location = new Point(ii * 19 + 2, 0),
                    FlatStyle = FlatStyle.System,
                    Font = new Font("Tahoma", 14, FontStyle.Bold),
                    Text = "★",
                    Tag = new int[] { ii, i, StarsList.Count - 1 }
                };
                if (ii < 4) Star10.ForeColor = Color.Red;
                if (ii > 3 && ii < 8) Star10.ForeColor = Color.Orange;
                if (ii > 7) Star10.ForeColor = Color.LimeGreen;
                Star10.Click += new EventHandler(Star10_Click);
                StarsList[StarsList.Count-1].Add(Star10);
                Stars10Panel.Controls.Add(Star10);
            }
            EditPanel.Controls.Add(Stars10Panel);
        }
        void Make10Cubes(int i)
        {
            StarsList.Add(new List<Label>());
            ColumnData.Add(new Label()
            {
                Text = "▒▒▒▒▒█████",
            });
            Panel Cubes10Panel = new Panel()
            {
                Size = new Size(150, 30),
                Margin = new Padding() { Left = 42 }
            };
            for (int ii = 0; ii < 10; ii++)
            {
                Label Cube = new Label()
                {
                    Size = new Size(15, 30),
                    Location = new Point(ii * 15, 0),
                    Font = new Font("Tahoma", 16, FontStyle.Bold),
                    FlatStyle = FlatStyle.System,
                    Text = "▒",
                    Tag = new int[] { ii, i, StarsList.Count-1 }
                };
                Cube.Click += new EventHandler(Cube10_Click);
                StarsList[StarsList.Count - 1].Add(Cube);
                Cubes10Panel.Controls.Add(Cube);
            }
            EditPanel.Controls.Add(Cubes10Panel);
        }
        #endregion
        private void SaveButton_Click(object sender, EventArgs e)
        {
            foreach (var control in ColumnData)
            {
                MessageBox.Show(control.GetType().ToString());
            }
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void EditForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F4: if (e.Alt) MessageBox.Show("Я не закрываюсь!"); break;
                case Keys.Escape: Cancel_Button.PerformClick(); break;
            }
        }

        private void Star5_Click(object sender, EventArgs e)
        {
            if ((sender as Label).Text == "☆") (sender as Label).Text = "★"; else (sender as Label).Text = "☆";
            //MessageBox.Show(((int[])(sender as Label).Tag)[0].ToString() + " " + ((int[])(sender as Label).Tag)[1].ToString());
        }
        private void Star10_Click(object sender, EventArgs e)
        {
            //if ((sender as Label).Text == "☆") (sender as Label).Text = "★"; else (sender as Label).Text = "☆";
            //MessageBox.Show(((int[])(sender as Label).Tag)[0].ToString() + " " + ((int[])(sender as Label).Tag)[1].ToString());
            
            int ind = ((int[])(sender as Label).Tag)[0];
            int ColCrd = ((int[])(sender as Label).Tag)[1];
            int ListCrd = ((int[])(sender as Label).Tag)[2];
            for (int i = 0; i < ind+1; i++)
            {
                StarsList[ListCrd][i].ForeColor = Color.Purple;
            } for (int i = StarsList[ListCrd].Count - ind-1; i > ind+1; i--)
            {
                StarsList[ListCrd][i].ForeColor = Color.Gray;
            }
        }
        private void Cube10_Click(object sender, EventArgs e)
        {
            if ((sender as Label).Text == "█") (sender as Label).Text = "▒"; else (sender as Label).Text = "█";
            //MessageBox.Show(((int[])(sender as Label).Tag)[0].ToString() + " " + ((int[])(sender as Label).Tag)[1].ToString());
        }
    }
}
