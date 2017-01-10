namespace MediaLibrarian
{
    partial class AboutForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label CurVersionHintLabel;
        private System.Windows.Forms.Label CurrentVersionLabel;
        private System.Windows.Forms.RichTextBox ChangelogRTB;
        private System.Windows.Forms.Label FirVerDateHintLabel;
        private System.Windows.Forms.Label FirstVersionDateLabel;
        private System.Windows.Forms.Label AuthorsNameHintLabel;
        private System.Windows.Forms.Label companyNameLabel;
        private System.Windows.Forms.Label ChangelogHintLabel;
        private System.Windows.Forms.Label CurVerDateHintLabel;
        private System.Windows.Forms.Label CurVersionDateLabel;

        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CurVersionHintLabel = new System.Windows.Forms.Label();
            this.CurrentVersionLabel = new System.Windows.Forms.Label();
            this.ChangelogRTB = new System.Windows.Forms.RichTextBox();
            this.FirVerDateHintLabel = new System.Windows.Forms.Label();
            this.FirstVersionDateLabel = new System.Windows.Forms.Label();
            this.AuthorsNameHintLabel = new System.Windows.Forms.Label();
            this.companyNameLabel = new System.Windows.Forms.Label();
            this.ChangelogHintLabel = new System.Windows.Forms.Label();
            this.CurVerDateHintLabel = new System.Windows.Forms.Label();
            this.CurVersionDateLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MediaLibrarian.Properties.Resources.splash;
            this.pictureBox1.Location = new System.Drawing.Point(12, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(340, 85);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // CurVersionHintLabel
            // 
            this.CurVersionHintLabel.Location = new System.Drawing.Point(12, 187);
            this.CurVersionHintLabel.Name = "CurVersionHintLabel";
            this.CurVersionHintLabel.Size = new System.Drawing.Size(100, 17);
            this.CurVersionHintLabel.TabIndex = 1;
            this.CurVersionHintLabel.Text = "Текущая версия:";
            this.CurVersionHintLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurrentVersionLabel
            // 
            this.CurrentVersionLabel.Location = new System.Drawing.Point(230, 189);
            this.CurrentVersionLabel.Name = "CurrentVersionLabel";
            this.CurrentVersionLabel.Size = new System.Drawing.Size(122, 17);
            this.CurrentVersionLabel.TabIndex = 2;
            this.CurrentVersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ChangelogRTB
            // 
            this.ChangelogRTB.AutoWordSelection = true;
            this.ChangelogRTB.BackColor = System.Drawing.SystemColors.Control;
            this.ChangelogRTB.Location = new System.Drawing.Point(12, 273);
            this.ChangelogRTB.Name = "ChangelogRTB";
            this.ChangelogRTB.ReadOnly = true;
            this.ChangelogRTB.Size = new System.Drawing.Size(340, 160);
            this.ChangelogRTB.TabIndex = 3;
            this.ChangelogRTB.Text = "";
            // 
            // FirVerDateHintLabel
            // 
            this.FirVerDateHintLabel.Location = new System.Drawing.Point(12, 221);
            this.FirVerDateHintLabel.Name = "FirVerDateHintLabel";
            this.FirVerDateHintLabel.Size = new System.Drawing.Size(173, 17);
            this.FirVerDateHintLabel.TabIndex = 4;
            this.FirVerDateHintLabel.Text = "Дата выхода первой версии:";
            this.FirVerDateHintLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FirstVersionDateLabel
            // 
            this.FirstVersionDateLabel.Location = new System.Drawing.Point(289, 223);
            this.FirstVersionDateLabel.Name = "FirstVersionDateLabel";
            this.FirstVersionDateLabel.Size = new System.Drawing.Size(63, 17);
            this.FirstVersionDateLabel.TabIndex = 5;
            this.FirstVersionDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AuthorsNameHintLabel
            // 
            this.AuthorsNameHintLabel.Location = new System.Drawing.Point(12, 237);
            this.AuthorsNameHintLabel.Name = "AuthorsNameHintLabel";
            this.AuthorsNameHintLabel.Size = new System.Drawing.Size(115, 17);
            this.AuthorsNameHintLabel.TabIndex = 6;
            this.AuthorsNameHintLabel.Text = "Автор программы:";
            this.AuthorsNameHintLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // companyNameLabel
            // 
            this.companyNameLabel.Location = new System.Drawing.Point(123, 239);
            this.companyNameLabel.Name = "companyNameLabel";
            this.companyNameLabel.Size = new System.Drawing.Size(229, 15);
            this.companyNameLabel.TabIndex = 7;
            this.companyNameLabel.Text = "Александр \"LinJay\" Лысенко";
            this.companyNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ChangelogHintLabel
            // 
            this.ChangelogHintLabel.Location = new System.Drawing.Point(9, 254);
            this.ChangelogHintLabel.Name = "ChangelogHintLabel";
            this.ChangelogHintLabel.Size = new System.Drawing.Size(340, 16);
            this.ChangelogHintLabel.TabIndex = 8;
            this.ChangelogHintLabel.Text = "Изменения в этой и предыдущих версиях:";
            this.ChangelogHintLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurVerDateHintLabel
            // 
            this.CurVerDateHintLabel.Location = new System.Drawing.Point(12, 204);
            this.CurVerDateHintLabel.Name = "CurVerDateHintLabel";
            this.CurVerDateHintLabel.Size = new System.Drawing.Size(173, 17);
            this.CurVerDateHintLabel.TabIndex = 9;
            this.CurVerDateHintLabel.Text = "Дата выхода текущей версии:";
            this.CurVerDateHintLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurVersionDateLabel
            // 
            this.CurVersionDateLabel.Location = new System.Drawing.Point(289, 206);
            this.CurVersionDateLabel.Name = "CurVersionDateLabel";
            this.CurVersionDateLabel.Size = new System.Drawing.Size(63, 17);
            this.CurVersionDateLabel.TabIndex = 10;
            this.CurVersionDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(340, 99);
            this.label1.TabIndex = 11;
            this.label1.Text = "Описание программы";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 446);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CurVersionDateLabel);
            this.Controls.Add(this.CurVerDateHintLabel);
            this.Controls.Add(this.ChangelogHintLabel);
            this.Controls.Add(this.companyNameLabel);
            this.Controls.Add(this.AuthorsNameHintLabel);
            this.Controls.Add(this.FirstVersionDateLabel);
            this.Controls.Add(this.FirVerDateHintLabel);
            this.Controls.Add(this.ChangelogRTB);
            this.Controls.Add(this.CurrentVersionLabel);
            this.Controls.Add(this.CurVersionHintLabel);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "О программе";
            this.Load += new System.EventHandler(this.AboutForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label label1;
    }
}
