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

        int FNo;
        List<object> ColumnData = new List<object>();
        public string[] ColumnValue;
        string CustomDateFormat = "d MMMM yyyy";
        string CustomDateTimeFormat = "d MMMM yyyy, HH:mm:ss";
        Point ThisPoint;
        Size ColNameSize = new Size(420, 15);
        int H_I = 0;
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
                case "VARCHAR(5)": Make5Stars(i); break;            //Поле оценка
                case "VARCHAR(10)": Make5Cubes(i); break;           //Поле приоритет
            }
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            ColumnData.Clear();
            SQLiteCommand GetColumns = new SQLiteCommand(string.Format("pragma table_info('{0}');", MainForm.SelectedLibLabel.Text), connection);
            connection.Open();
            SQLiteDataReader ReadCols = GetColumns.ExecuteReader();
            foreach (DbDataRecord col in ReadCols)
            {
                Label tt = new Label() { Text = col["name"].ToString() + col["type"].ToString() };
                MessageBox.Show(col["name"].ToString() + col["type"].ToString());
                EditPanel.Controls.Add(tt);
                EditPanel.RowCount++;
            }
            connection.Close();
        }
        #region CreateControls
        void CreateHeaderLabel(int i)
        {
            EditPanel.Controls.Add(new Label() 
            { 
                Size = ColNameSize, 
                Text = MainForm.CurrentLibraryColumns[i].Name+":", 
                Location = ThisPoint,
            });
            ThisPoint = new Point(0, ThisPoint.Y + ColNameSize.Height);
        }
        void MakeATextBox(int i)
        {
/*            ColumnData.Add(new TextBox() 
            {
                Tag = MainForm.CurrentLibraryColumns[i].FieldIndex,
                Size = new Size(420, 25), 
                Location = ThisPoint
            });
            EditPanel.Controls.Add(ColumnData[i] as TextBox);
            ThisPoint = new Point(0, ThisPoint.Y + 30);*/
        }
        void MakeATextArea(int i)
        {
/*            ColumnData.Add(new RichTextBox()
            {
                Tag = MainForm.CurrentLibraryColumns[i].FieldIndex,
                Size = new Size(420, 60),
                Location = ThisPoint,
                ScrollBars = RichTextBoxScrollBars.ForcedVertical,
                WordWrap = true,
                BorderStyle = BorderStyle.FixedSingle
            });
            EditPanel.Controls.Add(ColumnData[i] as RichTextBox);
            ThisPoint = new Point(0, ThisPoint.Y + 65);*/
        }
        void MakeADateField(int i)
        {
/*            ColumnData.Add(new DateTimePicker() 
            {
                Tag = MainForm.CurrentLibraryColumns[i].FieldIndex,
                Size = new Size(420, 20),
                Location = ThisPoint,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = CustomDateFormat,
                Value = DateTime.Now,
            });
            EditPanel.Controls.Add(ColumnData[i] as DateTimePicker);
            ThisPoint = new Point(0, ThisPoint.Y + 25);*/
        }
        void MakeADateTimeField(int i)
        {
/*            ColumnData.Add(new DateTimePicker()
            {
                Tag = MainForm.CurrentLibraryColumns[i].FieldIndex,
                Size = new Size(420, 20),
                Location = ThisPoint,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = CustomDateTimeFormat,
                Value = DateTime.Now,
            });
            EditPanel.Controls.Add(ColumnData[i] as DateTimePicker);
            ThisPoint = new Point(0, ThisPoint.Y + 25);*/
        }
        #endregion
        void Make5Stars(int i)
        {
           EditPanel.Controls.Add(new Label()
           {
               Text = "Здесь будет 5 звездочек",
               Location = ThisPoint,
               Size = new Size(420, 40)
           });
           ThisPoint = new Point(0, ThisPoint.Y + 45);
        }
        void Make5Cubes(int i)
        {
           EditPanel.Controls.Add(new Label()
            {
                Text = "Здесь будет 5 кубиков",
                Location = ThisPoint,
                Size = new Size(420, 40)
            });
           ThisPoint = new Point(0, ThisPoint.Y + 45);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
