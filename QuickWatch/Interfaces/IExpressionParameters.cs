using System;

namespace QuickWatchEx.QuickWatch.Interfaces {
    /// <summary>
    /// 
    /// </summary>
    public interface IExpressionParameters {
        /// <summary>
        /// Expression evaluation timeout 
        /// </summary>
        TimeSpan EvaluationTimeout { get; }

        /// <summary>
        /// Depth of search
        /// </summary>
        int DepthOfSearch { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeType"></param>
        /// <returns></returns>
        bool IgnoredNode(string nodeType);

        /// <summary>
        /// 
        /// </summary>
        bool SearchEnabled { get; }

        /// <summary>
        /// 
        /// </summary>
        bool SearchInName { get; }

        /// <summary>
        /// 
        /// </summary>
        bool SearchInValue { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Match(string value);
    }
}
