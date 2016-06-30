namespace MediaLibrarian
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
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
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
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ElementActionsGB = new System.Windows.Forms.GroupBox();
            this.EditElementButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.AddElementButton = new System.Windows.Forms.Button();
            this.DeleteElementButton = new System.Windows.Forms.Button();
            this.ElementInfoGB = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.PosterBox = new System.Windows.Forms.PictureBox();
            this.StatusBar.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.LibInfoGB.SuspendLayout();
            this.ElementActionsGB.SuspendLayout();
            this.ElementInfoGB.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PosterBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Collection
            // 
            resources.ApplyResources(this.Collection, "Collection");
            this.Collection.GridLines = true;
            this.Collection.Name = "Collection";
            this.Collection.ShowGroups = false;
            this.Collection.UseCompatibleStateImageBehavior = false;
            this.Collection.View = System.Windows.Forms.View.Details;
            // 
            // StatusBar
            // 
            this.StatusBar.BackColor = System.Drawing.Color.Transparent;
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            resources.ApplyResources(this.StatusBar, "StatusBar");
            this.StatusBar.Name = "StatusBar";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
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
            // 
            // CreateLibTSMI
            // 
            this.CreateLibTSMI.Name = "CreateLibTSMI";
            resources.ApplyResources(this.CreateLibTSMI, "CreateLibTSMI");
            // 
            // ClearLibTSMI
            // 
            this.ClearLibTSMI.Name = "ClearLibTSMI";
            resources.ApplyResources(this.ClearLibTSMI, "ClearLibTSMI");
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
            // 
            // ViewTSMI
            // 
            this.ViewTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AutoSortingTSMI,
            this.toolStripSeparator3,
            this.PreferencesTSMI});
            this.ViewTSMI.Name = "ViewTSMI";
            resources.ApplyResources(this.ViewTSMI, "ViewTSMI");
            // 
            // AutoSortingTSMI
            // 
            this.AutoSortingTSMI.Name = "AutoSortingTSMI";
            resources.ApplyResources(this.AutoSortingTSMI, "AutoSortingTSMI");
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
            // 
            // AboutTSMI
            // 
            this.AboutTSMI.Name = "AboutTSMI";
            resources.ApplyResources(this.AboutTSMI, "AboutTSMI");
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
            this.LibInfoGB.BackColor = System.Drawing.Color.Transparent;
            this.LibInfoGB.Controls.Add(this.ElementCount);
            this.LibInfoGB.Controls.Add(this.ElementCountHintLabel);
            this.LibInfoGB.Controls.Add(this.HintLabel);
            this.LibInfoGB.Controls.Add(this.SelectCollectionButton);
            this.LibInfoGB.Controls.Add(this.SelectedLibLabel);
            resources.ApplyResources(this.LibInfoGB, "LibInfoGB");
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
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            this.label6.AutoEllipsis = true;
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // ElementActionsGB
            // 
            this.ElementActionsGB.BackColor = System.Drawing.Color.Transparent;
            this.ElementActionsGB.Controls.Add(this.EditElementButton);
            this.ElementActionsGB.Controls.Add(this.SearchButton);
            this.ElementActionsGB.Controls.Add(this.AddElementButton);
            this.ElementActionsGB.Controls.Add(this.DeleteElementButton);
            resources.ApplyResources(this.ElementActionsGB, "ElementActionsGB");
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
            // 
            // ElementInfoGB
            // 
            resources.ApplyResources(this.ElementInfoGB, "ElementInfoGB");
            this.ElementInfoGB.BackColor = System.Drawing.Color.Transparent;
            this.ElementInfoGB.Controls.Add(this.panel1);
            this.ElementInfoGB.Name = "ElementInfoGB";
            this.ElementInfoGB.TabStop = false;
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.PosterBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Name = "panel1";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // PosterBox
            // 
            this.PosterBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.PosterBox, "PosterBox");
            this.PosterBox.Name = "PosterBox";
            this.PosterBox.TabStop = false;
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PosterBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem FileTSMI;
        private System.Windows.Forms.ToolStripMenuItem EditTSMI;
        private System.Windows.Forms.ToolStripMenuItem ViewTSMI;
        private System.Windows.Forms.ToolStripMenuItem HelpAboutTSMI;
        private System.Windows.Forms.Label HintLabel;
        private System.Windows.Forms.Button SelectCollectionButton;
        private System.Windows.Forms.GroupBox LibInfoGB;
        private System.Windows.Forms.Label ElementCount;
        private System.Windows.Forms.Label ElementCountHintLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox ElementActionsGB;
        private System.Windows.Forms.GroupBox ElementInfoGB;
        private System.Windows.Forms.Button DeleteElementButton;
        private System.Windows.Forms.Button EditElementButton;
        private System.Windows.Forms.Button AddElementButton;
        private System.Windows.Forms.PictureBox PosterBox;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Panel panel1;
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
        private System.Windows.Forms.ToolStripMenuItem AutoSortingTSMI;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem PreferencesTSMI;
        private System.Windows.Forms.ToolStripMenuItem HelpTSMI;
        private System.Windows.Forms.ToolStripMenuItem AboutTSMI;
        public System.Windows.Forms.Label SelectedLibLabel;
        public System.Windows.Forms.ListView Collection;
    }
}

