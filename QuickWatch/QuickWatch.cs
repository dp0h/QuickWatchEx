using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Aga.Controls.Tree.NodeControls;
using Aga.Controls.Tree;
using QuickWatchEx.QuickWatch.Interfaces;

namespace QuickWatchEx.QuickWatch {
    /// <summary>
    /// 
    /// </summary>
    public partial class QuickWatch : Form {

        private IDebugContoller _dbgController;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="expression"></param>
        public QuickWatch(IDebugContoller controller, string expression) {
            InitializeComponent();

            _dbgController = controller;
            _dbgController.ConfigurationUpdated += new ConfigurationUpdatedEvent(DbgWatch_ConfigurationUpdated);

            _domainUpDownSearchLevel.Items.Clear();
            for (int i = 10; i > 0; i--)
                _domainUpDownSearchLevel.Items.Add(i.ToString());

            _comboBoxExpression.Text = expression;

            _treeView.Model = _dbgController.Model;
            _dbgController.Refresh();
        }

        private void DbgWatch_ConfigurationUpdated() {
            _comboBoxSearchIn.SelectedIndex = (int)_dbgController.SearchLocation;
            _checkBoxMatchCase.Checked = _dbgController.MatchCase;
            _checkBoxMatchWholeWord.Checked = _dbgController.MatchWholeWord;
            _checkBoxUseRegularExpression.Checked = _dbgController.UseRegEx;
            //_checkBoxDontSearchInPrivateMemebers.Checked = _dbgController.DontSearchInPrivateMembers;
            _domainUpDownSearchLevel.SelectedIndex = _domainUpDownSearchLevel.Items.Count - _dbgController.DepthOfSearch;
        }

        private void buttonClose_Click(object sender, EventArgs e) {
            Close();
        }

        private void _buttonReevaluate_Click(object sender, EventArgs e) {
            _dbgController.Expression = _comboBoxExpression.Text;
            _treeView.Model = _dbgController.Model;

            var text = _comboBoxExpression.Text;
            if (_comboBoxExpression.Items.Contains(text)) {
                _comboBoxExpression.Items.Remove(text);
            }
            _comboBoxExpression.Items.Insert(0, text);
        }

        private void _domainUpDownSearchLevel_SelectedItemChanged(object sender, EventArgs e) {
            _dbgController.DepthOfSearch = Convert.ToInt32((string)_domainUpDownSearchLevel.SelectedItem);
            if (!string.IsNullOrEmpty(_comboBoxSearch.Text)) {
                _treeView.ExpandAll();
            }
        }

        private void _comboBoxSearch_KeyUp(object sender, KeyEventArgs e) {
            _dbgController.SearchText = _comboBoxSearch.Text;
            _treeView.ExpandAll();

            _searchStoreTimer.Stop();
            if (!string.IsNullOrEmpty(_comboBoxSearch.Text)) {
                _searchStoreTimer.Start();
            }
        }

        private void _checkBoxMatchCase_CheckedChanged(object sender, EventArgs e) {
            _dbgController.MatchCase = _checkBoxMatchCase.Checked;
            if (!string.IsNullOrEmpty(_comboBoxSearch.Text)) {
                _treeView.ExpandAll();
            }
        }

        private void _checkBoxMatchWholeWord_CheckedChanged(object sender, EventArgs e) {
            _dbgController.MatchWholeWord = _checkBoxMatchWholeWord.Checked;
            if (!string.IsNullOrEmpty(_comboBoxSearch.Text)) {
                _treeView.ExpandAll();
            }
        }

        private void _checkBoxUseRegularExpression_CheckedChanged(object sender, EventArgs e) {
            _dbgController.UseRegEx = _checkBoxUseRegularExpression.Checked;
            if (!string.IsNullOrEmpty(_comboBoxSearch.Text)) {
                _treeView.ExpandAll();
            }
        }

        private void _comboBoxSearchIn_SelectedIndexChanged(object sender, EventArgs e) {
            _dbgController.SearchLocation = (SearchLocation)_comboBoxSearchIn.SelectedIndex;
            if (!string.IsNullOrEmpty(_comboBoxSearch.Text)) {
                _treeView.ExpandAll();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            if (_saveFileDialog.ShowDialog() == DialogResult.OK) {
                try {
                    using (StreamWriter sw = new StreamWriter(_saveFileDialog.FileName, false)) {
                        sw.Write(_dbgController.Model.ToString());
                    }
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void expandAllToolStripMenuItem_Click(object sender, EventArgs e) {
            _treeView.ExpandAll();
        }

        private void collapseAllToolStripMenuItem_Click(object sender, EventArgs e) {
            _treeView.CollapseAll();
        }

        private void _searchStoreTimer_Tick(object sender, EventArgs e) {
            _searchStoreTimer.Stop();

            var text = _comboBoxSearch.Text;
            if (!string.IsNullOrEmpty(text)) {
                if (_comboBoxSearch.Items.Contains(text)) {
                    _comboBoxSearch.Items.Remove(text);
                }
                _comboBoxSearch.Items.Insert(0, text);
            }
        }

        private void _treeView_SelectionChanged(object sender, EventArgs e) {
            if (_treeView.CurrentNode != null) {
                _comboBoxExpression.Text = ((Expression)_treeView.CurrentNode.Tag).Path;
            }
        }
    }
}
