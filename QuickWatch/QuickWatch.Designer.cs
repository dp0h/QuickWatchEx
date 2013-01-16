namespace QuickWatchEx.QuickWatch {
    partial class QuickWatch {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this._labelExpression = new System.Windows.Forms.Label();
            this._comboBoxExpression = new System.Windows.Forms.ComboBox();
            this._buttonReevaluate = new System.Windows.Forms.Button();
            this._labelValue = new System.Windows.Forms.Label();
            this._treeView = new Aga.Controls.Tree.TreeViewAdv();
            this._treeColumn1 = new Aga.Controls.Tree.TreeColumn();
            this._treeColumn2 = new Aga.Controls.Tree.TreeColumn();
            this._treeColumn3 = new Aga.Controls.Tree.TreeColumn();
            this._contextMenuStripForTreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._expandAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._collapseAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._icon = new Aga.Controls.Tree.NodeControls.NodeStateIcon();
            this._name = new Aga.Controls.Tree.NodeControls.NodeTextBox();
            this._value = new Aga.Controls.Tree.NodeControls.NodeTextBox();
            this._type = new Aga.Controls.Tree.NodeControls.NodeTextBox();
            this._labelSearch = new System.Windows.Forms.Label();
            this._comboBoxSearch = new System.Windows.Forms.ComboBox();
            this._checkBoxMatchCase = new System.Windows.Forms.CheckBox();
            this._checkBoxMatchWholeWord = new System.Windows.Forms.CheckBox();
            this._checkBoxUseRegularExpression = new System.Windows.Forms.CheckBox();
            this._labelSearchIn = new System.Windows.Forms.Label();
            this._comboBoxSearchIn = new System.Windows.Forms.ComboBox();
            this._labelSearchLevel = new System.Windows.Forms.Label();
            this._domainUpDownSearchLevel = new System.Windows.Forms.DomainUpDown();
            this._buttonClose = new System.Windows.Forms.Button();
            this._saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this._searchStoreTimer = new System.Windows.Forms.Timer(this.components);
            this._contextMenuStripForTreeView.SuspendLayout();
            this.SuspendLayout();
            // 
            // _labelExpression
            // 
            this._labelExpression.AutoSize = true;
            this._labelExpression.Location = new System.Drawing.Point(12, 9);
            this._labelExpression.Name = "_labelExpression";
            this._labelExpression.Size = new System.Drawing.Size(61, 13);
            this._labelExpression.TabIndex = 0;
            this._labelExpression.Text = "&Expression:";
            // 
            // _comboBoxExpression
            // 
            this._comboBoxExpression.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._comboBoxExpression.FormattingEnabled = true;
            this._comboBoxExpression.Location = new System.Drawing.Point(15, 25);
            this._comboBoxExpression.Name = "_comboBoxExpression";
            this._comboBoxExpression.Size = new System.Drawing.Size(843, 21);
            this._comboBoxExpression.TabIndex = 1;
            // 
            // _buttonReevaluate
            // 
            this._buttonReevaluate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonReevaluate.Location = new System.Drawing.Point(877, 23);
            this._buttonReevaluate.Name = "_buttonReevaluate";
            this._buttonReevaluate.Size = new System.Drawing.Size(119, 23);
            this._buttonReevaluate.TabIndex = 2;
            this._buttonReevaluate.Text = "&Reevaluate";
            this._buttonReevaluate.UseVisualStyleBackColor = true;
            this._buttonReevaluate.Click += new System.EventHandler(this._buttonReevaluate_Click);
            // 
            // _labelValue
            // 
            this._labelValue.AutoSize = true;
            this._labelValue.Location = new System.Drawing.Point(12, 53);
            this._labelValue.Name = "_labelValue";
            this._labelValue.Size = new System.Drawing.Size(37, 13);
            this._labelValue.TabIndex = 4;
            this._labelValue.Text = "Value:";
            // 
            // _treeView
            // 
            this._treeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._treeView.AutoRowHeight = true;
            this._treeView.BackColor = System.Drawing.SystemColors.Window;
            this._treeView.Columns.Add(this._treeColumn1);
            this._treeView.Columns.Add(this._treeColumn2);
            this._treeView.Columns.Add(this._treeColumn3);
            this._treeView.ContextMenuStrip = this._contextMenuStripForTreeView;
            this._treeView.Cursor = System.Windows.Forms.Cursors.Default;
            this._treeView.DefaultToolTipProvider = null;
            this._treeView.DragDropMarkColor = System.Drawing.Color.Black;
            this._treeView.FullRowSelect = true;
            this._treeView.GridLineStyle = ((Aga.Controls.Tree.GridLineStyle)((Aga.Controls.Tree.GridLineStyle.Horizontal | Aga.Controls.Tree.GridLineStyle.Vertical)));
            this._treeView.LineColor = System.Drawing.SystemColors.ControlDark;
            this._treeView.LoadOnDemand = true;
            this._treeView.Location = new System.Drawing.Point(15, 69);
            this._treeView.Model = null;
            this._treeView.Name = "_treeView";
            this._treeView.NodeControls.Add(this._icon);
            this._treeView.NodeControls.Add(this._name);
            this._treeView.NodeControls.Add(this._value);
            this._treeView.NodeControls.Add(this._type);
            this._treeView.SelectedNode = null;
            this._treeView.ShowNodeToolTips = true;
            this._treeView.Size = new System.Drawing.Size(981, 418);
            this._treeView.TabIndex = 5;
            this._treeView.UseColumns = true;
            this._treeView.SelectionChanged += new System.EventHandler(this._treeView_SelectionChanged);
            // 
            // _treeColumn1
            // 
            this._treeColumn1.Header = "Name";
            this._treeColumn1.SortOrder = System.Windows.Forms.SortOrder.None;
            this._treeColumn1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._treeColumn1.TooltipText = "Name";
            this._treeColumn1.Width = 300;
            // 
            // _treeColumn2
            // 
            this._treeColumn2.Header = "Value";
            this._treeColumn2.SortOrder = System.Windows.Forms.SortOrder.None;
            this._treeColumn2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._treeColumn2.TooltipText = "Value";
            this._treeColumn2.Width = 400;
            // 
            // _treeColumn3
            // 
            this._treeColumn3.Header = "Type";
            this._treeColumn3.SortOrder = System.Windows.Forms.SortOrder.None;
            this._treeColumn3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._treeColumn3.TooltipText = "Type";
            this._treeColumn3.Width = 250;
            // 
            // _contextMenuStripForTreeView
            // 
            this._contextMenuStripForTreeView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._expandAllToolStripMenuItem,
            this._collapseAllToolStripMenuItem,
            this._saveToolStripMenuItem});
            this._contextMenuStripForTreeView.Name = "_contextMenuStripForTreeView";
            this._contextMenuStripForTreeView.Size = new System.Drawing.Size(137, 70);
            // 
            // _expandAllToolStripMenuItem
            // 
            this._expandAllToolStripMenuItem.Name = "_expandAllToolStripMenuItem";
            this._expandAllToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this._expandAllToolStripMenuItem.Text = "Expand All";
            this._expandAllToolStripMenuItem.Click += new System.EventHandler(this.expandAllToolStripMenuItem_Click);
            // 
            // _collapseAllToolStripMenuItem
            // 
            this._collapseAllToolStripMenuItem.Name = "_collapseAllToolStripMenuItem";
            this._collapseAllToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this._collapseAllToolStripMenuItem.Text = "Collapse All";
            this._collapseAllToolStripMenuItem.Click += new System.EventHandler(this.collapseAllToolStripMenuItem_Click);
            // 
            // _saveToolStripMenuItem
            // 
            this._saveToolStripMenuItem.Name = "_saveToolStripMenuItem";
            this._saveToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this._saveToolStripMenuItem.Text = "Save";
            this._saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // _icon
            // 
            this._icon.DataPropertyName = "Icon";
            this._icon.LeftMargin = 1;
            this._icon.ParentColumn = this._treeColumn1;
            this._icon.ScaleMode = Aga.Controls.Tree.ImageScaleMode.Clip;
            // 
            // _name
            // 
            this._name.DataPropertyName = "Name";
            this._name.IncrementalSearchEnabled = true;
            this._name.LeftMargin = 3;
            this._name.ParentColumn = this._treeColumn1;
            this._name.Trimming = System.Drawing.StringTrimming.EllipsisCharacter;
            this._name.UseCompatibleTextRendering = true;
            // 
            // _value
            // 
            this._value.DataPropertyName = "Value";
            this._value.EditEnabled = true;
            this._value.EditOnClick = true;
            this._value.IncrementalSearchEnabled = true;
            this._value.LeftMargin = 3;
            this._value.ParentColumn = this._treeColumn2;
            // 
            // _type
            // 
            this._type.DataPropertyName = "Type";
            this._type.IncrementalSearchEnabled = true;
            this._type.LeftMargin = 3;
            this._type.ParentColumn = this._treeColumn3;
            // 
            // _labelSearch
            // 
            this._labelSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._labelSearch.AutoSize = true;
            this._labelSearch.Location = new System.Drawing.Point(12, 490);
            this._labelSearch.Name = "_labelSearch";
            this._labelSearch.Size = new System.Drawing.Size(44, 13);
            this._labelSearch.TabIndex = 6;
            this._labelSearch.Text = "&Search:";
            // 
            // _comboBoxSearch
            // 
            this._comboBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._comboBoxSearch.FormattingEnabled = true;
            this._comboBoxSearch.Location = new System.Drawing.Point(15, 506);
            this._comboBoxSearch.Name = "_comboBoxSearch";
            this._comboBoxSearch.Size = new System.Drawing.Size(981, 21);
            this._comboBoxSearch.TabIndex = 7;
            this._comboBoxSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this._comboBoxSearch_KeyUp);
            // 
            // _checkBoxMatchCase
            // 
            this._checkBoxMatchCase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._checkBoxMatchCase.AutoSize = true;
            this._checkBoxMatchCase.Location = new System.Drawing.Point(15, 536);
            this._checkBoxMatchCase.Name = "_checkBoxMatchCase";
            this._checkBoxMatchCase.Size = new System.Drawing.Size(82, 17);
            this._checkBoxMatchCase.TabIndex = 8;
            this._checkBoxMatchCase.Text = "Match &case";
            this._checkBoxMatchCase.UseVisualStyleBackColor = true;
            this._checkBoxMatchCase.CheckedChanged += new System.EventHandler(this._checkBoxMatchCase_CheckedChanged);
            // 
            // _checkBoxMatchWholeWord
            // 
            this._checkBoxMatchWholeWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._checkBoxMatchWholeWord.AutoSize = true;
            this._checkBoxMatchWholeWord.Location = new System.Drawing.Point(103, 536);
            this._checkBoxMatchWholeWord.Name = "_checkBoxMatchWholeWord";
            this._checkBoxMatchWholeWord.Size = new System.Drawing.Size(113, 17);
            this._checkBoxMatchWholeWord.TabIndex = 9;
            this._checkBoxMatchWholeWord.Text = "Match whole &word";
            this._checkBoxMatchWholeWord.UseVisualStyleBackColor = true;
            this._checkBoxMatchWholeWord.CheckedChanged += new System.EventHandler(this._checkBoxMatchWholeWord_CheckedChanged);
            // 
            // _checkBoxUseRegularExpression
            // 
            this._checkBoxUseRegularExpression.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._checkBoxUseRegularExpression.AutoSize = true;
            this._checkBoxUseRegularExpression.Location = new System.Drawing.Point(222, 536);
            this._checkBoxUseRegularExpression.Name = "_checkBoxUseRegularExpression";
            this._checkBoxUseRegularExpression.Size = new System.Drawing.Size(138, 17);
            this._checkBoxUseRegularExpression.TabIndex = 10;
            this._checkBoxUseRegularExpression.Text = "Use regular e&xpressions";
            this._checkBoxUseRegularExpression.UseVisualStyleBackColor = true;
            this._checkBoxUseRegularExpression.CheckedChanged += new System.EventHandler(this._checkBoxUseRegularExpression_CheckedChanged);
            // 
            // _labelSearchIn
            // 
            this._labelSearchIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._labelSearchIn.AutoSize = true;
            this._labelSearchIn.Location = new System.Drawing.Point(546, 537);
            this._labelSearchIn.Name = "_labelSearchIn";
            this._labelSearchIn.Size = new System.Drawing.Size(55, 13);
            this._labelSearchIn.TabIndex = 12;
            this._labelSearchIn.Text = "Search &in:";
            // 
            // _comboBoxSearchIn
            // 
            this._comboBoxSearchIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._comboBoxSearchIn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxSearchIn.FormattingEnabled = true;
            this._comboBoxSearchIn.Items.AddRange(new object[] {
            "Name",
            "Values",
            "Everywhere"});
            this._comboBoxSearchIn.Location = new System.Drawing.Point(607, 534);
            this._comboBoxSearchIn.Name = "_comboBoxSearchIn";
            this._comboBoxSearchIn.Size = new System.Drawing.Size(92, 21);
            this._comboBoxSearchIn.TabIndex = 13;
            this._comboBoxSearchIn.SelectedIndexChanged += new System.EventHandler(this._comboBoxSearchIn_SelectedIndexChanged);
            // 
            // _labelSearchLevel
            // 
            this._labelSearchLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._labelSearchLevel.AutoSize = true;
            this._labelSearchLevel.Location = new System.Drawing.Point(719, 537);
            this._labelSearchLevel.Name = "_labelSearchLevel";
            this._labelSearchLevel.Size = new System.Drawing.Size(69, 13);
            this._labelSearchLevel.TabIndex = 14;
            this._labelSearchLevel.Text = "Search &level:";
            // 
            // _domainUpDownSearchLevel
            // 
            this._domainUpDownSearchLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._domainUpDownSearchLevel.Location = new System.Drawing.Point(794, 535);
            this._domainUpDownSearchLevel.Name = "_domainUpDownSearchLevel";
            this._domainUpDownSearchLevel.ReadOnly = true;
            this._domainUpDownSearchLevel.Size = new System.Drawing.Size(79, 20);
            this._domainUpDownSearchLevel.TabIndex = 15;
            this._domainUpDownSearchLevel.SelectedItemChanged += new System.EventHandler(this._domainUpDownSearchLevel_SelectedItemChanged);
            // 
            // _buttonClose
            // 
            this._buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonClose.Location = new System.Drawing.Point(924, 567);
            this._buttonClose.Name = "_buttonClose";
            this._buttonClose.Size = new System.Drawing.Size(72, 23);
            this._buttonClose.TabIndex = 16;
            this._buttonClose.Text = "Close";
            this._buttonClose.UseVisualStyleBackColor = true;
            this._buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // _saveFileDialog
            // 
            this._saveFileDialog.DefaultExt = "dump";
            this._saveFileDialog.Filter = "Dump Files|*.dump";
            // 
            // _searchStoreTimer
            // 
            this._searchStoreTimer.Interval = 1000;
            this._searchStoreTimer.Tick += new System.EventHandler(this._searchStoreTimer_Tick);
            // 
            // QuickWatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 602);
            this.Controls.Add(this._buttonClose);
            this.Controls.Add(this._domainUpDownSearchLevel);
            this.Controls.Add(this._labelSearchLevel);
            this.Controls.Add(this._comboBoxSearchIn);
            this.Controls.Add(this._labelSearchIn);
            this.Controls.Add(this._checkBoxUseRegularExpression);
            this.Controls.Add(this._checkBoxMatchWholeWord);
            this.Controls.Add(this._checkBoxMatchCase);
            this.Controls.Add(this._comboBoxSearch);
            this.Controls.Add(this._labelSearch);
            this.Controls.Add(this._treeView);
            this.Controls.Add(this._labelValue);
            this.Controls.Add(this._comboBoxExpression);
            this.Controls.Add(this._buttonReevaluate);
            this.Controls.Add(this._labelExpression);
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "QuickWatch";
            this.Text = "QuickWatch";
            this._contextMenuStripForTreeView.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _labelExpression;
        private System.Windows.Forms.ComboBox _comboBoxExpression;
        private System.Windows.Forms.Button _buttonReevaluate;
        private System.Windows.Forms.Label _labelValue;
        private Aga.Controls.Tree.TreeViewAdv _treeView;
        private Aga.Controls.Tree.NodeControls.NodeStateIcon _icon;
        private Aga.Controls.Tree.NodeControls.NodeTextBox _name;
        private Aga.Controls.Tree.NodeControls.NodeTextBox _value;
        private Aga.Controls.Tree.NodeControls.NodeTextBox _type;
        private Aga.Controls.Tree.TreeColumn _treeColumn1;
        private Aga.Controls.Tree.TreeColumn _treeColumn2;
        private Aga.Controls.Tree.TreeColumn _treeColumn3;
        private System.Windows.Forms.Label _labelSearch;
        private System.Windows.Forms.ComboBox _comboBoxSearch;
        private System.Windows.Forms.CheckBox _checkBoxMatchCase;
        private System.Windows.Forms.CheckBox _checkBoxMatchWholeWord;
        private System.Windows.Forms.CheckBox _checkBoxUseRegularExpression;
        private System.Windows.Forms.Label _labelSearchIn;
        private System.Windows.Forms.ComboBox _comboBoxSearchIn;
        private System.Windows.Forms.Label _labelSearchLevel;
        private System.Windows.Forms.DomainUpDown _domainUpDownSearchLevel;
        private System.Windows.Forms.Button _buttonClose;
        private System.Windows.Forms.ContextMenuStrip _contextMenuStripForTreeView;
        private System.Windows.Forms.ToolStripMenuItem _saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _expandAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _collapseAllToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog _saveFileDialog;
        private System.Windows.Forms.Timer _searchStoreTimer;



    }
}
