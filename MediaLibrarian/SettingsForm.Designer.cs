namespace MediaLibrarian
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.Tabs = new System.Windows.Forms.TabControl();
            this.GeneralPage = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.picMaxHeightNUD = new System.Windows.Forms.NumericUpDown();
            this.picMaxWidthNUD = new System.Windows.Forms.NumericUpDown();
            this.MaximumViewSizeChk = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.focusFirstItemChk = new System.Windows.Forms.CheckBox();
            this.rememberLastLibraryChk = new System.Windows.Forms.CheckBox();
            this.UIPage = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SelectedFontLabel = new System.Windows.Forms.Label();
            this.SelectedColorLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.formCaptionTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.selectThemeCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.OK_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.Apply_Button = new System.Windows.Forms.Button();
            this.HeaderColorDialog = new System.Windows.Forms.ColorDialog();
            this.HeaderFontDialog = new System.Windows.Forms.FontDialog();
            this.Tabs.SuspendLayout();
            this.GeneralPage.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMaxHeightNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMaxWidthNUD)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.UIPage.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tabs
            // 
            resources.ApplyResources(this.Tabs, "Tabs");
            this.Tabs.Controls.Add(this.GeneralPage);
            this.Tabs.Controls.Add(this.UIPage);
            this.Tabs.Controls.Add(this.tabPage1);
            this.Tabs.Controls.Add(this.tabPage2);
            this.Tabs.Multiline = true;
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            // 
            // GeneralPage
            // 
            resources.ApplyResources(this.GeneralPage, "GeneralPage");
            this.GeneralPage.Controls.Add(this.groupBox4);
            this.GeneralPage.Controls.Add(this.groupBox3);
            this.GeneralPage.Name = "GeneralPage";
            this.GeneralPage.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.picMaxHeightNUD);
            this.groupBox4.Controls.Add(this.picMaxWidthNUD);
            this.groupBox4.Controls.Add(this.MaximumViewSizeChk);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // picMaxHeightNUD
            // 
            resources.ApplyResources(this.picMaxHeightNUD, "picMaxHeightNUD");
            this.picMaxHeightNUD.Maximum = new decimal(new int[] {
            720,
            0,
            0,
            0});
            this.picMaxHeightNUD.Minimum = new decimal(new int[] {
            480,
            0,
            0,
            0});
            this.picMaxHeightNUD.Name = "picMaxHeightNUD";
            this.picMaxHeightNUD.Value = new decimal(new int[] {
            720,
            0,
            0,
            0});
            // 
            // picMaxWidthNUD
            // 
            resources.ApplyResources(this.picMaxWidthNUD, "picMaxWidthNUD");
            this.picMaxWidthNUD.Maximum = new decimal(new int[] {
            1280,
            0,
            0,
            0});
            this.picMaxWidthNUD.Minimum = new decimal(new int[] {
            480,
            0,
            0,
            0});
            this.picMaxWidthNUD.Name = "picMaxWidthNUD";
            this.picMaxWidthNUD.Value = new decimal(new int[] {
            1280,
            0,
            0,
            0});
            // 
            // MaximumViewSizeChk
            // 
            resources.ApplyResources(this.MaximumViewSizeChk, "MaximumViewSizeChk");
            this.MaximumViewSizeChk.Name = "MaximumViewSizeChk";
            this.MaximumViewSizeChk.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.focusFirstItemChk);
            this.groupBox3.Controls.Add(this.rememberLastLibraryChk);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // focusFirstItemChk
            // 
            resources.ApplyResources(this.focusFirstItemChk, "focusFirstItemChk");
            this.focusFirstItemChk.Name = "focusFirstItemChk";
            this.focusFirstItemChk.UseVisualStyleBackColor = true;
            // 
            // rememberLastLibraryChk
            // 
            resources.ApplyResources(this.rememberLastLibraryChk, "rememberLastLibraryChk");
            this.rememberLastLibraryChk.Name = "rememberLastLibraryChk";
            this.rememberLastLibraryChk.UseVisualStyleBackColor = true;
            // 
            // UIPage
            // 
            resources.ApplyResources(this.UIPage, "UIPage");
            this.UIPage.Controls.Add(this.groupBox2);
            this.UIPage.Controls.Add(this.groupBox1);
            this.UIPage.Name = "UIPage";
            this.UIPage.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox7);
            this.groupBox2.Controls.Add(this.checkBox8);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // checkBox7
            // 
            resources.ApplyResources(this.checkBox7, "checkBox7");
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            resources.ApplyResources(this.checkBox8, "checkBox8");
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.SelectedFontLabel);
            this.groupBox1.Controls.Add(this.SelectedColorLabel);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.formCaptionTB);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.selectThemeCB);
            this.groupBox1.Controls.Add(this.label1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // SelectedFontLabel
            // 
            resources.ApplyResources(this.SelectedFontLabel, "SelectedFontLabel");
            this.SelectedFontLabel.Name = "SelectedFontLabel";
            this.SelectedFontLabel.Click += new System.EventHandler(this.SelectedFontLabel_Click);
            // 
            // SelectedColorLabel
            // 
            resources.ApplyResources(this.SelectedColorLabel, "SelectedColorLabel");
            this.SelectedColorLabel.Name = "SelectedColorLabel";
            this.SelectedColorLabel.Click += new System.EventHandler(this.SelectedColorLabel_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // formCaptionTB
            // 
            resources.ApplyResources(this.formCaptionTB, "formCaptionTB");
            this.formCaptionTB.Name = "formCaptionTB";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // selectThemeCB
            // 
            this.selectThemeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectThemeCB.FormattingEnabled = true;
            resources.ApplyResources(this.selectThemeCB, "selectThemeCB");
            this.selectThemeCB.Name = "selectThemeCB";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // OK_Button
            // 
            resources.ApplyResources(this.OK_Button, "OK_Button");
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.UseVisualStyleBackColor = true;
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // Cancel_Button
            // 
            resources.ApplyResources(this.Cancel_Button, "Cancel_Button");
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            this.Cancel_Button.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // Apply_Button
            // 
            resources.ApplyResources(this.Apply_Button, "Apply_Button");
            this.Apply_Button.Name = "Apply_Button";
            this.Apply_Button.UseVisualStyleBackColor = true;
            this.Apply_Button.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.Apply_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.OK_Button);
            this.Controls.Add(this.Tabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Tabs.ResumeLayout(false);
            this.GeneralPage.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMaxHeightNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMaxWidthNUD)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.UIPage.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage GeneralPage;
        private System.Windows.Forms.TabPage UIPage;
        private System.Windows.Forms.Button OK_Button;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.Button Apply_Button;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.CheckBox MaximumViewSizeChk;
        private System.Windows.Forms.CheckBox rememberLastLibraryChk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox selectThemeCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox focusFirstItemChk;
        private System.Windows.Forms.TextBox formCaptionTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColorDialog HeaderColorDialog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FontDialog HeaderFontDialog;
        private System.Windows.Forms.Label SelectedFontLabel;
        private System.Windows.Forms.Label SelectedColorLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown picMaxHeightNUD;
        private System.Windows.Forms.NumericUpDown picMaxWidthNUD;
    }
}