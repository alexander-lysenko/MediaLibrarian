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
            this.label1 = new System.Windows.Forms.Label();
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
            this.EditPanel.Controls.Add(this.label1);
            this.EditPanel.Name = "EditPanel";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.LimeGreen;
            this.label1.Name = "label1";
            // 
            // EditForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Button;
            this.Controls.Add(this.EditPanel);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.SaveButton);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditForm";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.EditForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditForm_KeyDown);
            this.EditPanel.ResumeLayout(false);
            this.EditPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.FlowLayoutPanel EditPanel;
        private System.Windows.Forms.Label label1;
    }
}