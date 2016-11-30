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
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.EditPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.PosterHintLabel = new System.Windows.Forms.Label();
            this.PosterImageTB = new System.Windows.Forms.TextBox();
            this.SelectImageButton = new System.Windows.Forms.Button();
            this.OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.LoadingLabel = new System.Windows.Forms.Label();
            this.loadedPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.loadedPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            resources.ApplyResources(this.SaveButton, "SaveButton");
            this.SaveButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // Cancel_Button
            // 
            resources.ApplyResources(this.Cancel_Button, "Cancel_Button");
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            this.Cancel_Button.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // EditPanel
            // 
            resources.ApplyResources(this.EditPanel, "EditPanel");
            this.EditPanel.Name = "EditPanel";
            // 
            // PosterHintLabel
            // 
            resources.ApplyResources(this.PosterHintLabel, "PosterHintLabel");
            this.PosterHintLabel.Name = "PosterHintLabel";
            // 
            // PosterImageTB
            // 
            resources.ApplyResources(this.PosterImageTB, "PosterImageTB");
            this.PosterImageTB.Name = "PosterImageTB";
            this.PosterImageTB.TextChanged += new System.EventHandler(this.PosterImageTB_TextChanged);
            // 
            // SelectImageButton
            // 
            resources.ApplyResources(this.SelectImageButton, "SelectImageButton");
            this.SelectImageButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.SelectImageButton.Name = "SelectImageButton";
            this.SelectImageButton.UseVisualStyleBackColor = true;
            this.SelectImageButton.Click += new System.EventHandler(this.SelectImageButton_Click);
            // 
            // OpenFile
            // 
            resources.ApplyResources(this.OpenFile, "OpenFile");
            // 
            // LoadingLabel
            // 
            resources.ApplyResources(this.LoadingLabel, "LoadingLabel");
            this.LoadingLabel.ForeColor = System.Drawing.Color.Blue;
            this.LoadingLabel.Name = "LoadingLabel";
            // 
            // loadedPicture
            // 
            resources.ApplyResources(this.loadedPicture, "loadedPicture");
            this.loadedPicture.Name = "loadedPicture";
            this.loadedPicture.TabStop = false;
            // 
            // EditForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Button;
            this.Controls.Add(this.loadedPicture);
            this.Controls.Add(this.LoadingLabel);
            this.Controls.Add(this.SelectImageButton);
            this.Controls.Add(this.PosterImageTB);
            this.Controls.Add(this.PosterHintLabel);
            this.Controls.Add(this.EditPanel);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.SaveButton);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditForm_FormClosing);
            this.Load += new System.EventHandler(this.EditForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.loadedPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.FlowLayoutPanel EditPanel;
        private System.Windows.Forms.Label PosterHintLabel;
        private System.Windows.Forms.TextBox PosterImageTB;
        private System.Windows.Forms.Button SelectImageButton;
        private System.Windows.Forms.OpenFileDialog OpenFile;
        public System.Windows.Forms.Label LoadingLabel;
        private System.Windows.Forms.PictureBox loadedPicture;
    }
}