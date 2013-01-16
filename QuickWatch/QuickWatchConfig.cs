using System;
using System.Collections.Generic;

namespace QuickWatchEx.QuickWatch {
    /// <summary>
    /// Search location
    /// </summary>
    public enum SearchLocation {
        /// <summary>
        /// Search in name only
        /// </summary>
        Name = 0,
        
        /// <summary>
        /// Search in value only
        /// </summary>
        Value,

        /// <summary>
        /// Search in name and value
        /// </summary>
        Everywhere
    }

    /// <summary>
    /// Type of the string matching
    /// </summary>
    public enum SearchType {
        /// <summary>
        /// Search for part of word
        /// </summary>
        PartWord,

        /// <summary>
        /// Search for a whole word
        /// </summary>
        WholeWord,

        /// <summary>
        /// Use regular expression for search
        /// </summary>
        RegEx
    }

    /// <summary>
    /// Persistent configuration for QuickWatch
    /// </summary>
    public class QuickWatchConfig {
        /// <summary>
        /// Constructor
        /// </summary>
        public QuickWatchConfig() {
            DepthOfSearch = 5;
            SearchLocation = SearchLocation.Everywhere;
            SearchType = SearchType.PartWord;
            SkipNames = "Raw View|Static members|Non-Public members";
            CaseSensitive = false;
            EvaluationTimeout = new TimeSpan(0, 0, 5); 
            _evaluationHistory = new List<string>();
            _searchHistory = new List<string>();
        }

        /// <summary>
        /// Depth of search
        /// </summary>
        public int DepthOfSearch { get; set; }

        /// <summary>
        /// Search location
        /// </summary>
        public SearchLocation SearchLocation { get; set; }

        /// <summary>
        /// Search type
        /// </summary>
        public SearchType SearchType { get; set; }

        /// <summary>
        /// Use case sensitive search
        /// </summary>
        public bool CaseSensitive { get; set; }

        /// <summary>
        /// Masks to detect nodes for skipping during evaluation
        /// </summary>
        public string SkipNames { get; set; }

        /// <summary>
        /// The timeout for expression+children evaluation
        /// </summary>
        public TimeSpan EvaluationTimeout { get; set; }

        /// <summary>
        /// Loads evaluation and search history
        /// </summary>
        /// <param name="evaluationHistory"></param>
        /// <param name="searchHistory"></param>
        public void LoadHistory(List<string> evaluationHistory, List<string> searchHistory) {
            evaluationHistory.AddRange(_evaluationHistory);
            searchHistory.AddRange(_searchHistory);
        }
       
        /// <summary>
        /// Stores evaluation and search history
        /// </summary>
        /// <param name="evaluationHistory"></param>
        /// <param name="searchHistory"></param>
        public void StoreHistory(List<string> evaluationHistory, List<string> searchHistory) {
            _evaluationHistory.Clear();
            _evaluationHistory.AddRange(evaluationHistory);
            _searchHistory.Clear();
            _searchHistory.AddRange(searchHistory);
        }

        private readonly List<string> _evaluationHistory;
        private readonly List<string> _searchHistory;
    }
}
