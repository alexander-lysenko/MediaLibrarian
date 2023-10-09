namespace MediaLibrarian_
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Collection = new System.Windows.Forms.ListView();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CopyNameTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.EditItemTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteItemTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.informationLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.FileTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenLibTSMI = new System.Windows.Forms.ToolStripMenuItem();
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
            this.CurrentLibHintLabel = new System.Windows.Forms.Label();
            this.SelectCollectionButton = new System.Windows.Forms.Button();
            this.SelectedLibLabel = new System.Windows.Forms.Label();
            this.LibInfoGB = new System.Windows.Forms.GroupBox();
            this.ElementCount = new System.Windows.Forms.Label();
            this.ElementCountHintLabel = new System.Windows.Forms.Label();
            this.infoHintLabel = new System.Windows.Forms.Label();
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.paginationToolStrip = new System.Windows.Forms.ToolStrip();
            this.pagerEndBtn = new System.Windows.Forms.ToolStripButton();
            this.pagerUpBtn = new System.Windows.Forms.ToolStripButton();
            this.pagerCountLabel = new System.Windows.Forms.ToolStripLabel();
            this.pagerCurrentTb = new System.Windows.Forms.ToolStripTextBox();
            this.pagerDownBtn = new System.Windows.Forms.ToolStripButton();
            this.pagerBeginBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenu.SuspendLayout();
            this.StatusBar.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.LibInfoGB.SuspendLayout();
            this.ElementActionsGB.SuspendLayout();
            this.ElementInfoGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PosterBox)).BeginInit();
            this.InfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.paginationToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // Collection
            // 
            resources.ApplyResources(this.Collection, "Collection");
            this.Collection.BackColor = System.Drawing.Color.White;
            this.Collection.ContextMenuStrip = this.contextMenu;
            this.Collection.FullRowSelect = true;
            this.Collection.GridLines = true;
            this.Collection.Name = "Collection";
            this.Collection.ShowGroups = false;
            this.Collection.UseCompatibleStateImageBehavior = false;
            this.Collection.View = System.Windows.Forms.View.Details;
            this.Collection.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.Collection_ColumnClick);
            this.Collection.ItemActivate += new System.EventHandler(this.Collection_ItemActivate);
            this.Collection.SelectedIndexChanged += new System.EventHandler(this.Collection_SelectedIndexChanged);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyNameTSMI,
            this.EditItemTSMI,
            this.DeleteItemTSMI});
            this.contextMenu.Name = "contextMenu";
            resources.ApplyResources(this.contextMenu, "contextMenu");
            this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuBlockOpening);
            // 
            // CopyNameTSMI
            // 
            this.CopyNameTSMI.Name = "CopyNameTSMI";
            resources.ApplyResources(this.CopyNameTSMI, "CopyNameTSMI");
            this.CopyNameTSMI.Click += new System.EventHandler(this.copyNameTSMI_Click);
            // 
            // EditItemTSMI
            // 
            this.EditItemTSMI.Name = "EditItemTSMI";
            resources.ApplyResources(this.EditItemTSMI, "EditItemTSMI");
            this.EditItemTSMI.Click += new System.EventHandler(this.EditItemTSMI_Click);
            // 
            // DeleteItemTSMI
            // 
            this.DeleteItemTSMI.Name = "DeleteItemTSMI";
            resources.ApplyResources(this.DeleteItemTSMI, "DeleteItemTSMI");
            this.DeleteItemTSMI.Click += new System.EventHandler(this.DeleteItemTSMI_Click);
            // 
            // StatusBar
            // 
            this.StatusBar.BackColor = System.Drawing.Color.Transparent;
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel,
            this.informationLabel});
            resources.ApplyResources(this.StatusBar, "StatusBar");
            this.StatusBar.Name = "StatusBar";
            // 
            // StatusLabel
            // 
            this.StatusLabel.BackColor = System.Drawing.SystemColors.Control;
            this.StatusLabel.Name = "StatusLabel";
            resources.ApplyResources(this.StatusLabel, "StatusLabel");
            // 
            // informationLabel
            // 
            this.informationLabel.Name = "informationLabel";
            resources.ApplyResources(this.informationLabel, "informationLabel");
            this.informationLabel.Spring = true;
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
            // ClearLibTSMI
            // 
            resources.ApplyResources(this.ClearLibTSMI, "ClearLibTSMI");
            this.ClearLibTSMI.Name = "ClearLibTSMI";
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
            // CurrentLibHintLabel
            // 
            this.CurrentLibHintLabel.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.CurrentLibHintLabel, "CurrentLibHintLabel");
            this.CurrentLibHintLabel.Name = "CurrentLibHintLabel";
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
            this.LibInfoGB.Controls.Add(this.CurrentLibHintLabel);
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
            // infoHintLabel
            // 
            this.infoHintLabel.AutoEllipsis = true;
            resources.ApplyResources(this.infoHintLabel, "infoHintLabel");
            this.infoHintLabel.Name = "infoHintLabel";
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
            this.TitleHeaderLabel.AutoEllipsis = true;
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
            this.InfoPanel.Controls.Add(this.infoHintLabel);
            this.InfoPanel.Name = "InfoPanel";
            this.InfoPanel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.InfoPanel_Scroll);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // paginationToolStrip
            // 
            this.paginationToolStrip.AllowItemReorder = true;
            this.paginationToolStrip.AllowMerge = false;
            resources.ApplyResources(this.paginationToolStrip, "paginationToolStrip");
            this.paginationToolStrip.BackColor = System.Drawing.Color.Transparent;
            this.paginationToolStrip.CanOverflow = false;
            this.paginationToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pagerBeginBtn,
            this.pagerDownBtn,
            this.toolStripSeparator5,
            this.pagerCurrentTb,
            this.pagerCountLabel,
            this.toolStripSeparator4,
            this.pagerUpBtn,
            this.pagerEndBtn});
            this.paginationToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.paginationToolStrip.Name = "paginationToolStrip";
            // 
            // pagerEndBtn
            // 
            this.pagerEndBtn.BackColor = System.Drawing.SystemColors.Control;
            this.pagerEndBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.pagerEndBtn, "pagerEndBtn");
            this.pagerEndBtn.Margin = new System.Windows.Forms.Padding(1);
            this.pagerEndBtn.Name = "pagerEndBtn";
            this.pagerEndBtn.Click += new System.EventHandler(this.pagerEndBtn_Click);
            // 
            // pagerUpBtn
            // 
            this.pagerUpBtn.BackColor = System.Drawing.SystemColors.Control;
            this.pagerUpBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.pagerUpBtn, "pagerUpBtn");
            this.pagerUpBtn.Margin = new System.Windows.Forms.Padding(1);
            this.pagerUpBtn.Name = "pagerUpBtn";
            this.pagerUpBtn.Click += new System.EventHandler(this.pagerUpBtn_Click);
            // 
            // pagerCountLabel
            // 
            this.pagerCountLabel.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.pagerCountLabel.Name = "pagerCountLabel";
            resources.ApplyResources(this.pagerCountLabel, "pagerCountLabel");
            // 
            // pagerCurrentTb
            // 
            resources.ApplyResources(this.pagerCurrentTb, "pagerCurrentTb");
            this.pagerCurrentTb.Margin = new System.Windows.Forms.Padding(1);
            this.pagerCurrentTb.Name = "pagerCurrentTb";
            this.pagerCurrentTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pagerCurrentTb_KeyPress);
            this.pagerCurrentTb.TextChanged += new System.EventHandler(this.pagerCurrentTb_TextChanged);
            // 
            // pagerDownBtn
            // 
            this.pagerDownBtn.BackColor = System.Drawing.SystemColors.Control;
            this.pagerDownBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.pagerDownBtn, "pagerDownBtn");
            this.pagerDownBtn.Margin = new System.Windows.Forms.Padding(1);
            this.pagerDownBtn.Name = "pagerDownBtn";
            this.pagerDownBtn.Click += new System.EventHandler(this.pagerDownBtn_Click);
            // 
            // pagerBeginBtn
            // 
            this.pagerBeginBtn.BackColor = System.Drawing.SystemColors.Control;
            this.pagerBeginBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.pagerBeginBtn, "pagerBeginBtn");
            this.pagerBeginBtn.Margin = new System.Windows.Forms.Padding(1);
            this.pagerBeginBtn.Name = "pagerBeginBtn";
            this.pagerBeginBtn.Click += new System.EventHandler(this.pagerBeginBtn_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.Controls.Add(this.paginationToolStrip);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ElementInfoGB);
            this.Controls.Add(this.ElementActionsGB);
            this.Controls.Add(this.LibInfoGB);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.Collection);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.contextMenu.ResumeLayout(false);
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.LibInfoGB.ResumeLayout(false);
            this.ElementActionsGB.ResumeLayout(false);
            this.ElementInfoGB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PosterBox)).EndInit();
            this.InfoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.paginationToolStrip.ResumeLayout(false);
            this.paginationToolStrip.PerformLayout();
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
        private System.Windows.Forms.Label CurrentLibHintLabel;
        private System.Windows.Forms.Button SelectCollectionButton;
        private System.Windows.Forms.GroupBox LibInfoGB;
        private System.Windows.Forms.Label infoHintLabel;
        private System.Windows.Forms.GroupBox ElementInfoGB;
        private System.Windows.Forms.Button DeleteElementButton;
        private System.Windows.Forms.Button EditElementButton;
        private System.Windows.Forms.Button AddElementButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.ToolStripMenuItem OpenLibTSMI;
        private System.Windows.Forms.ToolStripMenuItem AddElementTSMI;
        private System.Windows.Forms.ToolStripMenuItem EditElementTSMI;
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
        private System.Windows.Forms.ToolStripMenuItem FullScreenTSMI;
        private System.Windows.Forms.Label ElementCountHintLabel;
        private System.Windows.Forms.ToolStripStatusLabel informationLabel;
        public System.Windows.Forms.PictureBox PosterBox;
        public System.Windows.Forms.Panel InfoPanel;
        public System.Windows.Forms.Label TitleLabel;
        public System.Windows.Forms.Label TitleHeaderLabel;
        public System.Windows.Forms.Label ElementCount;
        public System.Windows.Forms.ToolStripMenuItem ClearLibTSMI;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem CopyNameTSMI;
        private System.Windows.Forms.ToolStripMenuItem EditItemTSMI;
        private System.Windows.Forms.ToolStripMenuItem DeleteItemTSMI;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ToolStripButton pagerBeginBtn;
        private System.Windows.Forms.ToolStripButton pagerDownBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton pagerEndBtn;
        private System.Windows.Forms.ToolStripButton pagerUpBtn;
        public System.Windows.Forms.ToolStrip paginationToolStrip;
        public System.Windows.Forms.ToolStripLabel pagerCountLabel;
        public System.Windows.Forms.ToolStripTextBox pagerCurrentTb;
    }
}

