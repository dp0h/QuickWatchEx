using System.Collections.Generic;

namespace QuickWatchEx.QuickWatch.Interfaces {
    /// <summary>
    /// Interface for EnvDTE.Expression wrapper
    /// </summary>
    public interface IDebugExpression {
        /// <summary>
        /// DataMembers
        /// </summary>
        IEnumerable<IDebugExpression> DataMembers { get; }
        
        /// <summary>
        /// IsValidValue
        /// </summary>
        bool IsValidValue { get; }

        /// <summary>
        /// Name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Type
        /// </summary>
        string Type { get; }

        /// <summary>
        /// Value
        /// </summary>
        string Value { get; }
    }
}
