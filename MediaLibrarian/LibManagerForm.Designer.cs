namespace MediaLibrarian
{
    partial class LibManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LibManagerForm));
            this.LibsList = new System.Windows.Forms.ListView();
            this.CollectionName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CollectionFields = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LibsListHintLabel = new System.Windows.Forms.Label();
            this.CreateNewLibraryButton = new System.Windows.Forms.Button();
            this.RemoveLibraryButton = new System.Windows.Forms.Button();
            this.CollectionEditGB = new System.Windows.Forms.GroupBox();
            this.AddFieldsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SaveLibraryButton = new System.Windows.Forms.Button();
            this.AddMoreFieldsButton = new System.Windows.Forms.Button();
            this.CollectionEditGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // LibsList
            // 
            this.LibsList.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            resources.ApplyResources(this.LibsList, "LibsList");
            this.LibsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CollectionName,
            this.CollectionFields});
            this.LibsList.FullRowSelect = true;
            this.LibsList.GridLines = true;
            this.LibsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.LibsList.HideSelection = false;
            this.LibsList.MultiSelect = false;
            this.LibsList.Name = "LibsList";
            this.LibsList.ShowGroups = false;
            this.LibsList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.LibsList.UseCompatibleStateImageBehavior = false;
            this.LibsList.View = System.Windows.Forms.View.Details;
            this.LibsList.ItemActivate += new System.EventHandler(this.LibsList_ItemActivate);
            // 
            // CollectionName
            // 
            resources.ApplyResources(this.CollectionName, "CollectionName");
            // 
            // CollectionFields
            // 
            resources.ApplyResources(this.CollectionFields, "CollectionFields");
            // 
            // LibsListHintLabel
            // 
            resources.ApplyResources(this.LibsListHintLabel, "LibsListHintLabel");
            this.LibsListHintLabel.BackColor = System.Drawing.Color.Transparent;
            this.LibsListHintLabel.Name = "LibsListHintLabel";
            // 
            // CreateNewLibraryButton
            // 
            resources.ApplyResources(this.CreateNewLibraryButton, "CreateNewLibraryButton");
            this.CreateNewLibraryButton.Name = "CreateNewLibraryButton";
            this.CreateNewLibraryButton.UseVisualStyleBackColor = true;
            this.CreateNewLibraryButton.Click += new System.EventHandler(this.CreateNewLibraryButton_Click);
            // 
            // RemoveLibraryButton
            // 
            resources.ApplyResources(this.RemoveLibraryButton, "RemoveLibraryButton");
            this.RemoveLibraryButton.Name = "RemoveLibraryButton";
            this.RemoveLibraryButton.UseVisualStyleBackColor = true;
            this.RemoveLibraryButton.Click += new System.EventHandler(this.RemoveCollectionButton_Click);
            // 
            // CollectionEditGB
            // 
            resources.ApplyResources(this.CollectionEditGB, "CollectionEditGB");
            this.CollectionEditGB.BackColor = System.Drawing.Color.Transparent;
            this.CollectionEditGB.Controls.Add(this.AddFieldsPanel);
            this.CollectionEditGB.Controls.Add(this.SaveLibraryButton);
            this.CollectionEditGB.Controls.Add(this.AddMoreFieldsButton);
            this.CollectionEditGB.Name = "CollectionEditGB";
            this.CollectionEditGB.TabStop = false;
            // 
            // AddFieldsPanel
            // 
            resources.ApplyResources(this.AddFieldsPanel, "AddFieldsPanel");
            this.AddFieldsPanel.Name = "AddFieldsPanel";
            // 
            // SaveLibraryButton
            // 
            resources.ApplyResources(this.SaveLibraryButton, "SaveLibraryButton");
            this.SaveLibraryButton.Name = "SaveLibraryButton";
            this.SaveLibraryButton.UseVisualStyleBackColor = true;
            this.SaveLibraryButton.Click += new System.EventHandler(this.SaveLibraryButton_Click);
            // 
            // AddMoreFieldsButton
            // 
            resources.ApplyResources(this.AddMoreFieldsButton, "AddMoreFieldsButton");
            this.AddMoreFieldsButton.Name = "AddMoreFieldsButton";
            this.AddMoreFieldsButton.UseVisualStyleBackColor = true;
            this.AddMoreFieldsButton.Click += new System.EventHandler(this.AddMoreFieldsButton_Click);
            // 
            // LibManagerForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CollectionEditGB);
            this.Controls.Add(this.RemoveLibraryButton);
            this.Controls.Add(this.CreateNewLibraryButton);
            this.Controls.Add(this.LibsListHintLabel);
            this.Controls.Add(this.LibsList);
            this.KeyPreview = true;
            this.Name = "LibManagerForm";
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LibManagerForm_FormClosing);
            this.Load += new System.EventHandler(this.LibManagerForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LibManagerForm_KeyDown);
            this.CollectionEditGB.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader CollectionName;
        private System.Windows.Forms.ColumnHeader CollectionFields;
        private System.Windows.Forms.Label LibsListHintLabel;
        private System.Windows.Forms.Button RemoveLibraryButton;
        private System.Windows.Forms.GroupBox CollectionEditGB;
        private System.Windows.Forms.Button AddMoreFieldsButton;
        private System.Windows.Forms.Button SaveLibraryButton;
        public System.Windows.Forms.ListView LibsList;
        private System.Windows.Forms.FlowLayoutPanel AddFieldsPanel;
        public System.Windows.Forms.Button CreateNewLibraryButton;
    }
}