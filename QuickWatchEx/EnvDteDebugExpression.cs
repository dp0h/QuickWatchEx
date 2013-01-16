using System.Collections.Generic;
using QuickWatchEx.QuickWatch.Interfaces;

namespace QuickWatchEx {
    /// <summary>
    /// EnvDteDebugExpression
    /// </summary>
    class EnvDteDebugExpression : IDebugExpression {
        public EnvDteDebugExpression(EnvDTE.Expression expression) {
            _expression = expression;
        }

        public IEnumerable<IDebugExpression> DataMembers {
            get {
                foreach (EnvDTE.Expression e in _expression.DataMembers) {
                    yield return new EnvDteDebugExpression(e);
                }
            }
        }

        public bool IsValidValue { get { return _expression.IsValidValue; } }

        public string Name { get { return _expression.Name; } }

        public string Type { get { return _expression.Type; } }

        public string Value { get { return _expression.Value; } }

        readonly EnvDTE.Expression _expression;
    }
}
