using System.Collections.Generic;
using Aga.Controls.Tree;

namespace QuickWatchEx.QuickWatch.Interfaces {
    /// <summary>
    /// 
    /// </summary>
    public delegate void ConfigurationUpdatedEvent();

    /// <summary>
    /// IDebugContoller
    /// </summary>
    public interface IDebugContoller {
        /// <summary>
        /// 
        /// </summary>
        ITreeModel Model { get; }

        /// <summary>
        /// Expression
        /// </summary>
        string Expression { set; }

        /// <summary>
        /// Search text
        /// </summary>
        string SearchText { set; }

        /// <summary>
        /// Match case
        /// </summary>
        bool MatchCase { get; set; }

        /// <summary>
        /// Match whole word
        /// </summary>
        bool MatchWholeWord { get; set; }

        /// <summary>
        /// Use regular expressions
        /// </summary>
        bool UseRegEx { get; set; }

        /// <summary>
        /// Depth of search
        /// </summary>
        int DepthOfSearch { get; set; }

        /// <summary>
        /// Search 
        /// </summary>
        SearchLocation SearchLocation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="evaluationHistory"></param>
        /// <param name="searchHistory"></param>
        void LoadHistory(List<string> evaluationHistory, List<string> searchHistory);
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="evaluationHistory"></param>
        /// <param name="searchHistory"></param>
        void StoreHistory(List<string> evaluationHistory, List<string> searchHistory);

        /// <summary>
        /// 
        /// </summary>
        void Refresh();

        /// <summary>
        /// Configuration updated event
        /// </summary>
        event ConfigurationUpdatedEvent ConfigurationUpdated;
    }
}
