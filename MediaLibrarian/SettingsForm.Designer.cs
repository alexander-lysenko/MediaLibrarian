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
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.headerFontDialog = new System.Windows.Forms.FontDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.hintLabel = new System.Windows.Forms.Label();
            this.UIPage = new System.Windows.Forms.TabPage();
            this.backgroundGB = new System.Windows.Forms.GroupBox();
            this.themeColor2PB = new System.Windows.Forms.PictureBox();
            this.themeColor1Label = new System.Windows.Forms.Label();
            this.themeColor2CB = new System.Windows.Forms.ComboBox();
            this.themeColor1CB = new System.Windows.Forms.ComboBox();
            this.themeColor2Label = new System.Windows.Forms.Label();
            this.themeColor1PB = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fontColorPB = new System.Windows.Forms.PictureBox();
            this.fontColorCB = new System.Windows.Forms.ComboBox();
            this.fontColorLabel = new System.Windows.Forms.Label();
            this.mainColorPB = new System.Windows.Forms.PictureBox();
            this.mainColorCB = new System.Windows.Forms.ComboBox();
            this.mainFontLabel = new System.Windows.Forms.Label();
            this.fontSelectLabel = new System.Windows.Forms.Label();
            this.mainColorLabel = new System.Windows.Forms.Label();
            this.formCaptionTB = new System.Windows.Forms.TextBox();
            this.fromCaptionLabel = new System.Windows.Forms.Label();
            this.GeneralPage = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fullScreenStartChk = new System.Windows.Forms.CheckBox();
            this.autoSortByNameChk = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.picMaxHeightNUD = new System.Windows.Forms.NumericUpDown();
            this.picMaxWidthNUD = new System.Windows.Forms.NumericUpDown();
            this.cropMaxViewSizeChk = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.focusFirstItemChk = new System.Windows.Forms.CheckBox();
            this.rememberLastLibraryChk = new System.Windows.Forms.CheckBox();
            this.Tabs = new System.Windows.Forms.TabControl();
            this.UIPage.SuspendLayout();
            this.backgroundGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.themeColor2PB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.themeColor1PB)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fontColorPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainColorPB)).BeginInit();
            this.GeneralPage.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMaxHeightNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMaxWidthNUD)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.Tabs.SuspendLayout();
            this.SuspendLayout();
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
            // UIPage
            // 
            resources.ApplyResources(this.UIPage, "UIPage");
            this.UIPage.Controls.Add(this.backgroundGB);
            this.UIPage.Controls.Add(this.groupBox1);
            this.UIPage.Name = "UIPage";
            this.UIPage.UseVisualStyleBackColor = true;
            // 
            // backgroundGB
            // 
            this.backgroundGB.Controls.Add(this.themeColor2PB);
            this.backgroundGB.Controls.Add(this.themeColor1Label);
            this.backgroundGB.Controls.Add(this.themeColor2CB);
            this.backgroundGB.Controls.Add(this.themeColor1CB);
            this.backgroundGB.Controls.Add(this.themeColor2Label);
            this.backgroundGB.Controls.Add(this.themeColor1PB);
            resources.ApplyResources(this.backgroundGB, "backgroundGB");
            this.backgroundGB.Name = "backgroundGB";
            this.backgroundGB.TabStop = false;
            // 
            // themeColor2PB
            // 
            resources.ApplyResources(this.themeColor2PB, "themeColor2PB");
            this.themeColor2PB.Name = "themeColor2PB";
            this.themeColor2PB.TabStop = false;
            // 
            // themeColor1Label
            // 
            resources.ApplyResources(this.themeColor1Label, "themeColor1Label");
            this.themeColor1Label.Name = "themeColor1Label";
            // 
            // themeColor2CB
            // 
            this.themeColor2CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.themeColor2CB.FormattingEnabled = true;
            resources.ApplyResources(this.themeColor2CB, "themeColor2CB");
            this.themeColor2CB.Name = "themeColor2CB";
            this.themeColor2CB.SelectedIndexChanged += new System.EventHandler(this.themeColor2CB_SelectedIndexChanged);
            // 
            // themeColor1CB
            // 
            this.themeColor1CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.themeColor1CB.FormattingEnabled = true;
            resources.ApplyResources(this.themeColor1CB, "themeColor1CB");
            this.themeColor1CB.Name = "themeColor1CB";
            this.themeColor1CB.SelectedIndexChanged += new System.EventHandler(this.themeColor1CB_SelectedIndexChanged);
            // 
            // themeColor2Label
            // 
            resources.ApplyResources(this.themeColor2Label, "themeColor2Label");
            this.themeColor2Label.Name = "themeColor2Label";
            // 
            // themeColor1PB
            // 
            resources.ApplyResources(this.themeColor1PB, "themeColor1PB");
            this.themeColor1PB.Name = "themeColor1PB";
            this.themeColor1PB.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fontColorPB);
            this.groupBox1.Controls.Add(this.fontColorCB);
            this.groupBox1.Controls.Add(this.fontColorLabel);
            this.groupBox1.Controls.Add(this.mainColorPB);
            this.groupBox1.Controls.Add(this.mainColorCB);
            this.groupBox1.Controls.Add(this.mainFontLabel);
            this.groupBox1.Controls.Add(this.fontSelectLabel);
            this.groupBox1.Controls.Add(this.mainColorLabel);
            this.groupBox1.Controls.Add(this.formCaptionTB);
            this.groupBox1.Controls.Add(this.fromCaptionLabel);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // fontColorPB
            // 
            resources.ApplyResources(this.fontColorPB, "fontColorPB");
            this.fontColorPB.Name = "fontColorPB";
            this.fontColorPB.TabStop = false;
            // 
            // fontColorCB
            // 
            this.fontColorCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fontColorCB.FormattingEnabled = true;
            resources.ApplyResources(this.fontColorCB, "fontColorCB");
            this.fontColorCB.Name = "fontColorCB";
            this.fontColorCB.SelectedIndexChanged += new System.EventHandler(this.fontColorCB_SelectedIndexChanged);
            // 
            // fontColorLabel
            // 
            resources.ApplyResources(this.fontColorLabel, "fontColorLabel");
            this.fontColorLabel.Name = "fontColorLabel";
            // 
            // mainColorPB
            // 
            resources.ApplyResources(this.mainColorPB, "mainColorPB");
            this.mainColorPB.Name = "mainColorPB";
            this.mainColorPB.TabStop = false;
            // 
            // mainColorCB
            // 
            this.mainColorCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mainColorCB.FormattingEnabled = true;
            resources.ApplyResources(this.mainColorCB, "mainColorCB");
            this.mainColorCB.Name = "mainColorCB";
            this.mainColorCB.SelectedIndexChanged += new System.EventHandler(this.mainColorCB_SelectedIndexChanged);
            // 
            // mainFontLabel
            // 
            resources.ApplyResources(this.mainFontLabel, "mainFontLabel");
            this.mainFontLabel.Name = "mainFontLabel";
            this.mainFontLabel.Click += new System.EventHandler(this.mainFontLabel_Click);
            // 
            // fontSelectLabel
            // 
            resources.ApplyResources(this.fontSelectLabel, "fontSelectLabel");
            this.fontSelectLabel.Name = "fontSelectLabel";
            // 
            // mainColorLabel
            // 
            resources.ApplyResources(this.mainColorLabel, "mainColorLabel");
            this.mainColorLabel.Name = "mainColorLabel";
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
            // GeneralPage
            // 
            resources.ApplyResources(this.GeneralPage, "GeneralPage");
            this.GeneralPage.Controls.Add(this.groupBox2);
            this.GeneralPage.Controls.Add(this.groupBox4);
            this.GeneralPage.Controls.Add(this.groupBox3);
            this.GeneralPage.Name = "GeneralPage";
            this.GeneralPage.UseVisualStyleBackColor = true;
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
            // Tabs
            // 
            resources.ApplyResources(this.Tabs, "Tabs");
            this.Tabs.Controls.Add(this.GeneralPage);
            this.Tabs.Controls.Add(this.UIPage);
            this.Tabs.Multiline = true;
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
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
            this.UIPage.ResumeLayout(false);
            this.backgroundGB.ResumeLayout(false);
            this.backgroundGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.themeColor2PB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.themeColor1PB)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fontColorPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainColorPB)).EndInit();
            this.GeneralPage.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMaxHeightNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMaxWidthNUD)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.Tabs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.FontDialog headerFontDialog;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label hintLabel;
        private System.Windows.Forms.TabPage UIPage;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label mainFontLabel;
        private System.Windows.Forms.Label fontSelectLabel;
        private System.Windows.Forms.Label mainColorLabel;
        public System.Windows.Forms.TextBox formCaptionTB;
        private System.Windows.Forms.Label fromCaptionLabel;
        public System.Windows.Forms.ComboBox themeColor1CB;
        private System.Windows.Forms.Label themeColor1Label;
        private System.Windows.Forms.TabPage GeneralPage;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.NumericUpDown picMaxHeightNUD;
        public System.Windows.Forms.NumericUpDown picMaxWidthNUD;
        public System.Windows.Forms.CheckBox cropMaxViewSizeChk;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.CheckBox focusFirstItemChk;
        public System.Windows.Forms.CheckBox rememberLastLibraryChk;
        public System.Windows.Forms.TabControl Tabs;
        public System.Windows.Forms.ComboBox mainColorCB;
        private System.Windows.Forms.PictureBox mainColorPB;
        private System.Windows.Forms.PictureBox themeColor1PB;
        private System.Windows.Forms.PictureBox fontColorPB;
        public System.Windows.Forms.ComboBox fontColorCB;
        private System.Windows.Forms.Label fontColorLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.CheckBox fullScreenStartChk;
        public System.Windows.Forms.CheckBox autoSortByNameChk;
        private System.Windows.Forms.GroupBox backgroundGB;
        private System.Windows.Forms.PictureBox themeColor2PB;
        public System.Windows.Forms.ComboBox themeColor2CB;
        private System.Windows.Forms.Label themeColor2Label;
    }
}