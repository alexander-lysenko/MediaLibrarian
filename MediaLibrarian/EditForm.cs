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
        string CustomDateFormat = "d MMMM yyyy";
        string CustomDateTimeFormat = "d MMMM yyyy, HH:mm:ss";
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
                Text = ColumnValue[i].Name
            });
        }
        void MakeATextBox(int i)
        {
            ColumnData.Add(new TextBox() 
            {
                Size = new Size(420, 25),
                Margin = new Padding() { Bottom = 15 },
            });
            EditPanel.Controls.Add(ColumnData[i] as TextBox);
        }
        void MakeATextArea(int i)
        {
            ColumnData.Add(new RichTextBox()
            {
                Size = new Size(420, 60),
                Margin = new Padding() { Bottom = 15 },
                ScrollBars = RichTextBoxScrollBars.ForcedVertical,
                WordWrap = true,
                BorderStyle = BorderStyle.FixedSingle
            });
            EditPanel.Controls.Add(ColumnData[i] as RichTextBox);
        }
        void MakeADateField(int i)
        {
            ColumnData.Add(new DateTimePicker()
            {
                Size = new Size(180, 20),
                Margin = new Padding() { Left = 15},
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
                Size = new Size(180, 20),
                //Margin = new Padding(Left = 10),
                Format = DateTimePickerFormat.Custom,
                CustomFormat = CustomDateTimeFormat,
                Value = DateTime.Now,
            });
            EditPanel.Controls.Add(ColumnData[i] as DateTimePicker);
        }
        void Make5Stars(int i)
        {
            ColumnData.Add(new Label()
            {
                Text = "☆☆☆☆☆",
            });
            Panel Stars5Panel = new Panel()
            {
                Size = new Size(190, 30)
            };
            for (int ii = 0; ii < 5; ii++)
            {
                Label Star = new Label() { Size = new Size(15, 30), Text = "☆", Tag = new int[] { ii, i } };
                Stars5Panel.Controls.Add(Star);
            }
            EditPanel.Controls.Add(Stars5Panel);
        }
        void Make10Stars(int i)
        {
            ColumnData.Add(new Label()
            {
                Text = "☆☆☆☆☆☆☆☆☆☆",
            });
            Panel Stars10Panel = new Panel()
            {
                Size = new Size(190, 30)
            };
            for (int ii = 0; ii < 10; ii++)
            {
                Label Star = new Label() { Size = new Size(15, 30), Text = "☆", Tag = new int[] { ii, i } };
                Stars10Panel.Controls.Add(Star);
            }
            EditPanel.Controls.Add(Stars10Panel);
        }
        void Make10Cubes(int i)
        {
            ColumnData.Add(new Label()
            {
                Text = "▒▒▒▒▒█████",
            }); 
            Panel Cubes10Panel = new Panel()
            {
                Size = new Size(190, 30)
            };
            for (int ii = 0; ii < 10; ii++)
            {
                Label Cube = new Label() { Size = new Size(15, 30), Text = "▒", Tag = new int[] { ii, i } };
                Cubes10Panel.Controls.Add(Cube);
            }
            EditPanel.Controls.Add(Cubes10Panel);
        }
        #endregion
        private void SaveButton_Click(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
