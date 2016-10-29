﻿namespace MediaLibrarian
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Collection = new System.Windows.Forms.ListView();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.FileTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenLibTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateLibTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearLibTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CloseAppTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.EditTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.AddElementTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.EditElementTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteElementTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.FindElementTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.AutoSortingTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.FullScreenTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.PreferencesTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpAboutTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.HintLabel = new System.Windows.Forms.Label();
            this.SelectCollectionButton = new System.Windows.Forms.Button();
            this.SelectedLibLabel = new System.Windows.Forms.Label();
            this.LibInfoGB = new System.Windows.Forms.GroupBox();
            this.ElementCount = new System.Windows.Forms.Label();
            this.ElementCountHintLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ElementActionsGB = new System.Windows.Forms.GroupBox();
            this.EditElementButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.AddElementButton = new System.Windows.Forms.Button();
            this.DeleteElementButton = new System.Windows.Forms.Button();
            this.ElementInfoGB = new System.Windows.Forms.GroupBox();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.TitleHeaderLabel = new System.Windows.Forms.Label();
            this.PosterBox = new System.Windows.Forms.PictureBox();
            this.InfoPanel = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.StatusBar.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.LibInfoGB.SuspendLayout();
            this.ElementActionsGB.SuspendLayout();
            this.ElementInfoGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PosterBox)).BeginInit();
            this.InfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Collection
            // 
            resources.ApplyResources(this.Collection, "Collection");
            this.Collection.FullRowSelect = true;
            this.Collection.GridLines = true;
            this.Collection.Name = "Collection";
            this.Collection.ShowGroups = false;
            this.Collection.UseCompatibleStateImageBehavior = false;
            this.Collection.View = System.Windows.Forms.View.Details;
            this.Collection.ItemActivate += new System.EventHandler(this.Collection_ItemActivate);
            this.Collection.SelectedIndexChanged += new System.EventHandler(this.Collection_SelectedIndexChanged);
            // 
            // StatusBar
            // 
            this.StatusBar.BackColor = System.Drawing.Color.Transparent;
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            resources.ApplyResources(this.StatusBar, "StatusBar");
            this.StatusBar.Name = "StatusBar";
            // 
            // StatusLabel
            // 
            this.StatusLabel.BackColor = System.Drawing.SystemColors.Control;
            this.StatusLabel.Name = "StatusLabel";
            resources.ApplyResources(this.StatusLabel, "StatusLabel");
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.Color.Transparent;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileTSMI,
            this.EditTSMI,
            this.ViewTSMI,
            this.HelpAboutTSMI});
            resources.ApplyResources(this.MainMenu, "MainMenu");
            this.MainMenu.Name = "MainMenu";
            // 
            // FileTSMI
            // 
            this.FileTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenLibTSMI,
            this.CreateLibTSMI,
            this.ClearLibTSMI,
            this.toolStripSeparator1,
            this.CloseAppTSMI});
            this.FileTSMI.Name = "FileTSMI";
            resources.ApplyResources(this.FileTSMI, "FileTSMI");
            // 
            // OpenLibTSMI
            // 
            this.OpenLibTSMI.Name = "OpenLibTSMI";
            resources.ApplyResources(this.OpenLibTSMI, "OpenLibTSMI");
            this.OpenLibTSMI.Click += new System.EventHandler(this.OpenLibTSMI_Click);
            // 
            // CreateLibTSMI
            // 
            resources.ApplyResources(this.CreateLibTSMI, "CreateLibTSMI");
            this.CreateLibTSMI.Name = "CreateLibTSMI";
            this.CreateLibTSMI.Click += new System.EventHandler(this.CreateLibTSMI_Click);
            // 
            // ClearLibTSMI
            // 
            this.ClearLibTSMI.Name = "ClearLibTSMI";
            resources.ApplyResources(this.ClearLibTSMI, "ClearLibTSMI");
            this.ClearLibTSMI.Click += new System.EventHandler(this.ClearLibTSMI_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // CloseAppTSMI
            // 
            this.CloseAppTSMI.Name = "CloseAppTSMI";
            resources.ApplyResources(this.CloseAppTSMI, "CloseAppTSMI");
            this.CloseAppTSMI.Click += new System.EventHandler(this.CloseAppTSMI_Click);
            // 
            // EditTSMI
            // 
            this.EditTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddElementTSMI,
            this.EditElementTSMI,
            this.DeleteElementTSMI,
            this.toolStripSeparator2,
            this.FindElementTSMI});
            this.EditTSMI.Name = "EditTSMI";
            resources.ApplyResources(this.EditTSMI, "EditTSMI");
            // 
            // AddElementTSMI
            // 
            this.AddElementTSMI.Name = "AddElementTSMI";
            resources.ApplyResources(this.AddElementTSMI, "AddElementTSMI");
            this.AddElementTSMI.Click += new System.EventHandler(this.AddElementTSMI_Click);
            // 
            // EditElementTSMI
            // 
            this.EditElementTSMI.Name = "EditElementTSMI";
            resources.ApplyResources(this.EditElementTSMI, "EditElementTSMI");
            this.EditElementTSMI.Click += new System.EventHandler(this.EditElementTSMI_Click);
            // 
            // DeleteElementTSMI
            // 
            this.DeleteElementTSMI.Name = "DeleteElementTSMI";
            resources.ApplyResources(this.DeleteElementTSMI, "DeleteElementTSMI");
            this.DeleteElementTSMI.Click += new System.EventHandler(this.DeleteElementTSMI_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // FindElementTSMI
            // 
            this.FindElementTSMI.Name = "FindElementTSMI";
            resources.ApplyResources(this.FindElementTSMI, "FindElementTSMI");
            this.FindElementTSMI.Click += new System.EventHandler(this.FindElementTSMI_Click);
            // 
            // ViewTSMI
            // 
            this.ViewTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AutoSortingTSMI,
            this.FullScreenTSMI,
            this.toolStripSeparator3,
            this.PreferencesTSMI});
            this.ViewTSMI.Name = "ViewTSMI";
            resources.ApplyResources(this.ViewTSMI, "ViewTSMI");
            // 
            // AutoSortingTSMI
            // 
            this.AutoSortingTSMI.CheckOnClick = true;
            this.AutoSortingTSMI.Name = "AutoSortingTSMI";
            resources.ApplyResources(this.AutoSortingTSMI, "AutoSortingTSMI");
            this.AutoSortingTSMI.Click += new System.EventHandler(this.AutoSortingTSMI_Click);
            // 
            // FullScreenTSMI
            // 
            this.FullScreenTSMI.CheckOnClick = true;
            this.FullScreenTSMI.Name = "FullScreenTSMI";
            resources.ApplyResources(this.FullScreenTSMI, "FullScreenTSMI");
            this.FullScreenTSMI.Click += new System.EventHandler(this.FullScreenTSMI_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // PreferencesTSMI
            // 
            this.PreferencesTSMI.Name = "PreferencesTSMI";
            resources.ApplyResources(this.PreferencesTSMI, "PreferencesTSMI");
            this.PreferencesTSMI.Click += new System.EventHandler(this.PreferencesTSMI_Click);
            // 
            // HelpAboutTSMI
            // 
            this.HelpAboutTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpTSMI,
            this.AboutTSMI});
            this.HelpAboutTSMI.Name = "HelpAboutTSMI";
            resources.ApplyResources(this.HelpAboutTSMI, "HelpAboutTSMI");
            // 
            // HelpTSMI
            // 
            this.HelpTSMI.Name = "HelpTSMI";
            resources.ApplyResources(this.HelpTSMI, "HelpTSMI");
            this.HelpTSMI.Click += new System.EventHandler(this.HelpTSMI_Click);
            // 
            // AboutTSMI
            // 
            this.AboutTSMI.Name = "AboutTSMI";
            resources.ApplyResources(this.AboutTSMI, "AboutTSMI");
            this.AboutTSMI.Click += new System.EventHandler(this.AboutTSMI_Click);
            // 
            // HintLabel
            // 
            this.HintLabel.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.HintLabel, "HintLabel");
            this.HintLabel.Name = "HintLabel";
            // 
            // SelectCollectionButton
            // 
            resources.ApplyResources(this.SelectCollectionButton, "SelectCollectionButton");
            this.SelectCollectionButton.Name = "SelectCollectionButton";
            this.SelectCollectionButton.Tag = "Выберите библиотеку для просмотра и редактирования. В случае отсутствия библиотек" +
    " в списке Вам придется создать новую библиотеку. При открытии другой библиотеки " +
    "текущая будет сохранена автоматически";
            this.SelectCollectionButton.UseVisualStyleBackColor = true;
            this.SelectCollectionButton.Click += new System.EventHandler(this.SelectCollectionButton_Click);
            // 
            // SelectedLibLabel
            // 
            this.SelectedLibLabel.AutoEllipsis = true;
            this.SelectedLibLabel.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.SelectedLibLabel, "SelectedLibLabel");
            this.SelectedLibLabel.ForeColor = System.Drawing.Color.Blue;
            this.SelectedLibLabel.Name = "SelectedLibLabel";
            this.SelectedLibLabel.Tag = "";
            this.SelectedLibLabel.UseCompatibleTextRendering = true;
            // 
            // LibInfoGB
            // 
            resources.ApplyResources(this.LibInfoGB, "LibInfoGB");
            this.LibInfoGB.BackColor = System.Drawing.Color.Transparent;
            this.LibInfoGB.Controls.Add(this.ElementCount);
            this.LibInfoGB.Controls.Add(this.ElementCountHintLabel);
            this.LibInfoGB.Controls.Add(this.HintLabel);
            this.LibInfoGB.Controls.Add(this.SelectCollectionButton);
            this.LibInfoGB.Controls.Add(this.SelectedLibLabel);
            this.LibInfoGB.Name = "LibInfoGB";
            this.LibInfoGB.TabStop = false;
            // 
            // ElementCount
            // 
            this.ElementCount.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.ElementCount, "ElementCount");
            this.ElementCount.Name = "ElementCount";
            // 
            // ElementCountHintLabel
            // 
            this.ElementCountHintLabel.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.ElementCountHintLabel, "ElementCountHintLabel");
            this.ElementCountHintLabel.Name = "ElementCountHintLabel";
            // 
            // label6
            // 
            this.label6.AutoEllipsis = true;
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // ElementActionsGB
            // 
            resources.ApplyResources(this.ElementActionsGB, "ElementActionsGB");
            this.ElementActionsGB.BackColor = System.Drawing.Color.Transparent;
            this.ElementActionsGB.Controls.Add(this.EditElementButton);
            this.ElementActionsGB.Controls.Add(this.SearchButton);
            this.ElementActionsGB.Controls.Add(this.AddElementButton);
            this.ElementActionsGB.Controls.Add(this.DeleteElementButton);
            this.ElementActionsGB.Name = "ElementActionsGB";
            this.ElementActionsGB.TabStop = false;
            // 
            // EditElementButton
            // 
            resources.ApplyResources(this.EditElementButton, "EditElementButton");
            this.EditElementButton.Name = "EditElementButton";
            this.EditElementButton.UseVisualStyleBackColor = true;
            this.EditElementButton.Click += new System.EventHandler(this.Edit_Click);
            // 
            // SearchButton
            // 
            resources.ApplyResources(this.SearchButton, "SearchButton");
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // AddElementButton
            // 
            resources.ApplyResources(this.AddElementButton, "AddElementButton");
            this.AddElementButton.Name = "AddElementButton";
            this.AddElementButton.UseVisualStyleBackColor = true;
            this.AddElementButton.Click += new System.EventHandler(this.AddElementButton_Click);
            // 
            // DeleteElementButton
            // 
            resources.ApplyResources(this.DeleteElementButton, "DeleteElementButton");
            this.DeleteElementButton.Name = "DeleteElementButton";
            this.DeleteElementButton.UseVisualStyleBackColor = true;
            this.DeleteElementButton.Click += new System.EventHandler(this.DeleteElementButton_Click);
            // 
            // ElementInfoGB
            // 
            resources.ApplyResources(this.ElementInfoGB, "ElementInfoGB");
            this.ElementInfoGB.BackColor = System.Drawing.Color.Transparent;
            this.ElementInfoGB.Controls.Add(this.TitleLabel);
            this.ElementInfoGB.Controls.Add(this.TitleHeaderLabel);
            this.ElementInfoGB.Controls.Add(this.PosterBox);
            this.ElementInfoGB.Controls.Add(this.InfoPanel);
            this.ElementInfoGB.Name = "ElementInfoGB";
            this.ElementInfoGB.TabStop = false;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoEllipsis = true;
            resources.ApplyResources(this.TitleLabel, "TitleLabel");
            this.TitleLabel.ForeColor = System.Drawing.Color.Blue;
            this.TitleLabel.Name = "TitleLabel";
            // 
            // TitleHeaderLabel
            // 
            resources.ApplyResources(this.TitleHeaderLabel, "TitleHeaderLabel");
            this.TitleHeaderLabel.Name = "TitleHeaderLabel";
            // 
            // PosterBox
            // 
            resources.ApplyResources(this.PosterBox, "PosterBox");
            this.PosterBox.Name = "PosterBox";
            this.PosterBox.TabStop = false;
            this.PosterBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PosterBox_MouseClick);
            // 
            // InfoPanel
            // 
            resources.ApplyResources(this.InfoPanel, "InfoPanel");
            this.InfoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InfoPanel.Controls.Add(this.label7);
            this.InfoPanel.Controls.Add(this.label6);
            this.InfoPanel.Name = "InfoPanel";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.ElementInfoGB);
            this.Controls.Add(this.ElementActionsGB);
            this.Controls.Add(this.LibInfoGB);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.Collection);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.LibInfoGB.ResumeLayout(false);
            this.ElementActionsGB.ResumeLayout(false);
            this.ElementInfoGB.ResumeLayout(false);
            this.ElementInfoGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PosterBox)).EndInit();
            this.InfoPanel.ResumeLayout(false);
            this.InfoPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem FileTSMI;
        private System.Windows.Forms.ToolStripMenuItem EditTSMI;
        private System.Windows.Forms.ToolStripMenuItem ViewTSMI;
        private System.Windows.Forms.ToolStripMenuItem HelpAboutTSMI;
        private System.Windows.Forms.Label HintLabel;
        private System.Windows.Forms.Button SelectCollectionButton;
        private System.Windows.Forms.GroupBox LibInfoGB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox ElementInfoGB;
        private System.Windows.Forms.Button DeleteElementButton;
        private System.Windows.Forms.Button EditElementButton;
        private System.Windows.Forms.Button AddElementButton;
        private System.Windows.Forms.PictureBox PosterBox;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Panel InfoPanel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem OpenLibTSMI;
        private System.Windows.Forms.ToolStripMenuItem CreateLibTSMI;
        private System.Windows.Forms.ToolStripMenuItem AddElementTSMI;
        private System.Windows.Forms.ToolStripMenuItem EditElementTSMI;
        private System.Windows.Forms.ToolStripMenuItem ClearLibTSMI;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem CloseAppTSMI;
        private System.Windows.Forms.ToolStripMenuItem DeleteElementTSMI;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem FindElementTSMI;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem PreferencesTSMI;
        private System.Windows.Forms.ToolStripMenuItem HelpTSMI;
        private System.Windows.Forms.ToolStripMenuItem AboutTSMI;
        public System.Windows.Forms.Label SelectedLibLabel;
        public System.Windows.Forms.ListView Collection;
        public System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        public System.Windows.Forms.GroupBox ElementActionsGB;
        public System.Windows.Forms.ToolStripMenuItem AutoSortingTSMI;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label TitleHeaderLabel;
        private System.Windows.Forms.ToolStripMenuItem FullScreenTSMI;
        private System.Windows.Forms.Label ElementCount;
        private System.Windows.Forms.Label ElementCountHintLabel;
    }
}

