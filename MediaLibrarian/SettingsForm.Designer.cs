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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.Tabs = new System.Windows.Forms.TabControl();
            this.GeneralPage = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.picMaxHeightNUD = new System.Windows.Forms.NumericUpDown();
            this.picMaxWidthNUD = new System.Windows.Forms.NumericUpDown();
            this.cropMaxViewSizeChk = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.focusFirstItemChk = new System.Windows.Forms.CheckBox();
            this.rememberLastLibraryChk = new System.Windows.Forms.CheckBox();
            this.UIPage = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fullScreenStartChk = new System.Windows.Forms.CheckBox();
            this.autoSortByNameChk = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mainFontLabel = new System.Windows.Forms.Label();
            this.mainColorLabel = new System.Windows.Forms.Label();
            this.fontSelectLabel = new System.Windows.Forms.Label();
            this.colorSelectLabel = new System.Windows.Forms.Label();
            this.formCaptionTB = new System.Windows.Forms.TextBox();
            this.fromCaptionLabel = new System.Windows.Forms.Label();
            this.selectThemeCB = new System.Windows.Forms.ComboBox();
            this.selectThemeLabel = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.headerColorDialog = new System.Windows.Forms.ColorDialog();
            this.headerFontDialog = new System.Windows.Forms.FontDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.hintLabel = new System.Windows.Forms.Label();
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
            this.groupBox4.Controls.Add(this.cropMaxViewSizeChk);
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
            // cropMaxViewSizeChk
            // 
            resources.ApplyResources(this.cropMaxViewSizeChk, "cropMaxViewSizeChk");
            this.cropMaxViewSizeChk.Name = "cropMaxViewSizeChk";
            this.cropMaxViewSizeChk.UseVisualStyleBackColor = true;
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
            this.groupBox2.Controls.Add(this.fullScreenStartChk);
            this.groupBox2.Controls.Add(this.autoSortByNameChk);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // fullScreenStartChk
            // 
            resources.ApplyResources(this.fullScreenStartChk, "fullScreenStartChk");
            this.fullScreenStartChk.Name = "fullScreenStartChk";
            this.fullScreenStartChk.UseVisualStyleBackColor = true;
            // 
            // autoSortByNameChk
            // 
            resources.ApplyResources(this.autoSortByNameChk, "autoSortByNameChk");
            this.autoSortByNameChk.Name = "autoSortByNameChk";
            this.autoSortByNameChk.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mainFontLabel);
            this.groupBox1.Controls.Add(this.mainColorLabel);
            this.groupBox1.Controls.Add(this.fontSelectLabel);
            this.groupBox1.Controls.Add(this.colorSelectLabel);
            this.groupBox1.Controls.Add(this.formCaptionTB);
            this.groupBox1.Controls.Add(this.fromCaptionLabel);
            this.groupBox1.Controls.Add(this.selectThemeCB);
            this.groupBox1.Controls.Add(this.selectThemeLabel);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // mainFontLabel
            // 
            resources.ApplyResources(this.mainFontLabel, "mainFontLabel");
            this.mainFontLabel.Name = "mainFontLabel";
            this.mainFontLabel.Click += new System.EventHandler(this.mainFontLabel_Click);
            // 
            // mainColorLabel
            // 
            resources.ApplyResources(this.mainColorLabel, "mainColorLabel");
            this.mainColorLabel.Name = "mainColorLabel";
            this.mainColorLabel.Click += new System.EventHandler(this.mainColorLabel_Click);
            // 
            // fontSelectLabel
            // 
            resources.ApplyResources(this.fontSelectLabel, "fontSelectLabel");
            this.fontSelectLabel.Name = "fontSelectLabel";
            // 
            // colorSelectLabel
            // 
            resources.ApplyResources(this.colorSelectLabel, "colorSelectLabel");
            this.colorSelectLabel.Name = "colorSelectLabel";
            // 
            // formCaptionTB
            // 
            resources.ApplyResources(this.formCaptionTB, "formCaptionTB");
            this.formCaptionTB.Name = "formCaptionTB";
            // 
            // fromCaptionLabel
            // 
            resources.ApplyResources(this.fromCaptionLabel, "fromCaptionLabel");
            this.fromCaptionLabel.Name = "fromCaptionLabel";
            // 
            // selectThemeCB
            // 
            this.selectThemeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectThemeCB.FormattingEnabled = true;
            this.selectThemeCB.Items.AddRange(new object[] {
            resources.GetString("selectThemeCB.Items"),
            resources.GetString("selectThemeCB.Items1"),
            resources.GetString("selectThemeCB.Items2"),
            resources.GetString("selectThemeCB.Items3"),
            resources.GetString("selectThemeCB.Items4"),
            resources.GetString("selectThemeCB.Items5")});
            resources.ApplyResources(this.selectThemeCB, "selectThemeCB");
            this.selectThemeCB.Name = "selectThemeCB";
            // 
            // selectThemeLabel
            // 
            resources.ApplyResources(this.selectThemeLabel, "selectThemeLabel");
            this.selectThemeLabel.Name = "selectThemeLabel";
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
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // applyButton
            // 
            resources.ApplyResources(this.applyButton, "applyButton");
            this.applyButton.Name = "applyButton";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 200;
            this.toolTip.AutoPopDelay = 10000;
            this.toolTip.InitialDelay = 100;
            this.toolTip.ReshowDelay = 200;
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip.ToolTipTitle = "Подсказка к элементу:";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // hintLabel
            // 
            resources.ApplyResources(this.hintLabel, "hintLabel");
            this.hintLabel.Name = "hintLabel";
            // 
            // SettingsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.hintLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.Tabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.SettingsForm_Load);
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
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage GeneralPage;
        private System.Windows.Forms.TabPage UIPage;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.CheckBox cropMaxViewSizeChk;
        private System.Windows.Forms.CheckBox rememberLastLibraryChk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox autoSortByNameChk;
        private System.Windows.Forms.CheckBox fullScreenStartChk;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox selectThemeCB;
        private System.Windows.Forms.Label selectThemeLabel;
        private System.Windows.Forms.CheckBox focusFirstItemChk;
        private System.Windows.Forms.TextBox formCaptionTB;
        private System.Windows.Forms.Label fromCaptionLabel;
        private System.Windows.Forms.ColorDialog headerColorDialog;
        private System.Windows.Forms.Label fontSelectLabel;
        private System.Windows.Forms.Label colorSelectLabel;
        private System.Windows.Forms.FontDialog headerFontDialog;
        private System.Windows.Forms.Label mainFontLabel;
        private System.Windows.Forms.Label mainColorLabel;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown picMaxHeightNUD;
        private System.Windows.Forms.NumericUpDown picMaxWidthNUD;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label hintLabel;
    }
}