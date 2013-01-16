using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Aga.Controls.Tree;
using QuickWatchEx.QuickWatch.Interfaces;

namespace QuickWatchEx.QuickWatch {
    /// <summary>
    /// DebugControllerBase
    /// </summary>
    public abstract class DebugControllerBase : IDebugContoller, IExpressionParameters {
        protected DebugControllerBase(string expression, QuickWatchConfig config) {
            _model = new TreeModel(new Expression(this));
            _search = "";
            _config = config;
        }

        #region IDebugContoller and IExpressionParameters

        public event ConfigurationUpdatedEvent ConfigurationUpdated;

        public ITreeModel Model {
            get { return _model; }
        }

        public abstract string Expression { set; }

        public string SearchText {
            set {
                _search = value;
                UpdateTree();
            }
        }

        public void Refresh() {
            if (ConfigurationUpdated != null) {
                ConfigurationUpdated();
            }
        }

        public bool SearchEnabled { get { return _search != ""; } }

        public bool Match(string value) {
            if (string.IsNullOrWhiteSpace(_search)) {
                return true;
            }

            switch (_config.SearchType) {
                case SearchType.RegEx: {
                    try {
                        return Regex.Match(value, _search, _config.CaseSensitive ? RegexOptions.None : RegexOptions.IgnoreCase).Success;
                    } catch (Exception) {
                        return false;
                    }
                }
                case SearchType.WholeWord: {
                    return string.Equals(value, _search, _config.CaseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase);
                }
                default: {
                    return value.IndexOf(_search, _config.CaseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase) >= 0;
                }
            }
        }

        public bool SearchInName { get { return _config.SearchLocation == SearchLocation.Name || _config.SearchLocation == SearchLocation.Everywhere; } }

        public bool SearchInValue { get { return _config.SearchLocation == SearchLocation.Value || _config.SearchLocation == SearchLocation.Everywhere; } }

        public TimeSpan EvaluationTimeout { get { return _config.EvaluationTimeout; } }

        public void LoadHistory(List<string> evaluationHistory, List<string> searchHistory) {
            _config.LoadHistory(evaluationHistory, searchHistory);
        }

        public void StoreHistory(List<string> evaluationHistory, List<string> searchHistory) {
            _config.StoreHistory(evaluationHistory, searchHistory);
        }

        public bool MatchCase { 
            get { 
                return _config.CaseSensitive; 
            }
            set {
                var temp = _config.CaseSensitive;
                _config.CaseSensitive = value;
                if (temp != _config.CaseSensitive && ConfigurationUpdated != null) {
                    ConfigurationUpdated();
                    UpdateTree();
                }
            }
        }

        public bool MatchWholeWord { 
            get { 
                return _config.SearchType == SearchType.WholeWord; 
            }
            set {
                var temp = _config.SearchType;
                _config.SearchType = value ? SearchType.WholeWord : SearchType.PartWord;
                if (temp != _config.SearchType && ConfigurationUpdated != null) {
                    ConfigurationUpdated();
                    UpdateTree();
                }
            }
        }

        public bool UseRegEx { 
            get { 
                return _config.SearchType == SearchType.RegEx; 
            }
            set {
                var temp = _config.SearchType;
                _config.SearchType = value ? SearchType.RegEx : SearchType.PartWord;
                if (temp != _config.SearchType && ConfigurationUpdated != null) {
                    ConfigurationUpdated();
                    UpdateTree();
                }
            }
        }

        public int DepthOfSearch { 
            get { 
                return _config.DepthOfSearch; 
            }
            set {
                var temp = _config.DepthOfSearch;
                _config.DepthOfSearch = value;
                if (temp != _config.DepthOfSearch && ConfigurationUpdated != null) {
                    ConfigurationUpdated();
                    UpdateTree();
                }
            }
        }

        public SearchLocation SearchLocation { 
            get { 
                return _config.SearchLocation; 
            }
            set {
                var temp = _config.SearchLocation;
                _config.SearchLocation = value;
                if (temp != _config.SearchLocation && ConfigurationUpdated != null) {
                    ConfigurationUpdated();
                    UpdateTree();
                }
            }
        }

        public bool IgnoredNode(string nodeType) {
            return Regex.Match(nodeType, _config.SkipNames, RegexOptions.None).Success;
        }

        #endregion

        protected void UpdateTree() {
            _root.UpdateVisibility();
            _model.Update(_root);
        }

        #region Private Memebers

        protected TreeModel               _model;
        protected Expression              _root;
        private string                    _search;
        private readonly QuickWatchConfig _config;

        #endregion
    }
}
