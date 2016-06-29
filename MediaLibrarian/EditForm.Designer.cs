namespace MediaLibrarian
{
    partial class EditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditForm));
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.EditPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker4 = new System.Windows.Forms.DateTimePicker();
            this.EditPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            resources.ApplyResources(this.SaveButton, "SaveButton");
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            resources.ApplyResources(this.CancelButton, "CancelButton");
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // EditPanel
            // 
            resources.ApplyResources(this.EditPanel, "EditPanel");
            this.EditPanel.Controls.Add(this.dateTimePicker2);
            this.EditPanel.Controls.Add(this.dateTimePicker1);
            this.EditPanel.Controls.Add(this.button1);
            this.EditPanel.Controls.Add(this.dateTimePicker3);
            this.EditPanel.Controls.Add(this.dateTimePicker4);
            this.EditPanel.Name = "EditPanel";
            // 
            // dateTimePicker2
            // 
            resources.ApplyResources(this.dateTimePicker2, "dateTimePicker2");
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Value = new System.DateTime(2022, 9, 29, 9, 49, 0, 0);
            // 
            // dateTimePicker1
            // 
            resources.ApplyResources(this.dateTimePicker1, "dateTimePicker1");
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Value = new System.DateTime(2020, 9, 24, 13, 58, 59, 0);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker3
            // 
            resources.ApplyResources(this.dateTimePicker3, "dateTimePicker3");
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Value = new System.DateTime(2022, 9, 29, 9, 49, 0, 0);
            // 
            // dateTimePicker4
            // 
            resources.ApplyResources(this.dateTimePicker4, "dateTimePicker4");
            this.dateTimePicker4.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker4.Name = "dateTimePicker4";
            this.dateTimePicker4.Value = new System.DateTime(2022, 9, 29, 9, 49, 0, 0);
            // 
            // EditForm
            // 
            this.AcceptButton = this.SaveButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.EditPanel);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditForm";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.EditForm_Load);
            this.EditPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.FlowLayoutPanel EditPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.DateTimePicker dateTimePicker4;
    }
}